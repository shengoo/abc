/**  版本信息模板在安装目录下，可自行修改。
* MemberCardNum.cs
*
* 功 能： N/A
* 类 名： MemberCardNum
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:55   N/A    初版
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
	/// 数据访问类:MemberCardNum
	/// </summary>
	public partial class MemberCardNum:IMemberCardNum
	{
		public MemberCardNum()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MemberId", "MemberCardNum"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MemberId,int MemberCardId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberCardNum");
			strSql.Append(" where MemberId=SQL2012MemberId and MemberCardId=SQL2012MemberCardId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberCardId", SqlDbType.Int,4)			};
			parameters[0].Value = MemberId;
			parameters[1].Value = MemberCardId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.MemberCardNum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberCardNum(");
			strSql.Append("MemberId,CardCategoryId,CardTypeId,CardTotalNum,CardRemainderNum)");
			strSql.Append(" values (");
			strSql.Append("SQL2012MemberId,SQL2012CardCategoryId,SQL2012CardTypeId,SQL2012CardTotalNum,SQL2012CardRemainderNum)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CardCategoryId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CardTypeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CardTotalNum", SqlDbType.Int,4),
					new SqlParameter("SQL2012CardRemainderNum", SqlDbType.Int,4)};
			parameters[0].Value = model.MemberId;
			parameters[1].Value = model.CardCategoryId;
			parameters[2].Value = model.CardTypeId;
			parameters[3].Value = model.CardTotalNum;
			parameters[4].Value = model.CardRemainderNum;

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
		public bool Update(abc.Model.Model.MemberCardNum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberCardNum set ");
			strSql.Append("CardCategoryId=SQL2012CardCategoryId,");
			strSql.Append("CardTypeId=SQL2012CardTypeId,");
			strSql.Append("CardTotalNum=SQL2012CardTotalNum,");
			strSql.Append("CardRemainderNum=SQL2012CardRemainderNum");
			strSql.Append(" where MemberCardId=SQL2012MemberCardId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CardCategoryId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CardTypeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CardTotalNum", SqlDbType.Int,4),
					new SqlParameter("SQL2012CardRemainderNum", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberCardId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4)};
			parameters[0].Value = model.CardCategoryId;
			parameters[1].Value = model.CardTypeId;
			parameters[2].Value = model.CardTotalNum;
			parameters[3].Value = model.CardRemainderNum;
			parameters[4].Value = model.MemberCardId;
			parameters[5].Value = model.MemberId;

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
		public bool Delete(int MemberCardId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberCardNum ");
			strSql.Append(" where MemberCardId=SQL2012MemberCardId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberCardId", SqlDbType.Int,4)
			};
			parameters[0].Value = MemberCardId;

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
		public bool Delete(int MemberId,int MemberCardId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberCardNum ");
			strSql.Append(" where MemberId=SQL2012MemberId and MemberCardId=SQL2012MemberCardId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberId", SqlDbType.Int,4),
					new SqlParameter("SQL2012MemberCardId", SqlDbType.Int,4)			};
			parameters[0].Value = MemberId;
			parameters[1].Value = MemberCardId;

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
		public bool DeleteList(string MemberCardIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberCardNum ");
			strSql.Append(" where MemberCardId in ("+MemberCardIdlist + ")  ");
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
		public abc.Model.Model.MemberCardNum GetModel(int MemberCardId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MemberCardId,MemberId,CardCategoryId,CardTypeId,CardTotalNum,CardRemainderNum from MemberCardNum ");
			strSql.Append(" where MemberCardId=SQL2012MemberCardId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MemberCardId", SqlDbType.Int,4)
			};
			parameters[0].Value = MemberCardId;

			abc.Model.Model.MemberCardNum model=new abc.Model.Model.MemberCardNum();
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
		public abc.Model.Model.MemberCardNum DataRowToModel(DataRow row)
		{
			abc.Model.Model.MemberCardNum model=new abc.Model.Model.MemberCardNum();
			if (row != null)
			{
				if(row["MemberCardId"]!=null && row["MemberCardId"].ToString()!="")
				{
					model.MemberCardId=int.Parse(row["MemberCardId"].ToString());
				}
				if(row["MemberId"]!=null && row["MemberId"].ToString()!="")
				{
					model.MemberId=int.Parse(row["MemberId"].ToString());
				}
				if(row["CardCategoryId"]!=null && row["CardCategoryId"].ToString()!="")
				{
					model.CardCategoryId=int.Parse(row["CardCategoryId"].ToString());
				}
				if(row["CardTypeId"]!=null && row["CardTypeId"].ToString()!="")
				{
					model.CardTypeId=int.Parse(row["CardTypeId"].ToString());
				}
				if(row["CardTotalNum"]!=null && row["CardTotalNum"].ToString()!="")
				{
					model.CardTotalNum=int.Parse(row["CardTotalNum"].ToString());
				}
				if(row["CardRemainderNum"]!=null && row["CardRemainderNum"].ToString()!="")
				{
					model.CardRemainderNum=int.Parse(row["CardRemainderNum"].ToString());
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
			strSql.Append("select MemberCardId,MemberId,CardCategoryId,CardTypeId,CardTotalNum,CardRemainderNum ");
			strSql.Append(" FROM MemberCardNum ");
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
			strSql.Append(" MemberCardId,MemberId,CardCategoryId,CardTypeId,CardTotalNum,CardRemainderNum ");
			strSql.Append(" FROM MemberCardNum ");
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
			strSql.Append("select count(1) FROM MemberCardNum ");
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
				strSql.Append("order by T.MemberCardId desc");
			}
			strSql.Append(")AS Row, T.*  from MemberCardNum T ");
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
			parameters[0].Value = "MemberCardNum";
			parameters[1].Value = "MemberCardId";
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

