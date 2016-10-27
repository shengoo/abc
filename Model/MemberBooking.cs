/**  版本信息模板在安装目录下，可自行修改。
* MemberBooking.cs
*
* 功 能： N/A
* 类 名： MemberBooking
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:54   N/A    初版
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
	/// 学员预约表 学员预约表
	/// </summary>
	[Serializable]
	public partial class MemberBooking
	{
		public MemberBooking()
		{}
		#region Model
		private int _bookingid;
		private string _bookingno;
		private int _planid;
		private int _memberid;
		private string _oldbookingid;
		private int? _bookingtype;
		private DateTime? _classtime;
		private DateTime? _bookingtime;
		private DateTime? _begintime;
		private DateTime? _endtime;
		/// <summary>
		/// 预约内码 预约编号
		/// </summary>
		public int BookingId
		{
			set{ _bookingid=value;}
			get{return _bookingid;}
		}
		/// <summary>
		/// 预约流水号 预约流水号
		/// </summary>
		public string BookingNo
		{
			set{ _bookingno=value;}
			get{return _bookingno;}
		}
		/// <summary>
		/// 学习计划内码 学习计划编号
		/// </summary>
		public int PlanId
		{
			set{ _planid=value;}
			get{return _planid;}
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
		/// 原预约内码
		/// </summary>
		public string OldBookingId
		{
			set{ _oldbookingid=value;}
			get{return _oldbookingid;}
		}
		/// <summary>
		/// 约课类型 正常约课、取消约课
		/// </summary>
		public int? BookingType
		{
			set{ _bookingtype=value;}
			get{return _bookingtype;}
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
		/// 约课时间
		/// </summary>
		public DateTime? BookingTime
		{
			set{ _bookingtime=value;}
			get{return _bookingtime;}
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
		/// 上课结束日期
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		#endregion Model

	}
}

