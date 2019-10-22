<%@ Control Language="vb" autoeventwireup="false" codebehind="ArticleDetailsTemplateBase.ascx.vb" Inherits="EfficionConsulting.Articles.ArticleDetailsTemplateBase" %>
<div class="Article">
	<h1><asp:Literal id="litTitle" runat="server" /></h1>
	<div class="normal"><asp:Literal id="litArticle" visible="<%# Authorized %>" Runat="server" /></div>
	<asp:Label id="lblUnauthorized" text='<%# DotNetNuke.Services.Localization.Localization.GetString("NotAuthorized.Text", LocalResourceFile)%>' visible="<%# not Authorized %>" Runat="server" cssclass="normal" />

	<asp:Panel id="pnlDetailButtonRow" CssClass="detailButtonRow" runat="server">
		<asp:HyperLink ID="lnkPrint" runat="server" rel="NoFollow" style="cursor:pointer;"><asp:image ImageUrl="~/DesktopModules/Articles/Print.gif" alternatetext="Print" runat="server" /></asp:HyperLink>
		<asp:ImageButton id="btnSendToFriend" ImageUrl="~/DesktopModules/Articles/SendToAFriend.gif" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("SendToAFriend.Text", LocalResourceFile)%>' />
		<a class="addthis_button" href="http://addthis.com/bookmark.php?v=250&amp;pub=xa-4af9fa4b22cd79ad"><img src="http://s7.addthis.com/static/btn/v2/lg-share-en.gif" width="125" height="16" alt="Bookmark and Share" style="border:0"/></a><script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pub=xa-4af9fa4b22cd79ad"></script><br />
	</asp:Panel>
	<asp:PlaceHolder  id="phComments" runat="server" />
	<hr />
	<asp:LinkButton id="cmdReturn" resourceKey="cmdReturn" runat="server" CssClass="CommandButton" Text='<%# DotNetNuke.Services.Localization.Localization.GetString("cmdReturn.Text", LocalResourceFile)%>' BorderStyle="none" CausesValidation="False" />
</div>
