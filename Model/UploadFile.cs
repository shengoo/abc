/**  版本信息模板在安装目录下，可自行修改。
* UploadFile.cs
*
* 功 能： N/A
* 类 名： UploadFile
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:10   N/A    初版
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
	/// 上传文件表
	/// </summary>
	[Serializable]
	public partial class UploadFile
	{
		public UploadFile()
		{}
		#region Model
		private int _fileid;
		private string _filename;
		private string _filetype;
		private string _hash;
		private string _ext;
		private int? _size;
		private int? _enabled;
		private int? _ispublic;
		private int? _candownload;
		private DateTime? _createtime;
		/// <summary>
		/// 文件内码
		/// </summary>
		public int FileId
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		/// <summary>
		/// 文件名称
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 文件类型 ppt/document/video
		/// </summary>
		public string FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// 哈希路径
		/// </summary>
		public string Hash
		{
			set{ _hash=value;}
			get{return _hash;}
		}
		/// <summary>
		/// 扩展名
		/// </summary>
		public string Ext
		{
			set{ _ext=value;}
			get{return _ext;}
		}
		/// <summary>
		/// 大小
		/// </summary>
		public int? Size
		{
			set{ _size=value;}
			get{return _size;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
		}
		/// <summary>
		/// 是否公开
		/// </summary>
		public int? IsPublic
		{
			set{ _ispublic=value;}
			get{return _ispublic;}
		}
		/// <summary>
		/// 可以下载
		/// </summary>
		public int? CanDownLoad
		{
			set{ _candownload=value;}
			get{return _candownload;}
		}
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

