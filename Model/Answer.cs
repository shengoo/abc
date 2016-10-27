/**  版本信息模板在安装目录下，可自行修改。
* Answer.cs
*
* 功 能： N/A
* 类 名： Answer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:38   N/A    初版
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
	/// 回答表
	/// </summary>
	public partial class Answer
	{
		public Answer()
		{}
		#region Model
		private int _answerid;
		private int _askid;
		private int _teacherid;
		private string _content;
		private int? _isaccept;
		private string _voice;
		private string _image;
		private int? _orderby;
		private DateTime? _createtime;

        public string Logo { get; set; }
        /// <summary>
        /// 回答内码
        /// </summary>
        public int AnswerId
		{
			set{ _answerid=value;}
			get{return _answerid;}
		}
		/// <summary>
		/// 问题内码
		/// </summary>
		public int AskId
		{
			set{ _askid=value;}
			get{return _askid;}
		}

        public string Ask { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// 老师内码
        /// </summary>
        public int TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 问题内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 是否采纳
		/// </summary>
		public int? IsAccept
		{
			set{ _isaccept=value;}
			get{return _isaccept;}
		}
		/// <summary>
		/// 语音
		/// </summary>
		public string Voice
		{
			set{ _voice=value;}
			get{return _voice;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string Image
		{
			set{ _image=value;}
			get{return _image;}
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

