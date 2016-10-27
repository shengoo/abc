using System;

namespace Model
{
    public class MyOrder
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 课程卡名称
        /// </summary>
        public string CardName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 课程卡类型1：1/1：6
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 分配课程
        /// </summary>
        public string CourseName { set; get; }

        /// <summary>
        /// 课程卡类型 1:青少卡 2、成人卡
        /// </summary>
        public int CardType { get; set; }
        /// <summary>
        /// 课程卡状态 -1:已删除 0:待支付 1:已支付
        /// </summary>
        public int Enabled { get; set; }
    }
}
