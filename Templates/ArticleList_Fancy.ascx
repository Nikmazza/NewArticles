<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" Runat="server" />
<style type="text/css">
.FancyHeader {
	background-color: #AA0700;
	color: white;
	vertical-align:top;
	padding:5px;
	border: 1px solid #513500;
	border-bottom:0px;
	-moz-border-radius: 8px 8px 0 0;
	-webkit-border-top-left-radius: 8px;
	-webkit-border-top-right-radius: 8px;	
}
.FancyHeader .Head, .CategoryList {
	color: white;
	font-weight: bold;
	font-size: 14px;
}
.FancyBody {
	background-color: #E1D5BB;
	color: #91856B;
	padding:5px;
	border: 1px solid #513500;
	border-top: 1px dotted #513500;
	-moz-border-radius: 0 0 8px 8px;
	-webkit-border-bottom-left-radius: 8px;
	-webkit-border-bottom-right-radius: 8px;	
}
.FancyHR {
	border-top: 1px dotted black;
	height: 0px;
}
</style>
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" OnItemDataBound="Item_Bound" EnableViewState="false" CellPadding="4" Width="100%">
	<SeparatorTemplate><hr class="FancyHR"></SeparatorTemplate>
	<ItemTemplate>
		<table cellpadding="0" cellspacing="0" style="width:100%;">
			<tr>
				<td class="FancyHeader">
					<asp:Label id="lblCategories" style="float:right;" cssclass="CategoryList" runat="server" />

					<asp:HyperLink id="editLink" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
					<asp:HyperLink id="titleLink" cssclass="Head" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' />
				</td>
			</tr>
			<tr>
				<td class="FancyBody">
					<div>
						<asp:Label ID="lblPendingApproval" runat="server" Visible='<%# not DataBinder.Eval(Container.DataItem,"Authed") %>' ResourceKey="PendingApproval" class="NormalRed" />
						<asp:Label id="lblExpired" visible='<%# IsDBNull(DataBinder.Eval(Container.DataItem,"ExpireDate")) AND (Now >= DataBinder.Eval(Container.DataItem,"ExpireDate")) %>' class="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Expired.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"ExpireDate").ToShortDateString %>' />
						<asp:Label id="lblPublishDate" visible='<%# IsEditable AND (Now < DataBinder.Eval(Container.DataItem,"PublishDate")) %>' class="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("PublishDate.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString %>' />
					</div>
					<asp:Image ID="imgArticleImage" runat="server" vspace="3" hspace="3" />
					<asp:Literal id="lblDescription" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' />
					<asp:HyperLink id="lnkReadMore" ResourceKey="ReadMore" visible="false" class="NormalBold" runat="server" />
					<asp:HyperLink id="lnkComments" class="CommentsLink" runat="server" />
				</td>
			</tr>
		</table>
	</ItemTemplate>
	<FooterTemplate>
		<div class="MoreArticlesLink"><asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
	</FooterTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
