//基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com
using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Text;
namespace RuRo
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Specimen_handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["mode"] != null)
            {
                string mode = context.Request["mode"].ToString();
                switch (mode)
                { 
                    case "inf":/*查询实体类*/
                        InfoData(context);
                        break;
                    case "ins":/*新增*/
                        SaveData(context);
                        break;
                    case "upd":/*修改*/
                        SaveData(context);
                        break;
                    case "del":/*删除*/
                        DeleteData(context);  
                        break;
                    case "qry":/*查询*/
                        QueryData(context,false);
                        break;
                    case "exp":/*导出*/
                        QueryData(context,true);
                        break;
                }
            }
            else 
                QueryData(context, false);
        }

        /// <summary>
        /// 查询info数据实体类
        /// </summary>
        /// <param name="context"></param>
        private static void InfoData(HttpContext context)
        {
            //BLL.Specimen_BLL bll_Specimen = new BLL.Specimen_BLL();
            //Model.Specimen model_Specimen = new Model.Specimen();
            //DataTable dt = new DataTable();
            //if (context.Request["pk"] != null)
            //{
            //    int pk = int.Parse(context.Request["pk"]);
            //    model_Specimen = bll_Specimen.GetModel(pk);
            //    bll_Specimen.GetModel(ref dt, pk);
            //}
            //string strJson = JSONHelper.DataTable2Json(dt, true);
            //context.Response.Write(strJson);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="context"></param>
        private static void SaveData(HttpContext context)
        {
            //result rlt = new result(); 
            //try
            //{
            //    //获取保存方式
            //    string mode = context.Request["mode"].ToString();
            //    int strPk = 0;
            //    if (mode == "upd")
            //    {
            //        strPk = int.Parse(context.Request["pk"].ToString());
            //    }
            //    BLL.Specimen_BLL bll_Specimen = new BLL.Specimen_BLL();
            //    Model.Specimen model_Specimen = new Model.Specimen(); 
            //    #region 实体类赋值
            //    if (mode == "ins")
            //    {
            //        //编码表采用Max获取，请注意设置字段长度
            //        model_Specimen._id = bll_Specimen.GetMax_id();//主键赋值
            //    }

            //    if(context.Request["patientname"]!=null)
            //        model_Specimen._patientname = context.Request["patientname"];

            //    if(context.Request["sex"]!=null)
            //        model_Specimen._sex = context.Request["sex"];

            //    if(context.Request["specimennum"]!=null)
            //        model_Specimen._specimennum = context.Request["specimennum"];

            //    if(context.Request["patientnum"]!=null)
            //        model_Specimen._patientnum = context.Request["patientnum"];

            //    if(context.Request["department"]!=null)
            //        model_Specimen._department = context.Request["department"];

            //    if(context.Request["atsample"]!=null)
            //        model_Specimen._atsample = context.Request["atsample"];

            //    if(context.Request["age"]!=null)
            //        model_Specimen._age = context.Request["age"];

            //    if(context.Request["billingtime"]!=null)
            //        model_Specimen._billingtime = context.Request["billingtime"];

            //    if(context.Request["collectiondate"]!=null)
            //        model_Specimen._collectiondate = context.Request["collectiondate"];

            //    if(context.Request["collectiontime"]!=null)
            //        model_Specimen._collectiontime = context.Request["collectiontime"];

            //    if(context.Request["collectionby"]!=null)
            //        model_Specimen._collectionby = context.Request["collectionby"];

            //    if(context.Request["receivedate"]!=null)
            //        model_Specimen._receivedate = context.Request["receivedate"];

            //    if(context.Request["receivetime"]!=null)
            //        model_Specimen._receivetime = context.Request["receivetime"];

            //    if(context.Request["receiveby"]!=null)
            //        model_Specimen._receiveby = context.Request["receiveby"];

            //    #endregion
            //    if (mode == "ins")
            //    {
            //        if (bll_Specimen.Insert(model_Specimen))
            //        {
            //            rlt.success = true;
            //            rlt.msg = "新增保存成功";
            //        }
            //        else
            //        {
            //            rlt.success = false;
            //            rlt.msg = "新增保存失败:" + DbError.getErrorMsg();
            //        }
            //    }

            //    if (mode == "upd")
            //    {
            //        if (bll_Specimen.Update(model_Specimen, strPk))
            //        {
            //            rlt.success = true;
            //            rlt.msg = "修改保存成功";
            //        }
            //        else
            //        {
            //            rlt.success = false;
            //            rlt.msg = "修改保存失败:" + DbError.getErrorMsg();
            //        }
            //    }
            //}
            //catch(Exception exception)
            //{
            //    rlt.success = false;
            //    rlt.msg = exception.Message;
            //}
            //context.Response.Write(JSONHelper.Convert2Json(rlt)); 
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="context"></param>
        private static void DeleteData(HttpContext context)
        {
            //result rlt = new result();
            //if (context.Request["pk"] != null)
            //{
            //    string pk = context.Request["pk"];
            //    string[] ArrayPk = pk.Split(',');
            //    BLL.Specimen_BLL bll_Specimen = new BLL.Specimen_BLL();
            //    int successNumber = 0;
            //    string  errorMessage = "";
            //    foreach (string strPk in ArrayPk)
            //    {
            //        if (bll_Specimen.Delete(int.Parse(strPk)))
            //        {
            //            successNumber += 1;
            //        }
            //    }
            //    rlt.success = true;
            //    rlt.msg = "成功删除[" + successNumber.ToString() + "/" + ArrayPk.Length.ToString() + "]条数据;" + errorMessage; 
            //}
            //else
            //{
            //    rlt.success = false;
            //    rlt.msg = "PK字段为Null";
            //}
            //context.Response.Write(JSONHelper.Convert2Json(rlt));
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="export">是否导出Excel文件</param>
        private static void QueryData(HttpContext context, bool export)
        {
            #region 获取Jquery回传Server分页页码和每页行数
            int page,rows;
            if (context.Request["page"] != null)
               page = int.Parse(context.Request["page"]);
            else
               page = 1; 
            if (context.Request["rows"]!= null)
                rows = int.Parse(context.Request["rows"]);
            else
                rows = 10;
            #endregion

            #region 获取Jquery回传查询条件参数
            string strWhere = " 1=1 ";
            if (context.Request["so_keywords"] != null)
            {
                string strKeywords = context.Request["so_keywords"];
                if (strKeywords.Length > 0)
                {
                    strWhere += " and (";
                    strWhere += " id like '%" + strKeywords + "%'";
                    strWhere += " or patientname like '%" + strKeywords + "%'";
                    strWhere += " or sex like '%" + strKeywords + "%'";
                    strWhere += " or specimennum like '%" + strKeywords + "%'";
                    strWhere += " or patientnum like '%" + strKeywords + "%'";
                    strWhere += ")";
                }
            }
            #endregion

            #region 字段排序
            string sort = "id";
            string order = "asc";
            if (context.Request["sort"] != null)
                sort = context.Request["sort"];
            if (context.Request["order"] != null)
                order = context.Request["order"];
            #endregion

            #region 分页数据
            //DataTable m_dtTable = new DataTable();
            //PageAction pageAction = new PageAction();
            //pageAction.CurPage = page;
            //pageAction.PageSize = rows;
            //pageAction.TabName = "Specimen";
            //pageAction.Fields = "*";
            //pageAction.PkField = "id";
            //pageAction.Condition = strWhere;
            //pageAction.Sort = sort + " " + order;
            //DbHelper.FillDataTable(pageAction, m_dtTable); 
            #endregion 


            /*编码绑定代码由KFEasyUiMaker根据编码字段定义自动生成,因此未考虑最佳性能；
             如编码表数据较少情况下，可根据实际情况处理为：先查出编码表组合再遍历赋值。*/
            #region 根据下拉列表编码设置datagrid显示值
            //for (int i = 0; i < m_dtTable.Rows.Count; i++)
            //{
            //}

            #endregion 
            if (export)
            {
                //DataTable export_dataTable = new DataTable();
                //pageAction.Fields = "id as id,patientname as patientname,sex as sex,specimennum as specimennum,patientnum as patientnum,department as department,atsample as atsample,age as age,billingtime as billingtime,collectiondate as collectiondate,collectiontime as collectiontime,collectionby as collectionby,receivedate as receivedate,receivetime as receivetime,receiveby as receiveby";
                //DbHelper.GetTable(pageAction.Sql, ref export_dataTable);
                //commExcel._ExportExcel(export_dataTable, "Specimen");
                //result rlt = new result();
                //rlt.success = true;
                //rlt.msg = commExcel._Url("Specimen");
                //context.Response.Write(JSONHelper.Convert2Json(rlt));
            }
            else
            {
                //string strJson = JSONHelper.CreateJsonParameters(m_dtTable,true, pageAction.RdCount);
                //context.Response.Write(strJson);
            }
        }

        #region JSON实体返回类定义
        /// <summary>
        /// 实体Ajax返回类
        /// </summary>
        public class result
        {
            bool _success = false;
            string _msg = "";
            public bool success 
            {
                set { _success = value; }
                get { return _success; }
            }
            public string msg
            {
                set { _msg = value; }
                get { return _msg; } 
            }
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

