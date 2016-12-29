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
            string strScount = context.Request["ScountE"].ToString();//管数
            string strvolume = context.Request["volumeE"].ToString();//容量
            string strSampleType = context.Request["sampleTypeE"].ToString();//样本类型
            string strData = context.Request["rowSpecimen_dg"].ToString();//样本数据
            string strdescription = context.Request["descriptionE"].ToString();//描述
            //转化数据
            DataTable Specimen_dg = FreezerProUtility.Fp_Common.FpJsonHelper.DeserializeObject<DataTable>(strData);
            DataTable newSpecimen_dg = new DataTable();//转换后新数据存放
            int count = Convert.ToInt32(strScount);
            RuRo.BLL.TB_CONVERT tb_bll = new TB_CONVERT();
            DataSet ds = tb_bll.GetList("type='sample' order by num asc");//获取报表名称
            //循环读取Specimen_dg的列名,匹配成为报表字段
            for (int i = 0; i < Specimen_dg.Columns.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (Specimen_dg.Columns[i].ColumnName.ToString() == ds.Tables[0].Rows[j]["Name"].ToString())
                    {
                        Specimen_dg.Columns[i].ColumnName = ds.Tables[0].Rows[j]["REPORT_NAME"].ToString();
                    }
                }
            }
            //添加其他列
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Specimen_dg.Columns.Contains(ds.Tables[0].Rows[i]["REPORT_NAME"].ToString())) { }
                else
                {
                    Specimen_dg.Columns.Add(ds.Tables[0].Rows[i]["REPORT_NAME"].ToString());
                }
            }
            //插入数据
            for (int i = 0; i < Specimen_dg.Rows.Count; i++)
            {
                Specimen_dg.Rows[i]["Name"] = Specimen_dg.Rows[i]["patientnum"];
                Specimen_dg.Rows[i]["Sample Source"] = Specimen_dg.Rows[i]["patientnum"];
                Specimen_dg.Rows[i]["Description"] = strdescription;
                Specimen_dg.Rows[i]["Sample Type"] = strSampleType;
                Specimen_dg.Rows[i]["Volume"] = strvolume;
                Specimen_dg.Rows[i]["ALIQUOT"] = i + 1;
            }
            //分管计数
            DataTable dtt = Specimen_dg.Copy();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    Specimen_dg.Rows.Add(dtt.Rows[i].ItemArray);
                }
            }
            DataTable dt = new DataTable();
            //移除不需要的列
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Specimen_dg.Columns.Contains(ds.Tables[0].Rows[i]["REPORT_NAME"].ToString()))
                {
                    string strColumns = ds.Tables[0].Rows[i]["REPORT_NAME"].ToString();
                    newSpecimen_dg.Columns.Add(ds.Tables[0].Rows[i]["REPORT_NAME"].ToString());
                }
            }
            //列排序
            for (int i = 0; i < Specimen_dg.Rows.Count; i++)
            {
                newSpecimen_dg.ImportRow(Specimen_dg.Rows[i]);
            }
            //转化EXCEL
            //获取本地路径
            RuRo.Common.DataToExcel dataexp = new Common.DataToExcel();
            dataexp.OutputExcel(newSpecimen_dg, "", @"D:/EXCEL/");
           //RuRo.Common.Excel.ExcelHelper.OutputToExcel(newSpecimen_dg, @"D:/EXCEL/1.xls");
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="context"></param>
        private static void PostData(HttpContext context)
        {
            //获取前台数据
            string strdata = context.Request["_SpJsondata"].ToString();
            string num = context.Request["num"].ToString();//随机数
            List<Dictionary<string, string>> datalistdic = new List<Dictionary<string, string>>();//用来接收前台数据
            Dictionary<string, string> Valuedic = new Dictionary<string, string>();//用来接收字段设定
            datalistdic = FreezerProUtility.Fp_Common.FpJsonHelper.DeserializeObject<List<Dictionary<string, string>>>(strdata);
            if (datalistdic.Count > 0)
            {
                RuRo.BLL.TB_CONVERT tb_bll = new BLL.TB_CONVERT();
                DataSet ds = tb_bll.GetList("type='source'");
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
        #region 未使用代码块
        /// <summary>
        /// 查询info数据实体类
        /// </summary>
        /// <param name="context"></param>
        private static void InfoData(HttpContext context)
        {
        }

        #endregion

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

