<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="Christoc.Modules.NewArticles.Settings" %>
<%@ Register TagPrefix="dnn" TagName="DualList" Src="~/controls/DualListControl.ascx" %>


<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
<div class="dnnForm dnnClear" style="padding:10px;">
    <h2 id="BasicHead" class="dnnFormSectionHead"><a href="#">Basic Settings</a></h2>
    <fieldset title="Basic Settings">
	    <div class="dnnFormItem">
		    <asp:Label id="plTemplate" runat="server" suffix=":" />
		    <asp:DropDownList id="drpTemplate" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plDetailsTemplate" runat="server" suffix=":" />
		    <asp:DropDownList id="drpDetailsTemplate" runat="server" />
	    </div>
	    <div class="dnnFormItem">
	        <asp:Label ID="plPrintTemplate" runat="server" Suffix=":" />
	        <asp:DropDownList ID="drpPrintTemplate" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plDefaultDetailType" runat="server" suffix=":" />
		    <asp:DropDownList id="drpDefaultDetailType" runat="server">
			    <asp:ListItem Value="NoLink" ResourceKey="detailTypeNone" />
			    <asp:ListItem Value="HTML" ResourceKey="detailTypeHTML"/>
			    <asp:ListItem Value="Internal" ResourceKey="detailTypeInternal" />
			    <asp:ListItem Value="External" ResourceKey="detailTypeExternal" />
			    <asp:ListItem Value="File" ResourceKey="detailTypeFile" />
		    </asp:DropDownList>
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plDetailDisplay" runat="server" controlname="rblDetailDisplay" suffix=":" />
		    <asp:RadioButtonList id="rblDetailDisplay" cssclass="Normal" RepeatDirection="Horizontal" runat="server">
			    <asp:ListItem Value="SamePage" ResourceKey="DetailDisplaySamePage" />
			    <asp:ListItem Value="NewPage" ResourceKey="DetailDisplayNewPage" />
			    <asp:ListItem Value="OtherModule" ResourceKey="DetailDisplayOtherModule" />
		    </asp:RadioButtonList>
		    <div id="divDetailDisplayOtherModule" runat="server">
			    <div class="SubHead"><asp:Label id="plDetailDisplaySelectOtherModule" runat="server" suffix=":" /></div>
			    <asp:DropDownList id="ddlOtherModule" datavaluefield="ListValue" datatextfield="ListText" runat="server" />
		    </div>	
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plSortField" runat="server" controlname="drpSortField" suffix=":" />
		    <asp:DropDownList id="drpSortField" runat="server">
			    <asp:ListItem Value="CreationDate" Selected="True" ResourceKey="SortFieldCreationDate" />
			    <asp:ListItem Value="PublishDate" ResourceKey="SortFieldPublishDate" />
			    <asp:ListItem Value="ExpireDate" ResourceKey="SortFieldExpireDate" />
			    <asp:ListItem Value="LastModifiedDate" ResourceKey="SortFieldLastModifiedDate" />
			    <asp:ListItem Value="Title" ResourceKey="SortFieldTitle" />
                <asp:ListItem Value="NroSemana" ResourceKey="SortFieldNroSemana" />
			    <asp:ListItem Value="Random" ResourceKey="SortFieldRandom" />
		    </asp:DropDownList>
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plArticlesPerPage" runat="server" controlname="drpNumber" suffix=":" />
		    <asp:textbox id="txtArticlesPerPage" MaxLength="3" Columns="2" runat="server" />
		    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^\d+$" ControlToValidate="txtArticlesPerPage" ErrorMessage="Must be a positive number." Display="Dynamic" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plImages" runat="server" suffix=":" />
		    <div style="float:left;">
			    <asp:checkbox id="chkResizeImages" ResourceKey="chkResizeImages" runat="server" />
                <br />
			    <div id="divImageWidth">
				    <asp:label id="plImageWidth" resourcekey="plImageWidth" runat="server" controlname="txtImageWidth" suffix=":" />
				    <asp:TextBox id="txtImageWidth" Width="60" runat="server" /> px
				    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="^\d+$" ControlToValidate="txtImageWidth" ErrorMessage="Must be a positive number." Display="Dynamic" runat="server" />
			    </div>
		    </div>
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plImageAlignment" runat="server" suffix=":" />
		    <asp:DropDownList id="drpImageAlignment" runat="server">
			    <asp:ListItem Value="" ResourceKey="Left" />
			    <asp:ListItem Value="2" ResourceKey="Right"/>
			    <asp:ListItem Value="Alternate" ResourceKey="Alternate" />
			    <asp:ListItem Value="4" ResourceKey="Top" />
			    <asp:ListItem Value="3" ResourceKey="Baseline" />
			    <asp:ListItem Value="5" ResourceKey="Middle" />
		    </asp:DropDownList>
	    </div>
    </fieldset>
    <h2 id="FiltersHead" class="dnnFormSectionHead"><a href="#">Filters</a></h2>
    <fieldset class="dnnClear">
	    <div class="dnnFormItem">
        </div>
        <div class="dnnFormItem">
		    <asp:Label id="plCategory" runat="server" controlname="ctlCategories" suffix=":" />
		    <asp:Label id="lblNoCategories" runat="server" Visible="false" ResourceKey="lblNoCategories" />
		    <div ID="CategoryOptions" runat="server" style="float:left;">
			    <asp:checkbox id="chkRequireCategory" cssclass="SubHead" ResourceKey="chkRequireCategory" runat="server" /><br />
			    <asp:CheckBox id="chkFilterByCategory" cssclass="SubHead" ResourceKey="chkFilterByCategory" runat="server" />
			    <asp:CheckBox id="chkDisplayCategoryTabs" cssclass="SubHead" ResourceKey="chkDisplayCategoryTabs" runat="server" />
                <div id="CategorySelector" style="border: #ccc 1px solid;border-radius:8px;padding:8px;margin-bottom:5px;" runat="server">
			        <asp:CheckBoxList id="cblCategories" RepeatColumns="3" CssClass="Normal" runat="server" />
                </div>
		    </div>
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plDateRange" runat="server" controlname="drpDateRange" suffix=":" />
		    <asp:DropDownList id="drpDateRange" runat="server">
			    <asp:ListItem Value="-1" Selected="True" ResourceKey="NoRestriction" />
			    <asp:ListItem Value="-7" ResourceKey="dateRange1Week" />
			    <asp:ListItem Value="-14" ResourceKey="dateRange2Weeks" />
			    <asp:ListItem Value="-30" ResourceKey="dateRange1Month" />
			    <asp:ListItem Value="-90" ResourceKey="dateRange3Months" />
			    <asp:ListItem Value="-180" ResourceKey="dateRange6Months" />
			    <asp:ListItem Value="-365" ResourceKey="dateRange1Year" />
		    </asp:DropDownList>
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plSiteWide" runat="server" controlname="chkSiteWide" suffix=":" />
		    <asp:checkbox id="chkSiteWide" runat="server" />
	    </div>
	    <div runat="server" id="trDisableAddNew">
		    <asp:Label id="plDisableAddNew" runat="server" controlname="chkDisableAddNew" suffix=":" />
		    <asp:CheckBox ID="chkDisableAddNew" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plFeatured" runat="server" controlname="chkFeatured" suffix=":" />
		    <asp:checkbox id="chkFeatured" runat="server" />
	    </div>
    </fieldset>
    <h2 id="CommentsHead" class="dnnFormSectionHead"><a href="#">Comments</a></h2>
    <fieldset title="Comments" class="dnnClear">
	    <div class="dnnFormItem">
		    <asp:Label id="plAllowComments" runat="server" suffix=":" />
			<asp:CheckBox id="chkAllowComments" ResourceKey="chkAllowComments" runat="server" />
        </div>
		<div id="CommentOptions" runat="server">
	        <div class="dnnFormItem">
		        <asp:Label id="Label2" runat="server" Text="Comment Options" suffix=":" />
                <asp:CheckBox id="chkAnonymousComments" ResourceKey="chkAnonymousComments" runat="server" />
                <asp:CheckBox ID="chkModerateComments" ResourceKey="chkModerateComments" runat="server" />
            </div>
	        <div id="trModerationScope" runat="server">
		        <asp:Label id="plCMScope" runat="server" suffix=":" />
		        <asp:RadioButtonList id="rbModerationScope" cssclass="Normal" RepeatDirection="Horizontal" runat="server" >
				    <asp:listitem ResourceKey="liCMThisModule"  value="Module" />
				    <asp:listitem ResourceKey="liCMSiteWide" value="Site" />
			    </asp:RadioButtonList>
	        </div>
	        <div id="trModerationRoles" runat="server">
		        <asp:Label id="plModeratorRoles" runat="server" suffix=":" />
		        <asp:CheckBoxList ID="chkModerateRoles" CssClass="Normal" runat="server" DataTextField="RoleName" DataValueField="RoleID" RepeatColumns="2" RepeatDirection="Horizontal"/>
	        </div>
	        <div id="trCommentNotification" runat="server">
		        <asp:Label id="plCommentNotification" runat="server" suffix=":" />
		        <asp:TextBox id="txtCommentNotificationEmails" Width="400" runat="server"/>
	        </div>
	        <div class="dnnFormItem">
		        <asp:Label id="Label1" runat="server" Text="Gravatar" suffix=":" />
                <asp:CheckBox ID="chkDisplayGravatar" ResourceKey="chkDisplayGravatar" runat="server" />
            </div>
            <div id="GravatarOptions" runat="server">
    	        <div class="dnnFormItem">
                    <asp:Label ID="lblGravatarSize" resourcekey="lblGravatarSize" runat="server" controlname="txtGravatarSize" suffix=":" />
                    <asp:TextBox ID="txtGravatarSize" width="35" runat="server" /> px
                </div>
                <div id="Div1" runat="server">
                    <asp:Label ID="lblGravatarMaximumAllowedRating" ResourceKey="ddlGravatarMaximumAllowedRating" Suffix=":" runat="server"/> 
                    <asp:DropDownList ID="ddlGravatarMaximumAllowedRating" runat="server" Width="60">
                        <asp:ListItem ResourceKey="liGMARG" Value="G" />
                        <asp:ListItem ResourceKey="liGMARPG" Value="PG" />
                        <asp:ListItem ResourceKey="liGMARR" Value="R" />
                        <asp:ListItem ResourceKey="liGMARX" Value="X" />
                    </asp:DropDownList>
                </div>
            </div>
	    </div><!--End Comment Options-->
    </fieldset>
    <h2 id="OtherHead" class="dnnFormSectionHead"><a href="#">Other Settings</a></h2>
    <fieldset title="Other Settings" class="dnnClear">
	    <div class="dnnFormItem">
		    <asp:Label id="plAlwaysLink" runat="server" controlname="chkAlwaysLink" suffix=":" />
		    <asp:checkbox id="chkAlwaysLink" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plFriendlyUrls" runat="server" suffix=":" />
		    <asp:CheckBox id="chkFriendlyUrls" cssclass="Normal" runat="server" />
	    </div>
        <div class="dnnFormItem" visible="false"><!--TODO: no implementation yet for this -->
            <asp:Label ID="plShowMoreDetails" runat="server" ControlName="rblShowMoreDetails" Suffix=":" />
            <asp:RadioButtonList ID="rblShowMoreDetails" CssClass="Normal" RepeatDirection="Horizontal" runat="server">
                <asp:ListItem Value="Inline" ReourceKey="ShowMoreDetaisInline" />
                <asp:ListItem Value="SeparateLine" ResourceKey="ShowMoreDetailsSeparateLine" />
            </asp:RadioButtonList>
        </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plRequireApproval" runat="server" controlname="chkRequireApproval" suffix=":" />
		    <asp:checkbox id="chkRequireApproval" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plDisableRSS" runat="server" controlname="chkDisableRSS" suffix=":" />
		    <asp:checkbox id="chkDisableRSS" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plEnableAddThisRSS" runat="server" controlname="chkEnableAddThisRSS" suffix=":" />
		    <asp:checkbox id="chkEnableAddThisRSS" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plHidePaging" runat="server" controlname="chkHidePaging" suffix=":" />
		    <asp:checkbox id="chkHidePaging" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plShowSearch" runat="server" controlname="chkShowSearch" suffix=":" />
		    <asp:checkbox id="chkShowSearch" runat="server" />
	    </div>
	    <div style="display:none;"><!--There's no implementation in place for this-->
		    <asp:Label id="plAllowAuthorSelection" runat="server" controlname="chkAllowAuthorSelection" suffix=":" />
		    <asp:checkbox id="chkAllowAuthorSelection" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plDisplayedFields" runat="server" suffix=":" />
		    <asp:checkbox id="chkShowCategory" ResourceKey="chkShowCategory" runat="server" />
		    <asp:checkbox id="chkShowReadMore" ResourceKey="chkShowReadMore" runat="server" />
		    <asp:checkbox id="chkShowPrint" ResourceKey="chkShowPrint" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plMoreArticles" runat="server" controlname="chkMoreArticles" suffix=":" />
		    <asp:checkbox id="chkMoreArticles" runat="server" />
		    <asp:label id="plMoreArticlesPage" ResourceKey="plMoreArticlesPage" runat="server" class="SubHead" />&nbsp;
		    <asp:DropDownList id="drpPage" datavaluefield="TabId" datatextfield="TabName" runat="server" />
	    </div>
	    <div class="dnnFormItem">
		    <asp:Label id="plEnableSendToFriend" runat="server" controlname="chkEnableSendToFriend" suffix=":" />
		    <asp:checkbox id="chkEnableSendToFriend" ResourceKey="chkEnableSendToFriend" runat="server" />
	    </div>
        <div id="STFOptions" runat="server">
	        <div id="trSTFMessage" runat="server">
		        <asp:Label id="lblSTFMessage" resourcekey="plSTFMessage" runat="server" />
		        <asp:textbox id="txtSTFMessage" cssclass="NormalTextBox" textmode="Multiline" rows="4" columns="55" runat="server" /> 
	        </div>
	        <div id="trSTFPrivacyMessage" runat="server">
		        <asp:Label id="plSTFPrivacyMessage" resourcekey="plSTFPrivacyMessage" runat="server" />
		        <asp:textbox id="txtSTFPrivacyMessage" cssclass="NormalTextBox" textmode="Multiline" rows="4" columns="55" runat="server" /> 
	        </div>
	        <div id="trSTFPrivacyLink" runat="server">
		        <asp:Label id="plSTFPrivacyLink" resourcekey="plSTFPrivacyLink" runat="server" />
		        <asp:textbox id="txtSTFPrivacyLink" cssclass="NormalTextBox" columns="55" runat="server" /> 
	        </div>
        </div>
        <div class="dnnFormItem">
		    <asp:Label id="plCustomSelect" runat="server" controlname="txtCustomSelect" suffix=":" />
		    <asp:textbox id="txtCustomSelect" cssclass="NormalTextBox" TextMode="Multiline" rows="3" Columns="55" runat="server" />
	    </div>
    </fieldset>
</div>
