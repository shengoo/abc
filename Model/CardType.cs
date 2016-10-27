/**  版本信息模板在安装目录下，可自行修改。
* CardType.cs
*
* 功 能： N/A
* 类 名： CardType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:42   N/A    初版
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
	/// 课程卡类别表
	/// </summary>
	[Serializable]
	public partial class CardType
	{
		public CardType()
		{}
		#region Model
		private int _typeid;
		private string _typename;
		/// <summary>
		/// 卡类别内码
		/// </summary>
		public int TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 卡类别名称
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		#endregion Model

	}
}

