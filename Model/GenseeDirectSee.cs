using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 展示互动 直播
    /// </summary>
    public class GenseeDirectSee
    {
        /// <summary>
        /// 直播编号
        /// </summary>
        public string WebCastId { get; set; }
        /// <summary>
        /// 计划号
        /// </summary>
        public int CplId { get; set; }
        /// <summary>
        /// 访问url
        /// </summary>
        public string Url {get;set;}

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 时长(分)
        /// </summary>
        public int CourseLength { get; set; }

        /// <summary>
        /// 是否满员
        /// </summary>
        public bool IsFull { get; set; }

        public int ScheduleId { get; set; }
    }
}
