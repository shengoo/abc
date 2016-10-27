/**  版本信息模板在安装目录下，可自行修改。
* DataProvince.cs
*
* 功 能： N/A
* 类 名： DataProvince
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:52   N/A    初版
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
	/// 省份表
	/// </summary>
	[Serializable]
	public partial class DataProvince
	{
		public DataProvince()
		{}
		#region Model
		private int _provinceid;
		private string _provincename;
		private int _countryid;
		private int _status=1;
		private int _orderby;
		private DateTime _createtime;
		/// <summary>
		/// 省份内码
		/// </summary>
		public int ProvinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 省份名称
		/// </summary>
		public string ProvinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
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
		/// 状态
		/// </summary>
		public int Enabled
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int OrderBy
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

