/**  版本信息模板在安装目录下，可自行修改。
* DataCountry.cs
*
* 功 能： N/A
* 类 名： DataCountry
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:51   N/A    初版
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
	/// 国家表
	/// </summary>
	[Serializable]
	public partial class DataCountry
	{
		public DataCountry()
		{}
		#region Model
		private int _countryid;
		private string _countryname;
		private int _enabled=1;
		private int _orderby;
		private DateTime _createtime;
		/// <summary>
		/// 国家内码
		/// </summary>
		public int CountryId
		{
			set{ _countryid=value;}
			get{return _countryid;}
		}
		/// <summary>
		/// 国家名称
		/// </summary>
		public string CountryName
		{
			set{ _countryname=value;}
			get{return _countryname;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int Orderby
		{
			set{ _orderby=value;}
			get{return _orderby;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

