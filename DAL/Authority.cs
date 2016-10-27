/**  版本信息模板在安装目录下，可自行修改。
* Authority.cs
*
* 功 能： N/A
* 类 名： Authority
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:42   N/A    初版
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
	/// 数据访问类:Authority
	/// </summary>
	public partial class Authority:IAuthority
	{
		public Authority()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AuthorityId", "Authority"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AuthorityId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Authority");
			strSql.Append(" where AuthorityId=SQL2012AuthorityId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AuthorityId", SqlDbType.Int,4)
			};
			parameters[0].Value = AuthorityId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.Authority model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Authority(");
			strSql.Append("RoleId,SourceId,Authority)");
			strSql.Append(" values (");
			strSql.Append("SQL2012RoleId,SQL2012SourceId,SQL2012Authority)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012RoleId", SqlDbType.Int,4),
					new SqlParameter("SQL2012SourceId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Authority", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.RoleId;
			parameters[1].Value = model.SourceId;
			parameters[2].Value = model.Authority;

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
		public bool Update(abc.Model.Model.Authority model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Authority set ");
			strSql.Append("RoleId=SQL2012RoleId,");
			strSql.Append("SourceId=SQL2012SourceId,");
			strSql.Append("Authority=SQL2012Authority");
			strSql.Append(" where AuthorityId=SQL2012AuthorityId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012RoleId", SqlDbType.Int,4),
					new SqlParameter("SQL2012SourceId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Authority", SqlDbType.VarChar,1000),
					new SqlParameter("SQL2012AuthorityId", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleId;
			parameters[1].Value = model.SourceId;
			parameters[2].Value = model.Authority;
			parameters[3].Value = model.AuthorityId;

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
		public bool Delete(int AuthorityId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Authority ");
			strSql.Append(" where AuthorityId=SQL2012AuthorityId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AuthorityId", SqlDbType.Int,4)
			};
			parameters[0].Value = AuthorityId;

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
		public bool DeleteList(string AuthorityIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Authority ");
			strSql.Append(" where AuthorityId in ("+AuthorityIdlist + ")  ");
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
		public abc.Model.Model.Authority GetModel(int AuthorityId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AuthorityId,RoleId,SourceId,Authority from Authority ");
			strSql.Append(" where AuthorityId=SQL2012AuthorityId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AuthorityId", SqlDbType.Int,4)
			};
			parameters[0].Value = AuthorityId;

			abc.Model.Model.Authority model=new abc.Model.Model.Authority();
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
		public abc.Model.Model.Authority DataRowToModel(DataRow row)
		{
			abc.Model.Model.Authority model=new abc.Model.Model.Authority();
			if (row != null)
			{
				if(row["AuthorityId"]!=null && row["AuthorityId"].ToString()!="")
				{
					model.AuthorityId=int.Parse(row["AuthorityId"].ToString());
				}
				if(row["RoleId"]!=null && row["RoleId"].ToString()!="")
				{
					model.RoleId=int.Parse(row["RoleId"].ToString());
				}
				if(row["SourceId"]!=null && row["SourceId"].ToString()!="")
				{
					model.SourceId=int.Parse(row["SourceId"].ToString());
				}
				if(row["Authority"]!=null)
				{
					model.Authority=row["Authority"].ToString();
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
			strSql.Append("select AuthorityId,RoleId,SourceId,Authority ");
			strSql.Append(" FROM Authority ");
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
			strSql.Append(" AuthorityId,RoleId,SourceId,Authority ");
			strSql.Append(" FROM Authority ");
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
			strSql.Append("select count(1) FROM Authority ");
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
				strSql.Append("order by T.AuthorityId desc");
			}
			strSql.Append(")AS Row, T.*  from Authority T ");
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
			parameters[0].Value = "Authority";
			parameters[1].Value = "AuthorityId";
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

