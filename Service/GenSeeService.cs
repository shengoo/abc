using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace Service
{
    public class GenSeeService
    {
        ScheduleDao dao = new ScheduleDao();
        StudyPlanDao planDao = new StudyPlanDao();
        ClassAttendDao attendDao = new ClassAttendDao();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cplId"></param>
        /// <param name="courseType"></param>
        /// <param name="member"></param>
        /// <param name="valid">是否验证</param>
        /// <returns></returns>
        public GenseeDirectSee GetGenSeeDirectByCpl(int cplId, int courseType, MemberDto member, bool valid = false)
        {
            GenseeDirectSee see = new GenseeDirectSee();
            if (member.Type == 1)
            {
                see = dao.GetMemberScheduleByCpl(cplId, courseType);
            }
            else
            {
                see = dao.GetTeacherScheduleByCpl(cplId, courseType);
            }
            if (see == null)
            {
                DateTime date;
                if (courseType == 0)
                {
                    date = new ClassLessonDao().GetClassLesson(cplId).ClassStartTime;
                }
                else {
                    date = new ClassLessonDao().GetOpenClassLesson(cplId).ClassStartTime;
                }
                if (date > DateTime.Now.AddMinutes(30))
                {
                    throw new Exception("直播课程尚未开始！请在课程开始前30分钟进入！");
                }
                return see;
            }
            if ((see.BeginTime - DateTime.Now).TotalMinutes > 30)
                throw new Exception("本次课程将于 " + see.BeginTime.ToString("HH:mm:ss") + " 开始！请在课程开始前30分钟进入！");

            if (DateTime.Now > see.EndTime && member.Type != 3)
                throw new Exception("本次课程已于 " + see.EndTime.ToString("HH:mm:ss") + " 结束！");

            if (DateTime.Now.AddHours(-2) > see.EndTime && member.Type == 3)
                throw new Exception("本次课程已于 " + see.EndTime.ToString("HH:mm:ss") + " 结束！");

            return see;
        }

        public string GetUrl(int cplId)
        {
            var obj = dao.GetRecordUrl(cplId);
            return obj == null ? null : obj.ToString();
        }
    }
}
