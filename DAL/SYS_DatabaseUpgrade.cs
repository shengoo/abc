/**  版本信息模板在安装目录下，可自行修改。
* SYS_DatabaseUpgrade.cs
*
* 功 能： N/A
* 类 名： SYS_DatabaseUpgrade
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:05   N/A    初版
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
	/// 数据访问类:SYS_DatabaseUpgrade
	/// </summary>
	public partial class SYS_DatabaseUpgrade:ISYS_DatabaseUpgrade
	{
		public SYS_DatabaseUpgrade()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FileName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SYS_DatabaseUpgrade");
			strSql.Append(" where FileName=SQL2012FileName ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileName", SqlDbType.VarChar,200)			};
			parameters[0].Value = FileName;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(abc.Model.Model.SYS_DatabaseUpgrade model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_DatabaseUpgrade(");
			strSql.Append("FileName,Line,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("SQL2012FileName,SQL2012Line,SQL2012UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileName", SqlDbType.VarChar,200),
					new SqlParameter("SQL2012Line", SqlDbType.Decimal,9),
					new SqlParameter("SQL2012UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.FileName;
			parameters[1].Value = model.Line;
			parameters[2].Value = model.UpdateTime;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(abc.Model.Model.SYS_DatabaseUpgrade model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_DatabaseUpgrade set ");
			strSql.Append("Line=SQL2012Line,");
			strSql.Append("UpdateTime=SQL2012UpdateTime");
			strSql.Append(" where FileName=SQL2012FileName ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Line", SqlDbType.Decimal,9),
					new SqlParameter("SQL2012UpdateTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012FileName", SqlDbType.VarChar,200)};
			parameters[0].Value = model.Line;
			parameters[1].Value = model.UpdateTime;
			parameters[2].Value = model.FileName;

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
		public bool Delete(string FileName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_DatabaseUpgrade ");
			strSql.Append(" where FileName=SQL2012FileName ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileName", SqlDbType.VarChar,200)			};
			parameters[0].Value = FileName;

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
		public bool DeleteList(string FileNamelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_DatabaseUpgrade ");
			strSql.Append(" where FileName in ("+FileNamelist + ")  ");
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
		public abc.Model.Model.SYS_DatabaseUpgrade GetModel(string FileName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FileName,Line,UpdateTime from SYS_DatabaseUpgrade ");
			strSql.Append(" where FileName=SQL2012FileName ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileName", SqlDbType.VarChar,200)			};
			parameters[0].Value = FileName;

			abc.Model.Model.SYS_DatabaseUpgrade model=new abc.Model.Model.SYS_DatabaseUpgrade();
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
		public abc.Model.Model.SYS_DatabaseUpgrade DataRowToModel(DataRow row)
		{
			abc.Model.Model.SYS_DatabaseUpgrade model=new abc.Model.Model.SYS_DatabaseUpgrade();
			if (row != null)
			{
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["Line"]!=null && row["Line"].ToString()!="")
				{
					model.Line=decimal.Parse(row["Line"].ToString());
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
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
			strSql.Append("select FileName,Line,UpdateTime ");
			strSql.Append(" FROM SYS_DatabaseUpgrade ");
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
			strSql.Append(" FileName,Line,UpdateTime ");
			strSql.Append(" FROM SYS_DatabaseUpgrade ");
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
			strSql.Append("select count(1) FROM SYS_DatabaseUpgrade ");
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
				strSql.Append("order by T.FileName desc");
			}
			strSql.Append(")AS Row, T.*  from SYS_DatabaseUpgrade T ");
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
			parameters[0].Value = "SYS_DatabaseUpgrade";
			parameters[1].Value = "FileName";
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

