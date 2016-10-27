/**  版本信息模板在安装目录下，可自行修改。
* AnswerNotification.cs
*
* 功 能： N/A
* 类 名： AnswerNotification
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:39   N/A    初版
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
	/// 回答推送表
	/// </summary>
	[Serializable]
	public partial class AnswerNotification
	{
		public AnswerNotification()
		{}
		#region Model
		private int _notifyid;
		private int _askid;
		private int _memberid;
		private string _teacherid;
		private string _content;
		private int? _orderby;
		private int? _issend;
		private string _senddate;
		private DateTime? _createtime;
		/// <summary>
		/// 推送内码
		/// </summary>
		public int NotifyId
		{
			set{ _notifyid=value;}
			get{return _notifyid;}
		}
		/// <summary>
		/// 问题内码
		/// </summary>
		public int AskId
		{
			set{ _askid=value;}
			get{return _askid;}
		}
		/// <summary>
		/// 学员内码
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 老师内码
		/// </summary>
		public string TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? OrderBy
		{
			set{ _orderby=value;}
			get{return _orderby;}
		}
		/// <summary>
		/// 是否推送
		/// </summary>
		public int? IsSend
		{
			set{ _issend=value;}
			get{return _issend;}
		}
		/// <summary>
		/// 推送时间
		/// </summary>
		public string SendDate
		{
			set{ _senddate=value;}
			get{return _senddate;}
		}
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

