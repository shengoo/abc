﻿/**  版本信息模板在安装目录下，可自行修改。
* SMSTemplate.cs
*
* 功 能： N/A
* 类 名： SMSTemplate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:04   N/A    初版
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
	/// 数据访问类:SMSTemplate
	/// </summary>
	public partial class SMSTemplate:ISMSTemplate
	{
		public SMSTemplate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SmsId", "SMSTemplate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SmsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMSTemplate");
			strSql.Append(" where SmsId=SQL2012SmsId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012SmsId", SqlDbType.Int,4)
			};
			parameters[0].Value = SmsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.SMSTemplate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMSTemplate(");
			strSql.Append("Title,Subject,Content,SmsType,Enabled,CreateTime,Note)");
			strSql.Append(" values (");
			strSql.Append("SQL2012Title,SQL2012Subject,SQL2012Content,SQL2012SmsType,SQL2012Enabled,SQL2012CreateTime,SQL2012Note)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Title", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Subject", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012SmsType", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012Note", SqlDbType.VarChar,4000)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Subject;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.SmsType;
			parameters[4].Value = model.Enabled;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.Note;

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
		public bool Update(abc.Model.Model.SMSTemplate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMSTemplate set ");
			strSql.Append("Title=SQL2012Title,");
			strSql.Append("Subject=SQL2012Subject,");
			strSql.Append("Content=SQL2012Content,");
			strSql.Append("SmsType=SQL2012SmsType,");
			strSql.Append("Enabled=SQL2012Enabled,");
			strSql.Append("CreateTime=SQL2012CreateTime,");
			strSql.Append("Note=SQL2012Note");
			strSql.Append(" where SmsId=SQL2012SmsId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Title", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Subject", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012SmsType", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012Note", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012SmsId", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Subject;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.SmsType;
			parameters[4].Value = model.Enabled;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.Note;
			parameters[7].Value = model.SmsId;

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
		public bool Delete(int SmsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMSTemplate ");
			strSql.Append(" where SmsId=SQL2012SmsId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012SmsId", SqlDbType.Int,4)
			};
			parameters[0].Value = SmsId;

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
		public bool DeleteList(string SmsIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMSTemplate ");
			strSql.Append(" where SmsId in ("+SmsIdlist + ")  ");
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
		public abc.Model.Model.SMSTemplate GetModel(int SmsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SmsId,Title,Subject,Content,SmsType,Enabled,CreateTime,Note from SMSTemplate ");
			strSql.Append(" where SmsId=SQL2012SmsId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012SmsId", SqlDbType.Int,4)
			};
			parameters[0].Value = SmsId;

			abc.Model.Model.SMSTemplate model=new abc.Model.Model.SMSTemplate();
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
		public abc.Model.Model.SMSTemplate DataRowToModel(DataRow row)
		{
			abc.Model.Model.SMSTemplate model=new abc.Model.Model.SMSTemplate();
			if (row != null)
			{
				if(row["SmsId"]!=null && row["SmsId"].ToString()!="")
				{
					model.SmsId=int.Parse(row["SmsId"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Subject"]!=null)
				{
					model.Subject=row["Subject"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["SmsType"]!=null)
				{
					model.SmsType=row["SmsType"].ToString();
				}
				if(row["Enabled"]!=null && row["Enabled"].ToString()!="")
				{
					model.Enabled=int.Parse(row["Enabled"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
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
			strSql.Append("select SmsId,Title,Subject,Content,SmsType,Enabled,CreateTime,Note ");
			strSql.Append(" FROM SMSTemplate ");
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
			strSql.Append(" SmsId,Title,Subject,Content,SmsType,Enabled,CreateTime,Note ");
			strSql.Append(" FROM SMSTemplate ");
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
			strSql.Append("select count(1) FROM SMSTemplate ");
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
				strSql.Append("order by T.SmsId desc");
			}
			strSql.Append(")AS Row, T.*  from SMSTemplate T ");
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
			parameters[0].Value = "SMSTemplate";
			parameters[1].Value = "SmsId";
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

