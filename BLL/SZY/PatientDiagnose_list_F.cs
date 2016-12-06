﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RuRo.BLL.SZY
{
    public class PatientDiagnose_list_F
    {
        //1、获取前台页面的数据
        //2、创建查询字符串
        //3、调用webservice查询数据
        //4、将数据传回给web
        //5、创建获取数据对象
        private ClinicalData.PacsLisReportServices clinicalData = new ClinicalData.PacsLisReportServices();

        public string GetData(Model.DTO.PatientDiagnose_list_F model)
        {
            Model.DTO.JsonModel jsonmodel = new Model.DTO.JsonModel() { Statu = "err", Msg = "无数据", Data = "" };
            List<string> requestStr = new List<string>();
            #region 返回卡号
            if (model.codeType == "0")
            {
                requestStr = GetRequestStr(model);
                //保存记录（查询记录数据,更新或添加）  string.IsNullOrEmpty(requestStr)存在值 修改修！string.IsNullOrEmpty(requestStr) kaka
                if (requestStr != null && requestStr.Count > 0)
                {
                    List<Model.PatientDiagnose> patientDiagnoseList = new List<Model.PatientDiagnose>();
                    StringBuilder msg = new StringBuilder();
                    //调用接口获取数据
                    foreach (var item in requestStr)
                    {
                        string xmlStr = GetWebServiceData(item);
                        string _Msg = "";
                        //返回数据缺少结束标记
                        if (!xmlStr.Contains("</Response>"))
                        {
                            xmlStr += "</Response>";
                        }
                        Model.DTO.PatientDiagnoseResuest request = XmlStrToPatientDiagnoseResuest(item);
                        if (request != null)
                        {
                            List<Model.PatientDiagnose> patientDiagnoses = StrTObject(xmlStr, out _Msg, request);
                            if (patientDiagnoses != null)
                            {
                                foreach (Model.PatientDiagnose patientDiagnose in patientDiagnoses)
                                {
                                    if (!patientDiagnoseList.Contains(patientDiagnose))
                                    {
                                        bool check = CheckData(patientDiagnose);
                                        if (!check)
                                        {
                                            patientDiagnoseList.Add(patientDiagnose);
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(_Msg))
                                    {
                                        msg.Replace(_Msg, "");
                                        msg.Replace("&nbsp", "");
                                        msg.Replace(" ", "");
                                        msg.Append(" &nbsp " + _Msg);
                                    }
                                }

                            }
                        }
                        //nnn.Add(model.Code);

                        else
                        {
                            if (!string.IsNullOrEmpty(_Msg))
                            {
                                msg.Replace(_Msg, "");
                                msg.Replace("&nbsp", "");
                                msg.Replace(" ", "");
                                msg.Append(" &nbsp " + _Msg);
                            }
                        }
                    }
                    if (patientDiagnoseList != null && patientDiagnoseList.Count > 0)
                    {
                        //有数据
                        jsonmodel = CreatJsonMode("ok", msg.ToString(), patientDiagnoseList);
                        // ChangeQueryRecordStatu(cq, msg.ToString());
                    }
                    else
                    {
                        //无数据
                        jsonmodel = CreatJsonMode("err", msg.ToString(), patientDiagnoseList);
                        ///ChangeQueryRecordStatu(cq, msg.ToString());
                    }
                }
            }
            #endregion
            #region 返回住院号
            else if(model.codeType=="1")
            {
                RuRo.BLL.PK pk=new PK();
                //获取住院入参
                List<string> requestStrAdmissionDate = new List<string>();
                requestStrAdmissionDate = pk.GetRequestStrForAdmissionDate(model);
                //获取出院入参
                List<string> requestStrDischargeDate = new List<string>();
                requestStrDischargeDate = pk.GetRequestStrForDischargeDate(model);
                #region 获取住院日期数据
                //判断返回数据是否成功
                if (requestStrAdmissionDate != null && requestStrAdmissionDate.Count > 0)
                {
                    List<Model.PatientDiagnose> patientDiagnoseList = new List<Model.PatientDiagnose>();
                    StringBuilder msg = new StringBuilder();
                    foreach (var item in requestStrAdmissionDate)
                    {
                        string xmlStr = pk.GetHTTPWebServiceData(item);
                        string _Msg = "";
                        List<Model.PatientDiagnose> patientDiagnoses = pk.XmlStrToPatientDiagnoseResuestForZhuYuan(xmlStr, out _Msg);
                            if (patientDiagnoses != null)
                            {
                                foreach (Model.PatientDiagnose patientDiagnose in patientDiagnoses)
                                {
                                    if (!patientDiagnoseList.Contains(patientDiagnose))
                                    {
                                        bool check = CheckData(patientDiagnose);
                                        if (!check)
                                        {
                                            patientDiagnoseList.Add(patientDiagnose);
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(_Msg))
                                    {
                                        msg.Replace(_Msg, "");
                                        msg.Replace("&nbsp", "");
                                        msg.Replace(" ", "");
                                        msg.Append(" &nbsp " + _Msg);
                                    }
                                }

                            }
                            if (patientDiagnoseList != null && patientDiagnoseList.Count > 0)
                            {
                                //有数据
                                jsonmodel = CreatJsonMode("ok", msg.ToString(), patientDiagnoseList);
                                // ChangeQueryRecordStatu(cq, msg.ToString());
                            }
                            else
                            {
                                //无数据
                                jsonmodel = CreatJsonMode("err", msg.ToString(), patientDiagnoseList);
                                ///ChangeQueryRecordStatu(cq, msg.ToString());
                            }
                    }
                }
                #endregion
                #region 获取出院日期数据
                //if (requestStrDischargeDate != null && requestStrDischargeDate.Count > 0)
                //{
                //    List<Model.PatientDiagnose> patientDiagnoseList = new List<Model.PatientDiagnose>();
                //    StringBuilder msg = new StringBuilder();
                //    foreach (var item in requestStrDischargeDate)
                //    {
                //        string xmlStr = pk.GetHTTPWebServiceData(item);
                //        string _Msg = "";
                //        List<Model.PatientDiagnose> patientDiagnoses = pk.XmlStrToPatientDiagnoseResuestForZhuYuan(xmlStr, out _Msg);
                //        if (patientDiagnoses != null)
                //        {
                //            foreach (Model.PatientDiagnose patientDiagnose in patientDiagnoses)
                //            {
                //                if (!patientDiagnoseList.Contains(patientDiagnose))
                //                {
                //                    bool check = CheckData(patientDiagnose);
                //                    if (!check)
                //                    {
                //                        patientDiagnoseList.Add(patientDiagnose);
                //                    }
                //                }
                //                if (!string.IsNullOrEmpty(_Msg))
                //                {
                //                    msg.Replace(_Msg, "");
                //                    msg.Replace("&nbsp", "");
                //                    msg.Replace(" ", "");
                //                    msg.Append(" &nbsp " + _Msg);
                //                }
                //            }

                //        }
                //        if (patientDiagnoseList != null && patientDiagnoseList.Count > 0)
                //        {
                //            //有数据
                //            jsonmodel = CreatJsonMode("ok", msg.ToString(), patientDiagnoseList);
                //            // ChangeQueryRecordStatu(cq, msg.ToString());
                //        }
                //        else
                //        {
                //            //无数据
                //            jsonmodel = CreatJsonMode("err", msg.ToString(), patientDiagnoseList);
                //            ///ChangeQueryRecordStatu(cq, msg.ToString());
                //        }
                //    }
                //}
                #endregion
            }
            #endregion
            return JsonConvert.SerializeObject(jsonmodel);

        }

        private List<string> GetRequestStr(Model.DTO.PatientDiagnose_list_F model)
        {
            List<string> list = new List<string>();
            DateTime ksrq00 = new DateTime();
            DateTime jsrq00 = new DateTime();
            if (DateTime.TryParse(model.ksrq00, out ksrq00) && DateTime.TryParse(model.jsrq00, out jsrq00))
            {
                if (ksrq00 <= jsrq00)
                {
                    string str = CreatRequestStr(model.code, ksrq00, jsrq00);
                    list.Add(str);
                }
                if (ksrq00 > jsrq00)
                {
                    string str = CreatRequestStr(model.code, jsrq00, ksrq00);
                    list.Add(str);
                }
            }
            return list;
        }
        private string CreatRequestStr(string code, DateTime ksrq00, DateTime jsrq00)
        {
            return string.Format("<Request><cardno>{0}</cardno><cxrq00>{1}</cxrq00><jsrq00>{2}</jsrq00></Request>", code, ksrq00.ToString("yyyy-MM-dd"), jsrq00.ToString("yyyy-MM-dd"));
        }
        #region 检查数据对象在本地数据库是否存在 CheckData(Model.PatientDiagnose data)

        /// <summary>
        /// 检查数据对象在本地数据库是否存在 ,true--存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool CheckData(Model.PatientDiagnose data)
        {
            BLL.PatientDiagnose patientDiagnose = new BLL.PatientDiagnose();
            bool result = false;
            try
            {
                if (data != null)
                {
                    string whereStr = string.Format("Cardno ='{0}' and Csrq00 ='{1}' and DiagnoseDate ='{2}' and Flag='{3}' and Type='{4}'  and Diagnose='{5}'", data.Cardno, data.Csrq00, data.DiagnoseDate, data.Flag, data.Type, data.Diagnose);
                    List<Model.PatientDiagnose> list = patientDiagnose.GetModelList(whereStr);
                    if (list != null && list.Count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteError(ex);
            }
            return result;
        }

        #endregion 检查数据对象在本地数据库是否存在 CheckData(Model.PatientDiagnose data)

        private Model.DTO.JsonModel CreatJsonMode(string statu, string msg, object data)
        {
            Model.DTO.JsonModel jsonModel = new Model.DTO.JsonModel();
            if (statu == "err")
            {
                jsonModel.Statu = statu;
                jsonModel.Msg = msg;
            }
            else
            {
                jsonModel.Statu = statu;
                jsonModel.Msg = msg;
                jsonModel.Data = data;
            }
            return jsonModel;
        }

        #region 查询完WebService之后更新记录表

        #endregion 查询完WebService之后更新记录表

        #region 获取数据

        private string GetWebServiceData(string request)
        {
            try
            {
                //return Test("");
                return string.IsNullOrEmpty(request) ? "" : clinicalData.GetPatientDiagnose(request);
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteError(ex);
                return ex.Message + "--" + DateTime.Now.ToLongTimeString();
            }
        }
        #endregion 获取数据

        #region 生成临时数据

        /// <summary>
        /// 生成临时数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string Test(string request)
        {
            string getDataFromHospitalStr = @"<Response>
                                                <ResultCode>0</ResultCode>
                                                <ErrorMsg></ErrorMsg>
                                                <reocrd>
                                                  <PatientName>郭文宁</PatientName>
                                                  <Sex>男</Sex>
                                                  <Brithday>1981-01-01</Brithday>
                                                  <CardId>0272099</CardId>
                                                  <Tel>76</Tel>
                                                  <DiagnoseInfo>
                                                    <RegisterNo>11111111</RegisterNo>
                                                    <Icd>L40.900</Icd>
                                                    <Diagnose>银屑病</Diagnose>
                                                    <Type>3</Type>
                                                    <Flag>1</Flag>
                                                    <DiagnoseDate>2015-09-09</DiagnoseDate>
                                                    </DiagnoseInfo>
                                                 </reocrd>
                                                </Response>";
            return getDataFromHospitalStr;
        }
        #endregion 生成临时数据

        #region 将数据转换成对象

        #endregion 将数据转换成对象

        private List<Model.PatientDiagnose> StrTObject(string xmlStr, out string msg, Model.DTO.PatientDiagnoseResuest request)
        {
            XmlDocument xd = HospitalXmlStrHelper.HospitalXmlStrToXmlDoc(xmlStr);
            List<Model.PatientDiagnose> list = new List<Model.PatientDiagnose>();
            msg = "";
            if (xd == null)
            {
            }
            else
            {
                if (xd.HasChildNodes)
                {
                    XmlNode xn = xd.SelectSingleNode("//ResultCode");
                    if (xn != null)
                    {
                        if (xn.InnerText == "0")
                        {
                            try
                            {
                                string strNode = JsonConvert.SerializeXmlNode(xd.SelectSingleNode("//reocrd"), Newtonsoft.Json.Formatting.None, true);

                                XmlNodeList xns = xd.SelectNodes("//DiagnoseInfo");
                                foreach (XmlNode item in xns)
                                {
                                    Model.PatientDiagnose patientDiagnoseModel = new Model.PatientDiagnose();
                                    patientDiagnoseModel = JsonConvert.DeserializeObject<Model.PatientDiagnose>(strNode);
                                    string diagnoseInfoNode = JsonConvert.SerializeXmlNode(item, Newtonsoft.Json.Formatting.None, true);
                                    Model.DTO.DiagnoseInfoModel dg = JsonConvert.DeserializeObject<Model.DTO.DiagnoseInfoModel>(diagnoseInfoNode);
                                    patientDiagnoseModel.RegisterNo = dg.RegisterNo;
                                    patientDiagnoseModel.Type = dg.Type;
                                    patientDiagnoseModel.Icd = dg.Icd;
                                    patientDiagnoseModel.Flag = dg.Flag;
                                    patientDiagnoseModel.DiagnoseDate = dg.DiagnoseDate;
                                    patientDiagnoseModel.Diagnose = dg.Diagnose;
                                    patientDiagnoseModel.Cardno = request.cardno;
                                    patientDiagnoseModel.Csrq00 = request.cxrq00;
                                    list.Add(patientDiagnoseModel);
                                }
                            }
                            catch (Exception ex)
                            {
                                Common.LogHelper.WriteError(ex);
                            }

                        }
                        else
                        {
                            //查询数据出错，联接无问题
                            msg = xd.SelectSingleNode("//ErrorMsg").InnerText;
                        }
                    }
                    else
                    {
                        //查询数据出错，联接无问题
                        msg = xd.InnerText;
                    }
                }
            }
            return list;
        }

        public Model.PatientDiagnose DicToNormalLisReportModel(Dictionary<string, string> dic)
        {
            string str = JsonConvert.SerializeObject(dic);
            Model.PatientDiagnose patientDiagnose = JsonConvert.DeserializeObject<Model.PatientDiagnose>(str);
            return patientDiagnose;
        }

        private string PostData(string str)
        {
            UnameAndPwd up = new UnameAndPwd();
            string result = FreezerProUtility.Fp_BLL.TestData.ImportTestData(up.GetUp(), "诊断信息", str);
            return result;
        }

        //获取数据
        //解析数据
        //返回数据对象
        private Model.DTO.PatientDiagnoseResuest XmlStrToPatientDiagnoseResuest(string xml)
        {
            Model.DTO.PatientDiagnoseResuest pdr = new Model.DTO.PatientDiagnoseResuest();
            XmlDocument xd = Common.XmlHelper.XMLLoad(xml, Common.XmlHelper.XmlType.String);
            //<Request><cardno>{0}</cardno><cxrq00>{1}</cxrq00></Request>
            try
            {
                XmlNode xn = xd.SelectSingleNode("//Request");
                if (xn != null)
                {
                    string str = JsonConvert.SerializeXmlNode(xn, Newtonsoft.Json.Formatting.None, true);
                    pdr = JsonConvert.DeserializeObject<Model.DTO.PatientDiagnoseResuest>(str);
                }
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteError(ex);
            }
            return pdr;
        }


        private void ChangeQueryRecordStatu(BLL.Request.Request cq, string msg)
        {
            Model.QueryRecoder queryRecoder = cq.QueryRecoderModel;
            int queryDateInterval = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["QueryDateInterval"].Trim());
            if (queryRecoder != null)
            {
                try
                {
                    if ((DateTime.Now - queryRecoder.AddDate).Days > queryDateInterval)
                    {
                        //超时数据
                        queryRecoder.LastQueryDate = DateTime.Now;
                        queryRecoder.IsDel = true;
                    }
                    else
                    {
                        //不超时数据
                        queryRecoder.LastQueryDate = DateTime.Now;
                    }
                    queryRecoder.QueryResult = ("&nbsp" + DateTime.Now.ToLocalTime() + " " + msg + queryRecoder.QueryResult);
                    BLL.QueryRecoder q = new BLL.QueryRecoder();
                    q.Update(queryRecoder);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                }
            }
        }
    }
}
