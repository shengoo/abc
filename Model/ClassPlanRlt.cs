
namespace Model
{
    public class ClassPlanRlt
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string CategoryName{get;set;}
        /// <summary>
        /// 总课次
        /// </summary>
        public int Total{get;set;}
        /// <summary>
        /// 当前课次
        /// </summary>
        public int CurrentClass{get;set;}
    }
}
