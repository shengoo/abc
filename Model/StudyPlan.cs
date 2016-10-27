
using System;
namespace Model
{
	/// <summary>
	/// 学习计划表
	/// </summary>
	[Serializable]
	public partial class StudyPlan
	{
		public StudyPlan()
		{}
		#region Model
		private int _planid;
		private int _classid;
		private int _cardid;
		private int _courseid;
		private int _lessonid;
		private int _memberid;
		private int _teacherid;
		private int? _clength;
		private DateTime? _classtime;
		private DateTime? _begintime;
		private DateTime? _endtime;
		private int? _attending;
		private string _reasondesc;
		/// <summary>
		/// 计划编号
		/// </summary>
		public int PlanId
		{
			set{ _planid=value;}
			get{return _planid;}
		}
		/// <summary>
		/// 开课内码
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
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
		/// <summary>
		/// 课次内码
		/// </summary>
		public int LessonId
		{
			set{ _lessonid=value;}
			get{return _lessonid;}
		}
		/// <summary>
		/// 学员内码
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 老师内码
		/// </summary>
		public int TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 课时
		/// </summary>
		public int? Clength
		{
			set{ _clength=value;}
			get{return _clength;}
		}
		/// <summary>
		/// 上课时间
		/// </summary>
		public DateTime? ClassTime
		{
			set{ _classtime=value;}
			get{return _classtime;}
		}
		/// <summary>
		/// 上课开始时间
		/// </summary>
		public DateTime? BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 上课结束时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 上课标识 0：正常上课，1：旷课，2:重上
		/// </summary>
		public int? Attending
		{
			set{ _attending=value;}
			get{return _attending;}
		}
		/// <summary>
		/// 重上描述
		/// </summary>
		public string ReasonDesc
		{
			set{ _reasondesc=value;}
			get{return _reasondesc;}
		}
		#endregion Model

	}
}

