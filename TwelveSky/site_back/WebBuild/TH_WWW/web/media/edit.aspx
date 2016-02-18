﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="_12sky2.web.media.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Twelvesky2</title>
    
    <common:layout id="common" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="main_bg">
            <div id="wrap">
                <head:layout id="head" runat="server" /> 

                <div id="C_container">
	
	                <!-- left menu -->
                    <left:layout id="left" runat="server" setTITL="Media" />
                    			        
                    <!-- content -->
                    <div id="contents">
                    	<div class="con_top">
					        <div class="nav_hint">Home &gt; Media &gt; <span id="NAV_TITL" runat="server" class="now"></span></div>
					        <div class="page_tit"><span id="PAGE_TITL" runat="server"></span></div>
				        </div>

				        <!-- contents start -->
				        <div class="content_page">                
                            
                        <script type="text/javascript">
                            function setImg(data) {
                                var seq = data.seq;
                                var filename = data.filename;
                                addFile(seq, filename);

                                if (data.imagealign) {
                                    var imageUrl = data.imageurl;
                                    var element = CKEDITOR.dom.element.createFromHtml("<img src='" + imageUrl + "'/>");
                                    CKEDITOR.instances.CNTN.insertElement(element);
                                } else {
                                    var attachurl = data.attachurl;
                                    var _add = "<div id='tmp_" + seq + "'><a href='" + attachurl + "'>" + filename + "</a>";
                                    _add += " <a href='#' onclick='delFile(" + seq + ");'>delete</a></div>";

                                    $("#TEMP_FILE_LIST").html($("#TEMP_FILE_LIST").html() + _add);

                                }
                            }

                            function addFile(seq, filename) {
                                if ($("#_fileList").val()) $("#_fileList").val($("#_fileList").val() + "," + seq);
                                else $("#_fileList").val(seq);
                            }
                            
                            function delFile(seq) {
                                var target = $("#tmp_" + seq).html();
                                $("#TEMP_FILE_LIST").html($("#TEMP_FILE_LIST").html().replace(target, ""));

                                if ($("#DEL_FILE_SEQ").val()) $("#DEL_FILE_SEQ").val($("#DEL_FILE_SEQ").val() + "," + seq);
                                else $("#DEL_FILE_SEQ").val(seq);
                            }

                            function fileDelete(seq, typ) {
                                var target = $("#file_" + seq).html();
                                $("#EDIT_FILE_LIST").html($("#EDIT_FILE_LIST").html().replace(target, ''));

                                if ($("#DEL_FILE_SEQ").val()) $("#DEL_FILE_SEQ").val($("#DEL_FILE_SEQ").val() + "," + seq);
                                else $("#DEL_FILE_SEQ").val(seq);
                                
                                if (typ == "IMAGE") {
                                    var str = CKEDITOR.instances.CNTN.getData().replace('<img src="/resources/file/image.aspx?seq=' + seq + '" />', '');
                                    CKEDITOR.instances.CNTN.setData(str);
                                }
                            }
                            
                            function imageUpload() {
                                popup("/resources/file/imageUpload.aspx", "imageUplad", 400, 250, 1);
                            }

                            function fileUpload() {
                                popup("/resources/file/fileUpload.aspx", "fileUpload", 400, 150, 1);
                            }

                            function proc_save() {
                                var str = escape(CKEDITOR.instances.CNTN.getData());
                                save(str);
                            }

                            function save(str) {
                                if (!check_field("TITL", "Please input to Title!")) return;
                                if (!check_field("_fileList", "Please insert to Image!")) return;
                                
                                $("#_title").val($("#TITL").val());
                                $("#_contents").val(str);
                                $("#FILE_SEQ").val($("#_fileList").val());
                                
                                __doPostBack('btn_save', '');
                            }
                        </script>
                        
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        </ContentTemplate>
                        </asp:UpdatePanel> 
                        
                        <asp:HiddenField ID="_fileList" runat="server" />
                        <asp:HiddenField ID="FILE_SEQ" runat="server" />
                        <asp:HiddenField ID="DEL_FILE_SEQ" runat="server" />
                        <asp:HiddenField ID="_title" runat="server" />
                        <asp:HiddenField ID="_contents" runat="server" />
                
			            <div class="con_table">
				            <table cellspacing="0" cellpadding="0" class="N_table">
				                <tbody>
                                    <tr>
                                        <td>Title</td>
                                        <td>
                                            <asp:TextBox ID="TITL" runat="server" Width="98%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Contents</td>
                                        <td>
                                            <CKEditor:CKEditorControl ID="CNTN" BasePath="/resources/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                            <div class="btn2" style="float:right; margin:10px 0;">
                                                <ul>
                                                    <li><a href="#" onclick="imageUpload();">Insert Image</a></li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Attach Image</td>
                                        <td>
                                            <div class="fileList">
                                                <span id="TEMP_FILE_LIST"></span>
                                                <span id="EDIT_FILE_LIST" runat="server"></span>
                                            </div>                            
                                        </td>
                                    </tr> 
                                </tbody>        
                            </table>
                        </div>

                        <div class="btn">
					        <ul>
					            <li><a href="#" onclick="proc_save();">SAVE</a></li>						            
						        <li><asp:LinkButton ID="btn_cancel" runat="server" ToolTip="list" onclick="btn_cancel_Click">CANCEL</asp:LinkButton></li>
						        <li><asp:LinkButton ID="btn_list" runat="server" ToolTip="list" onclick="btn_list_Click">LIST</asp:LinkButton></li>
						    </ul>
						</div>
						<asp:LinkButton ID="btn_save" runat="server" ToolTip="save" onclick="btn_save_Click"></asp:LinkButton>
                        </div>
                        <div class="page_top">
			                <a href="#"><img src="/resources/images/con_img/btn_pagetop.gif" alt="top" title="top"></a>
			            </div>
			        </div>                         
                </div>
            </div>
            
            <tail:layout id="tail" runat="server" /> 
        </div>
    </form>
</body>
</html>