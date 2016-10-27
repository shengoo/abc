
using System;
namespace Model
{
	/// <summary>
	/// 上课评价表
	/// </summary>
	[Serializable]
	public partial class ClassComment
	{
		#region Model
		private int _commentid;
		private string _memberid;
		private string _content;
        public int ClassId { get; set; }
        public int CplId { get; set; }
        public int CommentType { get; set; }
        public int TeacherId { get; set; }
        /// <summary>
        /// 评价内码
        /// </summary>
        public int CommentId
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 用户内码
		/// </summary>
		public string MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 评价内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 评分数
		/// </summary>
		public int? Rate1
		{
            get; set;
        }
        /// <summary>
        /// 评分数
        /// </summary>
        public int? Rate2
        {
            get; set;
        }
        /// <summary>
        /// 评分数
        /// </summary>
        public int? Rate3
        {
            get; set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
		{
            get; set;
		}
		#endregion Model

	}
}

