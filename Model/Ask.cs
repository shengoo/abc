
using System;
using System.Collections.Generic;

namespace Model
{
	/// <summary>
	/// 提问表
	/// </summary>
	[Serializable]
	public partial class Ask
	{
		public Ask()
		{}
		#region Model
		private int _askid;
		private int _memberid;
		private string _content;
		private int _answernum;
		private int _closed=0;
		private string _voice;
		private string _image;
		private int? _orderby;
		private DateTime _createtime;
		/// <summary>
		/// 问题内码
		/// </summary>
		public int AskId
		{
			set{ _askid=value;}
			get{return _askid;}
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
		/// 问题内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}

        public List<Answer> Answers { get; set; }
		/// <summary>
		/// 回答数
		/// </summary>
		public int AnswerNum
		{
			set{ _answernum=value;}
			get{return _answernum;}
		}
		/// <summary>
		/// 是否关闭
		/// </summary>
		public int Closed
		{
			set{ _closed=value;}
			get{return _closed;}
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
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

