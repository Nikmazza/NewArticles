<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" OnItemDataBound="Item_Bound" RepeatLayout="Flow" RepeatDirection="Horizontal" EnableViewState="false">
	<ItemTemplate>
		<div class="row">
			<div class="col-xs-12">
			<asp:Label id="lblCategories" cssclass="CategoryList" Visible="False" runat="server" />
			<asp:HyperLink id="editLink" runat="server" CssClass="EditIcon" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
			</div>
			<div class="col-xs-12 col-md-4 marginTop20">
				<asp:Image ID="imgArticleImage" width="100%" runat="server" />
			</div>
			<div class="col-xs-12 col-md-8">
				<asp:HyperLink id="titleLink" runat="server" text='<%# "<h2>" + DataBinder.Eval(Container.DataItem,"Title") + "</h2>" %>' />
				<asp:Label ID="lblPendingApproval" runat="server" Visible='<%# not DataBinder.Eval(Container.DataItem,"Authed") %>' ResourceKey="PendingApproval" cssclass="NormalRed" />
				<asp:Label id="lblExpired" visible='<%# IsDBNull(DataBinder.Eval(Container.DataItem,"ExpireDate")) AND (Now >= DataBinder.Eval(Container.DataItem,"ExpireDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("Expired.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"ExpireDate").ToShortDateString %>' />
				<asp:Label id="lblPublishDate" visible='<%# IsEditable AND (Now < DataBinder.Eval(Container.DataItem,"PublishDate")) %>' cssclass="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("PublishDate.Text", LocalResourceFile) & DataBinder.Eval(Container.DataItem,"PublishDate").ToShortDateString %>' />
				<asp:Label id="lblSubHead" cssclass="SubHead" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Subhead") %>' />
				<asp:Literal id="lblDescription" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' />
				<asp:HyperLink id="lnkReadMore" resourcekey="ReadMore" cssclass="altButton" runat="server" />
				<asp:HyperLink id="lnkComments" cssclass="CommentsLink" runat="server" />
				<div class="col-xs-12 bajada-revista" id="area_tags" runat="server" visible="False">
				<p><i><b>En este art&iacute;culo:</b> <asp:Label id="lblTags" runat="server"></asp:Label></i></p>
					<asp:Label id="lblEnBiblioteca" runat="server"></asp:Label>
					<asp:Label id="lblRoles" runat="server"></asp:Label>
				</div>
			</div>					
		</div>
		<div class="sep-azul-fino"></div>	
	</ItemTemplate>
	<FooterTemplate>
		<div class="MoreArticlesLink"><asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
	</FooterTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>


<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
