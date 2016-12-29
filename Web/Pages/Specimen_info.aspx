<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Specimen_info.aspx.cs" Inherits="RuRo.Specimen_info" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head">
<title>Specimen</title>
    <link rel="stylesheet" type="text/css" href="/js/easyui/themes/default/easyui.css" />
	<link rel="stylesheet" type="text/css" href="/js/easyui/themes/icon.css" />
	<script type="text/javascript" src="/js/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="/js/easyui/jquery.easyui.min.js"></script>
	<script type="text/javascript" src="/js/easyui/locale/easyui-lang-zh_CN.js"></script>
	<script type="text/javascript" src="/js/gridPrint.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/kfmis.css"/>
</head>
<body>
<!--存储参数属性input控件，判断是新增还是修改--> 
<input value=""  id="mode" type="text" style="display:none"  runat="server"  />
<input value=""  id="pk" type="text"   style="display:none" runat="server"  />
<!--编辑数据--> 
<!--编辑容器，按钮固定在底部--> 
<div class="easyui-layout" data-options="fit:true">
<div data-options="region:'center',split:true" style="width:100px;padding:10px">
<div id="printBody"> 
<div class="ftitle">Specimen</div>
    <form id="frmAjax" method="post" novalidate>
        <!--如需控制表单控件为必填项，请增加class="easyui-validatebox" required="true" -->
        <div class="fitem">
            <div class="label">id:</div>
            <div class="control"><input id="id"  name="id"  disabled="disabled" /></div>
        </div>
        <div class="fitem">
            <div class="label">patientname:</div>
            <div class="control"><input  id="patientname"  name="patientname"   /></div>
        </div>
        <div class="fitem">
            <div class="label">sex:</div>
            <div class="control"><input  id="sex"  name="sex"   /></div>
        </div>
        <div class="fitem">
            <div class="label">specimennum:</div>
            <div class="control"><input  id="specimennum"  name="specimennum"   /></div>
        </div>
        <div class="fitem">
            <div class="label">patientnum:</div>
            <div class="control"><input  id="patientnum"  name="patientnum"   /></div>
        </div>
        <div class="fitem">
            <div class="label">department:</div>
            <div class="control"><input  id="department"  name="department"   /></div>
        </div>
        <div class="fitem">
            <div class="label">atsample:</div>
            <div class="control"><input  id="atsample"  name="atsample"   /></div>
        </div>
        <div class="fitem">
            <div class="label">age:</div>
            <div class="control"><input  id="age"  name="age"   /></div>
        </div>
        <div class="fitem">
            <div class="label">billingtime:</div>
            <div class="control"><input  id="billingtime"  name="billingtime"   /></div>
        </div>
        <div class="fitem">
            <div class="label">collectiondate:</div>
            <div class="control"><input  id="collectiondate"  name="collectiondate"   /></div>
        </div>
        <div class="fitem">
            <div class="label">collectiontime:</div>
            <div class="control"><input  id="collectiontime"  name="collectiontime"   /></div>
        </div>
        <div class="fitem">
            <div class="label">collectionby:</div>
            <div class="control"><input  id="collectionby"  name="collectionby"   /></div>
        </div>
        <div class="fitem">
            <div class="label">receivedate:</div>
            <div class="control"><input  id="receivedate"  name="receivedate"   /></div>
        </div>
        <div class="fitem">
            <div class="label">receivetime:</div>
            <div class="control"><input  id="receivetime"  name="receivetime"   /></div>
        </div>
        <div class="fitem">
            <div class="label">receiveby:</div>
            <div class="control"><input  id="receiveby"  name="receiveby"   /></div>
        </div>
    </form>
<div class="ftitle"></div>
</div>
</div>

<div data-options="region:'south'" style="height:40px; background:#f2f2f2;">
<!--按钮-->
<div class="fsubmit">
	<a href="javascript:void(0)" id="linkbuttonSave" class="easyui-linkbutton" iconCls="icon-ok" onclick="saveForm()">保存</a>
	<a href="javascript:void(0)" id="linkbuttonClear" class="easyui-linkbutton" iconCls="icon-back" onclick="clearForm();">清空</a>
	<a href="javascript:void(0)" id="linkbuttonPrint" class="easyui-linkbutton" iconCls="icon-print" onclick="printPage('printBody');">打印</a>
	<a href="javascript:void(0)" id="linkbuttonColse" class="easyui-linkbutton" iconCls="icon-cancel" onclick="$('#dlg').dialog('close');">关闭</a>
</div>
</div>
</div>

<script type="text/javascript">
var mode = $('#mode').val();
var pk =  $('#pk').val();

/*编辑或查看状态下控件赋值*/
if(mode=='upd'|| mode=='inf'){ 
    url = 'Specimen_handler.ashx?mode=inf&pk='+pk; 
    $.post(url,function(data){ 
         $('#frmAjax').form('load',data);
    },'json');
    $('#linkbuttonClear').linkbutton({disabled:true});
}

/*查看状态下disabled控件*/
if(mode=='inf'){ 
    $('#linkbuttonSave').linkbutton({disabled:true});
    $('input').attr('disabled','disabled');
    $('textarea').attr('disabled','disabled');
}

if(mode=='ins') url = 'Specimen_handler.ashx?mode=ins';
if(mode=='upd') url = 'Specimen_handler.ashx?mode=upd&pk='+pk;

/*清空充填*/
function clearForm(){
    $('#frmAjax').form('clear');
}

	/*保存表单数据*/
	function saveForm() {
	    var validate = true;
	    /*验证validatebox必填项*/
        try{
	        if($('#frmAjax').find('.easyui-validatebox').val() == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查必填项是否正确填写！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

        /*验证datebox日期*/
        try{
	        if($('#frmAjax').find('.easyui-datebox').datebox('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查日期是否正确选择！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

        /*验证datetimebox日期*/
        try{
	        if($('#frmAjax').find('.easyui-datetimebox').datetimebox('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查日期是否正确选择！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

	    /*验证numberbox数字*/
	    try{
	        if($('#frmAjax').find('.easyui-numberbox').numberbox('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查必填数字项是否正确填写！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

	    /*验证combobox必选项*/ 
	    try{
	        if($('#frmAjax').find('.easyui-combobox').combobox('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查必选项是否正确选择！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

	    /*验证combogrid必选项*/ 
	    try{
	        if($('#frmAjax').find('.easyui-combogrid').combogrid('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查必选项是否正确选择！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}
        /*URL支持参数受限制，小字段表使用
		if (validate==true){
			var Parm = $('#frmAjax').serialize();
			var saveUrl = url + '&' + Parm; 
			$.post(saveUrl, function (result) {
				if (result.success) {
					$('#dlg').dialog('close');
					$.messager.alert('提示',result.msg, 'info',function(){
						$('#datagrid').datagrid('reload'); // 重新加载数据
					});
				} else {
					$.messager.alert('警告', result.msg, 'warning');   //错误消息
				}
			}, 'json');
		}
		*/



		/*URL支持参数受限制，可采用submit,post提交Ajax表单*/
		if (validate==true){
		    $('#frmAjax').form('submit',{  
		        url:url,
                success: function(result){
                        resultJSON = $.parseJSON(result); 
                        if (resultJSON.success) {
					        $('#dlg').dialog('close');
					        $.messager.alert('提示',resultJSON.msg, 'info',function(){
						        $('#datagrid').datagrid('reload'); // 重新加载数据
					        });
				        } else {
					        $.messager.alert('警告', resultJSON.msg, 'warning');   //错误消息
				        }
                }  
            });
        }

	}

</script>

</body>
</html>
