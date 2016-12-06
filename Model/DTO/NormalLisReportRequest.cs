﻿using System;

namespace RuRo.Model.DTO
{
    public  partial class NormalLisReportRequest
    {
        private string _hospnum;
        private string _ksrq00;
        private string _jsrq00;
        //private string _requset;
        private string _ext_mthd;
        /// <summary>
        /// 病人门诊号、住院号
        /// </summary>
        public string hospnum
        {
            get { return _hospnum; }
            set { this._hospnum = value; }
        }

        /// <summary>
        /// 采集开始日期 YYYY-MM-DD
        /// </summary>
        public string ksrq00
        {
            get { return _ksrq00; }
            set { this._ksrq00 = value; }
        }

        /// <summary>
        /// 采集结束日期 YYYY-MM-DD
        /// </summary>
        public string jsrq00
        {
            get { return _jsrq00; }
            set { this._jsrq00 = value; }
        }
        public string ext_mthd
        {
            get { return _ext_mthd; }
            set { this._ext_mthd = value; }
        }
        ///// <summary>
        ///// 查询字符串
        ///// </summary>
        //public string Request
        //{
        //    get { return _requset; }
        //    set { this._requset = value; }
        //}

        //public NormalLisReportRequest(string hospnum, string dateNow)
        //{
        //    this._hospnum = hospnum;
        //    this._ksrq00 = DateTime.Parse(dateNow).AddDays(-5).ToString("yyyy-MM-dd");
        //    this._jsrq00 = DateTime.Parse(dateNow).AddDays(1).ToString("yyyy-MM-dd");
        //    this._requset = string.Format("<Request><hospnum>{0}</hospnum><ksrq00>{1}</ksrq00><jsrq00>{2}</jsrq00></Request>", hospnum, ksrq00, jsrq00);
        //}

        //public NormalLisReportRequest(string hospnum, string ksrq00, string jsrq00)
        //{
        //    this._hospnum = hospnum;
        //    this._ksrq00 = ksrq00;
        //    this._jsrq00 = jsrq00;
        //    this._requset = string.Format("<Request><hospnum>{0}</hospnum><ksrq00>{1}</ksrq00><jsrq00>{2}</jsrq00></Request>", hospnum, ksrq00, jsrq00);
        //}
    }
}