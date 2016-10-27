/**  版本信息模板在安装目录下，可自行修改。
* MemberAssign.cs
*
* 功 能： N/A
* 类 名： MemberAssign
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:53   N/A    初版
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
	/// 学员分配表 学员分配表
	///
	/// </summary>
	[Serializable]
	public partial class MemberAssign
	{
		public MemberAssign()
		{}
		#region Model
		private int _assignid;
		private int _memberid;
		private int _managerid;
		private int _creator;
		private DateTime? _createtime;
		/// <summary>
		/// 分配内码
		/// </summary>
		public int AssignId
		{
			set{ _assignid=value;}
			get{return _assignid;}
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
		/// 学管师内码
		/// </summary>
		public int ManagerId
		{
			set{ _managerid=value;}
			get{return _managerid;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public int Creator
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

