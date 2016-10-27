using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 系统设置--基本设置视图模型
    /// </summary>
    public class WebSiteBasicSetting
    {
        /// <summary>
        /// 网站标题
        /// </summary>
        public string WebSiteTitle { set; get; }

        /// <summary>
        /// 网站关键字
        /// </summary>
        public string MetaKeyWords { set; get; }
        /// <summary>
        /// 网站描述
        /// </summary>
        public string MetaDescription { set; get; }
        /// <summary>
        /// 网站logo
        /// </summary>
        public string WebSiteLogo { set; get; }
        /// <summary>
        /// 客服电话
        /// </summary>
        public string CustomerCarePhone { set; get; }
        /// <summary>
        /// 网站备案号
        /// </summary>
        public string WebSiteICPNumber { set; get; }
    }
}
