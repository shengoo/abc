using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DataBase
{
    public class DbHelperSQL
    {
        public static string connectionString { get; set; }

        public static int GetMaxID(string tableName, string column)
        {
            return (int)DbHelperSQL.GetSingleValue("select isnull(max(" + column + "),0) from " + tableName);
        }

        public static T MapRow<T>(SqlDataReader dr) where T : new()
        {
            var obj = new T();
            for (var i = 0; i < dr.FieldCount; i++)
            {
                DynamicVisitor<T>.Instance.SetValue(obj, dr.GetName(i), dr.GetValue(i));
            }
            return obj;
        }

        /// <summary>
        /// 执行SQL语句，返回影响结果数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExcuteNonquery(string sql)
        {
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    result = new SqlCommand(sql, cn).ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 执行SQL语句，返回第一个值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleValue(string sql, params object[] parameters)
        {
            object result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    var cmd = new SqlCommand(sql, cn);
                    if (parameters != null)
                    {
                        for (var i = 0; i < parameters.Length; i++)
                        {
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@" + i, Value = parameters[i], DbType = GetSqlType(parameters[i].GetType().Name) });
                        }
                    }

                    result = cmd.ExecuteScalar();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 读取数据库表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExcuteDataTable(string sql)
        {
            DataTable result = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    new SqlDataAdapter(new SqlCommand(sql, cn)).Fill(result);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
            }
            return result;
        }

        public static List<T> ExcuteScaler<T>(string sql, params object[] parameters) where T : new()
        {
            List<T> result = new List<T>();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    if (parameters != null)
                    {
                        for (var i = 0; i < parameters.Length; i++)
                        {
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@" + i, Value = parameters[i], DbType = GetSqlType(parameters[i].GetType().Name) });
                        }
                    }
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.HasRows)
                    {

                        while (!dr.IsClosed && dr.Read())
                        {
                            result.Add(MapRow<T>(dr));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行语句,适用于文件流类信息保存
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public static int ExcuteNonquery(string sql, params object[] parameters)
        {
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        if (parameters != null)
                        {
                            for (var i = 0; i < parameters.Length; i++)
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@" + i,
                                    Value = parameters[i]
                                });
                        }
                        result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
                throw ex;
            }
            return result;
        }


        public static int ExcuteNonquery(string sql, List<object> parameters)
        {
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        if (parameters != null)
                        {
                            for (var i = 0; i < parameters.Count; i++)
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@" + i,
                                    Value = parameters[i]
                                });
                        }
                        result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
                throw ex;
            }
            return result;
        }


        /// <summary>
        /// 批量执行语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public static int BatchExcuteNonquery(string sql, object[] sqlparam)
        {
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    SqlTransaction ts = cn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.Transaction = ts;
                        try
                        {
                            cmd.CommandText = sql;
                            foreach (object param in sqlparam)
                            {
                                cmd.Parameters.Clear();
                                var arr = param as List<object>;
                                if (arr != null)
                                {
                                    for (var i = 0; i < arr.Count; i++)
                                    {
                                        cmd.Parameters.Add(new SqlParameter
                                        {
                                            ParameterName = "@" + i,
                                            Value = arr[i],
                                            DbType = GetSqlType(arr[i].GetType().Name)
                                        });
                                    }
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter
                                    {
                                        ParameterName = "@0",
                                        Value = param,
                                        DbType = GetSqlType(param.GetType().Name)
                                    });
                                }
                                result += cmd.ExecuteNonQuery();
                            }
                            ts.Commit();
                            cmd.Dispose();
                        }
                        catch (Exception ex)
                        {
                            ts.Rollback();
                            result = 0;
                            WriteLog("批量执行sql语句异常", ex);
                            throw ex;
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("批量执行sql语句异常", ex);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void WriteLog(string message, Exception ex)
        {
            using (FileStream fs = new FileStream(GetLogPath(), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.Position = fs.Length;
                    StreamWriter sw = new System.IO.StreamWriter(fs);
                    sw.Write("\r\n" + DateTime.Now.ToString("HH:mm:ss") + " " + message);
                    if (ex != new Exception() && ex != default(Exception))
                    {
                        sw.Write("\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                    }
                    sw.Flush();
                    sw.Dispose();
                    fs.Close();
                }
            }
        }
        private static string GetLogPath()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory.ToString() + "/Log/");
            if (!dir.Exists) dir.Create();
            if (dir.GetDirectories(DateTime.Now.ToString("yyyyMM"), SearchOption.TopDirectoryOnly).Length == 0)
                dir.CreateSubdirectory(DateTime.Now.ToString("yyyyMM"));
            return AppDomain.CurrentDomain.BaseDirectory.ToString() + "/Log/" + DateTime.Now.ToString("yyyyMM") + "/log_" + DateTime.Now.ToString("dd") + ".log";
        }

        public static bool Exists(string sql, params object[] parameters)
        {
            object result = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        if (parameters != null)
                        {
                            for (var i = 0; i < parameters.Length; i++)
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@" + i,
                                    Value = parameters[i],
                                    DbType = GetSqlType(parameters[i].GetType().Name)
                                });
                        }
                        result = cmd.ExecuteScalar();
                        cmd.Dispose();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
            }
            return result != null;
        }

        public static object GetSingle(string sql, params object[] parameters)
        {
            object result = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        if (parameters != null)
                        {
                            for (var i = 0; i < parameters.Length; i++)
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@" + i,
                                    Value = parameters[i],
                                    DbType = GetSqlType(parameters[i].GetType().Name)
                                });
                        }
                        result = cmd.ExecuteScalar();
                        cmd.Dispose();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
                throw ex;
            }
            return result;
        }

        public static int ExecuteSql(string sql, params object[] parameters)
        {
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        if (parameters != null)
                        {
                            for (var i = 0; i < parameters.Length; i++)
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@" + i,
                                    Value = parameters[i],
                                    DbType = GetSqlType(parameters[i].GetType().Name)
                                });
                        }
                        result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
                throw ex;
            }
            return result;
        }

        public static DataSet Query(string sql, params object[] parameters)
        {
            DataSet result = new DataSet();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        if (parameters != null)
                        {
                            for (var i = 0; i < parameters.Length; i++)
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@" + i,
                                    Value = parameters[i],
                                    DbType = GetSqlType(parameters[i].GetType().Name)
                                });
                        }
                        new SqlDataAdapter(cmd).Fill(result);
                        cmd.Dispose();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("执行SQL语句:" + sql, ex);
                throw ex;
            }
            return result;
        }

        public static DbType GetSqlType(string typeName)
        {
            switch (typeName)
            {
                case "String":
                    return DbType.String;
                case "Int":
                case "Int32":
                    return DbType.Int32;
                case "Decimal":
                    return DbType.Decimal;
                case "DateTime":
                    return DbType.DateTime;
                default:
                    return DbType.String;
            }
        }

        public static List<T> ExcuteProcedure<T>(string procedure, Dictionary<string, object> parameters) where T : new()
        {
            List<T> result = new List<T>();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    if (parameters != null)
                    {
                        foreach (var kvp in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter { ParameterName = kvp.Key, Value = kvp.Value, DbType = GetSqlType(kvp.Value.GetType().Name) });
                        }
                    }
                    cmd.CommandText = procedure;
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.HasRows)
                    {
                        while (!dr.IsClosed && dr.Read())
                        {
                            result.Add(MapRow<T>(dr));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("调用存储过程失败:" + procedure, ex);
                throw ex;
            }
            return result;
        }
    }


    public class DynamicVisitor<TResult>
    {
        private static string tableName;
        private static Dictionary<string, PropertyInfo> attrs = new Dictionary<string, PropertyInfo>();
        private static DynamicVisitor<TResult> dynamicVisitor = null;
        private static readonly object lockHelper = new object();
        public static DynamicVisitor<TResult> Instance
        {
            get
            {
                //单例模式
                if (dynamicVisitor == null)
                {
                    lock (lockHelper)
                    {
                        if (dynamicVisitor == null)
                        {
                            dynamicVisitor = new DynamicVisitor<TResult>();
                        }
                    }
                }
                return dynamicVisitor;
            }
        }

        private Type _type;
        public DynamicVisitor()
        {
            _type = typeof(TResult);
            foreach (var pi in _type.GetProperties())
            {
                attrs.Add(pi.Name.ToLower(), pi);
            }
            var ta = _type.GetCustomAttributes(true).OfType<TableAttribute>().FirstOrDefault();
            tableName = ta == null ? _type.Name : ta.TableName;
            dynamicVisitor = this;
        }

        public string GetTableName() { return tableName; }


        public object GetValue(TResult instance, string column)
        {
            return attrs[column.ToLower()].GetValue(instance, null);
        }

        /// <summary>
        /// 通过aliasname 或 propertyname 给instance赋值
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public void SetValue(TResult instance, string column, object value)
        {
            if (attrs.ContainsKey(column.ToLower()))
            {
                if (value == DBNull.Value) value = null;
                if (attrs[column.ToLower()].PropertyType.Name == "Boolean")
                {
                    attrs[column.ToLower()].SetValue(instance, (int)value == 0, null);
                }
                else
                {
                    attrs[column.ToLower()].SetValue(instance, value, null);
                }
            }
        }
    }
}
