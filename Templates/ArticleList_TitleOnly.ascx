<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" Runat="server" />
<div class="ArticleList">
<asp:Repeater id="rptArticles" runat="server" OnItemDataBound="RepeaterItem_Bound" EnableViewState="false" >
	<ItemTemplate>
        <div>
		    <asp:HyperLink id="editLink" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
			<asp:HyperLink cssclass="Normal" id="titleLink" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' />
			<asp:Panel ID="ArticleWrapper" cssclass="Article" visible="false" runat="server"></asp:Panel>
		</div>
	</ItemTemplate>
</asp:Repeater>
</div>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
