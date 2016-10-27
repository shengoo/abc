using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Maticsoft
{
	/// <summary>
	/// 类OpenClassAttend。
	/// </summary>
	[Serializable]
	public partial class OpenClassAttend
	{
		public OpenClassAttend()
		{}
		#region Model
		private int _attendid;
		private int _classid;
		private DateTime? _attendtime;
		private int? _attendtype;
		/// <summary>
		/// 上课内码
		/// </summary>
		public int AttendId
		{
			set{ _attendid=value;}
			get{return _attendid;}
		}
		/// <summary>
		/// 开课内码
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 上课时间
		/// </summary>
		public DateTime? AttendTime
		{
			set{ _attendtime=value;}
			get{return _attendtime;}
		}
		/// <summary>
		/// 上课类型
		/// </summary>
		public int? AttendType
		{
			set{ _attendtype=value;}
			get{return _attendtype;}
		}
		#endregion Model


	}
}

