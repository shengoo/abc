using System;

namespace Model
{
    public class MemberCart
    {
        public int CartId { get; set; }
        public int MemberId { get; set; }
        public int CardId { get; set; }
        public string GiftIds { get; set; }
        public int Qty { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
