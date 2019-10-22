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

using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Data;
using System.Collections.Specialized;

namespace Christoc.Modules.NewArticles
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from NewArticlesModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : NewArticlesModuleBase, IActionable
    {
        private PortalModuleBase _lstArticles;


        protected PortalModuleBase lstArticles
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lstArticles;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lstArticles != null)
                {
                }

                _lstArticles = value;
                if (_lstArticles != null)
                {
                }
            }
        }

        public bool DisableAddNew
        {
            get
            {
                if (Settings["DisableAddNew"] == "True" & Settings["SiteWide"] == "True")
                    return true;
                else
                    return false;
            }
        }
        public bool DisplaySearchResultsPanelForCategory
        {
            get
            {
                return false;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // This Control primarily loads the appropriate List template 
                // most of the work is done in ArticleListBase.ascx.vb
                // It also holds the Search controls to simplify the templates
                pnlSearch.Visible = Convert.ToBoolean(Settings["ShowSearch"]);

                if (Request["SearchTerm"] != "" | Request["StartDate"] != "")
                {
                    SearchResultsPanel.Visible = true;
                    lblSearchResults.Text = Localization.GetString("SearchResults.Text", LocalResourceFile) + ": ";
                    if (Request["SearchTerm"] != "")
                        lblSearchResults.Text += " '" + Request["SearchTerm"] + "'<br/>";
                    else if (Request["StartDate"] != "")
                    {
                        if (Request["EndDate"] != "")
                            lblSearchResults.Text += Convert.ToString(Request["StartDate"] + " - ") + Request["EndDate"] + "<br/>";
                        else
                            // Too complex to handle this one here due to duration stuff
                            lblSearchResults.Text = "";
                    }
                    lblSearchResults.Visible = true;
                }
                if (Request["CategoryID"] != "" & DisplaySearchResultsPanelForCategory == true)
                {
                    lblSearchResults.Text = "Search Category: " + GetCategoryName(Convert.ToInt32(Request["CategoryID"])) + "<br/>";
                    SearchResultsPanel.Visible = true;
                    lblSearchResults.Visible = true;
                }

                var controlPath = default(string);
                // If Settings("DetailDisplay") = "SamePage" AND Request("View") = "Details" Then

                // Modificado por DAM para que no sea necesario pasar el AMID

                NameValueCollection pColl = Request.Params;
                string[] pValues = pColl.GetValues(1);
                string pKey = pColl.GetKey(1);

                if (string.IsNullOrEmpty(pKey) & !string.IsNullOrEmpty(pValues[0]))
                    // Si está habilitado el contenido relacionado cargo un modo lista para listar los relacionados.
                    controlPath = ArticleController.GetArticleTemplatePath(Settings["DetailsTemplate"].ToString(), "ArticleDetails_");
                else
                {
                    // Response.Write(ModuleID)
                    var lista_modulos_validos = new List<string>() { "556", "616", "622", "624", "633", "669", "670", "671", "676", "677", "678", "690", "696", "697", "742", "744", "745", "788", "1138" };

                    // Modificado por DAM para que la lista de articulos sea solo visible a los administradores
                    if (DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().IsInRole("Administrators") | DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().IsInRole("Editores") | lista_modulos_validos.Contains(ModuleId.ToString()))
                    {
                        // Si esta habilitado el contenido relacionado solo se puede ver en la vista detalles.			
                        if (Request["ListTemplate"] != "")
                            controlPath = ArticleController.GetArticleTemplatePath(Request["ListTemplate"], "ArticleList_");
                        else
                            controlPath = ArticleController.GetArticleTemplatePath(Settings["Template"].ToString(), "ArticleList_");
                    }
                    else
                        Response.Redirect("/");
                }



                // If Request("amid") = ModuleId And Not Request("itemid") = "" Then 'to shorten URLS, we no longer need this: Request("View") = "Details" And 
                // If Not Request("itemid") = "" Then 'to shorten URLS, we no longer need this: Request("View") = "Details" And 
                // controlPath = ArticleController.GetArticleTemplatePath(Settings("DetailsTemplate"), "ArticleDetails_")
                // Else
                // If Request("ListTemplate") <> "" Then
                // controlPath = ArticleController.GetArticleTemplatePath(Request("ListTemplate"), "ArticleList_")
                // Else
                // controlPath = ArticleController.GetArticleTemplatePath(Settings("Template"), "ArticleList_")
                // End If
                // End If

                if (!(Convert.ToBoolean(Settings["DisplayCategoryTabs"])) || !string.IsNullOrEmpty(Request["amid"]))
                    ViewCategoryTabs.Visible = false;
                else
                    this.ViewCategoryTabs.ModuleConfiguration = this.ModuleConfiguration.Clone();
                
                if (System.IO.File.Exists(Request.MapPath(controlPath)))
                    lstArticles = (View)LoadControl(controlPath);
                else
                    throw new Exception("Unable to load selected template. Please go into module settings and select a list and details template.");


                lstArticles.ModuleConfiguration = this.ModuleConfiguration.Clone();
                objPlaceholder.Controls.Add(lstArticles);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", "mid=" + ModuleId, "SearchTerm=" + txtSearch.Text));
        }




        protected void AddRSSLink()
        {
            if (Convert.ToBoolean(Settings["DisableRSS"]))
                return;

            var oLink = new System.Web.UI.HtmlControls.HtmlGenericControl("link");
            string sHref = ResolveUrl("~/DesktopModules/Articles/ArticlesRSS.aspx");
            sHref += Convert.ToString(Convert.ToString(Convert.ToString("?m=" + ModuleId.ToString() + "&p=") + PortalId.ToString() + "&t=") + TabId.ToString() + "&tm=") + TabModuleId.ToString();

            if (Request["CategoryID"] != "")
                sHref += "&cid=" + Convert.ToString(int.Parse(Request["CategoryID"]));
            oLink.Attributes["rel"] = "alternate";
            oLink.Attributes["type"] = "application/rss+xml";

            oLink.Attributes["title"] = Convert.ToString(ModuleConfiguration.ModuleTitle + "-") + PortalSettings.PortalName;
            oLink.Attributes["href"] = sHref;
            System.Web.UI.Control oCSS = this.Page.FindControl("CSS");
            if (!(oCSS == null))
                oCSS.Controls.AddAt(0, oLink);
        }

        private string GetCategoryName(int nCategoryID)
        {
            ArrayList ar = ArticleController.GetCategories(PortalId);           
            foreach (SimplifiedCategoryInfo c in ar)
            {
                if (c.CategoryId == nCategoryID)
                    return c.CategoryName;
            }
            return "Selected Category";
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };




                if (Convert.ToBoolean(Settings["ModerateComments"]))
                {
                    if (IsEditable)
                    {
                        actions.Add(GetNextActionID(), "Moderate Comments", "ModerateComments", "True", "", EditUrl("ModerateComments"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                    }
                    else
                    {
                        var permissionController = new Permissions(this.ModuleConfiguration);
                        if (permissionController.ModerateComments)
                            actions.Add(GetNextActionID(), "Moderate Comments", "ModerateComments", "True", "", EditUrl("ModerateComments"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                    }
                }

                if (Request["ItemId"] != "")
                    actions.Add(GetNextActionID(), Localization.GetString(DotNetNuke.Entities.Modules.Actions.ModuleActionType.EditContent, LocalResourceFile), DotNetNuke.Entities.Modules.Actions.ModuleActionType.EditContent, "", "", EditUrl("ItemID", Request["ItemID"]), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);

                actions.Add(GetNextActionID(), "Import From RSS", "ImportFromRSS", "True", "", EditUrl("ImportFromRSS"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);



                return actions;
            }
        }

        public string ExportModule(int ModuleID)
        {
            return default(string);
        }

        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
        }

        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        {
            return default(DotNetNuke.Services.Search.SearchItemInfoCollection);
        }

        // This call is required by the Web Form Designer.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
        }

        private void Page_Init(object sender, EventArgs e)
        {
            // CODEGEN: This method call is required by the Web Form Designer
            // Do not modify it using the code editor.
            InitializeComponent();

            AddRSSLink();
        }
    }
}