
using System;
namespace Model
{
	/// <summary>
	/// 课程卡
	/// </summary>
	[Serializable]
	public partial class CourseCard
	{
		public CourseCard()
		{}
		#region Model
		private int _cardid;
		private string _cardname;
		private int _cardcategoryid;
		private int _cardtypeid;
		private string _carddesc;
		private int? _total;
		private int? _period;
		private int? _months;
		private int? _frequency;
        private decimal? _price;
		private int _enabled=1;
		private int? _orderby;
		private string _classcontent;
		private string _discount;
		private int? _creator;
		private DateTime _createtime;
		/// <summary>
		/// 课程卡编号
		/// </summary>
		public int CardId
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// 课程卡名称
		/// </summary>
		public string CardName
		{
			set{ _cardname=value;}
			get{return _cardname;}
		}
		/// <summary>
		/// 课程卡分类内码
		/// </summary>
		public int CardCategoryId
		{
			set{ _cardcategoryid=value;}
			get{return _cardcategoryid;}
		}
		/// <summary>
		/// 卡类别内码 0：次卡；1：月卡
		/// </summary>
		public int CardTypeId
		{
			set{ _cardtypeid=value;}
			get{return _cardtypeid;}
		}
		/// <summary>
		/// 课程介绍
		/// </summary>
		public string Carddesc
		{
			set{ _carddesc=value;}
			get{return _carddesc;}
		}
		/// <summary>
		/// 上课次数
		/// </summary>
		public int? Total
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 有效期/天
		/// </summary>
		public int? Period
		{
			set{ _period=value;}
			get{return _period;}
		}
		/// <summary>
		/// 月数
		/// </summary>
		public int? Months
		{
			set{ _months=value;}
			get{return _months;}
		}
		/// <summary>
		/// 约课频率
		/// </summary>
		public int? Frequency
		{
			set{ _frequency=value;}
			get{return _frequency;}
		}
		/// <summary>
		/// 折扣价
		/// </summary>
        public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
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
		/// 排序
		/// </summary>
		public int? OrderBy
		{
			set{ _orderby=value;}
			get{return _orderby;}
		}
		/// <summary>
		/// 开课内容
		/// </summary>
		public string ClassContent
		{
			set{ _classcontent=value;}
			get{return _classcontent;}
		}
		/// <summary>
		/// 超值优惠
		/// </summary>
		public string Discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public int? Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}

		#endregion Model

	}
}

