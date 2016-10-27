
using System;
namespace Model
{
	/// <summary>
	/// 课程表 课程表
	/// </summary>
	[Serializable]
	public partial class Course
	{
		public Course()
		{}
		#region Model
		private int _courseid;
		private int _coursetype;
		private string _cnname;
		private string _enname;
		private string _about;
		private string _goals;
		private int? _clength;
		private string _picurl;
		private string _videourl;
		private int? _isfree;
		private int? _expiryday;
		private int? _lessonnum;
		private int? _enabled;
		/// <summary>
		/// 课程内码
		/// </summary>
		public int CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 课程类型 中教、外教
		/// </summary>
		public int CourseType
		{
			set{ _coursetype=value;}
			get{return _coursetype;}
		}
		/// <summary>
		/// 课程名称
		/// </summary>
		public string CnName
		{
			set{ _cnname=value;}
			get{return _cnname;}
		}
		/// <summary>
		/// 英文名称
		/// </summary>
		public string EnName
		{
			set{ _enname=value;}
			get{return _enname;}
		}
		/// <summary>
		/// 课程介绍
		/// </summary>
		public string About
		{
			set{ _about=value;}
			get{return _about;}
		}
		/// <summary>
		/// 课程目标
		/// </summary>
		public string Goals
		{
			set{ _goals=value;}
			get{return _goals;}
		}
		/// <summary>
		/// 课时 课时
		/// </summary>
		public int? Clength
		{
			set{ _clength=value;}
			get{return _clength;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string PicUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 视频url
		/// </summary>
		public string VideoUrl
		{
			set{ _videourl=value;}
			get{return _videourl;}
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
		/// 有效天数
		/// </summary>
		public int? ExpiryDay
		{
			set{ _expiryday=value;}
			get{return _expiryday;}
		}
		/// <summary>
		/// 课次总数
		/// </summary>
		public int? LessonNum
		{
			set{ _lessonnum=value;}
			get{return _lessonnum;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
		}
		#endregion Model

	}
}

