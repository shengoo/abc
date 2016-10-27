using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBase;
using System.Reflection;

namespace DAL
{
    public class BaseModel<T> where T : new()
    {
        private Type type = typeof(T);

        public void Insert(T t, params string[] fields)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder pam = new StringBuilder();
            List<object> paramters = new List<object>();
            sql.Append("insert into ").Append(type.Name).Append("(");

            if (fields == null)
            {
                var i = 0;
                foreach (PropertyInfo pi in type.GetProperties())
                {
                    if (pam.Length != 0)
                    {
                        sql.Append(",");
                        pam.Append(",");
                    }
                    sql.Append(pi.Name);
                    pam.Append("@").Append(i++);
                    paramters.Add(pi.GetValue(t, null));
                }
            }
            else
            {
                sql.Append(fields[0]);
                pam.Append("@0");
                paramters.Add(type.GetProperty(fields[0]).GetValue(t, null));
                for (var i = 1; i < fields.Length; i++)
                {
                    sql.Append(",").Append(fields[i]);
                    pam.Append(",@").Append(i);
                    paramters.Add(type.GetProperty(fields[i]).GetValue(t, null));
                }
            }
            sql.Append(") values (").Append(pam).Append(")");
            DbHelperSQL.ExcuteNonquery(sql.ToString(), paramters.ToArray());
        }

        public void Update(T t, string[] wheres, params string[] fields)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder pam = new StringBuilder();
            List<object> paramters = new List<object>();
            sql.Append("update ").Append(type.Name).Append(" set ");

            if (fields == null)
            {
                var i = 0;
                foreach (PropertyInfo pi in type.GetProperties())
                {
                    sql.Append(i == 0 ? "" : ",").Append(pi.Name).Append("=@").Append(i++);
                    paramters.Add(pi.GetValue(t, null));
                }
                if (wheres.Length > 0) sql.Append(" where ");
                foreach (string where in wheres)
                {
                    sql.Append(where).Append("=@").Append(i++);
                    paramters.Add(type.GetProperty(where).GetValue(t, null));
                }
            }
            else
            {
                var i = 0;
                foreach (string field in fields)
                {
                    sql.Append(i == 0 ? "" : ",").Append(field).Append("=@").Append(i++);
                    paramters.Add(type.GetProperty(field).GetValue(t, null));
                }
                if (wheres.Length > 0) sql.Append(" where 1=1 ");
                foreach (string where in wheres)
                {
                    sql.Append(" and ").Append(where).Append("=@").Append(i++);
                    paramters.Add(type.GetProperty(where).GetValue(t, null));
                }
            }
            DbHelperSQL.ExcuteNonquery(sql.ToString(), paramters.ToArray());
        }

        public void Delete(T t, params string[] fieldName)
        {
            List<object> paramters = new List<object>();
            List<string> pa = new List<string>();
            int i = 0;
            foreach (string name in fieldName)
            {
                pa.Add(name + "=@" + i++);
                paramters.Add(type.GetProperty(name).GetValue(t, null));
            }
            DbHelperSQL.ExcuteNonquery("delete from " + type.Name + (fieldName.Length > 0 ? " where " + string.Join(" and ", pa) : "")
                , paramters);
        }

        public void Delete(string where, params object[] paramters)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from ").Append(type.Name).Append(string.IsNullOrEmpty(where) ? " where " + where : "");
            DbHelperSQL.ExcuteNonquery(sql.ToString(), paramters);
        }

        public void BatchDelete(List<T> models, params string[] fieldName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from ").Append(type.Name).Append(" where 1=1 ");

            List<List<object>> paramters = new List<List<object>>();
            foreach (T t in models)
            {
                var obj = new List<object>();
                foreach (string name in fieldName)
                {
                    obj.Add(type.GetProperty(name).GetValue(t, null));
                }
                paramters.Add(obj);
            }
            var i = 0;
            foreach (string name in fieldName)
            {
                sql.Append(" and " + name + "=@" + i);
                i++;
            }
            DbHelperSQL.BatchExcuteNonquery(sql.ToString(), paramters.ToArray());
        }

        public void BatchInsert(List<T> models, params string[] fields)
        {
            var sql = new StringBuilder();
            var paramters = new List<List<object>>();
            foreach (T t in models)
            {
                List<object> obj = new List<object>();
                if (fields == null) fields = type.GetProperties().Select(pi => pi.Name).ToArray();
                for (var i = 0; i < fields.Length; i++)
                {
                    obj.Add(type.GetProperty(fields[i]).GetValue(t, null));
                }
                paramters.Add(obj);
            }
            sql.Append("insert into ").Append(type.Name).Append("(").Append(fields[0]);
            var pam = new StringBuilder("@0");

            for (var j = 1; j < fields.Length; j++)
            {
                sql.Append("," + fields[j] + "");
                pam.Append(",@" + j);
            }
            sql.Append(") values (").Append(pam).Append(")");
            DbHelperSQL.BatchExcuteNonquery(sql.ToString(), paramters.ToArray());
        }

        public List<T> GetModels(string where, params object[] paramters)
        {
            return DbHelperSQL.ExcuteScaler<T>(CreateSqlBuilder(where), paramters);
        }

        public List<T> GetClassModels(string sql, params object[] paramters)
        {
            return DbHelperSQL.ExcuteScaler<T>(sql, paramters);
        }

        public int GetMaxId(string fieldName)
        {
            return DbHelperSQL.GetMaxID(type.Name, fieldName);
        }

        private string CreateSqlBuilder(string where)
        {
            return "select " + GetColumns() + " from " + typeof(T).Name + " " + (string.IsNullOrEmpty(where) ? "" : " where " + where);
        }

        public bool Exist(string where, params object[] paramters)
        {
            return DbHelperSQL.Exists("select count(1) from " + type.Name + (string.IsNullOrEmpty(where) ? "" : " where " + where), paramters);
        }

        private string GetColumns()
        {
            var column = new StringBuilder();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                column.Append(",").Append(pi.Name);
            }
            return column.Remove(0, 1).ToString();
        }
    }
}
