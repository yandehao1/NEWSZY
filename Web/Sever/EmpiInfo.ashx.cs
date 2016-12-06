﻿using System;
using System.Web;

namespace RuRo.Web.Sever
{
    /// <summary>
    /// EmpiInfo 的摘要说明
    /// </summary>
    public class EmpiInfo : IHttpHandler
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
                        QueryData(context, false);
                        break;

                    case "post":/*提交*/
                        PostData(context);
                        break;
                }
            }
            else
                QueryData(context, false);
        }

        private void PostData(HttpContext context)
        {
            string empiInfo = context.Request.Params["empiInfo"];
            string code = context.Request.Params["code"].Trim();
            string codeType = context.Request.Params["codeType"];
            BLL.EmpiInfo bll = new BLL.EmpiInfo();
            string result = bll.PostData(empiInfo, code, codeType);
            context.Response.Write(result);
        }

        private void QueryData(HttpContext context, bool p)
        {
            if (p)
            {
            }
            else
            {
                string code = context.Request["code"];//0 门诊 1住院
                string codeType = context.Request["codeType"];//住院号或门诊号
                BLL.EmpiInfo EmpiInfo = new BLL.EmpiInfo();
                Model.DTO.EmpiInfoRequest request = new Model.DTO.EmpiInfoRequest(code, codeType);
                string result = EmpiInfo.GetSampleSourceData(request);
                //object obj = EmpiInfo.GetDataByCode(Mzhzyh, Mzzybz, out success);
                //ReturnData state = new ReturnData(obj,success);
                //string jsonStrResult = state.Res();
                context.Response.Write(result);
            }
        }

        private void DeleteData(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void SaveData(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void InfoData(HttpContext context)
        {
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}