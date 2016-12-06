//���������ɿƷ�EasyUi����������v3.5(build 20140519)��������������,��Ѱ��Զ����Ӱ�Ȩע��,�뱣����Ȩ��Ϣ�����������Ͷ��ɹ��������и��õĽ����뷢�����䣺843330160@qq.com
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
                    case "inf":/*��ѯʵ����*/
                        InfoData(context);
                        break;
                    case "ins":/*����*/
                        SaveData(context);
                        break;
                    case "upd":/*�޸�*/
                        SaveData(context);
                        break;
                    case "del":/*ɾ��*/
                        DeleteData(context);  
                        break;
                    case "qry":/*��ѯ*/
                        QueryData(context,false);
                        break;
                    case "exp":/*����*/
                        QueryData(context,true);
                        break;
                }
            }
            else 
                QueryData(context, false);
        }

        /// <summary>
        /// ��ѯinfo����ʵ����
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
        /// ��������
        /// </summary>
        /// <param name="context"></param>
        private static void SaveData(HttpContext context)
        {
            //result rlt = new result(); 
            //try
            //{
            //    //��ȡ���淽ʽ
            //    string mode = context.Request["mode"].ToString();
            //    int strPk = 0;
            //    if (mode == "upd")
            //    {
            //        strPk = int.Parse(context.Request["pk"].ToString());
            //    }
            //    BLL.Specimen_BLL bll_Specimen = new BLL.Specimen_BLL();
            //    Model.Specimen model_Specimen = new Model.Specimen(); 
            //    #region ʵ���ำֵ
            //    if (mode == "ins")
            //    {
            //        //��������Max��ȡ����ע�������ֶγ���
            //        model_Specimen._id = bll_Specimen.GetMax_id();//������ֵ
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
            //            rlt.msg = "��������ɹ�";
            //        }
            //        else
            //        {
            //            rlt.success = false;
            //            rlt.msg = "��������ʧ��:" + DbError.getErrorMsg();
            //        }
            //    }

            //    if (mode == "upd")
            //    {
            //        if (bll_Specimen.Update(model_Specimen, strPk))
            //        {
            //            rlt.success = true;
            //            rlt.msg = "�޸ı���ɹ�";
            //        }
            //        else
            //        {
            //            rlt.success = false;
            //            rlt.msg = "�޸ı���ʧ��:" + DbError.getErrorMsg();
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
        /// ɾ������
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
            //    rlt.msg = "�ɹ�ɾ��[" + successNumber.ToString() + "/" + ArrayPk.Length.ToString() + "]������;" + errorMessage; 
            //}
            //else
            //{
            //    rlt.success = false;
            //    rlt.msg = "PK�ֶ�ΪNull";
            //}
            //context.Response.Write(JSONHelper.Convert2Json(rlt));
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="context"></param>
        /// <param name="export">�Ƿ񵼳�Excel�ļ�</param>
        private static void QueryData(HttpContext context, bool export)
        {
            #region ��ȡJquery�ش�Server��ҳҳ���ÿҳ����
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

            #region ��ȡJquery�ش���ѯ��������
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

            #region �ֶ�����
            string sort = "id";
            string order = "asc";
            if (context.Request["sort"] != null)
                sort = context.Request["sort"];
            if (context.Request["order"] != null)
                order = context.Request["order"];
            #endregion

            #region ��ҳ����
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


            /*����󶨴�����KFEasyUiMaker���ݱ����ֶζ����Զ�����,���δ����������ܣ�
             ���������ݽ�������£��ɸ���ʵ���������Ϊ���Ȳ�����������ٱ�����ֵ��*/
            #region ���������б��������datagrid��ʾֵ
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

        #region JSONʵ�巵���ඨ��
        /// <summary>
        /// ʵ��Ajax������
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

