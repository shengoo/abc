/**  版本信息模板在安装目录下，可自行修改。
* Module.cs
*
* 功 能： N/A
* 类 名： Module
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:58   N/A    初版
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
	/// 数据访问类:Module
	/// </summary>
	public partial class Module:IModule
	{
		public Module()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ModuleId", "Module"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Module,int ModuleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Module");
			strSql.Append(" where Module=SQL2012Module and ModuleId=SQL2012ModuleId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Module", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012ModuleId", SqlDbType.Int,4)			};
			parameters[0].Value = Module;
			parameters[1].Value = ModuleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.Module model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Module(");
			strSql.Append("Module,ParentId,Level,Controller,ModuleType,OrderBy)");
			strSql.Append(" values (");
			strSql.Append("SQL2012Module,SQL2012ParentId,SQL2012Level,SQL2012Controller,SQL2012ModuleType,SQL2012OrderBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Module", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012ParentId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Level", SqlDbType.Int,4),
					new SqlParameter("SQL2012Controller", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012ModuleType", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012OrderBy", SqlDbType.Int,4)};
			parameters[0].Value = model.Module;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.Level;
			parameters[3].Value = model.Controller;
			parameters[4].Value = model.ModuleType;
			parameters[5].Value = model.OrderBy;

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
		public bool Update(abc.Model.Model.Module model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Module set ");
			strSql.Append("ParentId=SQL2012ParentId,");
			strSql.Append("Level=SQL2012Level,");
			strSql.Append("Controller=SQL2012Controller,");
			strSql.Append("ModuleType=SQL2012ModuleType,");
			strSql.Append("OrderBy=SQL2012OrderBy");
			strSql.Append(" where ModuleId=SQL2012ModuleId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ParentId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Level", SqlDbType.Int,4),
					new SqlParameter("SQL2012Controller", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012ModuleType", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012OrderBy", SqlDbType.Int,4),
					new SqlParameter("SQL2012ModuleId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module", SqlDbType.VarChar,255)};
			parameters[0].Value = model.ParentId;
			parameters[1].Value = model.Level;
			parameters[2].Value = model.Controller;
			parameters[3].Value = model.ModuleType;
			parameters[4].Value = model.OrderBy;
			parameters[5].Value = model.ModuleId;
			parameters[6].Value = model.Module;

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
		public bool Delete(int ModuleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Module ");
			strSql.Append(" where ModuleId=SQL2012ModuleId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ModuleId", SqlDbType.Int,4)
			};
			parameters[0].Value = ModuleId;

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
		public bool Delete(string Module,int ModuleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Module ");
			strSql.Append(" where Module=SQL2012Module and ModuleId=SQL2012ModuleId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Module", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012ModuleId", SqlDbType.Int,4)			};
			parameters[0].Value = Module;
			parameters[1].Value = ModuleId;

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
		public bool DeleteList(string ModuleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Module ");
			strSql.Append(" where ModuleId in ("+ModuleIdlist + ")  ");
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
		public abc.Model.Model.Module GetModel(int ModuleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ModuleId,Module,ParentId,Level,Controller,ModuleType,OrderBy from Module ");
			strSql.Append(" where ModuleId=SQL2012ModuleId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ModuleId", SqlDbType.Int,4)
			};
			parameters[0].Value = ModuleId;

			abc.Model.Model.Module model=new abc.Model.Model.Module();
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
		public abc.Model.Model.Module DataRowToModel(DataRow row)
		{
			abc.Model.Model.Module model=new abc.Model.Model.Module();
			if (row != null)
			{
				if(row["ModuleId"]!=null && row["ModuleId"].ToString()!="")
				{
					model.ModuleId=int.Parse(row["ModuleId"].ToString());
				}
				if(row["Module"]!=null)
				{
					model.Module=row["Module"].ToString();
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(row["ParentId"].ToString());
				}
				if(row["Level"]!=null && row["Level"].ToString()!="")
				{
					model.Level=int.Parse(row["Level"].ToString());
				}
				if(row["Controller"]!=null)
				{
					model.Controller=row["Controller"].ToString();
				}
				if(row["ModuleType"]!=null)
				{
					model.ModuleType=row["ModuleType"].ToString();
				}
				if(row["OrderBy"]!=null && row["OrderBy"].ToString()!="")
				{
					model.OrderBy=int.Parse(row["OrderBy"].ToString());
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
			strSql.Append("select ModuleId,Module,ParentId,Level,Controller,ModuleType,OrderBy ");
			strSql.Append(" FROM Module ");
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
			strSql.Append(" ModuleId,Module,ParentId,Level,Controller,ModuleType,OrderBy ");
			strSql.Append(" FROM Module ");
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
			strSql.Append("select count(1) FROM Module ");
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
				strSql.Append("order by T.ModuleId desc");
			}
			strSql.Append(")AS Row, T.*  from Module T ");
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
			parameters[0].Value = "Module";
			parameters[1].Value = "ModuleId";
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

