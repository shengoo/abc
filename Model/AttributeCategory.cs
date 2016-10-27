/**  版本信息模板在安装目录下，可自行修改。
* AttributeCategory.cs
*
* 功 能： N/A
* 类 名： AttributeCategory
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:41   N/A    初版
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
	/// 属性分类表
	/// </summary>
	[Serializable]
	public partial class AttributeCategory
	{
		public AttributeCategory()
		{}
		#region Model
		private int _attrcateid;
		private string _catename;
		private int? _enabled;
		private DateTime _createtime;
		/// <summary>
		/// 分类内码
		/// </summary>
		public int AttrCateId
		{
			set{ _attrcateid=value;}
			get{return _attrcateid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string CateName
		{
			set{ _catename=value;}
			get{return _catename;}
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
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

