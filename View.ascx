<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.NewArticles.View" %>
<%@ Register TagPrefix="innovaction" TagName="CategoryTabs" Src="~/DesktopModules/NewArticle/CategoryTabs.ascx" %>

<asp:panel id="SearchResultsPanel" class="SearchResultsPanel" visible="false" runat="server">
	<asp:Label ID="lblSearchResults" Visible="False" Runat="server" />
</asp:panel>
<innovaction:ViewCategoryTabs id="CategoryTabs" runat="server" />
<asp:Placeholder ID="objPlaceholder" Runat="server" />
<asp:panel id="pnlSearch" cssclass="SearchPanel" visible="false" runat="server">
	<asp:textbox id="txtSearch" runat="server" cssclass="NormalTextBox" Columns="30" maxlength="50" />&nbsp;
	<asp:requiredfieldvalidator id="valSearch" runat="server" CssClass="NormalRed" validationgroup="valSearchArticles" ErrorMessage="Please enter a search term or phrase" Display="Dynamic" ControlToValidate="txtSearch" />
	<asp:linkbutton id="cmdSearch" ResourceKey="Search" runat="server" causesvalidation="True" validationgroup="valSearchArticles" BorderStyle="none" CssClass="CommandButton" />
</asp:panel>