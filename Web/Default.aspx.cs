﻿using System;

namespace RuRo.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FreezerProUrl();
                //访问页面时做登陆检查
            }
        }

        private void FreezerProUrl()
        {
            string s = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
            FreezerPro.Attributes.Add("src", s);
        }

        protected void but_Click(object sender, EventArgs e)
        {
        }
    }
}