using System;
using System.Linq;
using System.Collections.Generic;
using DataBase;
using Model;
using Model.ViewModel;

namespace DAL
{
    /// <summary>
    /// 数据访问类:Schedule
    /// </summary>
    public partial class ScheduleDao : BaseModel<Schedule>
    {
        public List<MemberSchedule> GetSchedule(int memberId, int month, int memberType)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@memberId", memberId);
            dic.Add("@month", month);
            dic.Add("@memberType", memberType);
            return DbHelperSQL.ExcuteProcedure<MemberSchedule>("pro_GetMyClassSchedule", dic);
        }

        public List<DataModel> GetVideoInfoListByCplId(string cplId)
        {
            var sqlstring = @"SELECT schr.ScheduleId,schr.RecordStartTime FROM ScheduleRecord schr INNER JOIN Schedule sch ON schr.ScheduleId=sch.ScheduleId WHERE sch.CplId=@0";
            return DbHelperSQL.ExcuteScaler<DataModel>(sqlstring, cplId);
           // return null;
        }

        /// <summary>
        /// 获取学员直播地址
        /// </summary>
        /// <param name="cplId"></param>
        /// <param name="courseType"></param>
        /// <returns></returns>
        public GenseeDirectSee GetMemberScheduleByCpl(int cplId, int courseType)
        {//1）大课堂和公开测评课：AttendeeUrl
            //2）一对一和一对六，公开课 PanelListUrl
            // 3 CourseType		课程类型 0：收费课程，1：公开课
            var sql = "select webcastid,CplId,{0} url,ScheduleId,{1} token,clength courselength,begintime begintime,endtime,isfull from Schedule where cplid=@0 and CourseType=@1";
            //免费课 大课堂
            if (courseType == 1 || IsDaketan(cplId))
            {
                sql = string.Format(sql, "AttendeeUrl", "AttendeeToken");
            }
            else
            {
                sql = string.Format(sql, "PaneListUrl", "PaneListToken");
            }
            return DbHelperSQL.ExcuteScaler<GenseeDirectSee>(sql, cplId, courseType).FirstOrDefault();
        }

        /// <summary>
        /// 是否为大课堂
        /// </summary>
        /// <param name="cplId"></param>
        /// <returns></returns>
        public bool IsDaketan(int cplId)
        {
            return (int)DbHelperSQL.GetSingle("SELECT count(0) FROM CourseCategory t1 LEFT JOIN ClassPlan t2 on t1.CategoryId = t2.ClassCategoryId where t1.Code = '10' and t2.ClassId=@0", cplId) > 0;
        }

        public GenseeDirectSee GetTeacherScheduleByCpl(int cplId, int courseType)
        {
            return DbHelperSQL.ExcuteScaler<GenseeDirectSee>("select webcastid,CplId,PaneListUrl url,ScheduleId,OrganizerToken token,clength courselength,begintime begintime,endtime,isfull from Schedule where cplid=@0 and CourseType=@1", cplId, courseType).FirstOrDefault();
        }

        public object GetRecordUrl(int cplId)
        {
            return DbHelperSQL.GetSingleValue("SELECT VideoUrl url FROM OpenCourse t1 inner join OpenClass t2 on t1.CourseId=t2.CourseId and openclassid =@0", cplId);
        }
    }
}

