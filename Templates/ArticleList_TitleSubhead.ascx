<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" Runat="server" />
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" RepeatLayout="Flow" OnItemDataBound="Item_Bound" EnableViewState="false" CellPadding="4" Width="100%">
	<ItemTemplate>
		<div class="Article">
			<asp:HyperLink id="editLink" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
			<asp:HyperLink cssclass="Head" id="titleLink" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' />
        	<asp:Label CssClass="SubHead" id="SubHead" text='<%# DataBinder.Eval(Container.DataItem,"SubHead") %>' runat="server" />
		</div>
	</ItemTemplate>
</asp:DataList>
<asp:PlaceHolder ID="plcAddThisRSS" runat="server"></asp:PlaceHolder>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
