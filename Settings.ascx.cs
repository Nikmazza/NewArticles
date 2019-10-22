/*
' Copyright (c) 2019  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security.Roles;
using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;




namespace Christoc.Modules.NewArticles
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from NewArticlesSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : NewArticlesModuleSettingsBase
    {
        #region Base Method Implementations



        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            // Run SP to setup custom permissions
            ArticleController.SetupCustomPermissions();
            if (!IsPostBack)
            {
                string showhidejs = "__Articles_SectionShowHideOnCheck('{0}', '{1}');";
                string showhideOtherModulejs = "__Articles_showHideOtherModule('{0}', '{1}');";
                chkSiteWide.Attributes.Add("onclick", string.Format(showhidejs, chkSiteWide.ClientID, trDisableAddNew.ClientID));
                chkAllowComments.Attributes.Add("onclick", string.Format(showhidejs, chkAllowComments.ClientID, CommentOptions.ClientID));
                chkEnableSendToFriend.Attributes.Add("onclick", string.Format(showhidejs, chkEnableSendToFriend.ClientID, STFOptions.ClientID));
                chkDisplayGravatar.Attributes.Add("onclick", string.Format(showhidejs, chkDisplayGravatar.ClientID, GravatarOptions.ClientID));
                chkFilterByCategory.Attributes.Add("onclick", string.Format(showhidejs, chkFilterByCategory.ClientID, CategorySelector.ClientID));
                chkModerateComments.Attributes.Add("onclick", string.Format(showhidejs, chkModerateComments.ClientID, trCommentNotification.ClientID) + ";" + string.Format(showhidejs, chkModerateComments.ClientID, trModerationRoles.ClientID) + ";" + string.Format(showhidejs, chkModerateComments.ClientID, trModerationScope.ClientID));

             
                foreach (ListItem li in rblDetailDisplay.Items)
                    li.Attributes.Add("onclick", string.Format(showhideOtherModulejs, li.Value, divDetailDisplayOtherModule.ClientID));

                string strScript = "<script src=\"" + ResolveUrl("~/DesktopModules/Articles/Articles.js") + "\"></script>";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ArticlesScript", strScript);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    BindCategories();
                    BindExistingInstances();
                    GetTemplates();
                    BindPages();
                    chkFilterByCategory.Checked = Convert.ToBoolean(ModuleSettings["FilterByCategory"]);

                    if (string.IsNullOrEmpty(ModuleSettings["ArticlesPerPage"].ToString()))
                        txtArticlesPerPage.Text = "10";
                    else
                        txtArticlesPerPage.Text = System.Convert.ToString(ModuleSettings["ArticlesPerPage"]);

                    drpSortField.SelectedValue = System.Convert.ToString(ModuleSettings["SortField"]);
                    drpDateRange.SelectedValue = System.Convert.ToString(ModuleSettings["DateRange"]);
                    chkResizeImages.Checked = Convert.ToBoolean(ModuleSettings["ResizeImages"]);
                    if (string.IsNullOrEmpty(ModuleSettings["ImageWidth"].ToString()))
                    {
                        txtImageWidth.Text = "200";
                    }
                    else
                    {
                        txtImageWidth.Text = System.Convert.ToString(ModuleSettings["ImageWidth"]);
                    }
                    drpImageAlignment.SelectedValue = System.Convert.ToString(ModuleSettings["ImageAlignment"]);
                    chkShowSearch.Checked = Convert.ToBoolean(ModuleSettings["ShowSearch"]);
                    chkShowCategory.Checked = Convert.ToBoolean(ModuleSettings["ShowCategory"]);
                    chkShowReadMore.Checked = Convert.ToBoolean(ModuleSettings["ShowReadMore"]);
                    chkShowPrint.Checked = Convert.ToBoolean(ModuleSettings["ShowPrint"]);
                    chkSiteWide.Checked = Convert.ToBoolean(ModuleSettings["SiteWide"]);
                    chkDisableAddNew.Checked = Convert.ToBoolean(ModuleSettings["DisableAddNew"]);
                    chkRequireApproval.Checked = Convert.ToBoolean(ModuleSettings["RequireApproval"]);
                    chkRequireCategory.Checked = Convert.ToBoolean(ModuleSettings["RequireCategory"]); ;
                    chkDisplayCategoryTabs.Checked = Convert.ToBoolean(ModuleSettings["DisplayCategoryTabs"]);
                    chkFeatured.Checked = Convert.ToBoolean(ModuleSettings["Featured"]);
                    chkAlwaysLink.Checked = Convert.ToBoolean(ModuleSettings["AlwaysLink"]);
                    txtCustomSelect.Text = System.Convert.ToString(ModuleSettings["CustomSelect"]);
                    chkAllowComments.Checked = Convert.ToBoolean(ModuleSettings["AllowComments"]);
                    chkAnonymousComments.Checked = Convert.ToBoolean(ModuleSettings["AnonymousComments"]);
                    chkModerateComments.Checked = Convert.ToBoolean(ModuleSettings["ModerateComments"]);
                    if (ModuleSettings["DisplayGravatar"] == null)
                        chkDisplayGravatar.Checked = Convert.ToBoolean(ModuleSettings["DisplayGravatar"]);
                    else
                        chkDisplayGravatar.Checked = true;
                    if (!string.IsNullOrEmpty(ModuleSettings["GravatarSize"].ToString()))
                        txtGravatarSize.Text = ModuleSettings["GravatarSize"].ToString();
                    else
                        txtGravatarSize.Text = "65";

                    if (ddlGravatarMaximumAllowedRating.Items.FindByValue(System.Convert.ToString(ModuleSettings["GravatarMaximumAllowedRating"])) == null)
                        ddlGravatarMaximumAllowedRating.Items.FindByValue(System.Convert.ToString(ModuleSettings["GravatarMaximumAllowedRating"])).Selected = true;
                    else
                        ddlGravatarMaximumAllowedRating.SelectedValue = "PG";

                    if (rbModerationScope.Items.FindByValue(System.Convert.ToString(ModuleSettings["ModerateScope"])) == null)
                        rbModerationScope.Items.FindByValue(System.Convert.ToString(ModuleSettings["ModerateScope"])).Selected = true;
                    else
                        rbModerationScope.SelectedValue = "Module";


                    BindModerateRoles();

                    txtCommentNotificationEmails.Text = ModuleSettings["CommentNotificationEmails"].ToString();
                    chkDisableRSS.Checked = Convert.ToBoolean(ModuleSettings["DisableRSS"]);
                    chkEnableAddThisRSS.Checked = Convert.ToBoolean(ModuleSettings["EnableAddThisRSSLink"]);
                    chkHidePaging.Checked = Convert.ToBoolean(ModuleSettings["HidePaging"]);
                    chkMoreArticles.Checked = Convert.ToBoolean(ModuleSettings["MoreArticles"]);
                    chkEnableSendToFriend.Checked = Convert.ToBoolean(ModuleSettings["EnableSendToFriend"]);
                    txtSTFMessage.Text = Convert.ToString(ModuleSettings["STFMessage"]);
                    txtSTFPrivacyMessage.Text = Convert.ToString(ModuleSettings["STFPrivacyMessage"]);
                    txtSTFPrivacyLink.Text = Convert.ToString(ModuleSettings["STFPrivacyLink"]);
                    chkFriendlyUrls.Checked = Convert.ToBoolean(ModuleSettings["FriendlyUrls"]);

                    // BindAuthorizedRoles(ModuleSettings["AuthorizedRoles"))

                    if (rblDetailDisplay.Items.FindByValue(System.Convert.ToString(ModuleSettings["DetailDisplay"])) == null)
                        rblDetailDisplay.Items.FindByValue(System.Convert.ToString(ModuleSettings["DetailDisplay"])).Selected = true;
                    else
                        rblDetailDisplay.SelectedValue = "SamePage";

                    if (rblShowMoreDetails.Items.FindByValue(System.Convert.ToString(ModuleSettings["ShowMoreDetails"])) == null)
                        rblShowMoreDetails.Items.FindByValue(System.Convert.ToString(ModuleSettings["ShowMoreDetails"])).Selected = true;
                    else
                        rblShowMoreDetails.SelectedValue = "Inline";

                    if (drpPage.Items.FindByValue(System.Convert.ToString(ModuleSettings["MoreArticlesPage"])) == null)
                        drpPage.Items.FindByValue(System.Convert.ToString(ModuleSettings["MoreArticlesPage"])).Selected = true;

                    if (drpTemplate.Items.FindByValue(System.Convert.ToString(ModuleSettings["Template"])) == null)
                        drpTemplate.Items.FindByValue(System.Convert.ToString(ModuleSettings["Template"])).Selected = true;
                    else if (drpTemplate.Items.FindByValue("Standard") == null)
                        drpTemplate.Items.FindByValue("Standard").Selected = true;

                    if (drpDetailsTemplate.Items.FindByValue(System.Convert.ToString(ModuleSettings["DetailsTemplate"])) == null)
                        drpDetailsTemplate.Items.FindByValue(System.Convert.ToString(ModuleSettings["DetailsTemplate"])).Selected = true;
                    else if (drpDetailsTemplate.Items.FindByValue("Standard") == null)
                        drpDetailsTemplate.Items.FindByValue("Standard").Selected = true;

                    if (drpPrintTemplate.Items.FindByValue(System.Convert.ToString(ModuleSettings["PrintTemplate"])) == null)
                        drpPrintTemplate.Items.FindByValue(System.Convert.ToString(ModuleSettings["PrintTemplate"])).Selected = true;
                    else if (drpPrintTemplate.Items.FindByValue("Standard") == null)
                        drpPrintTemplate.Items.FindByValue("Standard").Selected = true;

                    if (ddlOtherModule.Items.FindByValue(System.Convert.ToString(ModuleSettings["DetailDisplayModule"])) == null)
                        ddlOtherModule.Items.FindByValue(System.Convert.ToString(ModuleSettings["DetailDisplayModule"])).Selected = true;
                    if (drpDefaultDetailType.Items.FindByValue(System.Convert.ToString(ModuleSettings["DefaultDetailType"])) == null)
                        drpDefaultDetailType.Items.FindByValue(System.Convert.ToString(ModuleSettings["DefaultDetailType"])).Selected = true;
                    else
                        drpDefaultDetailType.SelectedIndex = 0;

                    SetVisibility();

                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var objAdmin = new ModuleController();

                
                objAdmin.UpdateModuleSetting(ModuleId, "Template", drpTemplate.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "DetailsTemplate", drpDetailsTemplate.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "PrintTemplate", drpPrintTemplate.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "ArticlesPerPage", txtArticlesPerPage.Text);
                objAdmin.UpdateModuleSetting(ModuleId, "SortField", drpSortField.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "DateRange", drpDateRange.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "ResizeImages", chkResizeImages.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "ImageWidth", txtImageWidth.Text);
                objAdmin.UpdateModuleSetting(ModuleId, "ImageAlignment", drpImageAlignment.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "ShowSearch", chkShowSearch.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "ShowCategory", chkShowCategory.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "ShowReadMore", chkShowReadMore.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "ShowPrint", chkShowPrint.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "SiteWide", chkSiteWide.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "DisableAddNew", chkDisableAddNew.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "RequireApproval", chkRequireApproval.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "RequireCategory", chkRequireCategory.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "DisplayCategoryTabs", chkDisplayCategoryTabs.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "Featured", chkFeatured.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "AlwaysLink", chkAlwaysLink.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "FilterByCategory", chkFilterByCategory.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "CustomSelect", txtCustomSelect.Text);
                objAdmin.UpdateModuleSetting(ModuleId, "AllowComments", chkAllowComments.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "AnonymousComments", chkAnonymousComments.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "ModerateComments", chkModerateComments.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "ModerateScope", rbModerationScope.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "CommentNotificationEmails", txtCommentNotificationEmails.Text);
                objAdmin.UpdateModuleSetting(ModuleId, "EnableSendToFriend", chkEnableSendToFriend.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "STFMessage", txtSTFMessage.Text);
                objAdmin.UpdateModuleSetting(ModuleId, "STFPrivacyMessage", txtSTFPrivacyMessage.Text);
                objAdmin.UpdateModuleSetting(ModuleId, "STFPrivacyLink", txtSTFPrivacyLink.Text);
                objAdmin.UpdateModuleSetting(ModuleId, "DisableRSS", chkDisableRSS.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "EnableAddThisRSSLink", chkEnableAddThisRSS.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "HidePaging", chkHidePaging.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "MoreArticles", chkMoreArticles.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "MoreArticlesPage", drpPage.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "DetailDisplay", rblDetailDisplay.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "DetailDisplayModule", ddlOtherModule.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "DefaultDetailType", drpDefaultDetailType.SelectedValue);
                // objAdmin.UpdateModuleSetting(ModuleId, "AuthorizedRoles", GetSelectedRoles())
                objAdmin.UpdateModuleSetting(ModuleId, "FriendlyUrls", chkFriendlyUrls.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "ShowMoreDetails", rblShowMoreDetails.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "DisplayGravatar", chkDisplayGravatar.Checked.ToString());
                objAdmin.UpdateModuleSetting(ModuleId, "GravatarMaximumAllowedRating", ddlGravatarMaximumAllowedRating.SelectedValue);
                objAdmin.UpdateModuleSetting(ModuleId, "GravatarSize", txtGravatarSize.Text);
                if (chkModerateComments.Checked)
                    objAdmin.UpdateModuleSetting(ModuleId, "ModerateCommentRoles", GetModerateCommentRoles().ToString());
                if (ArticleController.CategoriesInstalled() & chkFilterByCategory.Checked)
                {

                    // Save the category selections
                    string sCategoryList = "";
                    foreach (ListItem oListItem in cblCategories.Items)
                    {
                        if (oListItem.Selected)
                            sCategoryList += oListItem.Value + ",";
                    }

                    // Remove the trailing comma if it exists and update the settings
                    if (sCategoryList.Length > 1)
                        sCategoryList = sCategoryList.Substring(0, sCategoryList.Length - 1);
                    objAdmin.UpdateModuleSetting(ModuleId, "CategoryID", sCategoryList);
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

        #region
        private void BindCategories()
        {
            if (ArticleController.CategoriesInstalled())
            {
                ArrayList arCategories;
                ArrayList arAvailableCategories = new ArrayList();
                ArrayList arAssignedCategories = new ArrayList();

                try
                {
                    arCategories = ArticleController.GetCategories(PortalId);
                }
                catch (Exception ex)
                {
                    lblNoCategories.Visible = true;
                    CategoryOptions.Visible = false;
                    return;
                }

                // Get the list of assigned categories
                string sCategoryList = System.Convert.ToString(ModuleSettings["CategoryID"]);
                ArrayList arIDs = new ArrayList();

                // Check to be sure we have a setting (short circuit "andalso" so we don't get an
                // error checking the length of a non-existent object)
                if ((string.IsNullOrEmpty(sCategoryList)) && sCategoryList.Length > 0)
                    arIDs.AddRange(sCategoryList.Split(','));

                // Add the checkboxes for each category, selecting them as necessary
               
                foreach (SimplifiedCategoryInfo oCategory in arCategories)
                {
                    ListItem oListItem = new ListItem(oCategory.CategoryName, oCategory.CategoryId.ToString());
                    if (arIDs.IndexOf(oCategory.CategoryId.ToString()) != -1)
                        oListItem.Selected = true;
                    cblCategories.Items.Add(oListItem);
                }
            }
            else
            {
                lblNoCategories.Visible = true;
                CategoryOptions.Visible = false;
            }
        }

        private void BindPages()
        {
            drpPage.DataSource = DotNetNuke.Entities.Tabs.TabController.GetPortalTabs(PortalId, -1, true, true, false, false);
            drpPage.DataBind();
            drpPage.Items.Insert(0, new ListItem(" ", "-1"));
        }

        private void BindExistingInstances()
        {
            // Fills the dropdown list with all existing instances of the Articles module in this portal
            ddlOtherModule.DataSource = ArticleController.GetExistingInstances(PortalId, ModuleId);
            ddlOtherModule.DataBind();
            if (ddlOtherModule.Items.Count == 0)
                // Hide the radio button for displaying details in another module since there are no other modules
                rblDetailDisplay.Items[2].Enabled = false;
            else
                ddlOtherModule.Items.Insert(0, new ListItem(" ", "-1"));
        }

        private void SetVisibility()
        {
            // If AllowComments is not checked then hide Anonymous Comments checkbox
            if (!chkAllowComments.Checked)
                CommentOptions.Style.Add("display", "none");
            if (!chkModerateComments.Checked)
            {
                trCommentNotification.Style.Add("display", "none");
                trModerationRoles.Style.Add("display", "none");
                trModerationScope.Style.Add("display", "none");
            }
            if (chkSiteWide.Checked)
                trDisableAddNew.Attributes["display"] = "";
            else
                trDisableAddNew.Attributes["display"] = "none";

            if (!chkEnableSendToFriend.Checked)
                STFOptions.Style.Add("display", "none");
            if (!chkDisplayGravatar.Checked)
                GravatarOptions.Style.Add("display", "none");
            if (!chkFilterByCategory.Checked)
                CategorySelector.Style.Add("display", "none");
            if (rblDetailDisplay.SelectedValue == "OtherModule")
                divDetailDisplayOtherModule.Attributes["display"] = "";
            else
                divDetailDisplayOtherModule.Attributes["display"] = "none";
        }

        private void GetTemplates()
        {
            drpTemplate.DataSource = ArticleController.GetArticleTemplates("ArticleList_");
            drpTemplate.DataBind();

            drpDetailsTemplate.DataSource = ArticleController.GetArticleTemplates("ArticleDetails_");
            drpDetailsTemplate.DataBind();

            drpPrintTemplate.DataSource = ArticleController.GetArticleTemplates("ArticleDetails_");
            drpPrintTemplate.DataBind();
        }
        private void BindModerateRoles()
        {
            RoleController objRoles = new RoleController();

            ArrayList Arr = objRoles.GetPortalRoles(PortalSettings.PortalId);
            chkModerateRoles.DataSource = Arr;
            chkModerateRoles.DataBind();
            string sCurRoles = System.Convert.ToString(ModuleSettings["ModerateCommentRoles"]);
            if (sCurRoles != "")
            {
                string[] curRoles = sCurRoles.Split(';');
                if (curRoles.Length > 0)
                {
                    int i;
                    for (i = 0; i <= curRoles.Length - 1; i++)
                    {
                        if (chkModerateRoles.Items.FindByText(curRoles[i]) == null)
                            chkModerateRoles.Items.FindByText(curRoles[i]).Selected = true;
                    }
                }
            }

            if (chkModerateRoles.SelectedIndex == -1 & !System.Convert.ToBoolean(ModuleSettings["ModerateComments"]))
            {
                // Default Administrators Role to selected
                if (chkModerateRoles.Items.FindByText("Administrators") == null)
                    chkModerateRoles.Items.FindByText("Administrators").Selected = true;
            }
        }
        private string GetModerateCommentRoles()
        {
            int i;
            string strModerateRoles = "";
            for (i = 0; i <= chkModerateRoles.Items.Count - 1; i++)
            {
                if (chkModerateRoles.Items[i].Selected)
                    strModerateRoles = strModerateRoles + chkModerateRoles.Items[i].Text + ";";
            }
            return strModerateRoles;
        }
        #endregion
    }
}