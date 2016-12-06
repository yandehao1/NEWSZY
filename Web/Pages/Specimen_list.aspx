<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Specimen_list.aspx.cs" Inherits="ruro.Specimen_list" %>

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
<!--datagrid��--> 
<table id="datagrid" title="Specimen" class="easyui-datagrid" style="width:auto;height:460px"
             url="Specimen_handler.ashx?mode=qry" fit='false'
             pagination="true" idField="id" rownumbers="true" 
             fitColumns="true"  singleSelect="true" toolbar="#toolbar"
             striped="false" pageList="[15,30,50,100,500]"
             SelectOnCheck="true" CheckOnSelect="true" remoteSort="true">
    <thead>    
			<tr>
			    <th field="ck" checkbox="true"></th>
                <th field="id" width="100" sortable="true">id</th>
                <th field="patientname" width="100" sortable="true">patientname</th>
                <th field="sex" width="100" sortable="true">sex</th>
                <th field="specimennum" width="100" sortable="true">specimennum</th>
                <th field="patientnum" width="100" sortable="true">patientnum</th>
                <th field="department" width="100" sortable="true">department</th>
                <th field="atsample" width="100" sortable="true">atsample</th>
                <th field="age" width="100" sortable="true">age</th>
                <th field="billingtime" width="100" sortable="true">billingtime</th>
                <th field="collectiondate" width="100" sortable="true">collectiondate</th>
                <th field="collectiontime" width="100" sortable="true">collectiontime</th>
                <th field="collectionby" width="100" sortable="true">collectionby</th>
                <th field="receivedate" width="100" sortable="true">receivedate</th>
                <th field="receivetime" width="100" sortable="true">receivetime</th>
                <th field="receiveby" width="100" sortable="true">receiveby</th>
            </tr>
    </thead>
</table>

<!--toolbar��������datagrid��toolbar�Զ�������--> 
<div id="toolbar">
<table style="width:100%;">
<tr>
    <td>
        <!--��ѯ������--> 
        <table>
            <tr>
               <!--Page����ѡ��ģʽ-->  
                <td><select onchange="$('#datagrid').datagrid({singleSelect:(this.value==0)})"><option value="0">��ѡģʽ</option><option value="1">��ѡģʽ</option></select></td>

                <!--��ѯ�ؼ�-->
                <td>
                    <!--
                    �����ֶ�<input id="so_�ֶ�����"  class="easyui-combobox" panelHeight="auto"  data-options="valueField:'������Ӧcode�ֶ���',textField:'������Ӧname�ֶ���', url:'/common/codeDataHandler.ashx?tabName=�������'"/>
                    <input id="date"     class="easyui-datebox" type="text" />
                    -->
                </td>
                <!--�����ؼ���-->
                <td><input id="so_keywords"  class="easyui-searchbox" data-options="prompt:'�������ѯ�ؼ���',searcher:searchData" ></input></td>
            </tr>
        </table> 
    </td>
    <!--button��ť������--> 
    <td  style="text-align:right;">
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonInfo" iconCls="icon-search" plain="false" onclick="infoForm();">�鿴</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonAdd" iconCls="icon-add" plain="false" onclick="newForm();">���</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonEdit" iconCls="icon-edit" plain="false" onclick="editForm();">�༭</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonDel" iconCls="icon-cancel" plain="false" onclick="destroy();">ɾ��</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonExport" iconCls="icon-save" plain="false" onclick="exportData();">����</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonPrint" iconCls="icon-print" plain="false" onclick="CreateFormPage('Specimen', $('#datagrid'));">��ӡ</a>
    </td>
</tr>
</table>  
</div>

<!--diaglog���ڣ����ڱ༭����--> 
<div id="dlg"  class="easyui-dialog" closed="true"></div>

