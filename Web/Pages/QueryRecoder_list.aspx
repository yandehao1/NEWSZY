<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryRecoder_list.aspx.cs" Inherits="RuRo.QueryRecoder_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>QueryRecoder</title>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link href="../include/css/kfmis.css" rel="stylesheet" />
</head>
<body>
    <!--datagrid��-->
    <table id="QueryRecoderDg" title="��������" class="easyui-datagrid" style="width: auto; height: 460px"
        url="" fit='false'
        pagination="true" rownumbers="true"
        fitcolumns="true" singleselect="false" toolbar="#toolbarN"
        striped="false"
        selectoncheck="true" checkonselect="true" remotesort="true">
        <thead>
            <tr>
                <th field="ck" checkbox="true"></th>
                <th field="Id" sortable="true" hidden="true">id</th>
                <th field="Uname" width="100" sortable="true">��ѯ���û�</th>
                <th field="AddDate" width="100" sortable="true">���ʱ��</th>
                <th field="LastQueryDate" width="100" sortable="true">���һ�β�ѯ����</th>
                <th field="Code" width="100" sortable="true">��ѯ�������</th>
                <th field="CodeType" width="100" sortable="true" hidden="true">���������</th>
                <th field="QueryType" width="100" sortable="true">��ѯ����������</th>
                <th field="QueryResult" width="100" sortable="true">��ѯ���</th>
                <th field="IsDel" width="100" sortable="true" hidden="true">isdel</th>
            </tr>
        </thead>
    </table>

    <!--toolbar��������datagrid��toolbar�Զ�������-->
    <!--toolbar��������datagrid��toolbar�Զ�������-->
    <div id="toolbarN">
        <table style="width: 100%;">
            <tr>
                <!--button��ť������-->
                <td style="text-align: right;">
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonInfo" iconcls="icon-search" plain="false" onclick="infoForm();">��ѯ</a>
                    <%--<a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonAdd" iconCls="icon-add" plain="false" onclick="newForm();">���</a>--%>
                    <%--<a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonEdit" iconCls="icon-edit" plain="false" onclick="editForm();">�༭</a>--%>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonDel" iconcls="icon-cancel" plain="false" onclick="destroy();">ɾ��</a>
                </td>
            </tr>
        </table>
    </div>

    <div id="footer" style="padding: 5px; margin: 10px" data-options="region:'south',">
        <a href="javascript:void(0)" class="easyui-linkbutton" id="submit" style="width: auto" onclick="postQueryRecoder()">������Ϣ</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="cancleSubmit" style="width: auto" onclick="CloseWebPage()">ȡ������</a>
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
        //���÷�ҳ
        $(function () {
            $("#QueryRecoderDg").datagrid("getPager").pagination({
                beforePageText: '��',
                afterPageText: 'ҳ    �� {pages} ҳ',
                pageList: [10],
                displayMsg: "��ʾ {from} �� {to} ����¼ ,  �� {total} ����¼",
                onSelectPage: function (pageNumber, pageSize) {
                    var page = pageNumber;
                    var myDate = new Date();
                    var year = myDate.getFullYear();       //��
                    var month = myDate.getMonth() + 1;     //��
                    var day = myDate.getDate();
                    var adddate = year + "-" + month + "-" + day
                    $.ajax({
                        type: "POST",
                        url: "/Sever/QueryRecoder_handler.ashx?mode=qryt",
                        data: {
                            "mode": "qryt",
                            "adddate": adddate,
                            "pageNum": pageNumber,
                            "pageSize": pageSize
                        },
                        success: function (data) {
                            var obj = $.parseJSON(data);
                            if (obj.Qdata == "") {
                            }
                            else {
                                var Qdata = $.parseJSON(obj.Qdata);
                                var total = Number(obj.total);
                                for (var i = 0; i < Qdata.length; i++) {
                                    var txtadddate = Qdata[i].AddDate.substring(0, 10);
                                    Qdata[i].AddDate = txtadddate;
                                    var txtqueryDate = Qdata[i].LastQueryDate.substring(0, 10);
                                    Qdata[i].LastQueryDate = txtqueryDate;
                                }
                                $('#QueryRecoderDg').datagrid('loadData', Qdata).datagrid('reload');
                                $("#QueryRecoderDg").datagrid("getPager").pagination({ total: total, pageNumber: page });
                            }
                        }
                    });
                }
            });
        })
        /*ɾ��ѡ������,������¼PK���������ö���,�ֿ�*/

        function destroy() {
            var $QueryRecoderDg = $('#QueryRecoderDg');
            var row = $('#QueryRecoderDg').datagrid('getSelections');
            var pk = "";
            for (var i = 0; i < row.length; i++) {
                var rowIndex = $QueryRecoderDg.datagrid('getRowIndex', row[i]);
                pk = pk + row[i].Id + ",";
                $QueryRecoderDg.datagrid('deleteRow', rowIndex);
            }
            //ɾ�����ݿ�����
            $.ajax({
                type: "POST",
                url: "/Sever/QueryRecoder_handler.ashx?mode=del",
                data: {
                    "mode": "del",
                    "pk": pk
                },
                success: function (data) { $.messager.alert('��ʾ', data); return; }
            });
            $("#QueryRecoderDg").datagrid("clearSelections");
        }
        //��ѯ����
        function infoForm() {
            var myDate = new Date();
            var year = myDate.getFullYear();       //��
            var month = myDate.getMonth() + 1;     //��
            var day = myDate.getDate();
            var adddate = year + "-" + month + "-" + day
            $.ajax({
                type: "POST",
                url: "/Sever/QueryRecoder_handler.ashx?mode=qryt",
                data: {
                    "mode": "qryt",
                    "adddate": adddate,
                    "pageNum": 1,
                    "pageSize": 10
                },
                success: function (data) {
                    var obj = $.parseJSON(data);
                    if (obj.Qdata == "") { $.messager.alert('����', '��ѯ��������', 'error'); }
                    else
                    {
                        var Qdata = $.parseJSON(obj.Qdata);
                        var total = Number(obj.total);
                        for (var i = 0; i < Qdata.length; i++) {
                            var txtadddate = Qdata[i].AddDate.substring(0, 10);
                            Qdata[i].AddDate = txtadddate;
                            var txtqueryDate = "";
                            if (Qdata[i].LastQueryDate != null) { txtqueryDate = Qdata[i].LastQueryDate.substring(0, 10); }
                            Qdata[i].LastQueryDate = txtqueryDate;
                        }
                        $('#QueryRecoderDg').datagrid('loadData', Qdata).datagrid('reload');
                        $("#QueryRecoderDg").datagrid("getPager").pagination({ total: total });
                    }
                }
            });
        }
        //�ϴ�����
        function postQueryRecoder() {
            var _QueryRecoder = $('#QueryRecoderDg').datagrid('getChecked');
            if (_QueryRecoder.length <= 0) { $.messager.alert('��ʾ', 'δѡ������Ϣ������ϢΪ��', 'error'); return; }
            var count = Math.random();
            var rowQueryRecoder = JSON.stringify(_QueryRecoder);
            ajaxLoading();
            $.ajax({
                type: 'post',
                dataType: "json",
                url: '/Sever/QueryRecoder_handler.ashx' + "?count" + count,
                data: {
                    "mode": "post",
                    //"count": count,
                    "Recoder": rowQueryRecoder
                },
                success: function (data) {
                    ajaxLoadEnd();
                    ShowMsg(data.message);
                    return;
                }
            });
            ajaxLoadEnd();
        }
        //����jquery easyui loading cssЧ��
        function ajaxLoading() {
            $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
            $("<div class=\"datagrid-mask-msg\"></div>").html("���ڴ������Ժ򡣡���").appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
        }
        function ajaxLoadEnd() {
            $(".datagrid-mask").remove();
            $(".datagrid-mask-msg").remove();
        }
    </script>
</body>
</html>