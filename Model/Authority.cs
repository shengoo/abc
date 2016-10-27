/**  版本信息模板在安装目录下，可自行修改。
* Authority.cs
*
* 功 能： N/A
* 类 名： Authority
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:42   N/A    初版
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
	/// 权限表
	/// </summary>
	[Serializable]
	public partial class Authority
	{
		public Authority()
		{}
		#region Model
		private int _authorityid;
		private int? _roleid;
		private int? _sourceid;
		private string _authority;
		/// <summary>
		/// 权限内码 编号
		/// </summary>
		public int AuthorityId
		{
			set{ _authorityid=value;}
			get{return _authorityid;}
		}
		/// <summary>
		/// 角色内码
		/// </summary>
		public int? RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 资源内码
		/// </summary>
		public int? SourceId
		{
			set{ _sourceid=value;}
			get{return _sourceid;}
		}
		/// <summary>
        /// 权限序列 Authority
		/// </summary>
		public string Authority_Sqe
		{
			set{ _authority=value;}
			get{return _authority;}
		}
		#endregion Model

	}
}

