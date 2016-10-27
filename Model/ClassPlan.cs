/**  版本信息模板在安装目录下，可自行修改。
* ClassPlan.cs
*
* 功 能： N/A
* 类 名： ClassPlan
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:44   N/A    初版
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
	/// 开课计划表
	/// </summary>
	[Serializable]
	public partial class ClassPlan
	{
		public ClassPlan()
		{}
		#region Model
		private int _classid;
		private int? _classtype;
		private int _courseid;
		private int _teacherid;
		private int? _total;
		private int? _classmodel;
		private string _classno;
		private int? _maxstudentnum;
		private int? _frequency;
		private DateTime? _repeattime;
		private int? _classenable;
		private DateTime? _classtime;
		private int? _creator;
		private DateTime? _createtime;
		/// <summary>
		/// 开课内码
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 开课类型
		/// </summary>
		public int? ClassType
		{
			set{ _classtype=value;}
			get{return _classtype;}
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
		/// 老师内码
		/// </summary>
		public int TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 开课总次数
		/// </summary>
		public int? Total
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 上课方式 0：固定时间上课；1：自约上课
		/// </summary>
		public int? ClassModel
		{
			set{ _classmodel=value;}
			get{return _classmodel;}
		}
		/// <summary>
		/// 班级号
		/// </summary>
		public string ClassNo
		{
			set{ _classno=value;}
			get{return _classno;}
		}
		/// <summary>
		/// 最大学生数
		/// </summary>
		public int? MaxStudentNum
		{
			set{ _maxstudentnum=value;}
			get{return _maxstudentnum;}
		}
		/// <summary>
		/// 开课重复次数
		/// </summary>
		public int? Frequency
		{
			set{ _frequency=value;}
			get{return _frequency;}
		}
		/// <summary>
		/// 开课重复时间
		/// </summary>
		public DateTime? RepeatTime
		{
			set{ _repeattime=value;}
			get{return _repeattime;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? ClassEnable
		{
			set{ _classenable=value;}
			get{return _classenable;}
		}
		/// <summary>
		/// 开课时间
		/// </summary>
		public DateTime? ClassTime
		{
			set{ _classtime=value;}
			get{return _classtime;}
		}
		/// <summary>
		/// 开课人
		/// </summary>
		public int? Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

