/**  版本信息模板在安装目录下，可自行修改。
* SysLog.cs
*
* 功 能： N/A
* 类 名： SysLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:06   N/A    初版
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
	/// 数据访问类:SysLog
	/// </summary>
	public partial class SysLog:ISysLog
	{
		public SysLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MemberId", "SysLog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MemberId,int LogId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SysLog");
			strSql.Append(" where MemberId=SQL2012MemberId and LogId=SQL2012LogId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012LogId", SqlDbType.Int,4)			};
			parameters[0].Value = MemberId;
			parameters[1].Value = LogId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.SysLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SysLog(");
			strSql.Append("MemberId,SysFrom,Module,Activity,Level,Content,CurrLoginIp,CurrLoginTime)");
			strSql.Append(" values (");
			strSql.Append("SQL2012MemberId,SQL2012SysFrom,SQL2012Module,SQL2012Activity,SQL2012Level,SQL2012Content,SQL2012CurrLoginIp,SQL2012CurrLoginTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012SysFrom", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Activity", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Level", SqlDbType.Int,4),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012CurrLoginIp", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012CurrLoginTime", SqlDbType.DateTime)};
			parameters[0].Value = model.MemberId;
			parameters[1].Value = model.SysFrom;
			parameters[2].Value = model.Module;
			parameters[3].Value = model.Activity;
			parameters[4].Value = model.Level;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.CurrLoginIp;
			parameters[7].Value = model.CurrLoginTime;

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
		public bool Update(abc.Model.Model.SysLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SysLog set ");
			strSql.Append("SysFrom=SQL2012SysFrom,");
			strSql.Append("Module=SQL2012Module,");
			strSql.Append("Activity=SQL2012Activity,");
			strSql.Append("Level=SQL2012Level,");
			strSql.Append("Content=SQL2012Content,");
			strSql.Append("CurrLoginIp=SQL2012CurrLoginIp,");
			strSql.Append("CurrLoginTime=SQL2012CurrLoginTime");
			strSql.Append(" where LogId=SQL2012LogId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012SysFrom", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Activity", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Level", SqlDbType.Int,4),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012CurrLoginIp", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012CurrLoginTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012LogId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4)};
			parameters[0].Value = model.SysFrom;
			parameters[1].Value = model.Module;
			parameters[2].Value = model.Activity;
			parameters[3].Value = model.Level;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.CurrLoginIp;
			parameters[6].Value = model.CurrLoginTime;
			parameters[7].Value = model.LogId;
			parameters[8].Value = model.MemberId;

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
		public bool Delete(int LogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysLog ");
			strSql.Append(" where LogId=SQL2012LogId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012LogId", SqlDbType.Int,4)
			};
			parameters[0].Value = LogId;

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
		public bool Delete(int MemberId,int LogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysLog ");
			strSql.Append(" where MemberId=SQL2012MemberId and LogId=SQL2012LogId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012LogId", SqlDbType.Int,4)			};
			parameters[0].Value = MemberId;
			parameters[1].Value = LogId;

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
		public bool DeleteList(string LogIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysLog ");
			strSql.Append(" where LogId in ("+LogIdlist + ")  ");
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
		public abc.Model.Model.SysLog GetModel(int LogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LogId,MemberId,SysFrom,Module,Activity,Level,Content,CurrLoginIp,CurrLoginTime from SysLog ");
			strSql.Append(" where LogId=SQL2012LogId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012LogId", SqlDbType.Int,4)
			};
			parameters[0].Value = LogId;

			abc.Model.Model.SysLog model=new abc.Model.Model.SysLog();
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
		public abc.Model.Model.SysLog DataRowToModel(DataRow row)
		{
			abc.Model.Model.SysLog model=new abc.Model.Model.SysLog();
			if (row != null)
			{
				if(row["LogId"]!=null && row["LogId"].ToString()!="")
				{
					model.LogId=int.Parse(row["LogId"].ToString());
				}
				if(row["MemberId"]!=null && row["MemberId"].ToString()!="")
				{
					model.MemberId=int.Parse(row["MemberId"].ToString());
				}
				if(row["SysFrom"]!=null && row["SysFrom"].ToString()!="")
				{
					model.SysFrom=int.Parse(row["SysFrom"].ToString());
				}
				if(row["Module"]!=null)
				{
					model.Module=row["Module"].ToString();
				}
				if(row["Activity"]!=null)
				{
					model.Activity=row["Activity"].ToString();
				}
				if(row["Level"]!=null && row["Level"].ToString()!="")
				{
					model.Level=int.Parse(row["Level"].ToString());
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["CurrLoginIp"]!=null)
				{
					model.CurrLoginIp=row["CurrLoginIp"].ToString();
				}
				if(row["CurrLoginTime"]!=null && row["CurrLoginTime"].ToString()!="")
				{
					model.CurrLoginTime=DateTime.Parse(row["CurrLoginTime"].ToString());
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
			strSql.Append("select LogId,MemberId,SysFrom,Module,Activity,Level,Content,CurrLoginIp,CurrLoginTime ");
			strSql.Append(" FROM SysLog ");
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
			strSql.Append(" LogId,MemberId,SysFrom,Module,Activity,Level,Content,CurrLoginIp,CurrLoginTime ");
			strSql.Append(" FROM SysLog ");
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
			strSql.Append("select count(1) FROM SysLog ");
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
				strSql.Append("order by T.LogId desc");
			}
			strSql.Append(")AS Row, T.*  from SysLog T ");
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
			parameters[0].Value = "SysLog";
			parameters[1].Value = "LogId";
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

