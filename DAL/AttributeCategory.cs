/**  版本信息模板在安装目录下，可自行修改。
* AttributeCategory.cs
*
* 功 能： N/A
* 类 名： AttributeCategory
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:41   N/A    初版
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
	/// 数据访问类:AttributeCategory
	/// </summary>
	public partial class AttributeCategory:IAttributeCategory
	{
		public AttributeCategory()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AttrCateId", "AttributeCategory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AttrCateId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AttributeCategory");
			strSql.Append(" where AttrCateId=SQL2012AttrCateId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AttrCateId", SqlDbType.Int,4)
			};
			parameters[0].Value = AttrCateId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.AttributeCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AttributeCategory(");
			strSql.Append("CateName,Enabled,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("SQL2012CateName,SQL2012Enabled,SQL2012CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CateName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.CateName;
			parameters[1].Value = model.Enabled;
			parameters[2].Value = model.CreateTime;

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
		public bool Update(abc.Model.Model.AttributeCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AttributeCategory set ");
			strSql.Append("CateName=SQL2012CateName,");
			strSql.Append("Enabled=SQL2012Enabled,");
			strSql.Append("CreateTime=SQL2012CreateTime");
			strSql.Append(" where AttrCateId=SQL2012AttrCateId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CateName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012AttrCateId", SqlDbType.Int,4)};
			parameters[0].Value = model.CateName;
			parameters[1].Value = model.Enabled;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.AttrCateId;

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
		public bool Delete(int AttrCateId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AttributeCategory ");
			strSql.Append(" where AttrCateId=SQL2012AttrCateId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AttrCateId", SqlDbType.Int,4)
			};
			parameters[0].Value = AttrCateId;

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
		public bool DeleteList(string AttrCateIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AttributeCategory ");
			strSql.Append(" where AttrCateId in ("+AttrCateIdlist + ")  ");
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
		public abc.Model.Model.AttributeCategory GetModel(int AttrCateId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AttrCateId,CateName,Enabled,CreateTime from AttributeCategory ");
			strSql.Append(" where AttrCateId=SQL2012AttrCateId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AttrCateId", SqlDbType.Int,4)
			};
			parameters[0].Value = AttrCateId;

			abc.Model.Model.AttributeCategory model=new abc.Model.Model.AttributeCategory();
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
		public abc.Model.Model.AttributeCategory DataRowToModel(DataRow row)
		{
			abc.Model.Model.AttributeCategory model=new abc.Model.Model.AttributeCategory();
			if (row != null)
			{
				if(row["AttrCateId"]!=null && row["AttrCateId"].ToString()!="")
				{
					model.AttrCateId=int.Parse(row["AttrCateId"].ToString());
				}
				if(row["CateName"]!=null)
				{
					model.CateName=row["CateName"].ToString();
				}
				if(row["Enabled"]!=null && row["Enabled"].ToString()!="")
				{
					model.Enabled=int.Parse(row["Enabled"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select AttrCateId,CateName,Enabled,CreateTime ");
			strSql.Append(" FROM AttributeCategory ");
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
			strSql.Append(" AttrCateId,CateName,Enabled,CreateTime ");
			strSql.Append(" FROM AttributeCategory ");
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
			strSql.Append("select count(1) FROM AttributeCategory ");
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
				strSql.Append("order by T.AttrCateId desc");
			}
			strSql.Append(")AS Row, T.*  from AttributeCategory T ");
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
			parameters[0].Value = "AttributeCategory";
			parameters[1].Value = "AttrCateId";
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

