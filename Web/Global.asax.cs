﻿using System;
using System.Globalization;
using System.IO;

namespace RuRo.Web
{
    /// <summary>
    /// Global 的摘要说明。
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Global()
        {
            InitializeComponent();
        }

        protected void Application_Start(Object sender, EventArgs e)
        {
            #region 默认蓝

            //Application["1xtop1_bgimage"]="images/top-1.gif"; //顶框背景图片
            //Application["1xtop2_bgimage"]="images/top-2.gif"; //顶框背景图片
            //Application["1xtop3_bgimage"]="images/top-3.gif"; //顶框背景图片
            //Application["1xtop4_bgimage"]="images/top-4.gif"; //顶框背景图片
            //Application["1xtop5_bgimage"]="images/top-5.gif"; //顶框背景图片
            //Application["1xtopbj_bgimage"]="images/top-bj.gif"; //顶框背景图片

            //Application["1xtopbar_bgimage"]="images/topbar_01.jpg"; //顶框工具条背景图片
            //Application["1xfirstpage_bgimage"]="images/dbsx_01.gif"; //首页背景图片
            //Application["1xforumcolor"]="#f0f4fb";
            //Application["1xleft_width"]="204"; //左框架宽度

            //Application["1xtree_bgcolor"]="#e3eeff"; //左框架树背景色
            //Application["1xleft1_bgimage"]="images/left-1.gif";
            //Application["1xleft2_bgimage"]="images/left-2.gif";
            //Application["1xleft3_bgimage"]="images/left-3.gif";
            //Application["1xleftbj_bgimage"]="images/left-bj.gif";

            //Application["1xspliter_color"]="#6B7DDE"; //分隔块色

            //Application["1xdesktop_bj"]="";//images/right-bj.gif
            //Application["1xdesktop_bgimage"]="images/desktop_01.gif";//right.gif

            //Application["1xtable_bgcolor"]="#F5F9FF"; //最外层表格背景
            //Application["1xtable_bordercolorlight"]="#4F7FC9"; //中层表格亮边框
            //Application["1xtable_bordercolordark"]="#D3D8E0"; //中层表格暗边框
            //Application["1xtable_titlebgcolor"]="#E3EFFF"; //中层表格标题栏

            //Application["1xform_requestcolor"]="#E78A29"; //表单中必填字段*颜色
            //Application["1xfirstpage_topimage"]="images/top_01.gif";
            //Application["1xfirstpage_bottomimage"]="images/bottom_01.gif";
            //Application["1xfirstpage_middleimage"]="images/bg_01.gif";

            #endregion 默认蓝
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            //Session["Style"]=1;
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            Exception objErr = Server.GetLastError().GetBaseException();
            //记录出现错误的IP地址
            string strIP = Request.UserHostAddress;
            string err = "Ip【" + strIP + "】" + Environment.NewLine + "Error in【" + Request.Url.ToString() +
                               "】" + Environment.NewLine + "Error Message【" + objErr.Message.ToString() + "】" + "Error TargetSite【" + objErr.TargetSite.ToString() + "】" + "Error Source【" + objErr.Source.ToString() + "】";
            //记录错误
            WriteError(err);
        }

        protected void Session_End(Object sender, EventArgs e)
        {
        }

        protected void Application_End(Object sender, EventArgs e)
        {
        }

        #region Web 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }

        #endregion Web 窗体设计器生成的代码

        public static void WriteError(string errorMessage)
        {
            try
            {
                string path = "~/Error/AppError/" + DateTime.Today.ToString("yyMMdd") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    w.WriteLine(errorMessage);
                    w.WriteLine("________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }
    }
}