using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using DataBase;

namespace DAL
{
    /// <summary>
    /// 数据访问类:Course
    /// </summary>
    public partial class CourseDao
    {
        public CourseDao()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("CourseType", "Course");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CourseType, int CourseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Course");
            strSql.Append(" where CourseType=SQL2012CourseType and CourseId=SQL2012CourseId ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseType", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4)			};
            parameters[0].Value = CourseType;
            parameters[1].Value = CourseId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Course(");
            strSql.Append("CourseType,CnName,EnName,About,Goals,Clength,PicUrl,VideoUrl,IsFree,ExpiryDay,LessonNum,Enabled)");
            strSql.Append(" values (");
            strSql.Append("SQL2012CourseType,SQL2012CnName,SQL2012EnName,SQL2012About,SQL2012Goals,SQL2012Clength,SQL2012PicUrl,SQL2012VideoUrl,SQL2012IsFree,SQL2012ExpiryDay,SQL2012LessonNum,SQL2012Enabled)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseType", SqlDbType.Int,4),
					new SqlParameter("SQL2012CnName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012EnName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012About", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Goals", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Clength", SqlDbType.Int,4),
					new SqlParameter("SQL2012PicUrl", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012VideoUrl", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012IsFree", SqlDbType.Int,4),
					new SqlParameter("SQL2012ExpiryDay", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonNum", SqlDbType.Int,4),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseType;
            parameters[1].Value = model.CnName;
            parameters[2].Value = model.EnName;
            parameters[3].Value = model.About;
            parameters[4].Value = model.Goals;
            parameters[5].Value = model.Clength;
            parameters[6].Value = model.PicUrl;
            parameters[7].Value = model.VideoUrl;
            parameters[8].Value = model.IsFree;
            parameters[9].Value = model.ExpiryDay;
            parameters[10].Value = model.LessonNum;
            parameters[11].Value = model.Enabled;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Course set ");
            strSql.Append("CnName=SQL2012CnName,");
            strSql.Append("EnName=SQL2012EnName,");
            strSql.Append("About=SQL2012About,");
            strSql.Append("Goals=SQL2012Goals,");
            strSql.Append("Clength=SQL2012Clength,");
            strSql.Append("PicUrl=SQL2012PicUrl,");
            strSql.Append("VideoUrl=SQL2012VideoUrl,");
            strSql.Append("IsFree=SQL2012IsFree,");
            strSql.Append("ExpiryDay=SQL2012ExpiryDay,");
            strSql.Append("LessonNum=SQL2012LessonNum,");
            strSql.Append("Enabled=SQL2012Enabled");
            strSql.Append(" where CourseId=SQL2012CourseId");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012CnName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012EnName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012About", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Goals", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Clength", SqlDbType.Int,4),
					new SqlParameter("SQL2012PicUrl", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012VideoUrl", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012IsFree", SqlDbType.Int,4),
					new SqlParameter("SQL2012ExpiryDay", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonNum", SqlDbType.Int,4),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseType", SqlDbType.Int,4)};
            parameters[0].Value = model.CnName;
            parameters[1].Value = model.EnName;
            parameters[2].Value = model.About;
            parameters[3].Value = model.Goals;
            parameters[4].Value = model.Clength;
            parameters[5].Value = model.PicUrl;
            parameters[6].Value = model.VideoUrl;
            parameters[7].Value = model.IsFree;
            parameters[8].Value = model.ExpiryDay;
            parameters[9].Value = model.LessonNum;
            parameters[10].Value = model.Enabled;
            parameters[11].Value = model.CourseId;
            parameters[12].Value = model.CourseType;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CourseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Course ");
            strSql.Append(" where CourseId=SQL2012CourseId");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CourseType, int CourseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Course ");
            strSql.Append(" where CourseType=SQL2012CourseType and CourseId=SQL2012CourseId ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseType", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4)			};
            parameters[0].Value = CourseType;
            parameters[1].Value = CourseId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string CourseIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Course ");
            strSql.Append(" where CourseId in (" + CourseIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Course GetModel(int CourseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CourseId,CourseType,CnName,EnName,About,Goals,Clength,PicUrl,VideoUrl,IsFree,ExpiryDay,LessonNum,Enabled from Course ");
            strSql.Append(" where CourseId=SQL2012CourseId");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseId;

            Course model = new Course();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Course DataRowToModel(DataRow row)
        {
            Course model = new Course();
            if (row != null)
            {
                if (row["CourseId"] != null && row["CourseId"].ToString() != "")
                {
                    model.CourseId = int.Parse(row["CourseId"].ToString());
                }
                if (row["CourseType"] != null && row["CourseType"].ToString() != "")
                {
                    model.CourseType = int.Parse(row["CourseType"].ToString());
                }
                if (row["CnName"] != null)
                {
                    model.CnName = row["CnName"].ToString();
                }
                if (row["EnName"] != null)
                {
                    model.EnName = row["EnName"].ToString();
                }
                if (row["About"] != null)
                {
                    model.About = row["About"].ToString();
                }
                if (row["Goals"] != null)
                {
                    model.Goals = row["Goals"].ToString();
                }
                if (row["Clength"] != null && row["Clength"].ToString() != "")
                {
                    model.Clength = int.Parse(row["Clength"].ToString());
                }
                if (row["PicUrl"] != null)
                {
                    model.PicUrl = row["PicUrl"].ToString();
                }
                if (row["VideoUrl"] != null)
                {
                    model.VideoUrl = row["VideoUrl"].ToString();
                }
                if (row["IsFree"] != null && row["IsFree"].ToString() != "")
                {
                    model.IsFree = int.Parse(row["IsFree"].ToString());
                }
                if (row["ExpiryDay"] != null && row["ExpiryDay"].ToString() != "")
                {
                    model.ExpiryDay = int.Parse(row["ExpiryDay"].ToString());
                }
                if (row["LessonNum"] != null && row["LessonNum"].ToString() != "")
                {
                    model.LessonNum = int.Parse(row["LessonNum"].ToString());
                }
                if (row["Enabled"] != null && row["Enabled"].ToString() != "")
                {
                    model.Enabled = int.Parse(row["Enabled"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CourseId,CourseType,CnName,EnName,About,Goals,Clength,PicUrl,VideoUrl,IsFree,ExpiryDay,LessonNum,Enabled ");
            strSql.Append(" FROM Course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CourseId,CourseType,CnName,EnName,About,Goals,Clength,PicUrl,VideoUrl,IsFree,ExpiryDay,LessonNum,Enabled ");
            strSql.Append(" FROM Course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CourseId desc");
            }
            strSql.Append(")AS Row, T.*  from Course T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012PageSize", SqlDbType.Int),
                    new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
                    new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
                    new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
                    new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Course";
            parameters[1].Value = "CourseId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

