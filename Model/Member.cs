/**  版本信息模板在安装目录下，可自行修改。
* Member.cs
*
* 功 能： N/A
* 类 名： Member
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:53   N/A    初版
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
	/// 会员表
	/// </summary>
	[Serializable]
	public partial class Member
	{
		public Member()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _pwd;
		private int _membertype=1;
		private string _mobile;
		private string _cnname;
		private string _enname;
		private int _sex;
		private int? _age;
		private DateTime? _birthday;
		private string _address;
		private int _provinceid;
		private int _cityid;
		private string _logo;
		private string _qq;
		private string _learninggoal;
		private string _learningtarget;
		private string _learningtime;
		private string _howknow;
		private DateTime? _createtime;
		private int _enabled=1;
		private int? _mobilevalid;
		private int? _score;
		private int _ispay=0;
		/// <summary>
		/// 会员内码
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 会员名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
        /// 会员类型1、 学员、2、答疑老师、3、授课教师 4、客服
		/// </summary>
		public int MemberType
		{
			set{ _membertype=value;}
			get{return _membertype;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 中文名
		/// </summary>
		public string CNName
		{
			set{ _cnname=value;}
			get{return _cnname;}
		}
		/// <summary>
		/// 英文名
		/// </summary>
		public string ENName
		{
			set{ _enname=value;}
			get{return _enname;}
		}
        /// <summary>
        /// 学员心声
        /// </summary>
        public string Voice { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public int? Age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 居住地
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}

        public string Email { get; set; }

		/// <summary>
		/// 头像
		/// </summary>
		public string Logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// QQ
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 学习目的
		/// </summary>
		public string LearningGoal
		{
			set{ _learninggoal=value;}
			get{return _learninggoal;}
		}
		/// <summary>
		/// 学习目标
		/// </summary>
		public string LearningTarget
		{
			set{ _learningtarget=value;}
			get{return _learningtarget;}
		}
		/// <summary>
		/// 学习时间
		/// </summary>
		public string LearningTime
		{
			set{ _learningtime=value;}
			get{return _learningtime;}
		}
		/// <summary>
		/// 获取ABC渠道
		/// </summary>
		public string HowKnow
		{
			set{ _howknow=value;}
			get{return _howknow;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
		}
		/// <summary>
		/// 会员积分
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 是否付费用户
		/// </summary>
		public int Ispay
		{
			set{ _ispay=value;}
			get{return _ispay;}
		}

		#endregion Model

	}
}

