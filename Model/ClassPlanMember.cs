/**  版本信息模板在安装目录下，可自行修改。
* ClassPlanMember.cs
*
* 功 能： N/A
* 类 名： ClassPlanMember
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
	/// 开课学员表
	/// </summary>
	[Serializable]
	public partial class ClassPlanMember
	{
		public ClassPlanMember()
		{}
		#region Model
		private int _cpmid;
		private int _classid;
		private int _memberid;
		/// <summary>
		/// 开课学员内码
		/// </summary>
		public int CpmId
		{
			set{ _cpmid=value;}
			get{return _cpmid;}
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
		/// 学员内码
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		#endregion Model

	}
}

