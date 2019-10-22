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
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.FileSystem;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Christoc.Modules.NewArticles
{
    partial class CommentsFB : DotNetNuke.Entities.Modules.PortalModuleBase
    {
        private int ArticleId;

        public Boolean IsNumeric(string value)
        {
            return value.All(Char.IsDigit);
        }

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            NameValueCollection pColl = Request.Params;
            string[] pValues = pColl.GetValues(1);
            string pKey = pColl.GetKey(1);
            
            if (pKey == "" & pValues[0].Contains("-") && IsNumeric(pValues[0].Split('-')[0]))
            hidarticleid.Value = System.Convert.ToInt32(pValues[0].Split('-')[0]).ToString();
        }

        public static string URLComentario(int id)
        {
            ArticleController Articles = new ArticleController();
            ArticleInfo objArticle = Articles.GetArticle(id);

            string Result = "http://" + System.Web.HttpContext.Current.Request.Url.Host + "/articulos/" + objArticle.ItemId.ToString() + "-" + TransformTitle(objArticle.Title).Replace(".aspx", "");
            return Result.ToString();
        }

        public static string TransformTitle(string sTitle)
        {
            // make it all lower case
            sTitle = sTitle.ToLower().Normalize(NormalizationForm.FormD);
            // remove entities
            sTitle = Regex.Replace(sTitle, @"&\w+;", "");
            // remove anything that is not letters, numbers, dash, or space
            sTitle = Regex.Replace(sTitle, @"[^a-z0-9\-\s]", "");
            // replace spaces
            sTitle = sTitle.Replace(' ', '-');
            // collapse dashes
            sTitle = Regex.Replace(sTitle, "-{2,}", "-");
            // trim excessive dashes at the beginning
            sTitle = sTitle.TrimStart('-');
            // if it's too long, clip it
            // If (sTitle.Length > 80) Then
            // sTitle = sTitle.Substring(0, 79)
            // End If
            // remove trailing dashes
            sTitle = sTitle.TrimEnd('-');
            sTitle += ".aspx";
            return sTitle;
        }
    }
}