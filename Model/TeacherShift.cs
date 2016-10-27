/**  版本信息模板在安装目录下，可自行修改。
* TeacherShift.cs
*
* 功 能： N/A
* 类 名： TeacherShift
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:09   N/A    初版
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
	/// 教师班次表
	/// </summary>
	[Serializable]
	public partial class TeacherShift
	{
		public TeacherShift()
		{}
		#region Model
		private int _shiftid;
		private string _color;
		private int? _shifttype;
		private string _shiftname;
		private DateTime? _begintime;
		private DateTime? _endtime;
		private string _note;
		/// <summary>
		/// 班次内码
		/// </summary>
		public int ShiftId
		{
			set{ _shiftid=value;}
			get{return _shiftid;}
		}
		/// <summary>
		/// 配色
		/// </summary>
		public string Color
		{
			set{ _color=value;}
			get{return _color;}
		}
		/// <summary>
		/// 班次类型 0,1:工作与非工作
		/// </summary>
		public int? ShiftType
		{
			set{ _shifttype=value;}
			get{return _shifttype;}
		}
		/// <summary>
		/// 班次名称
		/// </summary>
		public string ShiftName
		{
			set{ _shiftname=value;}
			get{return _shiftname;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

