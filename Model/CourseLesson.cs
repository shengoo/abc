/**  版本信息模板在安装目录下，可自行修改。
* CourseLesson.cs
*
* 功 能： N/A
* 类 名： CourseLesson
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:49   N/A    初版
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
	/// 课程课次表 课程课次表
	/// </summary>
	[Serializable]
	public partial class CourseLesson
	{
		public CourseLesson()
		{}
		#region Model
		private int _lessonid;
		private int _courseid;
		private int _number;
		private string _lessonname;
		private string _content;
		private string _lessondesc;
		private int? _clength;
		private int? _isfree;
		private int? _enabled;
		private DateTime? _createtime;

        public DateTime ClassStartTime { get; set; }
        public int CplId { get; set; }
		/// <summary>
		/// 课次内码
		/// </summary>
		public int LessonId
		{
			set{ _lessonid=value;}
			get{return _lessonid;}
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
		/// 序号
		/// </summary>
		public int Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 课次名称
		/// </summary>
		public string LessonName
		{
			set{ _lessonname=value;}
			get{return _lessonname;}
		}
		/// <summary>
		/// 课次内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 课次描述
		/// </summary>
		public string LessonDesc
		{
			set{ _lessondesc=value;}
			get{return _lessondesc;}
		}
		/// <summary>
		/// 时长
		/// </summary>
		public int? CLength
		{
			set{ _clength=value;}
			get{return _clength;}
		}
		/// <summary>
		/// 是否免费
		/// </summary>
		public int? IsFree
		{
			set{ _isfree=value;}
			get{return _isfree;}
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
		/// 创建日期
		/// </summary>
		public DateTime? Createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

