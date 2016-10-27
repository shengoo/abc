/**  版本信息模板在安装目录下，可自行修改。
* AttributeValue.cs
*
* 功 能： N/A
* 类 名： AttributeValue
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
	/// 属性值表
	/// </summary>
	[Serializable]
	public partial class AttributeValue
	{
		public AttributeValue()
		{}
		#region Model
		private int _valueid;
		private int? _attrid;
		private string _title;
		private int? _orderby;
		/// <summary>
		/// 属性值内码
		/// </summary>
		public int ValueId
		{
			set{ _valueid=value;}
			get{return _valueid;}
		}
		/// <summary>
		/// 属性内码
		/// </summary>
		public int? AttrId
		{
			set{ _attrid=value;}
			get{return _attrid;}
		}
		/// <summary>
		/// 属性值标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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

