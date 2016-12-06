<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NormalLisReport_list.aspx.cs" Inherits="RuRo.NormalLisReport_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>�ٴ����</title>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
</head>
<body>
    <!--datagrid��-->
    <table id="NormalLisReportDg" title="�ٴ����" class="easyui-datagrid" style="width: auto; height: 180px"
        fit='false'
        pagination="false" rownumbers="true"
        fitcolumns="true" singleselect="false" toolbar="#toolbarN"
        striped="false"
        selectoncheck="true" checkonselect="true" remotesort="true">
        <thead>
            <tr>
                <th field="ck" checkbox="true"></th>
                <th field="id" width="100" hidden="true">id</th>
                <th field="hospnum" width="100">�����סԺ��</th>
                <th field="patname" width="100">����</th>
                <th field="sex" width="100" sortable="true" hidden="true">�Ա�</th>
                <th field="age" width="100" sortable="true" hidden="true">����</th>
                <th field="age_month" width="100" sortable="true" hidden="true">��</th>
                <th field="ext_mthd" width="100" sortable="true">��Ŀ�ܳ�</th>
                <th field="chinese" width="100" sortable="true">��Ŀ����</th>
                <th field="result" width="100" sortable="true" hidden="true">���</th>
                <th field="units" width="100" sortable="true" hidden="true">��λ</th>
                <th field="ref_flag" width="100" sortable="true">�ߵ�</th>
                <th field="lowvalue" width="100" sortable="true" hidden="true">������ֵ</th>
                <th field="highvalue" width="100" sortable="true" hidden="true">������ֵ</th>
                <th field="print_ref" width="100" sortable="true" hidden="true">������Χ</th>
                <th field="check_date" width="100" sortable="true">��׼ʱ��</th>
                <th field="check_by_name" width="100" sortable="true" hidden="true">��׼��</th>
                <th field="prnt_order" width="100" sortable="true" hidden="true">��ӡ˳�����</th>
                <th field="isdel" width="100" sortable="true" hidden="true">isdel</th>
            </tr>
        </thead>
    </table>

    <!--toolbar��������datagrid��toolbar�Զ�������-->
    <div id="toolbarN">
        <table style="width: 100%;">
            <tr>
                <!--button��ť������-->
                <td style="text-align: right;">
                    <%--<a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonInfo" iconCls="icon-search" plain="false" onclick="infoForm();">�鿴</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonAdd" iconCls="icon-add" plain="false" onclick="newForm();">���</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonEdit" iconCls="icon-edit" plain="false" onclick="editForm();">�༭</a>--%>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonDel" iconcls="icon-cancel" plain="false" onclick="destroy();">ɾ��</a>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function ShowMsg(msg) {
            $.messager.show({
                title: "��ʾ",
                msg: msg,
                timeout: 2000,
                showType: 'fade'
            });
        }
        /*ɾ��ѡ������,������¼PK���������ö���,�ֿ�*/
        function destroy() {
            var $NormalLisReportDg = $('#NormalLisReportDg');
            var row = $('#NormalLisReportDg').datagrid('getSelections');
            for (var i = 0; i < row.length; i++) {
                var rowIndex = $NormalLisReportDg.datagrid('getRowIndex', row[i]);
                $NormalLisReportDg.datagrid('deleteRow', rowIndex);
            }
            $("#NormalLisReportDg").datagrid("clearSelections");
        }

        //POST�ٴ����ݵ���̨
        function PostNormalLisReport_list() {
            var _NormalLisReport = $('#NormalLisReportDg').datagrid('getChecked');
            //if (_NormalLisReport.length <= 0) {
            //    $.messager.alert('��ʾ', 'δѡ�������Ϣ�������ϢΪ��', 'error'); return;
            //}
            var code = $('#oldCode').textbox('getValue');
            var codeType = $('#oldCodeType').textbox('getValue');
            var count = Math.random();
            var rowNormalLisReport = JSON.stringify(_NormalLisReport);
            ajaxLoading();
            $.ajax({
                type: 'post',
                dataType: "json",
                url: '/Sever/NormalLisReport.ashx' + "?count" + count,
                data: {
                    "mode": "post",
                    //"count":count,
                    "NormalLis": rowNormalLisReport,
                    "code": code,
                    "codeType": codeType
                },
                success: function (data) {
                    ajaxLoadEnd();
                    if (data.success) {
                        ShowMsg("�ٴ�������Ϣ��"+data.message);
                    }
                    else {
                        $.messager.alert('��ʾ', data.message);
                    }
                }
            });
            ajaxLoadEnd();
        }
    </script>
</body>
</html>