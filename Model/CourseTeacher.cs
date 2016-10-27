/**  版本信息模板在安装目录下，可自行修改。
* CourseTeacher.cs
*
* 功 能： N/A
* 类 名： CourseTeacher
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:50   N/A    初版
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
	/// 课程授课老师表
	/// </summary>
	[Serializable]
	public partial class CourseTeacher
	{
		public CourseTeacher()
		{}
		#region Model
		private int _teachingid;
		private int _courseid;
		private int _teacherid;
		/// <summary>
		/// 授课内码
		/// </summary>
		public int TeachingId
		{
			set{ _teachingid=value;}
			get{return _teachingid;}
		}
		/// <summary>
		/// 课程内码
		/// </summary>
		public int CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 教师内码
		/// </summary>
		public int TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		#endregion Model

	}
}

