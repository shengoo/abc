using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Net;
using Model;
using Newtonsoft.Json;

namespace mvcweb
{
    public class ValidInfo
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
    public class MobileValid
    {
        public string UUID { get; set; }

        public List<ValidInfo> Result { get; set; }
    }

    public class SsoKey
    {
        private static Dictionary<string, Tuple<string, DateTime>> key = new Dictionary<string, Tuple<string, DateTime>>();
        private static bool status = false;

        private static void Init()
        {
            if (status) return;
            status = true;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 600 * 1000;
            timer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                var invalidkeys = new List<string>();
                foreach (var cookie in key)
                {
                    if ((DateTime.Now - cookie.Value.Item2).TotalMinutes > 120)
                    {
                        invalidkeys.Add(cookie.Key);
                    }
                }
                foreach (var cookie in invalidkeys)
                {
                    key.Remove(cookie);
                }
            };
            timer.Start();
        }

        public static string GetKey(Member member)
        {
            Init();
            if (key.ContainsKey(member.Mobile))
            {
                var cookie = key[member.Mobile];
                if ((DateTime.Now - cookie.Item2).TotalMinutes > 120)
                {
                    key[member.Mobile] = GetCookie(member);
                }
            }
            else
            {
                key.Add(member.Mobile, GetCookie(member));
            }
            return key[member.Mobile].Item1;
        }
        private static Tuple<string, DateTime> GetCookie(Member member)
        {
            return new Tuple<string, DateTime>(Common.GetRequestConent(null, Common.LoginUrl,
                "{\"DeviceType\":\"Android\",\"UserName\":\"" + member.UserName + "\",\"Pwd\":\"" +
                 new DES { IV = member.UserName, Key = member.UserName }.Encrypt(Common.DesEncrypt(member.Pwd))
                + "\",\"Mobile\":\"" + member.Mobile + "\",\"MemberType\":" + member.MemberType + ",\"RegistrationID\":\"\"}"), DateTime.Now);
        }
    }

    public class Common
    {
        public static string GetRequestConent(string CookiesStr, string url, string json)
        {
            HttpWebRequest myRequest = null;
            try
            {
                Encoding encoding = Encoding.UTF8;
                string postData = json.Replace("'", "\"");
                byte[] data = encoding.GetBytes(postData);
                myRequest = (HttpWebRequest)WebRequest.Create(url);
                if (!string.IsNullOrEmpty(CookiesStr))
                {
                    myRequest.Headers.Add("Cookie", CookiesStr);
                }
                myRequest.Method = "POST";
                myRequest.ContentType = "application/json";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();
                // 发送数据
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                string responseData = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse())
                {
                    if (string.IsNullOrEmpty(CookiesStr))
                    {
                        // 注销后要清除Common.session
                        String cookie = response.GetResponseHeader("Set-Cookie");
                        if (cookie != null)
                        {
                            return cookie;
                        }
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                    {
                        responseData = reader.ReadToEnd().ToString();
                    }
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                DataBase.DbHelperSQL.WriteLog(string.Format("调用服务:{0} 传入参数:{1} 失败！", url, json), ex);
                throw ex;
            }
        }

        public static string BaseFilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        private static string ssoLoginKey = null;
        public static string GetSsoLoginKey(Member member)
        {
            return ssoLoginKey ?? Common.GetRequestConent(null, Common.LoginUrl,
            "{\"DeviceType\":\"Android\",\"UserName\":\"" + member.UserName + "\",\"Pwd\":\"" +
             new DES { IV = member.UserName, Key = member.UserName }.Encrypt(Common.DesEncrypt(member.Pwd))
            + "\",\"Mobile\":\"" + member.Mobile + "\",\"MemberType\":" + member.MemberType + ",\"RegistrationID\":\"\"}");
        }

        public static string GetConfigValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key].ToString();
        }

        private static string serviceUrl = GetConfigValue("ServiceUrl");
        public static string ServiceUrl
        {
            get
            {
                return serviceUrl;
            }
        }
        public static string SsoUrl
        {
            get
            {
                return GetConfigValue("SsoUrl");
            }
        }

        /// <summary>
        /// 短信服务地址
        ///参数：{"Mobile":"18610822189","SendTime":"2015-10-24 20:55:19"}
        ///结果：{"Result":[{"Code":1,"Message":"验证码已发送成功"}],"UUID":"93a18d31c64e41538db762aa34b02a1a"}
        /// </summary>
        public static string MessageUrl { get { return SsoUrl + "/Auth/SendSMSCode"; } }

        /// <summary>
        /// 登录服务地址
        /// 参数：
        /// {AppVersion":"V1.1","UUID":"1b3da15d304e49fe8f287b9fba768d32","DeviceToken":"","DeviceType":"Android","UserName":"18610822189","Pwd":"X7YNaGtnUHw=","Mobile":"18610822189","MemberType":1,"RegistrationID":"wrewrdwer23243234"}
        /// 结果：
        /// {"Result":[{"Code":-1,"Message":"登录失败！"}],"Data":null}
        /// {"Result":[{"Code":1,"Message":"登录成功！"}],"Data":"{\"TableName\":\"MemberView\",\"PrimaryKey\":\"Id\",\"Id\":43,\"UserName\":\"18610822189\",\"Pwd\":\"40C1BE3DAA20EF74\",\"MemberType\":1,\"Mobile\":\"18610822189\",\"CNName\":\"18610822189\",\"ENName\":\"\",\"Sex\":\"\",\"Age\":0,\"Birthday\":\"\\/Date(-2209017600000)\\/\",\"Address\":\"\",\"ProvinceId\":0,\"CityId\":0,\"Logo\":\"\",\"QQ\":\"\",\"LearningGoal\":\"\",\"LearningTarget\":\"\",\"LearningTime\":\"\",\"HowKnow\":\"\",\"CreateTime\":\"\\/Date(1447930978930)\\/\",\"Enabled\":0,\"EmailValid\":0,\"MobileValid\":0,\"Score\":0,\"Ispay\":0,\"RegistrationID\":\"wrewrdwer23243234\",\"CountryId\":0,\"NickName\":\"\",\"ProvinceName\":\"\",\"CityName\":\"\",\"MemberTypeName\":\"学员\"}"}
        /// </summary>
        public static string LoginUrl { get { return SsoUrl + "/Auth/Login"; } }

        /// <summary>
        /// 获取智能约课时间地址
        /// 参数1-按时间提交预约：{"MemberId":"46","CourseId":"1015","ClassId":"1032","BookDate":"2015-12-12","BeginTime":"10:00","CourseCount":1,"TeacherIds":"1,5,6"}
        /// 结果：{"Result":[{"Code":1,"Message":"预约成功"}],"Data":null}
        /// </summary>
        public static string CapacityUrl { get { return SsoUrl + "/CourseBook/GetCourseBookValidTimes"; } }

        /// <summary>
        /// 提交约课服务地址
        /// 参数1-按时间提交预约：{"MemberId":"46","CourseId":"1015","ClassId":"1032","BookDate":"2015-12-12","BeginTime":"10:00","CourseCount":1,"TeacherIds":"1,5,6"}
        /// 结果：{"Result":[{"Code":1,"Message":"预约成功"}],"Data":null}
        /// </summary>
        public static string CommitCapacityUrl { get { return SsoUrl + "/CourseBook/CourseBook"; } }

        /// <summary>
        /// 参数：{"MemberId":"46","ClassId":"1032","CourseId":"1015"}
        ///结果：{"Result":[{"Code":1,"Message":"加入成功，请准时上课!"}],"Data":null}
        /// </summary>
        public static string CommitMultiCapacityUrl { get { return SsoUrl + "/CourseBook/JoinClassCourse"; } }

        /// <summary>
        /// 取消约课服务地址
        /// 参数1：取消预约-{"CplId":38}
        /// 结果：{"Result":[{"Code":1,"Message":"取消预约成功"}],"Data":null}
        /// </summary>
        public static string CancelOrderUrl { get { return SsoUrl + "/CourseBook/CourseBookCancel"; } }

        /// <summary>
        /// 加入课程服务地址
        /// 参数：{"MemberId":"46","ClassId":"1032","CplId":"1015"}
        /// 结果：{"Result":[{"Code":1,"Message":"加入成功，请准时上课!"}],"Data":null}
        /// </summary>
        public static string AddtoCourseUrl { get { return SsoUrl + "/CourseBook/JoinClassCourse"; } }


        /// <summary>
        /// 获取课件信息
        /// 参数：{"CplId":"1015"}
        /// </summary>
        public static string LessonAccessoryUrl
        {
            get { return SsoUrl + "/Class/GetMyLessonAccessory"; }
        }

        /// <summary>
        /// 获取视频列表信息
        /// 参数：{"CplId":"1015"}
        /// </summary>
        public static string VideoAccessoryUrl
        {
            get { return SsoUrl + "/Class/GetMyLessonVideo"; }
        }
        /// <summary>
        /// 系统根目录
        /// </summary>
        public static string RootPath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        /// <summary>
        /// 直播地址
        /// </summary>
        /// 参数： {\"CourseType\":0,\"CplId\":1}
        public static string VideoUrl
        {
            get
            {
                return SsoUrl + "/Class/GetMyLessonVideo";
            }
        }

        public static MemberDto GetCurrentUser(HttpContextBase context)
        {
            var cookie = context.Request.Cookies.Get("logininfo");

            return cookie == null ? null : JsonConvert.DeserializeObject<MemberDto>(HttpUtility.UrlDecode(Common.DesEncrypt(cookie.Value), Encoding.GetEncoding("UTF-8")));
        }

        public static string GetDistanceInfo(string url, string param)
        {
            Uri uri = new Uri(url);
            WebRequest web = HttpWebRequest.Create(uri);
            web.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            web.ContentType = "application/json";
            web.ContentLength = byteArray.Length;
            Stream dataStream = web.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            try
            {
                string result = new StreamReader(web.GetResponse().GetResponseStream()).ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {
                DataBase.DbHelperSQL.WriteLog(string.Format("调用接口服务{0}失败，参数：{1}", url, param), ex);
                return "{\"Data\":\"\",\"Result\":[]}";
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            return PassWordEncrypt.DesEncryptMethod(text);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DesEncrypt(string text)
        {
            return PassWordEncrypt.DesDecryptMethod(text);
        }
    }

    /// <summary>
    /// 支付配置
    /// </summary>
    public sealed class PayConfig
    {
        public class Union
        {
            public static string MemberId { get { return Common.GetConfigValue("UnionMemberId"); } }
            public static string SecurityKey { get { return Common.GetConfigValue("UnionMemberId"); } }
            public static string MemberAbbr { get { return Common.GetConfigValue("UnionMemberId"); } }
            public static string CommodityName { get { return Common.GetConfigValue("UnionMemberId"); } }
        }

        public class Aop
        {
            public static string AlipayPartner { get { return Common.GetConfigValue("AopAlipayPartner"); } }

            public static string AlipayKey { get { return Common.GetConfigValue("AopAlipayKey"); } }

            public static string AlipayOrderTitle { get { return Common.GetConfigValue("AopAlipayOrderTitle"); } }
        }
    }

    public sealed class DES
    {
        private string iv = "";
        private string key = "";

        public string Decrypt(string encryptedString)
        {
            string str;
            byte[] rgbKey = this.Encoder(this.key);
            byte[] rgbIV = this.Encoder(this.iv);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] buffer = Convert.FromBase64String(encryptedString);
                try
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                    {
                        stream2.Write(buffer, 0, buffer.Length);
                        stream2.FlushFinalBlock();
                    }
                    str = Encoding.UTF8.GetString(stream.ToArray());
                }
                catch
                {
                    throw;
                }
            }
            return str;
        }

        public void DecryptFile(string sourceFile)
        {
            this.DecryptFile(sourceFile, sourceFile);
        }

        public void DecryptFile(string sourceFile, string destFile)
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException("指定的文件路径不存在！", sourceFile);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(this.key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(this.iv);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] buffer = File.ReadAllBytes(sourceFile);
            using (FileStream stream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write))
                    {
                        stream2.Write(buffer, 0, buffer.Length);
                        stream2.FlushFinalBlock();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    stream.Close();
                }
            }
        }

        private byte[] Encoder(string key)
        {
            int num;
            byte[] bytes = Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0");
            byte[] buffer2 = Encoding.UTF8.GetBytes(key);
            if (buffer2.Length > 8)
            {
                for (num = 0; num < 8; num++)
                {
                    bytes[num] = buffer2[num];
                }
                return bytes;
            }
            for (num = 0; num < buffer2.Length; num++)
            {
                bytes[num] = buffer2[num];
            }
            return bytes;
        }

        public string Encrypt(string sourceString)
        {
            string str;
            byte[] rgbKey = this.Encoder(this.key);
            byte[] rgbIV = this.Encoder(this.iv);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(sourceString);
                try
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                    {
                        stream2.Write(bytes, 0, bytes.Length);
                        stream2.FlushFinalBlock();
                    }
                    str = Convert.ToBase64String(stream.ToArray());
                }
                catch
                {
                    throw;
                }
            }
            return str;
        }

        public void EncryptFile(string sourceFile)
        {
            this.EncryptFile(sourceFile, sourceFile);
        }

        public void EncryptFile(string sourceFile, string destFile)
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException("指定的文件路径不存在！", sourceFile);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(this.key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(this.iv);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] buffer = File.ReadAllBytes(sourceFile);
            using (FileStream stream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write))
                    {
                        stream2.Write(buffer, 0, buffer.Length);
                        stream2.FlushFinalBlock();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    stream.Close();
                }
            }
        }

        public string IV
        {
            get
            {
                return this.iv;
            }
            set
            {
                this.iv = value;
            }
        }

        public string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }
    }

    static internal class PassWordEncrypt
    {
        public static string InvalidPassword = "$P@ssw0rd";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static string DesEncryptMethod(string rs)
        {
            var desKey = new byte[] { 0x10, 0x11, 0x12, 0x04, 0x07, 0x09, 0x03, 0x08 };
            var desIV = new byte[] { 0x10, 0x11, 0x12, 0x04, 0x07, 0x09, 0x03, 0x08 };

            var des = new DESCryptoServiceProvider();
            try
            {
                byte[] inputByteArray = Encoding.Default.GetBytes(rs);
                des.Key = desKey;
                des.IV = desIV;
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                var ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();
            }
            catch
            {
                return rs;
            }
            finally
            {
                des = null;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static string DesDecryptMethod(string rs)
        {
            if (string.IsNullOrEmpty(rs))
                return InvalidPassword;
            var desKey = new byte[] { 0x10, 0x11, 0x12, 0x04, 0x07, 0x09, 0x03, 0x08 };
            var desIV = new byte[] { 0x10, 0x11, 0x12, 0x04, 0x07, 0x09, 0x03, 0x08 };

            var des = new DESCryptoServiceProvider();
            try
            {
                byte[] inputByteArray = new byte[rs.Length / 2];
                for (int x = 0; x < rs.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(rs.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = desKey;
                des.IV = desIV;
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                var ret = new StringBuilder();

                return Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return InvalidPassword;
            }
            finally
            {
                des = null;
            }
        }
    }
}