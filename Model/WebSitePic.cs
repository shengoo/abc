using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WebSitePic
    {
        public int PicId { get; set; }

        public int SiteType { get; set;}

        public int TypeId { get; set; }

        public string Url { get; set; }

        public int OrderBy { get; set; }

    }
}
