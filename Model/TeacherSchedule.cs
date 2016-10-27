/**  版本信息模板在安装目录下，可自行修改。
* TeacherSchedule.cs
*
* 功 能： N/A
* 类 名： TeacherSchedule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:08   N/A    初版
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
	/// 教师作息排班表 教师作息排班表
	/// </summary>
	[Serializable]
	public partial class TeacherSchedule
	{
		public TeacherSchedule()
		{}
		#region Model
		private int _wsid;
		private int _teacherid;
		private int _shiftid;
		private DateTime? _wsddate;
		private DateTime? _begintime;
		private DateTime? _endtime;
		private int? _creator;
		private DateTime? _createdate;
		/// <summary>
		/// 作息排班编号
		/// </summary>
		public int WsId
		{
			set{ _wsid=value;}
			get{return _wsid;}
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
		/// 班次
		/// </summary>
		public int ShiftId
		{
			set{ _shiftid=value;}
			get{return _shiftid;}
		}
		/// <summary>
		/// 作息日期
		/// </summary>
		public DateTime? WsDdate
		{
			set{ _wsddate=value;}
			get{return _wsddate;}
		}
		/// <summary>
		/// 开始时间点
		/// </summary>
		public DateTime? BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 结束时间点
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 排班人
		/// </summary>
		public int? Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 排班时间
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

