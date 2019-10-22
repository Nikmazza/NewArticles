<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" OnItemDataBound="Item_Bound" RepeatLayout="Flow" RepeatDirection="Horizontal" EnableViewState="false">
	<ItemTemplate>
		<div class="Article" style="margin-bottom:10px;">
		<div class="col-xs-3">
			<asp:Image ID="imgArticleImage" runat="server" cssclass="thumbnail" />
		</div>
		<div class="col-xs-9">
			
			<asp:HyperLink id="editLink" runat="server" CssClass="EditIcon" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
			<asp:HyperLink id="titleLink" runat="server" CssClass="Head" text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' />
			<asp:Label ID="lblPendingApproval" runat="server" Visible='<%# not DataBinder.Eval(Container.DataItem,"Authed") %>' ResourceKey="PendingApproval" cssclass="NormalRed" />
			<asp:Label id="lblExpired" visible='<%# IsDBNull(DataBinder.Eval(Container.DataItem,"ExpireDate")) AND (Now >= DataBinder.Eval(Container.DataItem,"ExpireDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Expired.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"ExpireDate").ToShortDateString %>' />
			<asp:Label id="lblPublishDate" visible='<%# IsEditable AND (Now < DataBinder.Eval(Container.DataItem,"PublishDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("PublishDate.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString %>' />
		
			<asp:Label id="lblSubHead" cssclass="SubHead" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Subhead") %>' />
			<asp:Literal id="lblDescription" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' />
			<asp:HyperLink id="lnkReadMore" resourcekey="ReadMore" cssclass="altButton" runat="server" />
			<asp:HyperLink id="lnkComments" cssclass="CommentsLink" runat="server" />
			<div class="row" style="background:rgba(10,10,10,0.1)">
				<div class="col-xs-12 marginTop10">
				
				</div>
				<div class="col-xs-12">
					<b>Categor&iacute;as: </b><asp:Label id="lblCategories" runat="server" />
				</div>
				<div id="area_tags" class="col-xs-12" runat="server">
					<b>Tags: </b><asp:Label id="lblTags" runat="server" visible="True"></asp:Label>
				</div>
				<div class="col-xs-12">
					<i><b>Visible para: </b><asp:Label id="lblRoles" runat="server"></asp:Label></i>
					<br>
					<asp:Label id="lblEnBiblioteca" runat="server" Visible="False" Text="<br><b>INDEXADO EN BIBLIOTECA</b>" />
				</div>
				<div class="col-xs-12 marginTop10">
				
				</div>
			</div>
			<div class="col-xs-12 marginTop10">
				
			</div>
		</div>
	</ItemTemplate>
	<FooterTemplate>
		<div class="MoreArticlesLink"><asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
	</FooterTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>


<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
