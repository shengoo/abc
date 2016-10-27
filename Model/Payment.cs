/**  版本信息模板在安装目录下，可自行修改。
* Payment.cs
*
* 功 能： N/A
* 类 名： Payment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:00   N/A    初版
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
	/// 支付表
	/// </summary>
	[Serializable]
	public partial class Payment
	{
		public Payment()
		{}
		#region Model
		private int _paymentid;
		private string _payment;
		private string _title;
		private string _config;
		private string _logo;
		private int? _enabled;
		private DateTime? _createtime;
		/// <summary>
		/// 支付内码
		/// </summary>
		public int PaymentId
		{
			set{ _paymentid=value;}
			get{return _paymentid;}
		}
		/// <summary>
        /// 支付类型 Payment
		/// </summary>
		public string Payment_Type
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 配置信息
		/// </summary>
		public string Config
		{
			set{ _config=value;}
			get{return _config;}
		}
		/// <summary>
		/// logo
		/// </summary>
		public string Logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
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

