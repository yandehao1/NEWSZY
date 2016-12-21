using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Text;
using RuRo.BLL;
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
                    case "posty":/*导入到FP*/
                        PostData(context);
                        break;
                    case "del":/*删除*/
                        DeleteData(context);
                        break;
                    case "qry":/*查询*/
                        QueryData(context, false);
                        break;
                    case "exp":/*导出*/
                        QueryImport(context, true);
                        break;
                }
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="export">是否导出Excel文件</param>
        private static void QueryData(HttpContext context, bool export)
        {
            string strcode = context.Request["bcode"].ToString();
            //查询WEB
            //记录数据
            //返回数据
            #region 未使用
            #region 获取Jquery回传Server分页页码和每页行数
            //int page,rows;
            //if (context.Request["page"] != null)
            //   page = int.Parse(context.Request["page"]);
            //else
            //   page = 1; 
            //if (context.Request["rows"]!= null)
            //    rows = int.Parse(context.Request["rows"]);
            //else
            //    rows = 10;
            #endregion
            #region 获取Jquery回传查询条件参数
            //string strWhere = " 1=1 ";
            //if (context.Request["so_keywords"] != null)
            //{
            //    string strKeywords = context.Request["so_keywords"];
            //    if (strKeywords.Length > 0)
            //    {
            //        strWhere += " and (";
            //        strWhere += " id like '%" + strKeywords + "%'";
            //        strWhere += " or patientname like '%" + strKeywords + "%'";
            //        strWhere += " or sex like '%" + strKeywords + "%'";
            //        strWhere += " or specimennum like '%" + strKeywords + "%'";
            //        strWhere += " or patientnum like '%" + strKeywords + "%'";
            //        strWhere += ")";
            //    }
            //}
            #endregion
            #region 字段排序
            //string sort = "id";
            //string order = "asc";
            //if (context.Request["sort"] != null)
            //    sort = context.Request["sort"];
            //if (context.Request["order"] != null)
            //    order = context.Request["order"];
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
            //if (export)
            //{
            //    //DataTable export_dataTable = new DataTable();
            //    //pageAction.Fields = "id as id,patientname as patientname,sex as sex,specimennum as specimennum,patientnum as patientnum,department as department,atsample as atsample,age as age,billingtime as billingtime,collectiondate as collectiondate,collectiontime as collectiontime,collectionby as collectionby,receivedate as receivedate,receivetime as receivetime,receiveby as receiveby";
            //    //DbHelper.GetTable(pageAction.Sql, ref export_dataTable);
            //    //commExcel._ExportExcel(export_dataTable, "Specimen");
            //    //result rlt = new result();
            //    //rlt.success = true;
            //    //rlt.msg = commExcel._Url("Specimen");
            //    //context.Response.Write(JSONHelper.Convert2Json(rlt));
            //}
            //else
            //{
            //    //string strJson = JSONHelper.CreateJsonParameters(m_dtTable,true, pageAction.RdCount);
            //    //context.Response.Write(strJson);
            //}
            #endregion
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
        /// 导出EXCEL
        /// </summary>
        /// <param name="context"></param>
        /// <param name="export"></param>
        private static void QueryImport(HttpContext context, bool export)
        {
            //获取数据
            string strScount = context.Request["ScountE"].ToString();
            string strvolume = context.Request["volumeE"].ToString();
            string strSampleType = context.Request["sampleTypeE"].ToString();
            string strData = context.Request["_Specimen_dg"].ToString();
            //转化数据
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            //创建datatable
            DataTable dt = new DataTable();
            //插入数据
            //for (int i = 0; i < length; i++)
            //{

            //}
            //转化为EXCEL
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
        private static void PostData(HttpContext context)
        {
            //获取前台数据
            string strdata = context.Request["_SpJsondata"].ToString();
            string num = context.Request["num"].ToString();
            List<Dictionary<string, string>> datalistdic = new List<Dictionary<string, string>>();//用来接收前台数据
            Dictionary<string, string> Valuedic = new Dictionary<string, string>();//用来接收字段设定
            datalistdic = FreezerProUtility.Fp_Common.FpJsonHelper.DeserializeObject<List<Dictionary<string, string>>>(strdata);
            if (datalistdic.Count > 0)
            {
                RuRo.BLL.TB_CONVERT tb_bll = new BLL.TB_CONVERT();
                DataSet ds = tb_bll.GetList("type=source");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Valuedic.Add(ds.Tables[0].Rows[i]["Name"].ToString(), ds.Tables[0].Rows[i]["REPORT_NAME"].ToString());
                    }
                }
                //匹配转换字段
                List<Dictionary<string, string>> newlistdic = tb_bll.PageForSource(Valuedic, datalistdic);
                BLL.EmpiInfo bll = new BLL.EmpiInfo();
                string msg = "";
                //将样本源导入到系统
                for (int i = 0; i < newlistdic.Count; i++)
                {
                    string result = bll.PostData(newlistdic[i]);
                    if (result.Contains("\"success\":true,") || result.Contains("should be unique."))
                    {
                        //导入成功
                    }
                    else
                    {
                        //导入失败
                    }
                }
            }
            else
            {

            }
        }
        //转换后的数据添加Name和描述
        public List<Dictionary<string, string>> AddData(List<Dictionary<string, string>> dic)
        {
            List<Dictionary<string, string>> lis = new List<Dictionary<string, string>>();
            return lis;
            
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

