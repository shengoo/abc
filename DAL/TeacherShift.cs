/**  版本信息模板在安装目录下，可自行修改。
* TeacherShift.cs
*
* 功 能： N/A
* 类 名： TeacherShift
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:09   N/A    初版
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
	/// 数据访问类:TeacherShift
	/// </summary>
	public partial class TeacherShift:ITeacherShift
	{
		public TeacherShift()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ShiftId", "TeacherShift"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ShiftId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TeacherShift");
			strSql.Append(" where ShiftId=SQL2012ShiftId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ShiftId", SqlDbType.Int,4)
			};
			parameters[0].Value = ShiftId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.TeacherShift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TeacherShift(");
			strSql.Append("Color,ShiftType,ShiftName,BeginTime,EndTime,Note)");
			strSql.Append(" values (");
			strSql.Append("SQL2012Color,SQL2012ShiftType,SQL2012ShiftName,SQL2012BeginTime,SQL2012EndTime,SQL2012Note)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Color", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012ShiftType", SqlDbType.Int,4),
					new SqlParameter("SQL2012ShiftName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012BeginTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012EndTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012Note", SqlDbType.VarChar,500)};
			parameters[0].Value = model.Color;
			parameters[1].Value = model.ShiftType;
			parameters[2].Value = model.ShiftName;
			parameters[3].Value = model.BeginTime;
			parameters[4].Value = model.EndTime;
			parameters[5].Value = model.Note;

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
		public bool Update(abc.Model.Model.TeacherShift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TeacherShift set ");
			strSql.Append("Color=SQL2012Color,");
			strSql.Append("ShiftType=SQL2012ShiftType,");
			strSql.Append("ShiftName=SQL2012ShiftName,");
			strSql.Append("BeginTime=SQL2012BeginTime,");
			strSql.Append("EndTime=SQL2012EndTime,");
			strSql.Append("Note=SQL2012Note");
			strSql.Append(" where ShiftId=SQL2012ShiftId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Color", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012ShiftType", SqlDbType.Int,4),
					new SqlParameter("SQL2012ShiftName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012BeginTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012EndTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012Note", SqlDbType.VarChar,500),
					new SqlParameter("SQL2012ShiftId", SqlDbType.Int,4)};
			parameters[0].Value = model.Color;
			parameters[1].Value = model.ShiftType;
			parameters[2].Value = model.ShiftName;
			parameters[3].Value = model.BeginTime;
			parameters[4].Value = model.EndTime;
			parameters[5].Value = model.Note;
			parameters[6].Value = model.ShiftId;

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
		public bool Delete(int ShiftId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TeacherShift ");
			strSql.Append(" where ShiftId=SQL2012ShiftId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ShiftId", SqlDbType.Int,4)
			};
			parameters[0].Value = ShiftId;

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
		public bool DeleteList(string ShiftIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TeacherShift ");
			strSql.Append(" where ShiftId in ("+ShiftIdlist + ")  ");
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
		public abc.Model.Model.TeacherShift GetModel(int ShiftId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ShiftId,Color,ShiftType,ShiftName,BeginTime,EndTime,Note from TeacherShift ");
			strSql.Append(" where ShiftId=SQL2012ShiftId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ShiftId", SqlDbType.Int,4)
			};
			parameters[0].Value = ShiftId;

			abc.Model.Model.TeacherShift model=new abc.Model.Model.TeacherShift();
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
		public abc.Model.Model.TeacherShift DataRowToModel(DataRow row)
		{
			abc.Model.Model.TeacherShift model=new abc.Model.Model.TeacherShift();
			if (row != null)
			{
				if(row["ShiftId"]!=null && row["ShiftId"].ToString()!="")
				{
					model.ShiftId=int.Parse(row["ShiftId"].ToString());
				}
				if(row["Color"]!=null)
				{
					model.Color=row["Color"].ToString();
				}
				if(row["ShiftType"]!=null && row["ShiftType"].ToString()!="")
				{
					model.ShiftType=int.Parse(row["ShiftType"].ToString());
				}
				if(row["ShiftName"]!=null)
				{
					model.ShiftName=row["ShiftName"].ToString();
				}
				if(row["BeginTime"]!=null && row["BeginTime"].ToString()!="")
				{
					model.BeginTime=DateTime.Parse(row["BeginTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
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
			strSql.Append("select ShiftId,Color,ShiftType,ShiftName,BeginTime,EndTime,Note ");
			strSql.Append(" FROM TeacherShift ");
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
			strSql.Append(" ShiftId,Color,ShiftType,ShiftName,BeginTime,EndTime,Note ");
			strSql.Append(" FROM TeacherShift ");
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
			strSql.Append("select count(1) FROM TeacherShift ");
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
				strSql.Append("order by T.ShiftId desc");
			}
			strSql.Append(")AS Row, T.*  from TeacherShift T ");
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
			parameters[0].Value = "TeacherShift";
			parameters[1].Value = "ShiftId";
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

