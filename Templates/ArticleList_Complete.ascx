<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" Runat="server" />
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" RepeatLayout="Flow" OnItemDataBound="Item_Bound" EnableViewState="false" CellPadding="4" Width="100%">
	<ItemTemplate>
		<div>
			<asp:HyperLink id="editLink" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
			<asp:HyperLink cssclass="Head" id="titleLink" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' />
		</div>
		<div>
			<asp:Label ID="lblPendingApproval" runat="server" Visible='<%# not DataBinder.Eval(Container.DataItem,"Authed") %>' ResourceKey="PendingApproval" cssclass="NormalRed" />
			<asp:Label id="lblExpired" visible='<%# IsDBNull(DataBinder.Eval(Container.DataItem,"ExpireDate")) AND (Now >= DataBinder.Eval(Container.DataItem,"ExpireDate")) %>' class="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Expired.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"ExpireDate").ToShortDateString %>' />
			<asp:Label id="lblAuthor" cssclass="Author" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Author.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"AuthorFullName") %>' /><br>
			<asp:Label id="lblPublishDate" runat="server" cssclass="PublishDate" text='<%# DotNetNuke.Services.Localization.Localization.GetString("PublishDate.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString %>' /><br>
			<asp:Label id="lblViews" runat="server" cssclass="NormalBold" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Views.Text", LocalResourceFile) & ": " & DataBinder.Eval(Container.DataItem,"NumberOfViews").ToString %>' /><br>
			<asp:Label id="lblSubHead" runat="server" cssclass="SubHead" ResourceKey="SubHead" text='<%# DataBinder.Eval(Container.DataItem,"SubHead") %>' />
		</div>
		<div>
			<asp:Image ID="imgArticleImage" runat="server" />
			<asp:Literal id="lblDescription" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' />
		    <asp:HyperLink id="lnkReadMore" ResourceKey="ReadMore" visible="false" cssclass="NormalBold" runat="server" />
		</div>
		<asp:HyperLink id="lnkComments" cssclass="CommentsLink" runat="server" />
		<br />
	</ItemTemplate>
	<FooterTemplate>
		<div class="MoreArticlesLink"><asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
	</FooterTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
