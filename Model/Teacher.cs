/**  版本信息模板在安装目录下，可自行修改。
* Teacher.cs
*
* 功 能： N/A
* 类 名： Teacher
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:07   N/A    初版
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
	/// 教师表 教师表
	/// </summary>
	[Serializable]
	public partial class Teacher
	{
		public Teacher()
		{}
		#region Model
		private int _teacherid;
		private int _mid;
		private int _countryid;
		private string _introduce;
		private string _signature;
		private string _video;
		private int? _grade;
		private int? _orderby;
		private int? _istop;
		private int? _visible;
		private int? _enabled;
		private string _creator;
		private DateTime? _createtime;
		/// <summary>
		/// 教师编号
		/// </summary>
		public int TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 会员内码
		/// </summary>
		public int MemberId
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 国家内码
		/// </summary>
		public int CountryId
		{
			set{ _countryid=value;}
			get{return _countryid;}
		}
		/// <summary>
		/// 自我介绍
		/// </summary>
		public string Introduce
		{
			set{ _introduce=value;}
			get{return _introduce;}
		}
		/// <summary>
		/// 个人签名
		/// </summary>
		public string Signature
		{
			set{ _signature=value;}
			get{return _signature;}
		}
		/// <summary>
		/// 介绍视频
		/// </summary>
		public string Video
		{
			set{ _video=value;}
			get{return _video;}
		}
		/// <summary>
		/// 优先级
		/// </summary>
		public int? Grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? OrderBy
		{
			set{ _orderby=value;}
			get{return _orderby;}
		}
		/// <summary>
		/// 置顶 0,1标识
		/// </summary>
		public int? IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 是否显示
		/// </summary>
		public int? Visible
		{
			set{ _visible=value;}
			get{return _visible;}
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
		/// 创建人
		/// </summary>
		public string Creator
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

