/**  版本信息模板在安装目录下，可自行修改。
* MemberMessage.cs
*
* 功 能： N/A
* 类 名： MemberMessage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:56   N/A    初版
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
	/// 会员消息
	/// </summary>
	[Serializable]
	public partial class MemberMessage
	{
		public MemberMessage()
		{}
		#region Model
		private int _msgid;
		private int? _fromid;
		private int? _toid;
		private string _title;
		private string _content;
		private DateTime? _senddate;
		private int? _enabled;
		/// <summary>
		/// 课程分类编号
		/// </summary>
		public int MsgId
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// 发送者
		/// </summary>
		public int? FromId
		{
			set{ _fromid=value;}
			get{return _fromid;}
		}
		/// <summary>
		/// 收信者
		/// </summary>
		public int? ToId
		{
			set{ _toid=value;}
			get{return _toid;}
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
		/// 内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 发送日期
		/// </summary>
		public DateTime? SendDate
		{
			set{ _senddate=value;}
			get{return _senddate;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
		}
		#endregion Model

	}
}

