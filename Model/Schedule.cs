/**  版本信息模板在安装目录下，可自行修改。
* Schedule.cs
*
* 功 能： N/A
* 类 名： Schedule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:03   N/A    初版
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
	/// 直播课表
	/// </summary>
	[Serializable]
	public partial class Schedule
	{
		public Schedule()
		{}
		#region Model
		private int _scheduleid;
		private int _planid;
		private int _cardid;
		private int _lenssonid;
		private int _courseid;
		private int _memberid;
		private int _teacherid;
		private DateTime _begintime;
		private int? _clength;
		private string _organizerurl;
		private string _panelisturl;
		private string _attendeeurl;
		private string _organizetoken;
		private string _panelisttoken;
		private string _attendeetoken;
		private int? _isfull;
		/// <summary>
		/// 内码
		/// </summary>
		public int ScheduleId
		{
			set{ _scheduleid=value;}
			get{return _scheduleid;}
		}
		/// <summary>
		/// 开课计划内码
		/// </summary>
		public int PlanId
		{
			set{ _planid=value;}
			get{return _planid;}
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
		/// 课次内码
		/// </summary>
		public int LenssonId
		{
			set{ _lenssonid=value;}
			get{return _lenssonid;}
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
		/// 会员内码
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 教师内码
		/// </summary>
		public int TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 上课时间
		/// </summary>
		public DateTime BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 时长
		/// </summary>
		public int? Clength
		{
			set{ _clength=value;}
			get{return _clength;}
		}
		/// <summary>
		/// 公司直播url
		/// </summary>
		public string OrganizerUrl
		{
			set{ _organizerurl=value;}
			get{return _organizerurl;}
		}
		/// <summary>
		/// 老师直播url
		/// </summary>
		public string PaneListUrl
		{
			set{ _panelisturl=value;}
			get{return _panelisturl;}
		}
		/// <summary>
		/// 与会人员直播url
		/// </summary>
		public string AttendeeUrl
		{
			set{ _attendeeurl=value;}
			get{return _attendeeurl;}
		}
		/// <summary>
		/// 公司直播令牌
		/// </summary>
		public string OrganizeToken
		{
			set{ _organizetoken=value;}
			get{return _organizetoken;}
		}
		/// <summary>
		/// 老师直播令牌
		/// </summary>
		public string PaneListToken
		{
			set{ _panelisttoken=value;}
			get{return _panelisttoken;}
		}
		/// <summary>
		/// 参与者直播令牌
		/// </summary>
		public string AttendeeToken
		{
			set{ _attendeetoken=value;}
			get{return _attendeetoken;}
		}
		/// <summary>
		/// 是否满员
		/// </summary>
		public int? Isfull
		{
			set{ _isfull=value;}
			get{return _isfull;}
		}
		#endregion Model

	}
}

