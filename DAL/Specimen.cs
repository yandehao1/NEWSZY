using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using RuRo.DBUtility;//Please add references
namespace RuRo.DAL
{
	/// <summary>
	/// 数据访问类:Specimen
	/// </summary>
	public partial class Specimen
	{
		public Specimen()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Specimen");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.Specimen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Specimen(");
			strSql.Append("PatientName,Sex,SpecimenNum,PatientNum,Department,atSample,age,BillingTime,collectionDate,collectionTime,collectionby,Receivedate,ReceiveTime,Receiveby)");
			strSql.Append(" values (");
			strSql.Append("@PatientName,@Sex,@SpecimenNum,@PatientNum,@Department,@atSample,@age,@BillingTime,@collectionDate,@collectionTime,@collectionby,@Receivedate,@ReceiveTime,@Receiveby)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PatientName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@SpecimenNum", SqlDbType.VarChar,50),
					new SqlParameter("@PatientNum", SqlDbType.VarChar,50),
					new SqlParameter("@Department", SqlDbType.VarChar,50),
					new SqlParameter("@atSample", SqlDbType.VarChar,50),
					new SqlParameter("@age", SqlDbType.VarChar,50),
					new SqlParameter("@BillingTime", SqlDbType.VarChar,50),
					new SqlParameter("@collectionDate", SqlDbType.VarChar,50),
					new SqlParameter("@collectionTime", SqlDbType.VarChar,50),
					new SqlParameter("@collectionby", SqlDbType.VarChar,50),
					new SqlParameter("@Receivedate", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiveTime", SqlDbType.VarChar,50),
					new SqlParameter("@Receiveby", SqlDbType.VarChar,50)};
			parameters[0].Value = model.PatientName;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.SpecimenNum;
			parameters[3].Value = model.PatientNum;
			parameters[4].Value = model.Department;
			parameters[5].Value = model.atSample;
			parameters[6].Value = model.age;
			parameters[7].Value = model.BillingTime;
			parameters[8].Value = model.collectionDate;
			parameters[9].Value = model.collectionTime;
			parameters[10].Value = model.collectionby;
			parameters[11].Value = model.Receivedate;
			parameters[12].Value = model.ReceiveTime;
			parameters[13].Value = model.Receiveby;

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
		public bool Update(RuRo.Model.Specimen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Specimen set ");
			strSql.Append("PatientName=@PatientName,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("SpecimenNum=@SpecimenNum,");
			strSql.Append("PatientNum=@PatientNum,");
			strSql.Append("Department=@Department,");
			strSql.Append("atSample=@atSample,");
			strSql.Append("age=@age,");
			strSql.Append("BillingTime=@BillingTime,");
			strSql.Append("collectionDate=@collectionDate,");
			strSql.Append("collectionTime=@collectionTime,");
			strSql.Append("collectionby=@collectionby,");
			strSql.Append("Receivedate=@Receivedate,");
			strSql.Append("ReceiveTime=@ReceiveTime,");
			strSql.Append("Receiveby=@Receiveby");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@PatientName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@SpecimenNum", SqlDbType.VarChar,50),
					new SqlParameter("@PatientNum", SqlDbType.VarChar,50),
					new SqlParameter("@Department", SqlDbType.VarChar,50),
					new SqlParameter("@atSample", SqlDbType.VarChar,50),
					new SqlParameter("@age", SqlDbType.VarChar,50),
					new SqlParameter("@BillingTime", SqlDbType.VarChar,50),
					new SqlParameter("@collectionDate", SqlDbType.VarChar,50),
					new SqlParameter("@collectionTime", SqlDbType.VarChar,50),
					new SqlParameter("@collectionby", SqlDbType.VarChar,50),
					new SqlParameter("@Receivedate", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiveTime", SqlDbType.VarChar,50),
					new SqlParameter("@Receiveby", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.PatientName;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.SpecimenNum;
			parameters[3].Value = model.PatientNum;
			parameters[4].Value = model.Department;
			parameters[5].Value = model.atSample;
			parameters[6].Value = model.age;
			parameters[7].Value = model.BillingTime;
			parameters[8].Value = model.collectionDate;
			parameters[9].Value = model.collectionTime;
			parameters[10].Value = model.collectionby;
			parameters[11].Value = model.Receivedate;
			parameters[12].Value = model.ReceiveTime;
			parameters[13].Value = model.Receiveby;
			parameters[14].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Specimen ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Specimen ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public RuRo.Model.Specimen GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,PatientName,Sex,SpecimenNum,PatientNum,Department,atSample,age,BillingTime,collectionDate,collectionTime,collectionby,Receivedate,ReceiveTime,Receiveby from Specimen ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			RuRo.Model.Specimen model=new RuRo.Model.Specimen();
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
		public RuRo.Model.Specimen DataRowToModel(DataRow row)
		{
			RuRo.Model.Specimen model=new RuRo.Model.Specimen();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["PatientName"]!=null)
				{
					model.PatientName=row["PatientName"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["SpecimenNum"]!=null)
				{
					model.SpecimenNum=row["SpecimenNum"].ToString();
				}
				if(row["PatientNum"]!=null)
				{
					model.PatientNum=row["PatientNum"].ToString();
				}
				if(row["Department"]!=null)
				{
					model.Department=row["Department"].ToString();
				}
				if(row["atSample"]!=null)
				{
					model.atSample=row["atSample"].ToString();
				}
				if(row["age"]!=null)
				{
					model.age=row["age"].ToString();
				}
				if(row["BillingTime"]!=null)
				{
					model.BillingTime=row["BillingTime"].ToString();
				}
				if(row["collectionDate"]!=null)
				{
					model.collectionDate=row["collectionDate"].ToString();
				}
				if(row["collectionTime"]!=null)
				{
					model.collectionTime=row["collectionTime"].ToString();
				}
				if(row["collectionby"]!=null)
				{
					model.collectionby=row["collectionby"].ToString();
				}
				if(row["Receivedate"]!=null)
				{
					model.Receivedate=row["Receivedate"].ToString();
				}
				if(row["ReceiveTime"]!=null)
				{
					model.ReceiveTime=row["ReceiveTime"].ToString();
				}
				if(row["Receiveby"]!=null)
				{
					model.Receiveby=row["Receiveby"].ToString();
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
			strSql.Append("select id,PatientName,Sex,SpecimenNum,PatientNum,Department,atSample,age,BillingTime,collectionDate,collectionTime,collectionby,Receivedate,ReceiveTime,Receiveby ");
			strSql.Append(" FROM Specimen ");
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
			strSql.Append(" id,PatientName,Sex,SpecimenNum,PatientNum,Department,atSample,age,BillingTime,collectionDate,collectionTime,collectionby,Receivedate,ReceiveTime,Receiveby ");
			strSql.Append(" FROM Specimen ");
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
			strSql.Append("select count(1) FROM Specimen ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from Specimen T ");
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
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Specimen";
			parameters[1].Value = "id";
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

