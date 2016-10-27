using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class ModelBase
    {
        public string ToJsonString()
        {
            Type dataClass = this.GetType();
            PropertyInfo[] pi = dataClass.GetProperties();
            System.Text.StringBuilder json = new System.Text.StringBuilder();
            json.Append("{");
            foreach (PropertyInfo p in pi)
                json.Append(p.Name).Append(":'").Append(p.GetValue(this, null)).Append("',");
            if (pi.Length > 0)
                json.Remove(json.Length - 1, 1);
            json.Append("}");
            return json.ToString();
        }
        public string ToXmlString()
        {
            Type dataClass = this.GetType();
            PropertyInfo[] pi = dataClass.GetProperties();
            System.Text.StringBuilder Xml = new System.Text.StringBuilder();
            Xml.Append("<").Append(dataClass.Name).Append(">");
            foreach (PropertyInfo p in pi)
                Xml.Append("<").Append(p.Name).Append(">").Append(p.GetValue(this, null)).Append("</").Append(p.Name).Append(">");
            Xml.Append("</").Append(dataClass.Name).Append(">");
            return Xml.ToString();
        }

        public List<T> GetModels<T>(string where) where T : new()
        {
            return DbHelperSQL.ExcuteScaler<T>("select * from " + typeof(T).Name + (string.IsNullOrEmpty(where) ? "" : " where " + where));
        }
    }
}
