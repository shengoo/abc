using System;
using System.Xml;
//using QianZhu.Utility;

namespace QianZhu.API.Unionpay
{
    /// <summary>
    /// 银联在线支付接口
    /// 功能：管理配置参数
    /// </summary> 
    public class UnionpayConfig
    {
        //配置文件默认路径
        private static string path = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\conf.xml.config";

        public static string Path
        {
            get { return path; }
            set { path = value; }
        }

        /// <summary>
        /// 获取配置参数的方法
        /// </summary>
        public static UnionpayConfigModel GetParams()
        {
            UnionpayConfigModel model = new UnionpayConfigModel();
            model.SecurityKey = mvcweb.PayConfig.Union.SecurityKey;
            model.MerId = mvcweb.PayConfig.Union.MemberId;
            model.MerAbbr = mvcweb.PayConfig.Union.MemberAbbr;
            model.CommodityName = mvcweb.PayConfig.Union.CommodityName; 
            return model;
        }

        /// <summary>
        /// 设置配置参数的方法
        /// </summary>
        public static void SetParams(UnionpayConfigModel model)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNode xmlRoot = xmlDoc.DocumentElement;

            xmlRoot.SelectSingleNode("securityKey").InnerText = model.SecurityKey;
            xmlRoot.SelectSingleNode("payParamsPredef/merId").InnerText = model.MerId;
            xmlRoot.SelectSingleNode("payParamsPredef/merAbbr").InnerText = model.MerAbbr;
            xmlRoot.SelectSingleNode("payParamsPredef/commodityName").InnerText = model.CommodityName;

            xmlDoc.Save(path);
        }
    }

    /// <summary>
    /// 配置参数实体
    /// </summary> 
    public class UnionpayConfigModel
    {
        private string securityKey;
        private string merId;
        private string merAbbr;
        private string commodityName;

        public UnionpayConfigModel() { }

        public string SecurityKey
        {
            get { return securityKey; }
            set { securityKey = value; }
        }

        public string MerId
        {
            get { return merId; }
            set { merId = value; }
        }

        public string MerAbbr
        {
            get { return merAbbr; }
            set { merAbbr = value; }
        }

        public string CommodityName
        {
            get { return commodityName; }
            set { commodityName = value; }
        }
    }
}