/**  版本信息模板在安装目录下，可自行修改。
* CourseAssign.cs
*
* 功 能： N/A
* 类 名： CourseAssign
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
	/// 数据访问类:CourseAssign
	/// </summary>
	public partial class CourseAssign:ICourseAssign
	{
		public CourseAssign()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CardId", "CourseAssign"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CardId,int CourseId,int AssignId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CourseAssign");
			strSql.Append(" where CardId=SQL2012CardId and CourseId=SQL2012CourseId and AssignId=SQL2012AssignId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CardId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012AssignId", SqlDbType.Int,4)			};
			parameters[0].Value = CardId;
			parameters[1].Value = CourseId;
			parameters[2].Value = AssignId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.CourseAssign model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CourseAssign(");
			strSql.Append("CardId,CourseId)");
			strSql.Append(" values (");
			strSql.Append("SQL2012CardId,SQL2012CourseId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CardId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4)};
			parameters[0].Value = model.CardId;
			parameters[1].Value = model.CourseId;

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
		public bool Update(abc.Model.Model.CourseAssign model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CourseAssign set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("AssignId=SQL2012AssignId,");
			strSql.Append("CardId=SQL2012CardId,");
			strSql.Append("CourseId=SQL2012CourseId");
			strSql.Append(" where AssignId=SQL2012AssignId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AssignId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CardId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4)};
			parameters[0].Value = model.AssignId;
			parameters[1].Value = model.CardId;
			parameters[2].Value = model.CourseId;

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
		public bool Delete(int AssignId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseAssign ");
			strSql.Append(" where AssignId=SQL2012AssignId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AssignId", SqlDbType.Int,4)
			};
			parameters[0].Value = AssignId;

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
		public bool Delete(int CardId,int CourseId,int AssignId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseAssign ");
			strSql.Append(" where CardId=SQL2012CardId and CourseId=SQL2012CourseId and AssignId=SQL2012AssignId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CardId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012AssignId", SqlDbType.Int,4)			};
			parameters[0].Value = CardId;
			parameters[1].Value = CourseId;
			parameters[2].Value = AssignId;

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
		public bool DeleteList(string AssignIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseAssign ");
			strSql.Append(" where AssignId in ("+AssignIdlist + ")  ");
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
		public abc.Model.Model.CourseAssign GetModel(int AssignId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AssignId,CardId,CourseId from CourseAssign ");
			strSql.Append(" where AssignId=SQL2012AssignId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AssignId", SqlDbType.Int,4)
			};
			parameters[0].Value = AssignId;

			abc.Model.Model.CourseAssign model=new abc.Model.Model.CourseAssign();
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
		public abc.Model.Model.CourseAssign DataRowToModel(DataRow row)
		{
			abc.Model.Model.CourseAssign model=new abc.Model.Model.CourseAssign();
			if (row != null)
			{
				if(row["AssignId"]!=null && row["AssignId"].ToString()!="")
				{
					model.AssignId=int.Parse(row["AssignId"].ToString());
				}
				if(row["CardId"]!=null && row["CardId"].ToString()!="")
				{
					model.CardId=int.Parse(row["CardId"].ToString());
				}
				if(row["CourseId"]!=null && row["CourseId"].ToString()!="")
				{
					model.CourseId=int.Parse(row["CourseId"].ToString());
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
			strSql.Append("select AssignId,CardId,CourseId ");
			strSql.Append(" FROM CourseAssign ");
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
			strSql.Append(" AssignId,CardId,CourseId ");
			strSql.Append(" FROM CourseAssign ");
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
			strSql.Append("select count(1) FROM CourseAssign ");
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
				strSql.Append("order by T.AssignId desc");
			}
			strSql.Append(")AS Row, T.*  from CourseAssign T ");
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
			parameters[0].Value = "CourseAssign";
			parameters[1].Value = "AssignId";
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

