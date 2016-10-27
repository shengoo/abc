using System.Collections.Generic;

namespace DAL
{
    using Model;
    using DataBase;
	/// <summary>
	/// 数据访问类:Ask
	/// </summary>
	public partial class AskDao:BaseModel<Ask>
	{
        public List<Ask> GetAsks(int id)
        {
            return DbHelperSQL.ExcuteScaler<Ask>("select askid, content, createtime,(select count(1) from answer t2 where t2.askid=t1.askid) answernum  from ask t1 where memberid = @0 and closed = 0 order by orderby asc", id);
        }
	}
}

