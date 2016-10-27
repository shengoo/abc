/**  版本信息模板在安装目录下，可自行修改。
* CourseComment.cs
*
* 功 能： N/A
* 类 名： CourseComment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:48   N/A    初版
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
	/// 课程评价表 课程评价表
	/// </summary>
	[Serializable]
	public partial class CourseComment
	{
		public CourseComment()
		{}
		#region Model
		private int _commentid;
		private int _courseid;
		private int _memberid;
		private string _comment;
		private DateTime? _createtime;
		/// <summary>
		/// 评价内码
		/// </summary>
		public int CommentId
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 课程内码
		/// </summary>
		public int CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 学员内码
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 评价内容
		/// </summary>
		public string COMMENT
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		/// <summary>
		/// 评价时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

