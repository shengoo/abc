using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Response<T>
    {
        public string ErrMsg { get; set; }

        /// <summary>
        /// 1002 表示
        /// </summary>
        public string ErrCode { get; set; }

        public T Result { get; set; }

        public bool IsSuccess { get { return string.IsNullOrEmpty(this.ErrMsg); } }
    }
}
