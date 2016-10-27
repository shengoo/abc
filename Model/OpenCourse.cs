using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Maticsoft
{
	/// <summary>
	/// 类OpenCourse。
	/// </summary>
	[Serializable]
	public partial class OpenCourse
	{
		public OpenCourse()
		{}
		#region Model
		private int _courseid;
		private string _cnname;
		private string _enname;
		private string _coursedesc;
		private string _picurl;
		private string _videourl;
		private int? _enabled;
		private DateTime? _createtime;
		/// <summary>
		/// 课程内码
		/// </summary>
		public int CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 课程名称
		/// </summary>
		public string CnName
		{
			set{ _cnname=value;}
			get{return _cnname;}
		}
		/// <summary>
		/// 英文名称
		/// </summary>
		public string EnName
		{
			set{ _enname=value;}
			get{return _enname;}
		}
		/// <summary>
		/// 课程描述
		/// </summary>
		public string CourseDesc
		{
			set{ _coursedesc=value;}
			get{return _coursedesc;}
		}
		/// <summary>
		/// 课程图片地址
		/// </summary>
		public string PicUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 视频地址
		/// </summary>
		public string VideoUrl
		{
			set{ _videourl=value;}
			get{return _videourl;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model


	}
}

