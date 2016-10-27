using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string WeiXinUrl { set; get; }

        public string Content { set; get; }

        public string Description { get; set; }
    }
}
