<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:DataList id="lstArticles" CssClass="ArticleList marginTop20" runat="server" OnItemDataBound="Item_Bound" RepeatLayout="Flow" RepeatDirection="Horizontal" EnableViewState="false">
	<ItemTemplate>
		<div class="row marginTop20">
			<div class="col-xs-12 info-nota"><asp:Label id="lblFecha" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString%>'/> | <asp:Label id="lblCategories" Visible="True" runat="server" /></div>
			<div class="col-xs-12 titulo-revista">
				
				<asp:HyperLink id="editLink" runat="server" CssClass="EditIcon" Visible="False" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
				<h3><asp:Label id="lblSubHead" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"SubHead").ToString().ToUpper()%>'/></h3>
				<asp:HyperLink id="titleLink" runat="server" text='<%# "<h2>" + DataBinder.Eval(Container.DataItem,"Title") + "</h2>" %>' />
			</div>	
			<div class="col-xs-12 imagen-blog">
				<asp:Image ID="imgArticleImage" width="100%" runat="server" />
			</div>			
			<div class="col-xs-12 bajada-revista">
				<asp:Label ID="lblPendingApproval" runat="server" Visible='<%# not DataBinder.Eval(Container.DataItem,"Authed") %>' ResourceKey="PendingApproval" cssclass="NormalRed" />
				<asp:Label id="lblExpired" visible='<%# IsDBNull(DataBinder.Eval(Container.DataItem,"ExpireDate")) AND (Now >= DataBinder.Eval(Container.DataItem,"ExpireDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Expired.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"ExpireDate").ToShortDateString %>' />
				<asp:Label id="lblPublishDate" visible='<%# IsEditable AND (Now < DataBinder.Eval(Container.DataItem,"PublishDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("PublishDate.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString %>' />
				
				<p><asp:Literal id="lblDescription" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' /></p>
				<asp:HyperLink id="lnkReadMore" CssClass="btn-ver-mas" resourcekey="ReadMore" runat="server" />
				<asp:HyperLink id="lnkComments" cssclass="CommentsLink" runat="server" />
			</div>		
			<div class="col-xs-12 bajada-revista" id="area_tags" runat="server" visible="False">
				<i><b>En este art&iacute;culo:</b> <asp:Label id="lblTags" runat="server"></asp:Label></i>
			</div>
			<div class="col-xs-12 bajada-revista">
				<i><b>Visible para:</b> <asp:Label id="lblRoles" runat="server"></asp:Label></i> 
				<asp:Label id="lblEnBiblioteca" runat="server" Visible="False" Text="<b><br>INDEXADO EN BIBLIOTECA" /></b>
			</div>
		</div>
		<div class="sep-azul-fino"></div>	
	</ItemTemplate>
	<FooterTemplate>
		<asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" />
	</FooterTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>


<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
