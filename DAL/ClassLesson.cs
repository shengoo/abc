using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBase;
using Model;

namespace DAL
{
    public class ClassLessonDao : BaseModel<ClassPlan>
    {
        public List<CourseProcess> GetClassLesson(int classId, int memberId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("@classId", classId);
            dic.Add("@memberId", memberId);
            return DbHelperSQL.ExcuteProcedure<CourseProcess>("PRO_MemberClassLesson", dic);
        }
        public CourseLesson GetClassLesson(int cplId)
        {
            return DbHelperSQL.ExcuteScaler<CourseLesson>("select classstarttime,cplid from classplanlesson where cplid=@0", cplId).FirstOrDefault();
        }

        public CourseLesson GetOpenClassLesson(int cplId) {
            return DbHelperSQL.ExcuteScaler<CourseLesson>("select freestarttime classstarttime,openclassid cplid from OpenClass where openclassid=@0", cplId).FirstOrDefault();
        }
    }
}