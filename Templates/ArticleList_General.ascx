<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" OnItemDataBound="Item_Bound" RepeatLayout="Flow" RepeatDirection="Horizontal" EnableViewState="false">
	<ItemTemplate>
		<div class="containerNotaHome seccionGeneral">
			<h3><asp:HyperLink id="editLink" runat="server" CssClass="EditIcon" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" /> <asp:Label id="lblSubHead" CssClass="SubHead" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Subhead") %>' /></h3>
			<h2><asp:HyperLink id="titleLink" runat="server" CssClass="Head" text='<%# "(" + DataBinder.Eval(Container.DataItem, "ItemID").ToString + ") " + DataBinder.Eval(Container.DataItem, "Title") %>' /></h2>
			<asp:Image ID="imgArticleImage" runat="server"/>
			<p> <asp:Label id="lblDescription" CssClass="Content" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' /></p>
			<asp:Label ID="lblPendingApproval" runat="server" Visible='<%# not DataBinder.Eval(Container.DataItem,"Authed") %>' ResourceKey="PendingApproval" cssclass="NormalRed" />
			<asp:Label id="lblExpired" visible='<%# IsDBNull(DataBinder.Eval(Container.DataItem,"ExpireDate")) AND (Now >= DataBinder.Eval(Container.DataItem,"ExpireDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Expired.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"ExpireDate").ToShortDateString %>' />
			<asp:Label id="lblPublishDate" visible='<%# IsEditable AND (Now < DataBinder.Eval(Container.DataItem,"PublishDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("PublishDate.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString %>' />		
			<asp:HyperLink id="lnkReadMore" resourcekey="ReadMore" Visible="false" cssclass="altButton" runat="server" />
			<asp:HyperLink id="lnkComments" cssclass="CommentsLink" Visible="false" runat="server" />
			<h3>Categorias: <asp:Label id="lblCategories" runat="server" /></h3>
            <h3>Tags: <asp:Label id="lblTags" runat="server" /></h3>
		</div>
	    <hr />
	</ItemTemplate>
	<FooterTemplate>
		<asp:HyperLink id="lnkMoreArticles" Visible="false" ResourceKey="MoreArticles" runat="server" />
	</FooterTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>


<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
