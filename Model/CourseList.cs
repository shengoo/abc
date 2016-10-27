using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 我的课表
    /// </summary>
    public class CourseList
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }

        public string Type { get; set; }

        public int CourseTimes { get; set; }

        public int Process { get; set; }
    }
}
