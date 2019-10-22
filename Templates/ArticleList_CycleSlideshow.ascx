<%@ Control Language="vb" Inherits="EfficionConsulting.Articles.ArticleListBase" codebehind="ArticleListBase.ascx.vb" autoeventwireup="false" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<script runat="server" >
    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.ClientScript.RegisterClientScriptInclude("Cycle", "http://ajax.aspnetcdn.com/ajax/jquery.cycle/2.99/jquery.cycle.min.js")
    End Sub
</script>

<asp:Label ID="lblMessage" Runat="server" />
<div class="rotatingArticleList">
<asp:Repeater id="rptArticles" runat="server" OnItemDataBound="RepeaterItem_Bound" EnableViewState="false" >
	<ItemTemplate>
		<asp:Panel ID="ArticleWrapper" cssclass="Article" runat="server">
			<div class="Head">
					<asp:HyperLink id="editLink" runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# EditURL("ItemID",DataBinder.Eval(Container.DataItem,"ItemID")) %>' ImageUrl="~/images/edit.gif" />
					<asp:HyperLink id="titleLink" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' />
			</div>
			<asp:Image ID="imgArticleImage" runat="server" cssclass="thumbnail" /><br/>
			<asp:Label id="lblSubHead" cssclass="SubHead" runat="server" text='<%# DataBinder.Eval(Container.DataItem,"Subhead") %>' />
			<asp:Literal id="lblDescription" runat="server" text='<%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"Description")) %>' />
			<asp:HyperLink id="lnkReadMore" text="Read More >>" cssclass="NormalBold" runat="server" />
			<% WriteTab() %>
		</asp:Panel>		
	</ItemTemplate>
</asp:Repeater>
</div>
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $('.rotatingArticleList').cycle({
			timeout:4000,
			speed:500
		});
    });
</script>
