<%@ Control Language="vb" autoeventwireup="false" codebehind="ArticleDetailsTemplateBase.ascx.vb" Inherits="EfficionConsulting.Articles.ArticleDetailsTemplateBase" %>
<div class="Article">
	<h1><asp:Label cssclass="Head" id="lblTitle" runat="server" /></h1>
	<div style="padding-top:8px;">
		<asp:Image id="imgArticleImage" CssClass="thumbnail" Runat="server" />
		<div><asp:Label cssclass="SubHead" id="lblSubHead" runat="server" /></div>
		<div class="description">
			<asp:Literal id="litDescription" Runat="server" />
		</div>
		<div class="details">
			<asp:Literal id="litArticle" visible="<%# Authorized %>" Runat="server" />
		</div>
		<asp:Label id="lblUnauthorized" text='<%# DotNetNuke.Services.Localization.Localization.GetString("NotAuthorized.Text", LocalResourceFile)%>' visible="<%# not Authorized %>" Runat="server" cssclass="normal" />
		<asp:Panel id="pnlDetailButtonRow" CssClass="detailButtonRow" runat="server">
    		<asp:HyperLink ID="lnkPrint" cssclass="CommandButton" runat="server" rel="NoFollow" style="cursor:pointer;"><asp:image ID="imgPrint" ImageUrl="~/DesktopModules/Articles/Print.gif" AlternateText='<%# DotNetNuke.Services.Localization.Localization.GetString("imgPrint.AlternateText", LocalResourceFile)%>' runat="server" /></asp:HyperLink>
			<asp:ImageButton id="btnSendToFriend" AlternateText='<%# DotNetNuke.Services.Localization.Localization.GetString("SendToAFriend.Text", LocalResourceFile)%>' ImageUrl="~/DesktopModules/Articles/SendToAFriend.gif" runat="server" cssclass="CommandButton" />
			<a class="addthis_button" href="http://addthis.com/bookmark.php?v=250&amp;pub=xa-4af9fa4b22cd79ad"><img id="imgShare" src="http://s7.addthis.com/static/btn/v2/lg-share-en.gif" width="125" height="16" alt='<%# DotNetNuke.Services.Localization.Localization.GetString("imgShare.AlternateText", LocalResourceFile)%>' style="border:0"/></a><script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pub=xa-4af9fa4b22cd79ad"></script><br />
		</asp:Panel>
	</div>
</div>

<asp:PlaceHolder  id="phComments" runat="server" />
<hr />
<asp:LinkButton id="cmdReturn" runat="server" CssClass="CommandButton" Text='<%# DotNetNuke.Services.Localization.Localization.GetString("cmdReturn.Text", LocalResourceFile)%>' BorderStyle="none" CausesValidation="False" />
