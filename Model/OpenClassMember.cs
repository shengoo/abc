using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Model
{
    public partial class OpenClassMember
	{
		public OpenClassMember()
		{}
		#region Model
		private int _classmemberid;
		private int _memberid;
		private DateTime? _jointime;
		/// <summary>
		/// 开课学员内码
		/// </summary>
		public int ClassMemberId
		{
			set{ _classmemberid=value;}
			get{return _classmemberid;}
		}
        public int OpenClassId { get; set; }

		/// <summary>
		/// 学员内码
		/// </summary>
		public int MemberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 加入时间
		/// </summary>
		public DateTime? JoinTime
		{
			set{ _jointime=value;}
			get{return _jointime;}
		}
		#endregion Model

	}
}

