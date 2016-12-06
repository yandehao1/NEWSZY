<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientDiagnose_list.aspx.cs" Inherits="RuRo.PatientDiagnose_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>�����Ϣ</title>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
</head>
<body>
    <!--datagrid��-->
    <table id="PatientDiagnoseDg" title="�����Ϣ" class="easyui-datagrid" style="width: auto; height: 180px"
        fit='false'
        pagination="false" rownumbers="true"
        fitcolumns="true" singleselect="false" toolbar="#toolbarP"
        striped="false"
        selectoncheck="true" checkonselect="true" remotesort="true">
        <thead>
            <tr>
                <th field="ck" checkbox="true"></th>
                <th field="id" width="100" sortable="true" hidden="true">id</th>
                <th field="cardno" width="100" sortable="false">����</th>
                <th field="csrq00" width="100" sortable="true">��ѯ����</th>
                <th field="patientname" width="100" sortable="false">����</th>
                <th field="sex" width="100" sortable="false" hidden="true">�Ա�</th>
                <th field="brithday" width="100" sortable="false" hidden="true">��������</th>
                <th field="cardid" width="100" sortable="false" hidden="true">���֤��</th>
                <th field="tel" width="100" sortable="false" hidden="true">tel</th>
                <th field="registerno" width="100" sortable="true" hidden="true">registerno</th>
                <th field="icd" width="100" sortable="true">ICD��</th>
                <th field="diagnose" width="100" sortable="true">�������</th>
                <th field="type" width="100" sortable="true">�������</th>
                <th field="flag" width="100" sortable="true">������</th>
                <th field="diagnosedate" width="100" sortable="true">�������</th>
                <th field="isdel" width="100" sortable="true" hidden="true">isdel</th>
            </tr>
        </thead>
    </table>

    <!--toolbar��������datagrid��toolbar�Զ�������-->
    <div id="toolbarP">
        <table style="width: 100%;">
            <tr>
                <!--button��ť������-->
                <td style="text-align: right;">
                    <%--<a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonInfo" iconCls="icon-search" plain="false" onclick="infoForm();">�鿴</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonAdd" iconCls="icon-add" plain="false" onclick="newForm();">���</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonEdit" iconCls="icon-edit" plain="false" onclick="editForm();">�༭</a>--%>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="toolbarPDel" iconcls="icon-cancel" plain="false" onclick="destroy();">ɾ��</a>
                </td>
            </tr>
        </table>
    </div>

    <!--diaglog���ڣ����ڱ༭����-->
    <div id="dlg" class="easyui-dialog" closed="true"></div>

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
            var $PatientDiagnoseDg = $('#PatientDiagnoseDg');
            var row = $('#PatientDiagnoseDg').datagrid('getSelections');
            for (var i = 0; i < row.length; i++) {
                var rowIndex = $PatientDiagnoseDg.datagrid('getRowIndex', row[i]);
                $PatientDiagnoseDg.datagrid('deleteRow', rowIndex);
            }
            $("#PatientDiagnoseDg").datagrid("clearSelections");
        }

        //POST�ٴ����ݵ���̨
        function PostPatientDiagnose_list() {
            var _PatientDiagnose = $('#PatientDiagnoseDg').datagrid('getChecked');
            //if (_PatientDiagnose.length <= 0) {
            //    $.messager.alert('��ʾ', 'δѡ�������Ϣ�������ϢΪ��', 'error'); return;
            //}
            var code = $('#oldCode').textbox('getValue');
            var codeType = $('#oldCodeType').textbox('getValue');
            var count = Math.random();
            var rowPatientDiagnose = JSON.stringify(_PatientDiagnose);
            ajaxLoading();
            $.ajax({
                type: 'post',
                dataType: "json",
                url: '/Sever/PatientDiagnose.ashx' + "?count" + count,
                data: {
                    "mode": "post",
                    //"count": count,
                    "PatientDiagnoseLis": rowPatientDiagnose,
                    "code": code,
                    "codeType": codeType
                },
                success: function (data) {
                    ajaxLoadEnd();
                    if (data.success) {
                        ShowMsg("�����Ϣ��"+data.message);
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