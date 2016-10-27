using Model;
using DataBase;
using System.Collections.Generic;

namespace DAL
{
    public class MemberCartDao : BaseModel<MemberCart>
    {
        public List<Cart> GetCart(int memberId)
        {
            return DbHelperSQL.ExcuteScaler<Cart>(@"SELECT cartId id,mc.cardid,cc1.cardname,mc.giftids,'' giftnames,
qty number,mc.createtime,cc1.Price 
FROM MemberCart mc INNER JOIN CourseCard cc1 ON mc.MemberId= @0 AND mc.cardid=cc1.cardid", new object[] { memberId });
        }
    }
}
