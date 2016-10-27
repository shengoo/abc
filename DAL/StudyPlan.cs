using System;

namespace DAL
{
    using Model;
    using DataBase;

    /// <summary>
    /// 数据访问类:StudyPlan
    /// </summary>
    public partial class StudyPlanDao : BaseModel<StudyPlan>
    {
        public void RefreshStudyPlanStatus(int planId, int attending,int memberId)
        {
            DbHelperSQL.ExcuteNonquery("update studyplay set attending= @0 where planid=@1 and memberid=@2", attending, planId,memberId);
        }
    }
}

