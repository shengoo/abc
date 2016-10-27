/**  版本信息模板在安装目录下，可自行修改。
* CourseAccessory.cs
*
* 功 能： N/A
* 类 名： CourseAccessory
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:46   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using abc.Model.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace abc.Model.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:CourseAccessory
	/// </summary>
	public partial class CourseAccessory:ICourseAccessory
	{
		public CourseAccessory()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CourseId", "CourseAccessory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CourseId,int LessonId,int FileId,int AccessoryId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CourseAccessory");
			strSql.Append(" where CourseId=SQL2012CourseId and LessonId=SQL2012LessonId and FileId=SQL2012FileId and AccessoryId=SQL2012AccessoryId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4),
					new SqlParameter("SQL2012FileId", SqlDbType.Int,4),
					new SqlParameter("SQL2012AccessoryId", SqlDbType.Int,4)			};
			parameters[0].Value = CourseId;
			parameters[1].Value = LessonId;
			parameters[2].Value = FileId;
			parameters[3].Value = AccessoryId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.CourseAccessory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CourseAccessory(");
			strSql.Append("CourseId,LessonId,FileId)");
			strSql.Append(" values (");
			strSql.Append("SQL2012CourseId,SQL2012LessonId,SQL2012FileId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4),
					new SqlParameter("SQL2012FileId", SqlDbType.Int,4)};
			parameters[0].Value = model.CourseId;
			parameters[1].Value = model.LessonId;
			parameters[2].Value = model.FileId;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(abc.Model.Model.CourseAccessory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CourseAccessory set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("AccessoryId=SQL2012AccessoryId,");
			strSql.Append("CourseId=SQL2012CourseId,");
			strSql.Append("LessonId=SQL2012LessonId,");
			strSql.Append("FileId=SQL2012FileId");
			strSql.Append(" where AccessoryId=SQL2012AccessoryId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AccessoryId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4),
					new SqlParameter("SQL2012FileId", SqlDbType.Int,4)};
			parameters[0].Value = model.AccessoryId;
			parameters[1].Value = model.CourseId;
			parameters[2].Value = model.LessonId;
			parameters[3].Value = model.FileId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int AccessoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseAccessory ");
			strSql.Append(" where AccessoryId=SQL2012AccessoryId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AccessoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = AccessoryId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int CourseId,int LessonId,int FileId,int AccessoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseAccessory ");
			strSql.Append(" where CourseId=SQL2012CourseId and LessonId=SQL2012LessonId and FileId=SQL2012FileId and AccessoryId=SQL2012AccessoryId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4),
					new SqlParameter("SQL2012FileId", SqlDbType.Int,4),
					new SqlParameter("SQL2012AccessoryId", SqlDbType.Int,4)			};
			parameters[0].Value = CourseId;
			parameters[1].Value = LessonId;
			parameters[2].Value = FileId;
			parameters[3].Value = AccessoryId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string AccessoryIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseAccessory ");
			strSql.Append(" where AccessoryId in ("+AccessoryIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public abc.Model.Model.CourseAccessory GetModel(int AccessoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AccessoryId,CourseId,LessonId,FileId from CourseAccessory ");
			strSql.Append(" where AccessoryId=SQL2012AccessoryId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AccessoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = AccessoryId;

			abc.Model.Model.CourseAccessory model=new abc.Model.Model.CourseAccessory();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public abc.Model.Model.CourseAccessory DataRowToModel(DataRow row)
		{
			abc.Model.Model.CourseAccessory model=new abc.Model.Model.CourseAccessory();
			if (row != null)
			{
				if(row["AccessoryId"]!=null && row["AccessoryId"].ToString()!="")
				{
					model.AccessoryId=int.Parse(row["AccessoryId"].ToString());
				}
				if(row["CourseId"]!=null && row["CourseId"].ToString()!="")
				{
					model.CourseId=int.Parse(row["CourseId"].ToString());
				}
				if(row["LessonId"]!=null && row["LessonId"].ToString()!="")
				{
					model.LessonId=int.Parse(row["LessonId"].ToString());
				}
				if(row["FileId"]!=null && row["FileId"].ToString()!="")
				{
					model.FileId=int.Parse(row["FileId"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AccessoryId,CourseId,LessonId,FileId ");
			strSql.Append(" FROM CourseAccessory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" AccessoryId,CourseId,LessonId,FileId ");
			strSql.Append(" FROM CourseAccessory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM CourseAccessory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.AccessoryId desc");
			}
			strSql.Append(")AS Row, T.*  from CourseAccessory T ");
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
			parameters[0].Value = "CourseAccessory";
			parameters[1].Value = "AccessoryId";
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

