<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Specimen_list.aspx.cs" Inherits="RuRo.Specimen_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>Specimen</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../include/js/jquery.cookie.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="../include/css/default.css" rel="stylesheet" />
    <script src="../include/js/default.js"></script>
    <script src="../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
</head>
<body>
    <div class="easyui-panel" style="height: 95px;">
        <div>&nbsp;</div>
        <form id="querybycodeform" style="margin-left: 20px">
            <div runat="server">
                标本编号：
                <input id="code" class="easyui-textbox" name="code" data-options="prompt:'请输入条码',required:true" />
                <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="getspecimennum();">查询信息</a>
            </div>
        </form>
        <div style="display: none">
            <input class="easyui-textbox" id="oldCode" name="oldCode" />
            <input class="easyui-textbox" id="oldCodeType" name="oldCodeType" />
        </div>
    </div>
    <table id="Specimen_dg" title="样本信息" class="easyui-datagrid" style="width: auto; height: 460px"
        url="Specimen_handler.ashx?mode=qry" fit='false'
        pagination="true" idfield="id" rownumbers="true"
        fitcolumns="true" singleselect="true" toolbar="#toolbar"
        striped="false" pagelist="[10,50,100]"
        selectoncheck="true" checkonselect="true" remotesort="true">
        <thead>
            <tr>
                <%--<th field="ck" checkbox="true"></th>--%>
                <%--<th field="num" width="50" sortable="true">序号</th>--%>
                <th field="patientname" width="70" sortable="true">姓名</th>
                <th field="sex" width="60" sortable="true">性别</th>
                <th field="specimennum" width="100" sortable="true">标本编号</th>
                <th field="patientnum" width="100" sortable="true">患者编号</th>
                <th field="department" width="80" sortable="true">科室</th>
                <th field="atsample" width="90" sortable="true">样本来源</th>
                <th field="age" width="100" sortable="true">采集时年龄</th>
                <th field="billingtime" width="90" sortable="true">开单日期</th>
                <th field="collectiondate" width="90" sortable="true">采集日期</th>
                <th field="collectiontime" width="90" sortable="true">采集时间</th>
                <th field="collectionby" width="80" sortable="true">采集人</th>
                <th field="receivedate" width="100" sortable="true">接收日期</th>
                <th field="receivetime" width="100" sortable="true">接收时间</th>
                <th field="receiveby" width="80" sortable="true">接收人</th>
                <th field="Timechange" width="80" sortable="true">时差</th>
            </tr>
        </thead>
    </table>
    <div id="toolbar">
        <table style="width: 100%;">
            <tr>
                <td>
                    <%--                    <!--查询输入栏-->
                    <table>
                        <tr>
                            <!--Page数据选择模式-->
                            <td>
                                <select onchange="$('#datagrid').datagrid({singleSelect:(this.value==0)})">
                                    <option value="0">单选模式</option>
                                    <option value="1">多选模式</option>
                                </select></td>

                            <!--查询控件-->
                            <td></td>
                            <td>
                                <input id="so_keywords" class="easyui-searchbox" data-options="prompt:'请输入查询关键字',searcher:searchData"></input></td>
                        </tr>
                    </table>--%>
                </td>
                <!--button按钮工具栏-->
                <td style="text-align: right;">管数：<input class="easyui-combobox" name="ScountE" id="ScountE" style="width: 100px" data-options="required:true" />
                    体积：<input class="easyui-combobox" name="volumeE" id="volumeE" style="width: 100px" data-options="required:true" />
                    样本类型：<input class="easyui-combobox" name="sampleTypeE" id="sampleTypeE" style="width: 100px" data-options="required:true" />
                    <%--<a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonAdd" iconcls="icon-add" plain="false" onclick="newForm();">添加</a>--%>
                    <%--  <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonEdit" iconcls="icon-edit" plain="false" onclick="editForm();">编辑</a>--%>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonInfo"  plain="false" onclick="postinfoForm();">导入样本源</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonExport" iconcls="icon-save" plain="false" onclick="exportData();">导出EXCEL</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonDel" iconcls="icon-cancel" plain="false" onclick="destroy();">删除</a>
                    <%--<a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonPrint" iconcls="icon-print" plain="false" onclick="CreateFormPage('Specimen', $('#datagrid'));">打印</a>--%>
                </td>
            </tr>
        </table>
    </div>

    <!--diaglog窗口，用于编辑数据-->
    <div id="dlg" class="easyui-dialog" closed="true"></div>

    <script type="text/javascript">
        /*页面设置*/
        //样品类型
        $(function () {
            //$('#sampleTypeE').combobox({
            //    url: '../Fp_Ajax/PageConData.aspx?conMarc=SampleType',
            //    method: 'get',
            //    valueField: 'text',
            //    textField: 'text',
            //    panelHeight: 'auto',
            //    onSelect: function (rec) {
            //        var text = $('#sampleTypeE').combobox('getValue');
            //        $('#volumeE').textbox('clear');
            //        $('#volumeE').textbox('setValue', '0');
            //    }
            //});
        })
        //体积
        $(function () {
            $('#volumeE').combobox({
                valueField: 'value',
                textField: 'text',
                multiple: false,
                data: [{
                    value: '500',
                    text: '500'
                }, {
                    value: '400',
                    text: '400'
                }, {
                    value: '300',
                    text: '300'
                }, {
                    value: '200',
                    text: '200'
                }, {
                    value: '100',
                    text: '100'
                }],
                panelHeight: 'auto'
            });
        })
        //管数
        $(function () {
            $('#ScountE').combobox({
                valueField: 'value',
                textField: 'text',
                multiple: false,
                data: [{
                    value: '5',
                    text: '5'
                }, {
                    value: '4',
                    text: '4'
                }, {
                    value: '3',
                    text: '3'
                }, {
                    value: '2',
                    text: '2'
                }, {
                    value: '1',
                    text: '1'
                }],
                panelHeight: 'auto'
            });
        })
        /*页面设置-----------------------------end*/
        /*查询数据*/
        function getspecimennum() {
            $('#Specimen_dg').datagrid({
                data: [
                {
                    patientname: "kaka",
                    sex: "男",
                    specimennum: "bb123456",
                    patientnum: "hz123456",
                    department: "中心实验室",
                    atsample: "样本来源",
                    age: "12",
                    billingtime: "2016-11-11",
                    collectiondate: "2016-11-12",
                    collectiontime: "12:00",
                    collectionby: "张三",
                    receivedate: "2016-11-12",
                    receivetime: "13:00",
                    receiveby: "李四",
                    Timechange: "3.15"
                },
                                {
                                    patientname: "kaka1",
                                    sex: "男",
                                    specimennum: "bb123456",
                                    patientnum: "hz123456",
                                    department: "中心实验室",
                                    atsample: "样本来源",
                                    age: "12",
                                    billingtime: "2016-11-11",
                                    collectiondate: "2016-11-12",
                                    collectiontime: "12:00",
                                    collectionby: "张三",
                                    receivedate: "2016-11-12",
                                    receivetime: "13:00",
                                    receiveby: "李四",
                                    Timechange: "3.15"
                                }
                ]
            });
            //正式获取代码
            //var url='/Sever/Specimen_handler.ashx?mode=exp&bcode=' + code,
            //var Bcode = $('#code').textbox('getValue');//获取编号
            //if (/.*[\u4e00-\u9fa5]+.*$/.test(code)) { $.messager.alert('错误', '不能输入中文', 'error'); $('#In_Code').textbox('clear'); return; }
            //if (code.length > 14) { $.messager.alert('错误', '条码最高不能超过15位', 'error'); $('#In_Code').textbox('clear'); return; }
            //if (isEmptyStr(codeType) || isEmptyStr(code)) { $.messager.alert('提示', '请检查条码类型和条码号', 'error'); }
            //else {
            //    ajaxLoading();
            //    $.ajax({
            //        type: 'GET',
            //        url: url,
            //        success: function (data) {
            //            ajaxLoadEnd();

            //            //接收后这里写代码
            //        }
            //    });
            //}
        }
        //导入样本源
        function postinfoForm() {
            //获取信息
            var _Specimen_dg = $('#Specimen_dg').datagrid('getRows');
            var num = MathRand();
            //判断是否获取为空
            if (_Specimen_dg.length > 0) {
                var _SpJsondata = JSON.stringify(_Specimen_dg);
                ajaxLoading();
                $.ajax({
                    type: 'post',
                    datatype:"json",
                    url: '/Sever/Specimen_handler.ashx?mode=posty&num=' + num,
                    data: { spJson: _SpJsondata },
                    success: function (data) {
                        ajaxLoadEnd();
                        //接收后这里写代码
                    }
                });
            }
            else {
                $.messager.alert('警告', '请选择数据', 'error');
            }
        }
        /*导出数据*/
        function exportData() {
            var ScountE = $('#ScountE').textbox('getValue');
            var volumeE = $('#volumeE').textbox('getValue');
            var sampleTypeE = $('#sampleTypeE').textbox('getValue');
            var _Specimen_dg = $('#Specimen_dg').datagrid('getChecked');
            if (ScountE || volumeE || sampleTypeE || _Specimen_dg) {
                //上面几个不能为空
            }
            else {
                var QryUrl = 'Specimen_handler.ashx?mode=exp&' + Parm;
                $.ajax({
                    type: 'json',
                    url: '',
                    data: [ScountE, volumeE, sampleTypeE, _Specimen_dg],
                    success: function (data) {

                    }
                });
            }
        }
        /*删除选择数据,多条记录PK主键参数用逗号,分开*/
        function destroy() {
            var rows = $('#datagrid').datagrid('getSelections');
            if (rows.length > 0) {
                var pkSelect = "";
                for (var i = 0; i < rows.length; i++) {
                    row = rows[i];
                    if (i == 0) {
                        pkSelect += row.id;
                    } else {
                        pkSelect += ',' + row.id;
                    }
                }
                $.messager.confirm('提示', '是否确认删除数据？', function (r) {
                    if (r) {
                        $.post('Specimen_handler.ashx?mode=del&pk=' + pkSelect, function (result) {
                            if (result.success) {
                                $.messager.alert('提示', result.msg, 'info', function () {
                                    $('#datagrid').datagrid('reload');    //重新加载载数据
                                });
                            } else {
                                $.messager.alert('错误', result.msg, 'warning');
                            }
                        }, 'json');
                    }
                });
            } else {
                $.messager.alert('警告', '请选择数据', 'warning');
            }
        }
        //生成随机数
        function MathRand() {
            var Num = "";
            for (var i = 0; i < 6; i++) {
                Num += Math.floor(Math.random() * 10);
            }
            return Num;
        }
        /*查询条件参数构建*/
        function getSearchParm() {
            //增加条件，请追加参数名称
            /*combobox值获取方法,用于下拉条件查询条件组合*/
            //var v_so_字段名称 = $('#so_字段名称').combobox('getValue');
            var v_parm
            var v_so_keywords = $('#so_keywords').searchbox('getValue');
            v_parm = 'so_keywords=' + escape(v_so_keywords);
            return v_parm;
        }
        //采用jquery easyui loading css效果
        function ajaxLoading() {
            $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
            $("<div class=\"datagrid-mask-msg\"></div>").html("正在处理，请稍候。。。").appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
        }
        function ajaxLoadEnd() {
            $(".datagrid-mask").remove();
            $(".datagrid-mask-msg").remove();
        }
        /*关闭dialog重新加载datagrid数据*/
        $('#dlg').dialog({
            onClose: function () {
                $('#datagrid').datagrid('reload'); //重新加载载数据
            }
        });

        /*新增表单*/
        //function newForm() {
        //    $('#dlg').dialog({
        //        title: 'Specimen-添加数据',
        //        width: 650,
        //        height: 450,
        //        closed: false,
        //        cache: false,
        //        href: 'Specimen_info.aspx?mode=ins'
        //    });
        //}

        ///*查看数据*/
        //function infoForm() {
        //    var rows = $('#datagrid').datagrid('getSelections');
        //    if (rows.length > 0) {
        //        if (rows.length == 1) {
        //            var row = $('#datagrid').datagrid('getSelected');
        //            $('#dlg').dialog({
        //                title: 'Specimen-查看数据',
        //                width: 650,
        //                height: 450,
        //                closed: false,
        //                cache: true,
        //                href: 'Specimen_info.aspx?mode=inf&pk=' + row.id
        //            });
        //        } else {
        //            $.messager.alert('警告', '查看操作只能选择一条数据', 'warning');
        //        }
        //    } else {
        //        $.messager.alert('警告', '请选择数据', 'warning');
        //    }
        //}

        ///*修改数据*/
        //function editForm() {
        //    var rows = $('#datagrid').datagrid('getSelections');
        //    if (rows.length > 0) {
        //        if (rows.length == 1) {
        //            var row = $('#datagrid').datagrid('getSelected');
        //            $('#dlg').dialog({
        //                title: 'Specimen-修改数据',
        //                width: 650,
        //                height: 450,
        //                closed: false,
        //                cache: true,
        //                href: 'Specimen_info.aspx?mode=upd&pk=' + row.id
        //            });
        //        } else {
        //            $.messager.alert('警告', '修改操作只能选择一条数据', 'warning');
        //        }
        //    } else {
        //        $.messager.alert('警告', '请选择数据', 'warning');
        //    }
        //}
        ///*查询条件参数构建*/
        //function getSearchParm() {
        //    //增加条件，请追加参数名称
        //    /*combobox值获取方法,用于下拉条件查询条件组合*/
        //    //var v_so_字段名称 = $('#so_字段名称').combobox('getValue');
        //    var v_parm
        //    var v_so_keywords = $('#so_keywords').searchbox('getValue');
        //    v_parm = 'so_keywords=' + escape(v_so_keywords);
        //    return v_parm;
        //}

        ///*查询数据*/
        //function searchData() {
        //    /*兼顾导出Excel公用条件，在这里datagrid不用load函数加载参数，直接用URL传递参数*/
        //    var Parm = getSearchParm();//获得查询条件参数构建，用URL传递查询参数
        //    var QryUrl = 'Specimen_handler.ashx?mode=qry&' + Parm;
        //    $('#datagrid').datagrid({ url: QryUrl });
        //}
    </script>

</body>
</html>
