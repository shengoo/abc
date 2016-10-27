using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBase
{
    public class SingleTableDao<T> where T : new()
    {
        private T MapRow(SqlDataReader dr)
        {
            var map = new T();
            var properties = typeof(T).GetProperties();
            for (var i = 0; i < dr.FieldCount; i++)
            {
                properties.Where(t =>
                    {
                        return t.Name == dr.GetName(i);
                    }).First().SetValue(map, dr.GetValue(i), null);
            }
            return map;
        }

        private SqlConnection CreateConnection(string connectionString)
        {
            var conn= new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        private SqlCommand CreateComand(string sql, SqlConnection conn)
        {
            return new SqlCommand(sql, conn);
        }

        public List<T> Excute(string sql)
        {
            var res = new List<T>();
            var dr = CreateComand(sql, CreateConnection(DBHelperSQL.connectionString)).ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                res.Add(MapRow(dr));
            }
            return res;
        }
    }
}
