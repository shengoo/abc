namespace Model
{
    public class MyCourse
    {
        public int CourseType { get; set; }
        public string CreateDate { get; set; }
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int StudentNum { get; set; }
        public int ClassModel { get; set; }
        public string ClassModelName { get; set; }
        public int ClassStatus { get; set; }
        public string ClassStatusName { get; set; }
        public int LessonCount { get; set; }

        public int FinishCount { set; get; }
        // public decimal ClassProgress { get; set; }
        public int CurrCplId { get; set; }
    }

    public class CourseDetail
    {
        public int ClassId { get; set; }
        public int CplId { get; set; }
        public string LessonIds { get; set; }
        public int LessonNo { get; set; }
        public int Clength { get; set; }
        public int TeacherId { get; set; }
        public string TeacherCNName { get; set; }
        public string TeacherEnName { get; set; }
        public string ClassDate { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public int LessonStatus { get; set; }
        public string LessonStatusName { get; set; }
        public int CurrLessonId { get; set; }
        public string CurrLessonName { get; set; }
        public string VideoUrl { get; set; }
        public string FileUrl { get; set; }
        public int CourseType { get; set; }
        public int CategoryCode { get; set; }
        public string ManagerName { get; set; }
        public int MaxStudentNum { get; set; }
        public int CurrStudentNum { get; set; }
    }
}
