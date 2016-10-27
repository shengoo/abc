/**  版本信息模板在安装目录下，可自行修改。
* SYS_DatabaseUpgrade.cs
*
* 功 能： N/A
* 类 名： SYS_DatabaseUpgrade
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:05   N/A    初版
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
	/// 学习计划表
	/// </summary>
	[Serializable]
	public partial class SYS_DatabaseUpgrade
	{
		public SYS_DatabaseUpgrade()
		{}
		#region Model
		private string _filename;
		private decimal _line=0M;
		private DateTime _updatetime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Line
		{
			set{ _line=value;}
			get{return _line;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

