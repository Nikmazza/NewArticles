<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentsFB.ascx.cs" Inherits="Christoc.Modules.NewArticles.CommentsFB" %>

<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>


<style>
	.fb-comments, .fb-comments * {
		width:100% !important;
	}
</style>
<asp:HiddenField ID="hidarticleid" runat="server" />
<div class="fb-comments-unloaded" data-numposts="10" data-order-by="reverse_time">
	<div class="seccionGeneral">
	    <center><img src="/Portals/0/Images/preload_comment.gif" alt="cargando"/></center>
		<center><h4>cargando comentarios</h4></center>
	</div>
</div>

<script>
	setTimeout(function(){
	var foundFBComs = false;
	$(".fb-comments-unloaded").html("");
	$('.fb-comments-unloaded').each(function(){
		var $fbCom = $(this),
		contWidth = $fbCom.parent().width();
		$fbCom.attr('data-width', contWidth)
			  .removeClass('fb-comments-unloaded')
			  .addClass('fb-comments')
              .attr('data-href', '<%= URLComentario(hidarticleid.Value)%>');
		foundFBComs = true;
	});
	if (foundFBComs && typeof FB !== 'undefined') {
		FB.XFBML.parse();
	}},7500);
</script>