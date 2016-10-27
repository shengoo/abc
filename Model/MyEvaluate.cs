using System;

namespace Model
{
    public class MyEvaluate
    {

        public string Teacher { get; set; }

        public string CourseName { get; set; }

        public string Content { get; set; }

        public string About { get; set; }

        public int Remark { get; set; }

        public DateTime CreateTime { get; set; }

        public string Logo { get; set; }

        /// <summary>
        /// 0:收费 1:免费
        /// </summary>
        public int CourseType { get; set; }

        public int CplId { get; set; }

        public int ClassId { get; set; }
    }
}
