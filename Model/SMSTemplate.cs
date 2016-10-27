/**  版本信息模板在安装目录下，可自行修改。
* SMSTemplate.cs
*
* 功 能： N/A
* 类 名： SMSTemplate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:03   N/A    初版
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
	/// 短信模板表
	/// </summary>
	[Serializable]
	public partial class SMSTemplate
	{
		public SMSTemplate()
		{}
		#region Model
		private int _smsid;
		private string _title;
		private string _subject;
		private string _content;
		private string _smstype;
		private int? _enabled;
		private DateTime? _createtime;
		private string _note;
		/// <summary>
		/// 短信内码
		/// </summary>
		public int SmsId
		{
			set{ _smsid=value;}
			get{return _smsid;}
		}
		/// <summary>
		/// 短信标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 短信主题
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 短信格式
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 类型 学员/答疑老师
		/// </summary>
		public string SmsType
		{
			set{ _smstype=value;}
			get{return _smstype;}
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
		/// 操作日期
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 短信备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

