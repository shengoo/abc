using System;

namespace Model
{
    public class MemberSchedule
    {
        public string ClassDate { get; set; }
        public int ClassId { get; set; }
        public int CplId { get; set; }
        public int ScheduleId { get; set; }
        public int DayTotalCount { get; set; }
        public int DayFinishCount { get; set; }
        public string TimeName { get; set; }
        public string LevelName { get; set; }
        public int CourseCount { get; set; }
        public int CourseType { get; set; }
        public int FinishCount { get; set; }
        public int StudentNum { get; set; }
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string TeacherCNName { get; set; }
        public string TeacherEnName { get; set; }
        public string MemberCNName { get; set; }
        public string MemberEnName { get; set; }
        public string CourseName { get; set; }
        public int LessonNo { get; set; }
        public int Clength { get; set; }
        public int Status { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public int ClassModel { get; set; }

    }
}
