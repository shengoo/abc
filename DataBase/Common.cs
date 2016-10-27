using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Common
    {
        public static string SqlUpdate(string col, string val, string tableName, string where)
        {
            StringBuilder colval = new StringBuilder();
            for (int i = 0; i < col.Split(',').Length; i++)
                colval.Append(col.Split(',')[i]).Append("=").Append(val.Split(',')[i]).Append(",");
            return "update " + tableName + " set " + colval.ToString().Remove(colval.Length - 1) + " where 1=1 " + where;
        }
        public static string SqlInsert(string col, string val, string tableName)
        {
            return "insert into " + tableName + "(" + col + ") values (" + val + ")";
        }
        public static string SqlInsert(string val, string tableName)
        {
            return "insert into " + tableName + " values (" + val + ")";
        }
        public static string SqlInsertCopy(string sql, string tableName)
        {
            return "insert into " + tableName + " (" + sql + ")";
        }
        public static string SqlDelete(string tableName, string where)
        {
            return "delete from " + tableName + " where 1=1 " + where;
        }
        public static string SqlSelect(string col, string tableName, string where)
        {
            return "select " + col + " from " + tableName + " where " + where;
        }
        public static string SqlSelect(string col, string tableName)
        {
            return "select " + col + " from " + tableName;
        }
    }
}
