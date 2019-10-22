<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:DataList id="lstArticles" CssClass="articleConexion" runat="server" OnItemDataBound="Item_Bound" RepeatLayout="Flow" RepeatDirection="Horizontal" EnableViewState="false">
	<HeaderTemplate>
			<div class="row">
			<div class="col-xs-12">
				<h5 class="masRelacionados">ARTÍCULOS RECIENTES</h5>
			</div>
	</HeaderTemplate>
	<ItemTemplate>
		<div class="col-xs-12 masRelacionados-item">
			<div class="row no-gutters">
				<div class="col-xs-1"><i class="fa fa-link" aria-hidden="true"></i>
				</div>
				<div class="col-xs-10">
					<asp:HyperLink id="editLink" runat="server" CssClass="EditIcon" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
					<asp:HyperLink id="titleLink" runat="server" text='<%#DataBinder.Eval(Container.DataItem,"Title") %>' />
				</div>
				<div class="col-xs-1">
				</div>
				<div class="col-xs-10">
					<p><asp:Label id="lblPublishDate" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString %>' /></p>
				</div>
			</div>
		</div>
		
		
			
			<asp:Label id="lblCategories" cssclass="CategoryList" Visible="False" runat="server" />	
			<asp:Image ID="imgArticleImage" width="100%" Visible="False" runat="server" />				<asp:Label ID="lblPendingApproval" runat="server" Visible='<%# not DataBinder.Eval(Container.DataItem,"Authed") %>' ResourceKey="PendingApproval" cssclass="NormalRed" />
			<asp:Label id="lblExpired" visible='<%# IsDBNull(DataBinder.Eval(Container.DataItem,"ExpireDate")) AND (Now >= DataBinder.Eval(Container.DataItem,"ExpireDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Expired.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"ExpireDate").ToShortDateString %>' />
			
			<asp:Label id="lblSubHead" Visible="False" cssclass="SubHead" runat="server" />
			<asp:Literal id="lblDescription"  Visible="False" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' />
			<asp:HyperLink id="lnkReadMore" Visible="False" resourcekey="ReadMore" cssclass="altButton" runat="server" />
			<asp:HyperLink id="lnkComments" Visible="False" cssclass="CommentsLink" runat="server" />
			<div class="col-xs-12 bajada-revista" id="area_tags" runat="server" visible="False">
				<p><i><b>En este art&iacute;culo:</b> <asp:Label id="lblTags" runat="server"></asp:Label></i></p>
				<i><b>Visible para:</b> <asp:Label id="lblRoles" runat="server"></asp:Label></i> 
				<asp:Label id="lblEnBiblioteca" runat="server" Visible="False" Text="<b><br>INDEXADO EN BIBLIOTECA" /></b>
			</div>				
	</ItemTemplate>
	<FooterTemplate>
		<asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" />
		</div>
	</FooterTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>


<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
