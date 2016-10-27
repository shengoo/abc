using Model;
using DataBase;
using System.Collections.Generic;

namespace DAL
{
    /// <summary>
    /// 数据访问类:ClassPlan
    /// </summary>
    public partial class ClassPlanDao
    {
        /// <summary>
        /// 获取课程计划
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<ClassPlanRlt> GetClassPlans(int memberId)
        {
            return DbHelperSQL.ExcuteScaler<ClassPlanRlt>(@"
SELECT cp.ClassId Id, c.CnName Name,cc.CategoryName,cp.ClassTime,cp.Total,(SELECT sum(1) from StudyPlan WHERE ClassId=cp.ClassId)CurrentClass FROM ClassPlanMember cpm, ClassPlan cp,Course c,CourseCategory cc WHERE cpm.ClassId = cp.ClassId AND cpm.MemberId=@0
AND cp.CourseId =c.CourseId AND cp.ClassCategoryId = cc.CategoryId", memberId);
        }
    }
}

