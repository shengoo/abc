/**  版本信息模板在安装目录下，可自行修改。
* UploadFile.cs
*
* 功 能： N/A
* 类 名： UploadFile
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/24 11:44:10   N/A    初版
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
	/// 数据访问类:UploadFile
	/// </summary>
	public partial class UploadFile:IUploadFile
	{
		public UploadFile()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FileId", "UploadFile"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FileId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UploadFile");
			strSql.Append(" where FileId=SQL2012FileId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileId", SqlDbType.Int,4)
			};
			parameters[0].Value = FileId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(abc.Model.Model.UploadFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UploadFile(");
			strSql.Append("FileName,FileType,Hash,Ext,Size,Enabled,IsPublic,CanDownLoad,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("SQL2012FileName,SQL2012FileType,SQL2012Hash,SQL2012Ext,SQL2012Size,SQL2012Enabled,SQL2012IsPublic,SQL2012CanDownLoad,SQL2012CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012FileType", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Hash", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Ext", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Size", SqlDbType.Int,4),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012IsPublic", SqlDbType.Int,4),
					new SqlParameter("SQL2012CanDownLoad", SqlDbType.Int,4),
					new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.FileName;
			parameters[1].Value = model.FileType;
			parameters[2].Value = model.Hash;
			parameters[3].Value = model.Ext;
			parameters[4].Value = model.Size;
			parameters[5].Value = model.Enabled;
			parameters[6].Value = model.IsPublic;
			parameters[7].Value = model.CanDownLoad;
			parameters[8].Value = model.CreateTime;

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
		public bool Update(abc.Model.Model.UploadFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UploadFile set ");
			strSql.Append("FileName=SQL2012FileName,");
			strSql.Append("FileType=SQL2012FileType,");
			strSql.Append("Hash=SQL2012Hash,");
			strSql.Append("Ext=SQL2012Ext,");
			strSql.Append("Size=SQL2012Size,");
			strSql.Append("Enabled=SQL2012Enabled,");
			strSql.Append("IsPublic=SQL2012IsPublic,");
			strSql.Append("CanDownLoad=SQL2012CanDownLoad,");
			strSql.Append("CreateTime=SQL2012CreateTime");
			strSql.Append(" where FileId=SQL2012FileId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileName", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012FileType", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Hash", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Ext", SqlDbType.VarChar,255),
					new SqlParameter("SQL2012Size", SqlDbType.Int,4),
					new SqlParameter("SQL2012Enabled", SqlDbType.Int,4),
					new SqlParameter("SQL2012IsPublic", SqlDbType.Int,4),
					new SqlParameter("SQL2012CanDownLoad", SqlDbType.Int,4),
					new SqlParameter("SQL2012CreateTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012FileId", SqlDbType.Int,4)};
			parameters[0].Value = model.FileName;
			parameters[1].Value = model.FileType;
			parameters[2].Value = model.Hash;
			parameters[3].Value = model.Ext;
			parameters[4].Value = model.Size;
			parameters[5].Value = model.Enabled;
			parameters[6].Value = model.IsPublic;
			parameters[7].Value = model.CanDownLoad;
			parameters[8].Value = model.CreateTime;
			parameters[9].Value = model.FileId;

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
		public bool Delete(int FileId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UploadFile ");
			strSql.Append(" where FileId=SQL2012FileId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileId", SqlDbType.Int,4)
			};
			parameters[0].Value = FileId;

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
		public bool DeleteList(string FileIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UploadFile ");
			strSql.Append(" where FileId in ("+FileIdlist + ")  ");
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
		public abc.Model.Model.UploadFile GetModel(int FileId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FileId,FileName,FileType,Hash,Ext,Size,Enabled,IsPublic,CanDownLoad,CreateTime from UploadFile ");
			strSql.Append(" where FileId=SQL2012FileId");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FileId", SqlDbType.Int,4)
			};
			parameters[0].Value = FileId;

			abc.Model.Model.UploadFile model=new abc.Model.Model.UploadFile();
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
		public abc.Model.Model.UploadFile DataRowToModel(DataRow row)
		{
			abc.Model.Model.UploadFile model=new abc.Model.Model.UploadFile();
			if (row != null)
			{
				if(row["FileId"]!=null && row["FileId"].ToString()!="")
				{
					model.FileId=int.Parse(row["FileId"].ToString());
				}
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["FileType"]!=null)
				{
					model.FileType=row["FileType"].ToString();
				}
				if(row["Hash"]!=null)
				{
					model.Hash=row["Hash"].ToString();
				}
				if(row["Ext"]!=null)
				{
					model.Ext=row["Ext"].ToString();
				}
				if(row["Size"]!=null && row["Size"].ToString()!="")
				{
					model.Size=int.Parse(row["Size"].ToString());
				}
				if(row["Enabled"]!=null && row["Enabled"].ToString()!="")
				{
					model.Enabled=int.Parse(row["Enabled"].ToString());
				}
				if(row["IsPublic"]!=null && row["IsPublic"].ToString()!="")
				{
					model.IsPublic=int.Parse(row["IsPublic"].ToString());
				}
				if(row["CanDownLoad"]!=null && row["CanDownLoad"].ToString()!="")
				{
					model.CanDownLoad=int.Parse(row["CanDownLoad"].ToString());
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
			strSql.Append("select FileId,FileName,FileType,Hash,Ext,Size,Enabled,IsPublic,CanDownLoad,CreateTime ");
			strSql.Append(" FROM UploadFile ");
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
			strSql.Append(" FileId,FileName,FileType,Hash,Ext,Size,Enabled,IsPublic,CanDownLoad,CreateTime ");
			strSql.Append(" FROM UploadFile ");
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
			strSql.Append("select count(1) FROM UploadFile ");
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
				strSql.Append("order by T.FileId desc");
			}
			strSql.Append(")AS Row, T.*  from UploadFile T ");
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
			parameters[0].Value = "UploadFile";
			parameters[1].Value = "FileId";
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

