/**  版本信息模板在安装目录下，可自行修改。
* CourseCategory.cs
*
* 功 能： N/A
* 类 名： CourseCategory
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:47   N/A    初版
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
	/// 课程分类表
	/// </summary>
	[Serializable]
	public partial class CourseCategory
	{
		public CourseCategory()
		{}
		#region Model
		private int _categoryid;
		private string _categoryname;
		private int? _enabled;
		private DateTime _createtime;
		/// <summary>
		/// 分类内码
		/// </summary>
		public int CategoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string CategoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
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

        public int Code { get; set; }
		#endregion Model

	}
}

