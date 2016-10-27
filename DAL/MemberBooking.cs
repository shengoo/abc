/**  版本信息模板在安装目录下，可自行修改。
* MemberBooking.cs
*
* 功 能： N/A
* 类 名： MemberBooking
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:54   N/A    初版
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
	/// 数据访问类:MemberBooking
	/// </summary>
	public partial class MemberBooking:IMemberBooking
	{
		public MemberBooking()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MemberId", "MemberBooking"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MemberId,int BookingId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberBooking");
			strSql.Append(" where MemberId=SQL2012MemberId and BookingId=SQL2012BookingId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012BookingId", SqlDbType.Int,4)			};
			parameters[0].Value = MemberId;
			parameters[1].Value = BookingId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.MemberBooking model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberBooking(");
			strSql.Append("BookingNo,PlanId,MemberId,OldBookingId,BookingType,ClassTime,BookingTime,BeginTime,EndTime)");
			strSql.Append(" values (");
			strSql.Append("SQL2012BookingNo,SQL2012PlanId,SQL2012MemberId,SQL2012OldBookingId,SQL2012BookingType,SQL2012ClassTime,SQL2012BookingTime,SQL2012BeginTime,SQL2012EndTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012BookingNo", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012PlanId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012OldBookingId", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012BookingType", SqlDbType.Int,4),
					new SqlParameter("SQL2012ClassTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012BookingTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012BeginTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012EndTime", SqlDbType.DateTime)};
			parameters[0].Value = model.BookingNo;
			parameters[1].Value = model.PlanId;
			parameters[2].Value = model.MemberId;
			parameters[3].Value = model.OldBookingId;
			parameters[4].Value = model.BookingType;
			parameters[5].Value = model.ClassTime;
			parameters[6].Value = model.BookingTime;
			parameters[7].Value = model.BeginTime;
			parameters[8].Value = model.EndTime;

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
		public bool Update(abc.Model.Model.MemberBooking model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberBooking set ");
			strSql.Append("BookingNo=SQL2012BookingNo,");
			strSql.Append("PlanId=SQL2012PlanId,");
			strSql.Append("OldBookingId=SQL2012OldBookingId,");
			strSql.Append("BookingType=SQL2012BookingType,");
			strSql.Append("ClassTime=SQL2012ClassTime,");
			strSql.Append("BookingTime=SQL2012BookingTime,");
			strSql.Append("BeginTime=SQL2012BeginTime,");
			strSql.Append("EndTime=SQL2012EndTime");
			strSql.Append(" where BookingId=SQL2012BookingId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012BookingNo", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012PlanId", SqlDbType.Int,4),
					new SqlParameter("SQL2012OldBookingId", SqlDbType.VarChar,4000),
					new SqlParameter("SQL2012BookingType", SqlDbType.Int,4),
					new SqlParameter("SQL2012ClassTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012BookingTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012BeginTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012EndTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012BookingId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4)};
			parameters[0].Value = model.BookingNo;
			parameters[1].Value = model.PlanId;
			parameters[2].Value = model.OldBookingId;
			parameters[3].Value = model.BookingType;
			parameters[4].Value = model.ClassTime;
			parameters[5].Value = model.BookingTime;
			parameters[6].Value = model.BeginTime;
			parameters[7].Value = model.EndTime;
			parameters[8].Value = model.BookingId;
			parameters[9].Value = model.MemberId;

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
		public bool Delete(int BookingId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberBooking ");
			strSql.Append(" where BookingId=SQL2012BookingId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012BookingId", SqlDbType.Int,4)
			};
			parameters[0].Value = BookingId;

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
		public bool Delete(int MemberId,int BookingId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberBooking ");
			strSql.Append(" where MemberId=SQL2012MemberId and BookingId=SQL2012BookingId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012BookingId", SqlDbType.Int,4)			};
			parameters[0].Value = MemberId;
			parameters[1].Value = BookingId;

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
		public bool DeleteList(string BookingIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberBooking ");
			strSql.Append(" where BookingId in ("+BookingIdlist + ")  ");
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
		public abc.Model.Model.MemberBooking GetModel(int BookingId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BookingId,BookingNo,PlanId,MemberId,OldBookingId,BookingType,ClassTime,BookingTime,BeginTime,EndTime from MemberBooking ");
			strSql.Append(" where BookingId=SQL2012BookingId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012BookingId", SqlDbType.Int,4)
			};
			parameters[0].Value = BookingId;

			abc.Model.Model.MemberBooking model=new abc.Model.Model.MemberBooking();
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
		public abc.Model.Model.MemberBooking DataRowToModel(DataRow row)
		{
			abc.Model.Model.MemberBooking model=new abc.Model.Model.MemberBooking();
			if (row != null)
			{
				if(row["BookingId"]!=null && row["BookingId"].ToString()!="")
				{
					model.BookingId=int.Parse(row["BookingId"].ToString());
				}
				if(row["BookingNo"]!=null)
				{
					model.BookingNo=row["BookingNo"].ToString();
				}
				if(row["PlanId"]!=null && row["PlanId"].ToString()!="")
				{
					model.PlanId=int.Parse(row["PlanId"].ToString());
				}
				if(row["MemberId"]!=null && row["MemberId"].ToString()!="")
				{
					model.MemberId=int.Parse(row["MemberId"].ToString());
				}
				if(row["OldBookingId"]!=null)
				{
					model.OldBookingId=row["OldBookingId"].ToString();
				}
				if(row["BookingType"]!=null && row["BookingType"].ToString()!="")
				{
					model.BookingType=int.Parse(row["BookingType"].ToString());
				}
				if(row["ClassTime"]!=null && row["ClassTime"].ToString()!="")
				{
					model.ClassTime=DateTime.Parse(row["ClassTime"].ToString());
				}
				if(row["BookingTime"]!=null && row["BookingTime"].ToString()!="")
				{
					model.BookingTime=DateTime.Parse(row["BookingTime"].ToString());
				}
				if(row["BeginTime"]!=null && row["BeginTime"].ToString()!="")
				{
					model.BeginTime=DateTime.Parse(row["BeginTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
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
			strSql.Append("select BookingId,BookingNo,PlanId,MemberId,OldBookingId,BookingType,ClassTime,BookingTime,BeginTime,EndTime ");
			strSql.Append(" FROM MemberBooking ");
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
			strSql.Append(" BookingId,BookingNo,PlanId,MemberId,OldBookingId,BookingType,ClassTime,BookingTime,BeginTime,EndTime ");
			strSql.Append(" FROM MemberBooking ");
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
			strSql.Append("select count(1) FROM MemberBooking ");
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
				strSql.Append("order by T.BookingId desc");
			}
			strSql.Append(")AS Row, T.*  from MemberBooking T ");
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
			parameters[0].Value = "MemberBooking";
			parameters[1].Value = "BookingId";
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