<script type="text/javascript">
	var url;
	/*������*/
	function newForm(){
		$('#dlg').dialog({    
            title: 'Specimen-�������',    
            width: 650, 
            height: 450,    
            closed: false,  
            cache: false,    
            href: 'Specimen_info.aspx?mode=ins'
        });     
	}

	/*�鿴����*/
	function infoForm(){
		var rows = $('#datagrid').datagrid('getSelections');
	    if(rows.length>0){
	       if(rows.length==1){
				var row = $('#datagrid').datagrid('getSelected');
				$('#dlg').dialog({    
                    title: 'Specimen-�鿴����',    
                    width: 650,    
                    height: 450,    
                    closed: false,    
                    cache: true,    
                    href: 'Specimen_info.aspx?mode=inf&pk='+ row.id
                });     
			}else{ 
				$.messager.alert('����', '�鿴����ֻ��ѡ��һ������', 'warning'); 
			}  
	    }else{
	         $.messager.alert('����', '��ѡ������', 'warning');
	    }
	}

	/*�޸�����*/
	function editForm(){
		var rows = $('#datagrid').datagrid('getSelections');
	    if(rows.length>0){
	       if(rows.length==1){
				var row = $('#datagrid').datagrid('getSelected');
				$('#dlg').dialog({    
                    title: 'Specimen-�޸�����',    
                    width: 650,    
                    height: 450,    
                    closed: false,    
                    cache: true,    
                    href: 'Specimen_info.aspx?mode=upd&pk='+ row.id
                });     
			}else{ 
				$.messager.alert('����', '�޸Ĳ���ֻ��ѡ��һ������', 'warning'); 
			}  
	    }else{
	         $.messager.alert('����', '��ѡ������', 'warning');
	    }
	}

	/*ɾ��ѡ������,������¼PK���������ö���,�ֿ�*/
	function destroy(){
		var rows = $('#datagrid').datagrid('getSelections');
		if(rows.length>0){ 
				var pkSelect="";
				for(var i=0;i<rows.length;i++){
					row = rows[i];
					if(i==0){
						pkSelect+= row.id;
					}else{
						pkSelect+=','+row.id;
					}
				}
				$.messager.confirm('��ʾ','�Ƿ�ȷ��ɾ�����ݣ�',function(r){
				if (r){
						$.post('Specimen_handler.ashx?mode=del&pk='+pkSelect,function(result){
							if (result.success){
								$.messager.alert('��ʾ', result.msg, 'info',function(){
									$('#datagrid').datagrid('reload');    //���¼���������
								}); 
							} else {
								$.messager.alert('����', result.msg, 'warning');
							}
						},'json');
					}
				}); 
		}else{
			 $.messager.alert('����', '��ѡ������', 'warning');
		}
	}

	/*��ѯ������������*/
	function getSearchParm(){
		//������������׷�Ӳ�������
		/*comboboxֵ��ȡ����,��������������ѯ�������*/
		//var v_so_�ֶ����� = $('#so_�ֶ�����').combobox('getValue');
		var v_parm
		var v_so_keywords = $('#so_keywords').searchbox('getValue');
		v_parm = 'so_keywords='+escape(v_so_keywords);
		return v_parm;
	}

	/*��ѯ����*/
	function searchData(){
		/*��˵���Excel����������������datagrid����load�������ز�����ֱ����URL���ݲ���*/
		var Parm = getSearchParm();//��ò�ѯ����������������URL���ݲ�ѯ����
		var QryUrl='Specimen_handler.ashx?mode=qry&'+Parm; 
		$('#datagrid').datagrid({url:QryUrl});
	}

	/*��������*/
	function exportData(){
		var Parm = getSearchParm();//��ò�ѯ����������������URL���ݲ�ѯ����
		var QryUrl='Specimen_handler.ashx?mode=exp&'+Parm; 
		$.post(QryUrl,function(result){
			if (result.success){
				window.location.href = result.msg;
			} else {
				$.messager.alert('����', result.msg, 'warning');
			}
		},'json');
	}

    /*�ر�dialog���¼���datagrid����*/
    $('#dlg').dialog({onClose:function(){ 
        $('#datagrid').datagrid('reload'); //���¼���������
    }});

</script>

</body>
</html>
