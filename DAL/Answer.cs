using System.Collections.Generic;

namespace DAL
{
    using DataBase;
    using Model;
    /// <summary>
    /// 数据访问类:Answer
    /// </summary>
    public partial class AnswerDao : BaseModel<Answer>
    {
        /// <summary>
        /// 获取我的回答
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Answer> GetAnswers(int id)
        {
            return DbHelperSQL.ExcuteScaler<Answer>(@"
                select t3.content ask, t4.UserName, t1.content,t1.createtime from answer t1
                join teacher t2 on t1.teacherid = t2.teacherid and t2.memberid=@0
                join ask t3 on t1.askid = t3.askid 
                join member t4 on t3.memberid = t4.id order by t1.orderby,t1.createtime desc", id);
        }

        /// <summary>
        /// 获取问题答案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Answer> GetAnswersByAsk(int id)
        {
            return DbHelperSQL.ExcuteScaler<Answer>(@"
                select t1.AnswerId,t4.UserName,t4.Logo, t1.content,t1.createtime,t1.isaccept,t1.answerid from answer t1
                join teacher t2 on t1.teacherid = t2.teacherid 
                join member t4 on t2.memberid = t4.id where t1.askid=@0 order by isaccept desc", id);

        }
    }
}

