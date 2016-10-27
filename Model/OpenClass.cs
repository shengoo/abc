using System;

namespace Model
{
    public class OpenClass
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string About { get; set; }

        public string Teacher { get; set; }

        public string ImgUrl { set; get; }

        //public string Type { get; set; }

        public int Maxnum { get; set; }

        public int Num { get; set; }

        public DateTime ClassTime { get; set; }

        public string FreeStartTime { set; get; }

        public string FreeEndTime { set; get; }

        /// <summary>
        /// 是否已加入 0:未加入 1:已加入
        /// </summary>
        public int Exist { get; set; }
    }
}
