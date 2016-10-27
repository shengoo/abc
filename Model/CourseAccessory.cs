/**  版本信息模板在安装目录下，可自行修改。
* CourseAccessory.cs
*
* 功 能： N/A
* 类 名： CourseAccessory
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
	/// 课程课件表 课程课件表
	/// </summary>
	[Serializable]
	public partial class CourseAccessory
	{
		public CourseAccessory()
		{}
		#region Model
		private int _accessoryid;
		private int _courseid;
		private int _lessonid;
		private int _fileid;
		/// <summary>
		/// 课件内码
		/// </summary>
		public int AccessoryId
		{
			set{ _accessoryid=value;}
			get{return _accessoryid;}
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
		/// 课次内码
		/// </summary>
		public int LessonId
		{
			set{ _lessonid=value;}
			get{return _lessonid;}
		}
		/// <summary>
		/// 附件内码
		/// </summary>
		public int FileId
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		#endregion Model

	}
}

