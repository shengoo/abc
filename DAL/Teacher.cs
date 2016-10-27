using DataBase;
using Model;
using System.Collections.Generic;

namespace DAL
{
    /// <summary>
    /// 数据访问类:Teacher
    /// </summary>
    public class TeacherDao : BaseModel<Teacher>
    {
        /// <summary>
        /// 获取外教
        /// </summary>
        /// <returns></returns>
        public List<TeamTeature> GetForeignTeature()
        {
            return DbHelperSQL.ExcuteScaler<TeamTeature>("SELECT m.Id,m.Logo,m.EnName Name,t.Signature,t.Video FROM Member m,Teacher t WHERE m.MemberType=3 AND m.Id=t.MemberId AND t.Visible=1 AND t.Enabled=1 And t.TeacherType=0 ORDER BY t.orderby");
        }

        /// <summary>
        /// 获取上课老师
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<TeamTeature> GetClassTeacher(int classId)
        {
            object limitIds = ValidLimitTeacher(classId);
            if (limitIds == null || limitIds.ToString() == "")
            {
                return DbHelperSQL.ExcuteScaler<TeamTeature>(@"select t1.teacherid id,t1.Video,t3.cnname name,t3.enname,t1.signature,t3.logo from teacher t1 inner join member t3 on t1.memberid=t3.id and t1.enabled=1 and t1.teachertype=0 and t3.Enabled=1
inner join courseteacher t2 on t1.teacherid = t2.teacherid
inner join classplan t4 on t2.courseid = t4.courseid and t4.classid =@0 where t3.Enabled=1", classId);
            }
            else
            {
                return DbHelperSQL.ExcuteScaler<TeamTeature>(@"select t1.teacherid id,t1.Video,t3.cnname name,t3.enname,t1.signature,t3.logo from teacher t1 inner join member t3 on t1.memberid = t3.id and t1.enabled = 1 and t1.teachertype = 0 and t3.Enabled=1 and t1.teacherid in (" + limitIds.ToString() + ")");
            }
        }

        public object ValidLimitTeacher(int classId)
        {
            return DbHelperSQL.GetSingle("select LimitTeacherIds from ClassPlan where ClassId = @0", classId);
        }
    }
}

