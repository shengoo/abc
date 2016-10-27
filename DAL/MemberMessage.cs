/**  版本信息模板在安装目录下，可自行修改。
* MemberMessage.cs
*
* 功 能： N/A
* 类 名： MemberMessage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:56   N/A    初版
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
	/// 数据访问类:MemberMessage
	/// </summary>
	public partial class MemberMessage:IMemberMessage
	{
		public MemberMessage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MsgId", "MemberMessage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MsgId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberMessage");
			strSql.Append(" where MsgId=SQL2012MsgId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MsgId", SqlDbType.Int,4)
			};
			parameters[0].Value = MsgId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.MemberMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberMessage(");
			strSql.Append("FromId,ToId,Title,Content,SendDate,Enabled)");
			strSql.Append(" values (");
			strSql.Append("SQL2012FromId,SQL2012ToId,SQL2012Title,SQL2012Content,SQL2012SendDate,SQL2012Enabled)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FromId", SqlDbType.Int,4),
					new SqlParameter("SQL2012ToId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Title", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012SendDate", SqlDbType.DateTime),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4)};
			parameters[0].Value = model.FromId;
			parameters[1].Value = model.ToId;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.SendDate;
			parameters[5].Value = model.Enabled;

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
		public bool Update(abc.Model.Model.MemberMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberMessage set ");
			strSql.Append("FromId=SQL2012FromId,");
			strSql.Append("ToId=SQL2012ToId,");
			strSql.Append("Title=SQL2012Title,");
			strSql.Append("Content=SQL2012Content,");
			strSql.Append("SendDate=SQL2012SendDate,");
			strSql.Append("Enabled=SQL2012Enabled");
			strSql.Append(" where MsgId=SQL2012MsgId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FromId", SqlDbType.Int,4),
					new SqlParameter("SQL2012ToId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Title", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012SendDate", SqlDbType.DateTime),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012MsgId", SqlDbType.Int,4)};
			parameters[0].Value = model.FromId;
			parameters[1].Value = model.ToId;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.SendDate;
			parameters[5].Value = model.Enabled;
			parameters[6].Value = model.MsgId;

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
		public bool Delete(int MsgId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberMessage ");
			strSql.Append(" where MsgId=SQL2012MsgId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MsgId", SqlDbType.Int,4)
			};
			parameters[0].Value = MsgId;

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
		public bool DeleteList(string MsgIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberMessage ");
			strSql.Append(" where MsgId in ("+MsgIdlist + ")  ");
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
		public abc.Model.Model.MemberMessage GetModel(int MsgId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MsgId,FromId,ToId,Title,Content,SendDate,Enabled from MemberMessage ");
			strSql.Append(" where MsgId=SQL2012MsgId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MsgId", SqlDbType.Int,4)
			};
			parameters[0].Value = MsgId;

			abc.Model.Model.MemberMessage model=new abc.Model.Model.MemberMessage();
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
		public abc.Model.Model.MemberMessage DataRowToModel(DataRow row)
		{
			abc.Model.Model.MemberMessage model=new abc.Model.Model.MemberMessage();
			if (row != null)
			{
				if(row["MsgId"]!=null && row["MsgId"].ToString()!="")
				{
					model.MsgId=int.Parse(row["MsgId"].ToString());
				}
				if(row["FromId"]!=null && row["FromId"].ToString()!="")
				{
					model.FromId=int.Parse(row["FromId"].ToString());
				}
				if(row["ToId"]!=null && row["ToId"].ToString()!="")
				{
					model.ToId=int.Parse(row["ToId"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["SendDate"]!=null && row["SendDate"].ToString()!="")
				{
					model.SendDate=DateTime.Parse(row["SendDate"].ToString());
				}
				if(row["Enabled"]!=null && row["Enabled"].ToString()!="")
				{
					model.Enabled=int.Parse(row["Enabled"].ToString());
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
			strSql.Append("select MsgId,FromId,ToId,Title,Content,SendDate,Enabled ");
			strSql.Append(" FROM MemberMessage ");
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
			strSql.Append(" MsgId,FromId,ToId,Title,Content,SendDate,Enabled ");
			strSql.Append(" FROM MemberMessage ");
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
			strSql.Append("select count(1) FROM MemberMessage ");
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
				strSql.Append("order by T.MsgId desc");
			}
			strSql.Append(")AS Row, T.*  from MemberMessage T ");
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
			parameters[0].Value = "MemberMessage";
			parameters[1].Value = "MsgId";
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

