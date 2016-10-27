using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CourseProcess
    {
        /// <summary>
        /// 直播编号
        /// </summary>
        public int Id { get; set; }

        public string Teacher { get; set; }

        public DateTime Time { get; set; }

        public string FileAttr { get; set; }

        public int IsClosed { get; set; }
    }
}
