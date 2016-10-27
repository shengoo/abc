
using System;
namespace Model
{
	/// <summary>
	/// 上课记录表
	/// </summary>
	[Serializable]
	public partial class ClassAttend
	{
		public ClassAttend()
		{}
		#region Model
		private int _attendid;
		private int _scheduleid;
		private int? _attendtype;
		private DateTime? _begintime;
		private DateTime? _endtime;
		private int? _flag;
		/// <summary>
		/// 记录内码
		/// </summary>
		public int AttendId
		{
			set{ _attendid=value;}
			get{return _attendid;}
		}
		/// <summary>
		/// 直播内码
		/// </summary>
		public int ScheduleId
		{
			set{ _scheduleid=value;}
			get{return _scheduleid;}
		}
		/// <summary>
		/// 上课类型 0：正常上课，1:迟到，2:异常
		/// </summary>
		public int? AttendType
		{
			set{ _attendtype=value;}
			get{return _attendtype;}
		}
		/// <summary>
		/// 上课时间
		/// </summary>
		public DateTime? BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 下课时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 上课标识
		/// </summary>
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}

