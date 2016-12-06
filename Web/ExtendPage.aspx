﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtendPage.aspx.cs" Inherits="RuRo.Web.ExtendPage" %>

<!doctype html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <script src="../include/js/default.js"></script>
    <script src="include/js/sy_func.js"></script>
    <script src="include/js/page.js"></script>
    <script src="include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <title>信息导入</title>
</head>
<body style="overflow: auto;">
    <div id="main" style="width: 900px; padding: 1px;">
        <div class="easyui-panel">
            <div>
                <%--<a href="javascript:void(0)" id="loginOut" class="easyui-linkbutton" data-options="plain:true" style="position: absolute; right: 15px; top: 10px" onclick="loginOut()">注销</a>--%><%--注销操作，清除cookie，关闭--%>
                <%--<asp:Label ID="lakeshi" runat="server" Text=""></asp:Label>--%>
                <ul>
                    <li><b>查找患者</b></li>
                </ul>
            </div>
            <form id="querybycodeform">
                <div runat="server">
                    查找方式：
                <input id="codeType" class="easyui-combobox" name="codeType" style="width: 200px;" data-options="prompt:'请选择条码类型',required:true" />
                    <input id="code" class="easyui-textbox" name="code" data-options="prompt:'请输入条码',required:true" />
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="querybycode();">查询患者信息</a>
                </div>
            </form>
            <div style="display: none">
                <input class="easyui-textbox" id="oldCode" name="oldCode" />
                <input class="easyui-textbox" id="oldCodeType" name="oldCodeType" />
            </div>
        </div>
        <div class="h"></div>
        <div class="easyui-panel">
            <div style="padding: 2px">
                <b>基本资料：</b>
                <div class="easyui-panel" data-options="href:'Pages/EmpiInfo_info.aspx'"></div>
            </div>
            <div class="h"></div>
            <%--<div style="padding: 2px">
                <b>诊断信息：</b>
                <div class="easyui-panel" data-options="href:'Pages/PatientDiagnose_info.aspx'"></div>
            </div>--%>
            <div class="easyui-panel" data-options="href:'Pages/PatientDiagnose_list.aspx'"></div>
            <div class="h"></div>
            <div class="easyui-panel" data-options="href:'Pages/NormalLisReport_list.aspx'"></div>
        </div>
        <!--diaglog窗口，用于编辑数据-->
        <div id="dlg" class="easyui-dialog" closed="true"></div>
        <div class="h"></div>
        <div id="footer" style="padding: 5px; margin: 5px" data-options="region:'south'">
            <a href="javascript:void(0)" class="easyui-linkbutton" id="submit" style="width: auto" plain="false" onclick="postPatientInfo();">导入信息</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" id="cancleSubmit" style="width: auto" plain="false" onclick="CloseWebPage();">取消导入</a>
        </div>
    </div>
</body>
</html>