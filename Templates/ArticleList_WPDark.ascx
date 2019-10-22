<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" Runat="server" />
<asp:DataList id="lstArticles" CssClass="ArticleList WPDark" runat="server" OnItemDataBound="Item_Bound" EnableViewState="false" CellPadding="4" Width="100%">
	<ItemTemplate>
		<div class="Article">
		<div class="Head">
				<asp:HyperLink id="editLink" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
				<asp:HyperLink id="titleLink" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' />
		</div>
			<asp:Label ID="lblPendingApproval" runat="server" Visible='<%# not DataBinder.Eval(Container.DataItem,"Authed") %>' ResourceKey="PendingApproval" cssclass="NormalRed" />
			<asp:Label id="lblExpired" visible='<%# IsDBNull(DataBinder.Eval(Container.DataItem,"ExpireDate")) AND (Now >= DataBinder.Eval(Container.DataItem,"ExpireDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Expired.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"ExpireDate").ToShortDateString %>' />
			<div class="normal">
				<asp:Image ID="imgArticleImage" runat="server" cssclass="thumbnail" />
				<asp:Label id="lblSubHead" cssclass="SubHead" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Subhead") %>' />
				<asp:Literal id="lblDescription" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' />
				<asp:HyperLink id="lnkReadMore" resourcekey="ReadMore" runat="server" />
			</div>
			<div class="postinfo">
				<asp:literal id="litAuthor" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"AuthorFullName") %>' /> |
				<asp:literal id="litPublishDate" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString %>' /> |
				<asp:HyperLink id="lnkComments" runat="server" /> |
				<asp:Label id="lblCategories" runat="server" />
			</div>
		</div>
	</ItemTemplate>
	<FooterTemplate>
		<div class="MoreArticlesLink"><asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
	</FooterTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>


<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
