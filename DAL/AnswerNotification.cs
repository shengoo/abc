/**  版本信息模板在安装目录下，可自行修改。
* AnswerNotification.cs
*
* 功 能： N/A
* 类 名： AnswerNotification
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:39   N/A    初版
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
	/// 数据访问类:AnswerNotification
	/// </summary>
	public partial class AnswerNotification:IAnswerNotification
	{
		public AnswerNotification()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AskId", "AnswerNotification"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AskId,int MemberId,int NotifyId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AnswerNotification");
			strSql.Append(" where AskId=SQL2012AskId and MemberId=SQL2012MemberId and NotifyId=SQL2012NotifyId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AskId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012NotifyId", SqlDbType.Int,4)			};
			parameters[0].Value = AskId;
			parameters[1].Value = MemberId;
			parameters[2].Value = NotifyId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.AnswerNotification model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AnswerNotification(");
			strSql.Append("AskId,MemberId,TeacherId,Content,OrderBy,IsSend,SendDate,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("SQL2012AskId,SQL2012MemberId,SQL2012TeacherId,SQL2012Content,SQL2012OrderBy,SQL2012IsSend,SQL2012SendDate,SQL2012CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AskId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012TeacherId", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012OrderBy", SqlDbType.Int,4),
					new SqlParameter("SQL2012IsSend", SqlDbType.Int,4),
					new SqlParameter("SQL2012SendDate", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.AskId;
			parameters[1].Value = model.MemberId;
			parameters[2].Value = model.TeacherId;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.OrderBy;
			parameters[5].Value = model.IsSend;
			parameters[6].Value = model.SendDate;
			parameters[7].Value = model.CreateTime;

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
		public bool Update(abc.Model.Model.AnswerNotification model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AnswerNotification set ");
			strSql.Append("TeacherId=SQL2012TeacherId,");
			strSql.Append("Content=SQL2012Content,");
			strSql.Append("OrderBy=SQL2012OrderBy,");
			strSql.Append("IsSend=SQL2012IsSend,");
			strSql.Append("SendDate=SQL2012SendDate,");
			strSql.Append("CreateTime=SQL2012CreateTime");
			strSql.Append(" where NotifyId=SQL2012NotifyId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012TeacherId", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012OrderBy", SqlDbType.Int,4),
					new SqlParameter("SQL2012IsSend", SqlDbType.Int,4),
					new SqlParameter("SQL2012SendDate", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012NotifyId", SqlDbType.Int,4),
					new SqlParameter("SQL2012AskId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4)};
			parameters[0].Value = model.TeacherId;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.OrderBy;
			parameters[3].Value = model.IsSend;
			parameters[4].Value = model.SendDate;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.NotifyId;
			parameters[7].Value = model.AskId;
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
		public bool Delete(int NotifyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AnswerNotification ");
			strSql.Append(" where NotifyId=SQL2012NotifyId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012NotifyId", SqlDbType.Int,4)
			};
			parameters[0].Value = NotifyId;

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
		public bool Delete(int AskId,int MemberId,int NotifyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AnswerNotification ");
			strSql.Append(" where AskId=SQL2012AskId and MemberId=SQL2012MemberId and NotifyId=SQL2012NotifyId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012AskId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012NotifyId", SqlDbType.Int,4)			};
			parameters[0].Value = AskId;
			parameters[1].Value = MemberId;
			parameters[2].Value = NotifyId;

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
		public bool DeleteList(string NotifyIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AnswerNotification ");
			strSql.Append(" where NotifyId in ("+NotifyIdlist + ")  ");
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
		public abc.Model.Model.AnswerNotification GetModel(int NotifyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NotifyId,AskId,MemberId,TeacherId,Content,OrderBy,IsSend,SendDate,CreateTime from AnswerNotification ");
			strSql.Append(" where NotifyId=SQL2012NotifyId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012NotifyId", SqlDbType.Int,4)
			};
			parameters[0].Value = NotifyId;

			abc.Model.Model.AnswerNotification model=new abc.Model.Model.AnswerNotification();
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
		public abc.Model.Model.AnswerNotification DataRowToModel(DataRow row)
		{
			abc.Model.Model.AnswerNotification model=new abc.Model.Model.AnswerNotification();
			if (row != null)
			{
				if(row["NotifyId"]!=null && row["NotifyId"].ToString()!="")
				{
					model.NotifyId=int.Parse(row["NotifyId"].ToString());
				}
				if(row["AskId"]!=null && row["AskId"].ToString()!="")
				{
					model.AskId=int.Parse(row["AskId"].ToString());
				}
				if(row["MemberId"]!=null && row["MemberId"].ToString()!="")
				{
					model.MemberId=int.Parse(row["MemberId"].ToString());
				}
				if(row["TeacherId"]!=null)
				{
					model.TeacherId=row["TeacherId"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["OrderBy"]!=null && row["OrderBy"].ToString()!="")
				{
					model.OrderBy=int.Parse(row["OrderBy"].ToString());
				}
				if(row["IsSend"]!=null && row["IsSend"].ToString()!="")
				{
					model.IsSend=int.Parse(row["IsSend"].ToString());
				}
				if(row["SendDate"]!=null)
				{
					model.SendDate=row["SendDate"].ToString();
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
			strSql.Append("select NotifyId,AskId,MemberId,TeacherId,Content,OrderBy,IsSend,SendDate,CreateTime ");
			strSql.Append(" FROM AnswerNotification ");
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
			strSql.Append(" NotifyId,AskId,MemberId,TeacherId,Content,OrderBy,IsSend,SendDate,CreateTime ");
			strSql.Append(" FROM AnswerNotification ");
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
			strSql.Append("select count(1) FROM AnswerNotification ");
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
				strSql.Append("order by T.NotifyId desc");
			}
			strSql.Append(")AS Row, T.*  from AnswerNotification T ");
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
			parameters[0].Value = "AnswerNotification";
			parameters[1].Value = "NotifyId";
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

