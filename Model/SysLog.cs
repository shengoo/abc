/**  版本信息模板在安装目录下，可自行修改。
* SysLog.cs
*
* 功 能： N/A
* 类 名： SysLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:06   N/A    初版
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
	/// 系统日志表
	/// </summary>
	[Serializable]
	public partial class SysLog
	{
		public SysLog()
		{}
		#region Model
		private int _logid;
		private int _memberid;
		private int? _sysfrom;
		private string _module;
		private string _activity;
		private int? _level;
		private string _content;
		private string _currloginip;
		private DateTime? _currlogintime;
		/// <summary>
		/// 日志内码
		/// </summary>
		public int LogId
		{
			set{ _logid=value;}
			get{return _logid;}
		}
		/// <summary>
		/// 用户内码
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 系统来源 0：前台，1：后台
		/// </summary>
		public int? SysFrom
		{
			set{ _sysfrom=value;}
			get{return _sysfrom;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string Module
		{
			set{ _module=value;}
			get{return _module;}
		}
		/// <summary>
		/// 操作功能
		/// </summary>
		public string Activity
		{
			set{ _activity=value;}
			get{return _activity;}
		}
		/// <summary>
		/// 级别
		/// </summary>
		public int? Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 日志内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 当前IP
		/// </summary>
		public string CurrLoginIp
		{
			set{ _currloginip=value;}
			get{return _currloginip;}
		}
		/// <summary>
		/// 当前时间
		/// </summary>
		public DateTime? CurrLoginTime
		{
			set{ _currlogintime=value;}
			get{return _currlogintime;}
		}
		#endregion Model

	}
}

