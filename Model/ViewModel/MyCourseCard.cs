using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    /// 我的卡次 课程类型，课程名称，卡次总数，剩余次数
    /// </summary>
    public class MyCourseCard
    {
        /// <summary>
        /// 行号
        /// </summary>
        public Int64 RowNumber { set; get; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { set; get; }

        /// <summary>
        /// 课程卡类型名称
        /// </summary>
        public string CategoryName { set; get; }


        /// <summary>
        /// 课程卡类型名称
        /// </summary>
        public string CardName { set; get; }

        /// <summary>
        /// 卡次总数
        /// </summary>
        public int CardTotalNum { set; get; }

        /// <summary>
        /// 剩余卡次总数
        /// </summary>
        public int CardRemainderNum { set; get; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { set; get; }

        /// <summary>
        /// 课程类型名称
        /// </summary>
        public string CourseType { set; get; }

        /// <summary>
        /// 截止有效期
        /// </summary>
        public string ValidPeriod { set; get; }

    }
}
