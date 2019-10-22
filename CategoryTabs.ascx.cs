using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Christoc.Modules.NewArticles
{
    public partial class CategoryTabs : DotNetNuke.Entities.Modules.PortalModuleBase
    {
        private DotNetNuke.Entities.Tabs.TabInfo _CurrentTab;

        public int SelectedCategory
        {
            get
            {
                int nSelectedCategory = 0;
                int.TryParse(Request.QueryString["CategoryID"], out nSelectedCategory);
                return nSelectedCategory;
            }
        }

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            if (!ArticleController.CategoriesInstalled())
                return;

            DotNetNuke.Entities.Tabs.TabController objTabController = new DotNetNuke.Entities.Tabs.TabController();
            _CurrentTab = objTabController.GetTab(PortalSettings.ActiveTab.TabID, PortalId, false);

            var categories = ArticleController.GetCategories(PortalId);

            var IncludeCategories = Settings["CategoryID"];
            if (IncludeCategories == "")
                rptTabs.DataSource = categories;
            else
            {
                ArrayList CategorySubSet = new ArrayList();
                 
                string[] CategoryIDList = IncludeCategories.ToString().Split(',');
              
                foreach (SimplifiedCategoryInfo c in categories)
                {
                    foreach (var CategoryID in CategoryIDList)
                    {
                        if (c.CategoryId == Convert.ToInt32(CategoryID))
                            CategorySubSet.Add(c);
                    }
                }

                rptTabs.DataSource = CategorySubSet;
            }

            rptTabs.DataBind();
        }

        public string GetLink(string CategoryId, string CategoryName)
        {
            if (CategoryId == "-1")
                return DotNetNuke.Services.Url.FriendlyUrl.FriendlyUrlProvider.Instance().FriendlyUrl(_CurrentTab, "~/default.aspx?tabid=" + _CurrentTab.TabID);
            else
                return DotNetNuke.Services.Url.FriendlyUrl.FriendlyUrlProvider.Instance().FriendlyUrl(_CurrentTab, "~/default.aspx?tabid=" + _CurrentTab.TabID + "&categoryid=" + CategoryId, "Category-" + CategoryName);
        }
    }
}