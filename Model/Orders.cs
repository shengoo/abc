/**  版本信息模板在安装目录下，可自行修改。
* Orders.cs
*
* 功 能： N/A
* 类 名： Orders
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:59   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// 订单表
	/// </summary>
	[Serializable]
	public partial class Orders
	{
		public Orders()
		{}
		#region Model
		private int _orderid;
		private int _memberid;
		private string _orderno;
		private int? _totalqty;
		private decimal? _totalamount;
		private int _enabled=0;
		private DateTime? _ordertime;
		private string _tradeno;
		/// <summary>
		/// 订单内码
		/// </summary>
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 会员内码
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 订单流水号
		/// </summary>
		public string OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 课程卡数量
		/// </summary>
		public int? TotalQty
		{
            set { _totalqty = value; }
            get { return _totalqty; }
		}
		/// <summary>
		/// 订单金额
		/// </summary>
		public decimal? TotalAmount
		{
			set{ _totalamount=value;}
            get { return _totalamount; }
		}
		/// <summary>
		/// 订单状态 订单状态（0：下单成功，1：已支付）
		/// </summary>
		public int Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
		}
		/// <summary>
		/// 订单日期
		/// </summary>
		public DateTime? OrderTime
		{
			set{ _ordertime=value;}
			get{return _ordertime;}
		}
		/// <summary>
		/// 交易流水号
		/// </summary>
		public string TradeNo
		{
			set{ _tradeno=value;}
			get{return _tradeno;}
		}
		#endregion Model

	}
}

