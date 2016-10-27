/**  版本信息模板在安装目录下，可自行修改。
* Module.cs
*
* 功 能： N/A
* 类 名： Module
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:58   N/A    初版
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
	/// 模块表
	/// </summary>
	[Serializable]
	public partial class Module
	{
		public Module()
		{}
		#region Model
		private int _moduleid;
		private string _module;
		private int? _parentid;
		private int? _level;
		private string _controller;
		private string _moduletype;
		private int? _orderby;
		/// <summary>
		/// 模块内码 编号
		/// </summary>
		public int ModuleId
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
        /// 模块名称 //Module
		/// </summary>
		public string Module_Name
		{
			set{ _module=value;}
			get{return _module;}
		}
		/// <summary>
		/// 父节点内码
		/// </summary>
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 级次 
		/// </summary>
		public int? Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 控制器
		/// </summary>
		public string Controller
		{
			set{ _controller=value;}
			get{return _controller;}
		}
		/// <summary>
		/// 模块类型 功能、页面、按钮
		/// </summary>
		public string ModuleType
		{
			set{ _moduletype=value;}
			get{return _moduletype;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? OrderBy
		{
			set{ _orderby=value;}
			get{return _orderby;}
		}
		#endregion Model

	}
}

