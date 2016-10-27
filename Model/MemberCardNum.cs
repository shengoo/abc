/**  版本信息模板在安装目录下，可自行修改。
* MemberCardNum.cs
*
* 功 能： N/A
* 类 名： MemberCardNum
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:55   N/A    初版
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
	/// 会员卡次
	/// </summary>
	[Serializable]
	public partial class MemberCardNum
	{
		public MemberCardNum()
		{}
		#region Model
		private int _membercardid;
		private int _memberid;
		private int? _cardcategoryid;
		private int? _cardtypeid;
		private int? _cardtotalnum;
		private int? _cardremaindernum;
		/// <summary>
		/// 内码
		/// </summary>
		public int MemberCardId
		{
			set{ _membercardid=value;}
			get{return _membercardid;}
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
		/// 卡分类内码
		/// </summary>
		public int? CardCategoryId
		{
			set{ _cardcategoryid=value;}
			get{return _cardcategoryid;}
		}
		/// <summary>
		/// 卡类别内码
		/// </summary>
		public int? CardTypeId
		{
			set{ _cardtypeid=value;}
			get{return _cardtypeid;}
		}
		/// <summary>
		/// 课次总数
		/// </summary>
		public int? CardTotalNum
		{
			set{ _cardtotalnum=value;}
			get{return _cardtotalnum;}
		}
		/// <summary>
		/// 剩余次数 
		/// </summary>
		public int? CardRemainderNum
		{
			set{ _cardremaindernum=value;}
			get{return _cardremaindernum;}
		}
		#endregion Model

	}
}

