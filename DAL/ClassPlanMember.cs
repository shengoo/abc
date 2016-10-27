/**  版本信息模板在安装目录下，可自行修改。
* ClassPlanMember.cs
*
* 功 能： N/A
* 类 名： ClassPlanMember
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:45   N/A    初版
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
	/// 数据访问类:ClassPlanMember
	/// </summary>
	public partial class ClassPlanMember:IClassPlanMember
	{
		public ClassPlanMember()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ClassId", "ClassPlanMember"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ClassId,int MemberId,int CpmId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ClassPlanMember");
			strSql.Append(" where ClassId=SQL2012ClassId and MemberId=SQL2012MemberId and CpmId=SQL2012CpmId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ClassId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CpmId", SqlDbType.Int,4)			};
			parameters[0].Value = ClassId;
			parameters[1].Value = MemberId;
			parameters[2].Value = CpmId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.ClassPlanMember model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ClassPlanMember(");
			strSql.Append("ClassId,MemberId)");
			strSql.Append(" values (");
			strSql.Append("SQL2012ClassId,SQL2012MemberId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ClassId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassId;
			parameters[1].Value = model.MemberId;

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
		public bool Update(abc.Model.Model.ClassPlanMember model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ClassPlanMember set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("CpmId=SQL2012CpmId,");
			strSql.Append("ClassId=SQL2012ClassId,");
			strSql.Append("MemberId=SQL2012MemberId");
			strSql.Append(" where CpmId=SQL2012CpmId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CpmId", SqlDbType.Int,4),
					new SqlParameter("SQL2012ClassId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4)};
			parameters[0].Value = model.CpmId;
			parameters[1].Value = model.ClassId;
			parameters[2].Value = model.MemberId;

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
		public bool Delete(int CpmId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClassPlanMember ");
			strSql.Append(" where CpmId=SQL2012CpmId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CpmId", SqlDbType.Int,4)
			};
			parameters[0].Value = CpmId;

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
		public bool Delete(int ClassId,int MemberId,int CpmId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClassPlanMember ");
			strSql.Append(" where ClassId=SQL2012ClassId and MemberId=SQL2012MemberId and CpmId=SQL2012CpmId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ClassId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CpmId", SqlDbType.Int,4)			};
			parameters[0].Value = ClassId;
			parameters[1].Value = MemberId;
			parameters[2].Value = CpmId;

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
		public bool DeleteList(string CpmIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClassPlanMember ");
			strSql.Append(" where CpmId in ("+CpmIdlist + ")  ");
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
		public abc.Model.Model.ClassPlanMember GetModel(int CpmId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CpmId,ClassId,MemberId from ClassPlanMember ");
			strSql.Append(" where CpmId=SQL2012CpmId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CpmId", SqlDbType.Int,4)
			};
			parameters[0].Value = CpmId;

			abc.Model.Model.ClassPlanMember model=new abc.Model.Model.ClassPlanMember();
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
		public abc.Model.Model.ClassPlanMember DataRowToModel(DataRow row)
		{
			abc.Model.Model.ClassPlanMember model=new abc.Model.Model.ClassPlanMember();
			if (row != null)
			{
				if(row["CpmId"]!=null && row["CpmId"].ToString()!="")
				{
					model.CpmId=int.Parse(row["CpmId"].ToString());
				}
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["MemberId"]!=null && row["MemberId"].ToString()!="")
				{
					model.MemberId=int.Parse(row["MemberId"].ToString());
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
			strSql.Append("select CpmId,ClassId,MemberId ");
			strSql.Append(" FROM ClassPlanMember ");
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
			strSql.Append(" CpmId,ClassId,MemberId ");
			strSql.Append(" FROM ClassPlanMember ");
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
			strSql.Append("select count(1) FROM ClassPlanMember ");
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
				strSql.Append("order by T.CpmId desc");
			}
			strSql.Append(")AS Row, T.*  from ClassPlanMember T ");
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
			parameters[0].Value = "ClassPlanMember";
			parameters[1].Value = "CpmId";
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

