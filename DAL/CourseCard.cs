
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DataBase;
using Model;
using Model.ViewModel;

namespace DAL
{
    /// <summary>
    /// 数据访问类:CourseCard
    /// </summary>
    public partial class CourseCardDao : BaseModel<CourseCard>
    {
        public List<CourseCard> GetCardGift(string cardId)
        {
            return GetClassModels(@"
                SELECT 
	                CourseCard.CardId,
	                CardName,
	                CardCategoryId,
	                CardTypeId,
	                Carddesc,
	                Total,
	                Period,
	                Months,
	                Frequency,
	                Price,
	                IsGift,
	                Enabled,
	                OrderBy,
	                ClassContent,
	                Discount,
	                Creator,
	                CreateTime
                FROM CourseCard inner join CourseCardGift on CourseCard.CardId = CourseCardGift.GiftCardId AND coursecard.IsGift=1 and CourseCardGift.CardId=@0", cardId);
        }

        /// <summary>
        /// 查看课程
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="queryType"></param>
        /// <param name="courseType"></param>
        /// <returns></returns>
        public List<MyCourse> GetPactCourse(int memberId, int queryType, int courseType)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("@MemberId", memberId);
            dic.Add("@ClassType", 0);
            dic.Add("@QueryType", queryType);
            dic.Add("@CourseType", courseType);
            dic.Add("@ClassId", 0);
            dic.Add("@BeginDate", "");
            dic.Add("@EndDate", "");

            return DbHelperSQL.ExcuteProcedure<MyCourse>("pro_GetMyClassCourse", dic);
        }

        /// <summary>
        /// 查课次
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="queryType"></param>
        /// <param name="classId"></param>
        /// <param name="courseType"></param>
        /// <returns></returns>
        public List<CourseDetail> GetPactCourse(int memberId, int queryType, int classId, int courseType)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("@MemberId", memberId);
            dic.Add("@ClassType", 1);
            dic.Add("@QueryType", queryType);
            dic.Add("@CourseType", courseType);
            dic.Add("@ClassId", classId);
            dic.Add("@BeginDate", "");
            dic.Add("@EndDate", "");

            return DbHelperSQL.ExcuteProcedure<CourseDetail>("pro_GetMyClassCourse", dic);
        }

        public List<BuyCourseCard> GetCourseCard(int type, int cardTypeId)
        {
            return DbHelperSQL.ExcuteScaler<BuyCourseCard>(@"SELECT CardId,CardName,CardCategoryId,CardTypeId,Total,Months,Price,ClassContent,Discount FROM CourseCard t1 INNER JOIN CourseCategory t3 ON t1.CardCategoryId=t3.CategoryId where t1.IsGift=0 AND t1.Enabled=1 and t3.Code=@0 and t1.CardTypeId=@1", type, cardTypeId);
        }

        /// <summary>
        /// 获取我的课程卡次
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MyCourseCard> GetMyCourseCard(int memberId)
        {
            var sqlstring = @"SELECT ROW_NUMBER() OVER (ORDER BY OptionStatus desc) AS RowNumber,* from CourseCardViewForPerson WHERE MemberId=@0 ORDER BY OptionStatus  desc ";
            return DbHelperSQL.ExcuteScaler<MyCourseCard>(sqlstring, memberId);
        }
    }
}

