
using System;
namespace Model
{
	/// <summary>
	/// 订单明细表
	/// </summary>
	[Serializable]
	public partial class OrderDetail
	{
		public OrderDetail()
		{}
		#region Model
		private int _detailid;
		private int _orderid;
		private int _cardid;
        private int _giftid;
		private int? _qty;
		private decimal? _amount;
		/// <summary>
		/// 明细内码
		/// </summary>
		public int DetailId
		{
			set{ _detailid=value;}
			get{return _detailid;}
		}
		/// <summary>
		/// 订单内码
		/// </summary>
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 课程卡内码
		/// </summary>
		public int CardId
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// 课程卡数量
		/// </summary>
		public int? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 订单金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 订单日期
		/// </summary>
		public int GiftId
		{
			set{ _giftid=value;}
            get { return _giftid; }
		}

        public int AssignNum { get; set; }

        public int IsAssign { get; set; }
		#endregion Model

        public string CardNo { get; set; }
	}
}

