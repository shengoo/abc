/**  版本信息模板在安装目录下，可自行修改。
* PaymentLog.cs
*
* 功 能： N/A
* 类 名： PaymentLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:01   N/A    初版
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
	/// 支付日志表
	/// </summary>
	[Serializable]
	public partial class PaymentLog
	{
		public PaymentLog()
		{}
		#region Model
		private int _plogid;
		private int _memberid;
		private int _sourceorderid;
		private string _payment;
		private string _tradeno;
		private decimal? _amount;
		private string _ispayed;
		private string _payedip;
		private DateTime? _payedtime;
		private string _payinfo;
		private DateTime? _createtime;
		/// <summary>
		/// 支付内码
		/// </summary>
		public int PLogId
		{
			set{ _plogid=value;}
			get{return _plogid;}
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
		/// 来源订单内码
		/// </summary>
		public int SourceOrderId
		{
			set{ _sourceorderid=value;}
			get{return _sourceorderid;}
		}
		/// <summary>
		/// 支付接口
		/// </summary>
		public string Payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// 支付流水号
		/// </summary>
		public string TradeNo
		{
			set{ _tradeno=value;}
			get{return _tradeno;}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 是否支付 0:未支付，1:已支付
		/// </summary>
		public string IsPayed
		{
			set{ _ispayed=value;}
			get{return _ispayed;}
		}
		/// <summary>
		/// 支付成功时IP
		/// </summary>
		public string PayedIp
		{
			set{ _payedip=value;}
			get{return _payedip;}
		}
		/// <summary>
		/// 支付成功通知时间
		/// </summary>
		public DateTime? PayedTime
		{
			set{ _payedtime=value;}
			get{return _payedtime;}
		}
		/// <summary>
		/// 支付信息
		/// </summary>
		public string PayInfo
		{
			set{ _payinfo=value;}
			get{return _payinfo;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

