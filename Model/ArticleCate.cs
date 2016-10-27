using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ArticleCate
    {
        private int _cateid;
        public int CateId
        {
            get { return _cateid; }
            set { _cateid = value; }
        }

        private int _parentid;
        public int ParentId
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 分类代码
        /// </summary>		
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>		
        private string _catename;
        public string CateName
        {
            get { return _catename; }
            set { _catename = value; }
        }
        /// <summary>
        /// 级次
        /// </summary>		
        private int _level;
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
    }
}
