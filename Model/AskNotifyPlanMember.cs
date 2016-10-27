/**  版本信息模板在安装目录下，可自行修改。
* AskNotifyPlanMember.cs
*
* 功 能： N/A
* 类 名： AskNotifyPlanMember
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:40   N/A    初版
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
	/// 问题推送表
	/// </summary>
	[Serializable]
	public partial class AskNotifyPlanMember
	{
		public AskNotifyPlanMember()
		{}
		#region Model
		private int _notifymid;
		private string _notifyid;
		private int _askid;
		private int _receiverid;
		private string _content;
		private int? _issend;
		private string _senddate;
		private int? _orderby;
		private DateTime? _createtime;
		/// <summary>
		/// 推送明细内码
		/// </summary>
		public int NotifyMId
		{
			set{ _notifymid=value;}
			get{return _notifymid;}
		}
		/// <summary>
		/// 推送内码
		/// </summary>
		public string NotifyId
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
		/// 接收者内码
		/// </summary>
		public int ReceiverId
		{
			set{ _receiverid=value;}
			get{return _receiverid;}
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
		/// 是否推送
		/// </summary>
		public int? IsSend
		{
			set{ _issend=value;}
			get{return _issend;}
		}
		/// <summary>
		/// 发送日期
		/// </summary>
		public string SendDate
		{
			set{ _senddate=value;}
			get{return _senddate;}
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

