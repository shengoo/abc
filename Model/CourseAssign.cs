/**  版本信息模板在安装目录下，可自行修改。
* CourseAssign.cs
*
* 功 能： N/A
* 类 名： CourseAssign
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:46   N/A    初版
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
	/// 课程卡课程分配表
	/// </summary>
	[Serializable]
	public partial class CourseAssign
	{
		public CourseAssign()
		{}
		#region Model
		private int _assignid;
		private int _cardid;
		private int _courseid;
		/// <summary>
		/// 课程分配内码
		/// </summary>
		public int AssignId
		{
			set{ _assignid=value;}
			get{return _assignid;}
		}
		/// <summary>
		/// 课程卡内码
		/// </summary>
		public int CardId
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// 课程内码
		/// </summary>
		public int CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		#endregion Model

	}
}

