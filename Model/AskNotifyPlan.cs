/**  版本信息模板在安装目录下，可自行修改。
* AskNotifyPlan.cs
*
* 功 能： N/A
* 类 名： AskNotifyPlan
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
	/// 问题推送计划表
	/// </summary>
	[Serializable]
	public partial class AskNotifyPlan
	{
		public AskNotifyPlan()
		{}
		#region Model
		private int _notifyid;
		private int _askid;
		private string _content;
		private int? _orderby;
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

