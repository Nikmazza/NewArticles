<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryTabs.ascx.cs" Inherits="Christoc.Modules.NewArticles.CategoryTabs" %>

<asp:Repeater ID="rptTabs" runat="server">
    <HeaderTemplate>
        <ul class="dnnForm dnnAdminTabNav ArticleTabs">
        <li id='liAll' class="ui-tabs ui-tabs-nav"><a href='<%# GetLink(-1,"") %>'>All</a></li>
    </HeaderTemplate>
    <ItemTemplate><li id='li<%# DataBinder.Eval(Container.DataItem, "CategoryID")%>' class="ui-tabs ui-tabs-nav"><a href="<%# GetLink(DataBinder.Eval(Container.DataItem, "CategoryID"), DataBinder.Eval(Container.DataItem,"CategoryName")) %>"><%# DataBinder.Eval(Container.DataItem,"CategoryName") %></a></li></ItemTemplate>
    <FooterTemplate>
        </ul>
        <script type="text/javascript">
            if (<%# SelectedCategory %> == 0)
                $("#liAll").addClass("ui-tabs-active");
            else
                $("#li<%# SelectedCategory %>").addClass("ui-tabs-active");
        </script>

    </FooterTemplate>

</asp:Repeater>
