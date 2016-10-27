/**  版本信息模板在安装目录下，可自行修改。
* CourseLesson.cs
*
* 功 能： N/A
* 类 名： CourseLesson
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:43:49   N/A    初版
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
	/// 数据访问类:CourseLesson
	/// </summary>
	public partial class CourseLesson:ICourseLesson
	{
		public CourseLesson()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CourseId", "CourseLesson"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CourseId,int Number,int LessonId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CourseLesson");
			strSql.Append(" where CourseId=SQL2012CourseId and Number=SQL2012Number and LessonId=SQL2012LessonId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Number", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4)			};
			parameters[0].Value = CourseId;
			parameters[1].Value = Number;
			parameters[2].Value = LessonId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.CourseLesson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CourseLesson(");
			strSql.Append("CourseId,Number,LessonName,Content,LessonDesc,CLength,IsFree,Enabled,Createtime)");
			strSql.Append(" values (");
			strSql.Append("SQL2012CourseId,SQL2012Number,SQL2012LessonName,SQL2012Content,SQL2012LessonDesc,SQL2012CLength,SQL2012IsFree,SQL2012Enabled,SQL2012Createtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Number", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012LessonDesc", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012CLength", SqlDbType.Int,4),
					new SqlParameter("SQL2012IsFree", SqlDbType.Int,4),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012Createtime", SqlDbType.DateTime)};
			parameters[0].Value = model.CourseId;
			parameters[1].Value = model.Number;
			parameters[2].Value = model.LessonName;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.LessonDesc;
			parameters[5].Value = model.CLength;
			parameters[6].Value = model.IsFree;
			parameters[7].Value = model.Enabled;
			parameters[8].Value = model.Createtime;

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
		public bool Update(abc.Model.Model.CourseLesson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CourseLesson set ");
			strSql.Append("LessonName=SQL2012LessonName,");
			strSql.Append("Content=SQL2012Content,");
			strSql.Append("LessonDesc=SQL2012LessonDesc,");
			strSql.Append("CLength=SQL2012CLength,");
			strSql.Append("IsFree=SQL2012IsFree,");
			strSql.Append("Enabled=SQL2012Enabled,");
			strSql.Append("Createtime=SQL2012Createtime");
			strSql.Append(" where LessonId=SQL2012LessonId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012LessonName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Content", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012LessonDesc", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012CLength", SqlDbType.Int,4),
					new SqlParameter("SQL2012IsFree", SqlDbType.Int,4),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012Createtime", SqlDbType.DateTime),
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4),
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Number", SqlDbType.Int,4)};
			parameters[0].Value = model.LessonName;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.LessonDesc;
			parameters[3].Value = model.CLength;
			parameters[4].Value = model.IsFree;
			parameters[5].Value = model.Enabled;
			parameters[6].Value = model.Createtime;
			parameters[7].Value = model.LessonId;
			parameters[8].Value = model.CourseId;
			parameters[9].Value = model.Number;

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
		public bool Delete(int LessonId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseLesson ");
			strSql.Append(" where LessonId=SQL2012LessonId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4)
			};
			parameters[0].Value = LessonId;

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
		public bool Delete(int CourseId,int Number,int LessonId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseLesson ");
			strSql.Append(" where CourseId=SQL2012CourseId and Number=SQL2012Number and LessonId=SQL2012LessonId ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CourseId", SqlDbType.Int,4),
					new SqlParameter("SQL2012Number", SqlDbType.Int,4),
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4)			};
			parameters[0].Value = CourseId;
			parameters[1].Value = Number;
			parameters[2].Value = LessonId;

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
		public bool DeleteList(string LessonIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseLesson ");
			strSql.Append(" where LessonId in ("+LessonIdlist + ")  ");
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
		public abc.Model.Model.CourseLesson GetModel(int LessonId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LessonId,CourseId,Number,LessonName,Content,LessonDesc,CLength,IsFree,Enabled,Createtime from CourseLesson ");
			strSql.Append(" where LessonId=SQL2012LessonId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012LessonId", SqlDbType.Int,4)
			};
			parameters[0].Value = LessonId;

			abc.Model.Model.CourseLesson model=new abc.Model.Model.CourseLesson();
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
		public abc.Model.Model.CourseLesson DataRowToModel(DataRow row)
		{
			abc.Model.Model.CourseLesson model=new abc.Model.Model.CourseLesson();
			if (row != null)
			{
				if(row["LessonId"]!=null && row["LessonId"].ToString()!="")
				{
					model.LessonId=int.Parse(row["LessonId"].ToString());
				}
				if(row["CourseId"]!=null && row["CourseId"].ToString()!="")
				{
					model.CourseId=int.Parse(row["CourseId"].ToString());
				}
				if(row["Number"]!=null && row["Number"].ToString()!="")
				{
					model.Number=int.Parse(row["Number"].ToString());
				}
				if(row["LessonName"]!=null)
				{
					model.LessonName=row["LessonName"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["LessonDesc"]!=null)
				{
					model.LessonDesc=row["LessonDesc"].ToString();
				}
				if(row["CLength"]!=null && row["CLength"].ToString()!="")
				{
					model.CLength=int.Parse(row["CLength"].ToString());
				}
				if(row["IsFree"]!=null && row["IsFree"].ToString()!="")
				{
					model.IsFree=int.Parse(row["IsFree"].ToString());
				}
				if(row["Enabled"]!=null && row["Enabled"].ToString()!="")
				{
					model.Enabled=int.Parse(row["Enabled"].ToString());
				}
				if(row["Createtime"]!=null && row["Createtime"].ToString()!="")
				{
					model.Createtime=DateTime.Parse(row["Createtime"].ToString());
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
			strSql.Append("select LessonId,CourseId,Number,LessonName,Content,LessonDesc,CLength,IsFree,Enabled,Createtime ");
			strSql.Append(" FROM CourseLesson ");
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
			strSql.Append(" LessonId,CourseId,Number,LessonName,Content,LessonDesc,CLength,IsFree,Enabled,Createtime ");
			strSql.Append(" FROM CourseLesson ");
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
			strSql.Append("select count(1) FROM CourseLesson ");
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
				strSql.Append("order by T.LessonId desc");
			}
			strSql.Append(")AS Row, T.*  from CourseLesson T ");
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
			parameters[0].Value = "CourseLesson";
			parameters[1].Value = "LessonId";
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

