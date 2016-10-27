using System;
namespace Model
{
	/// <summary>
	/// 赠送课程表 赠送课程表
	/// </summary>
	[Serializable]
	public partial class CourseGift
	{
		public CourseGift()
		{}
		#region Model
		private int _giftid;
		private int _courseid;
		/// <summary>
		/// 赠送内码
		/// </summary>
		public int GiftId
		{
			set{ _giftid=value;}
			get{return _giftid;}
		}
		/// <summary>
		/// 课程内码
		/// </summary>
		public int CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		#endregion Model

	}
}

