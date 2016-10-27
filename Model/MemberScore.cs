/**  版本信息模板在安装目录下，可自行修改。
* MemberScore.cs
*
* 功 能： N/A
* 类 名： MemberScore
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:56   N/A    初版
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
	/// 会员积分表
	/// </summary>
	[Serializable]
	public partial class MemberScore
	{
		public MemberScore()
		{}
		#region Model
		private int _mscoreid;
		private int _memberid;
		private string _operator;
		private string _score;
		private string _createtime;
		/// <summary>
		/// 内码
		/// </summary>
		public int MScoreId
		{
			set{ _mscoreid=value;}
			get{return _mscoreid;}
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
		/// 操作项
		/// </summary>
		public string Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		/// <summary>
		/// 收支分值
		/// </summary>
		public string Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 操作日期
		/// </summary>
		public string CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

