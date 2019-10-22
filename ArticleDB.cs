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
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DotNetNuke.Data;
using DotNetNuke.Services.Search;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Security.Permissions;
using System.Text.RegularExpressions;
using System.Web;
namespace Christoc.Modules.NewArticles
{
    public class ArticleInfo
    {
        private int _ItemId;
        private int _PortalId;
        private int _ModuleId;
        private string _Categories;
        private string _CategoryIcon;
        private int _UserId;
        private string _UserName;
        private string _AuthorFullName;
        private DateTime _CreatedDate;
        private DateTime _LastModifiedDate;
        private string _Title;
        private string _SubHead;
        private string _Description;
        private string _Keywords;
        private string _Tags;
        private string _Productos;
        private string _Especialidades;
        private bool _Authed;
        private DateTime _PublishDate;
        private DateTime _ExpireDate;
        private bool _Featured;
        private bool _FeaturedHome;
        private string _Article;
        private string _ImageFile;
        private string _ImageTitle;
        private int _ImagePositionY;
        private string _Email;
        private int _NumberOfViews;
        private int _ItemIDPrev;
        private int _ItemIDNext;
        private string _Codigo;
        private string _NroRevista;
        private bool _ShowImage;
        private string _Roles;
        private bool _EnBiblioteca;

        public ArticleInfo()
        {
        }

        public bool Contains(string searchString)
        {
            // _Keywords.IndexOf(searchString) <> -1 OR _
            if ((_Title.ToLower().IndexOf(searchString.ToLower())) != -1 | (_SubHead.ToLower().IndexOf(searchString.ToLower()) != -1) | (_Description.ToLower().IndexOf(searchString.ToLower()) != -1) | (_Article.ToLower().IndexOf(searchString.ToLower()) != -1))
                return true;
            else
                return false;
        }

        public int ItemId
        {
            get
            {
                return _ItemId;
            }
            set
            {
                _ItemId = value;
            }
        }

        public int PortalId
        {
            get
            {
                return _PortalId;
            }
            set
            {
                _PortalId = value;
            }
        }

        public int ModuleId
        {
            get
            {
                return _ModuleId;
            }
            set
            {
                _ModuleId = value;
            }
        }

        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        public string SubHead
        {
            get
            {
                return _SubHead;
            }
            set
            {
                _SubHead = value;
            }
        }

        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        public string AuthorFullName
        {
            get
            {
                return _AuthorFullName;
            }
            set
            {
                _AuthorFullName = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
            }
        }

        public DateTime LastModifiedDate
        {
            get
            {
                return _LastModifiedDate;
            }
            set
            {
                _LastModifiedDate = value;
            }
        }

        public DateTime PublishDate
        {
            get
            {
                return _PublishDate;
            }
            set
            {
                _PublishDate = value;
            }
        }

        public DateTime ExpireDate
        {
            get
            {
                return _ExpireDate;
            }
            set
            {
                _ExpireDate = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        public string Keywords
        {
            get
            {
                return _Keywords;
            }
            set
            {
                _Keywords = value;
            }
        }

        public string Tags
        {
            get
            {
                return _Tags;
            }
            set
            {
                _Tags = value;
            }
        }

        public string Roles
        {
            get
            {
                return _Roles;
            }
            set
            {
                _Roles = value;
            }
        }
        public string Productos
        {
            get
            {
                return _Productos;
            }
            set
            {
                _Productos = value;
            }
        }

        public string Especialidades
        {
            get
            {
                return _Especialidades;
            }
            set
            {
                _Especialidades = value;
            }
        }

        public string Article
        {
            get
            {
                return _Article;
            }
            set
            {
                _Article = value;
            }
        }

        public string Categories
        {
            get
            {
                return _Categories;
            }
            set
            {
                _Categories = value;
            }
        }

        public string CategoryIcon
        {
            get
            {
                return _CategoryIcon;
            }
            set
            {
                _CategoryIcon = value;
            }
        }

        public string ImageFile
        {
            get
            {
                return _ImageFile;
            }
            set
            {
                _ImageFile = value;
            }
        }

        public string ImageTitle
        {
            get
            {
                return _ImageTitle;
            }
            set
            {
                _ImageTitle = value;
            }
        }

        public int ImagePositionY
        {
            get
            {
                return _ImagePositionY;
            }
            set
            {
                _ImagePositionY = value;
            }
        }


        public bool Authed
        {
            get
            {
                return _Authed;
            }
            set
            {
                _Authed = value;
            }
        }

        public bool Featured
        {
            get
            {
                return _Featured;
            }
            set
            {
                _Featured = value;
            }
        }

        public bool FeaturedHome
        {
            get
            {
                return _FeaturedHome;
            }
            set
            {
                _FeaturedHome = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public int NumberOfViews
        {
            get
            {
                return _NumberOfViews;
            }
            set
            {
                _NumberOfViews = value;
            }
        }

        public int ItemIDPrev
        {
            get
            {
                return _ItemIDPrev;
            }
            set
            {
                _ItemIDPrev = value;
            }
        }

        public int ItemIDNext
        {
            get
            {
                return _ItemIDNext;
            }
            set
            {
                _ItemIDNext = value;
            }
        }

        public string Codigo
        {
            get
            {
                return _Codigo;
            }
            set
            {
                _Codigo = value;
            }
        }

        public string NroRevista
        {
            get
            {
                return _NroRevista;
            }
            set
            {
                _NroRevista = value;
            }
        }

        public bool ShowImage
        {
            get
            {
                return _ShowImage;
            }
            set
            {
                _ShowImage = value;
            }
        }
        public bool EnBiblioteca
        {
            get
            {
                return _EnBiblioteca;
            }
            set
            {
                _EnBiblioteca = value;
            }
        }
    }

    public class CommentInfo
    {
        private int _CommentId;
        private int _ArticleId;
        private string _Name;
        private string _Email;
        private string _Comment;
        private string _PublishDate;
        private bool _Approved;

        public int CommentId
        {
            get
            {
                return _CommentId;
            }
            set
            {
                _CommentId = value;
            }
        }

        public int ArticleId
        {
            get
            {
                return _ArticleId;
            }
            set
            {
                _ArticleId = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                _Comment = value;
            }
        }

        public string PublishDate
        {
            get
            {
                return _PublishDate;
            }
            set
            {
                _PublishDate = value;
            }
        }
        public bool Approved
        {
            get
            {
                return _Approved;
            }
            set
            {
                _Approved = value;
            }
        }
    }

    public class UnApprovedCommentInfo
    {
        private int _CommentId;
        private int _ArticleId;
        private string _Title;
        private string _Name;
        private string _Email;
        private string _Comment;
        private string _PublishDate;
        private bool _Approved;

        public int CommentId
        {
            get
            {
                return _CommentId;
            }
            set
            {
                _CommentId = value;
            }
        }

        public int ArticleId
        {
            get
            {
                return _ArticleId;
            }
            set
            {
                _ArticleId = value;
            }
        }
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                _Comment = value;
            }
        }

        public string PublishDate
        {
            get
            {
                return _PublishDate;
            }
            set
            {
                _PublishDate = value;
            }
        }
        public bool Approved
        {
            get
            {
                return _Approved;
            }
            set
            {
                _Approved = value;
            }
        }
    }
    public class SiteWideUnApprovedCommentInfo
    {
        private int _ModuleId;
        private int _UnApprovedCount;
        private string _ModuleTitle;
        private string _TabName;
        public int ModuleId
        {
            get
            {
                return _ModuleId;
            }
            set
            {
                _ModuleId = value;
            }
        }
        public int UnApprovedCount
        {
            get
            {
                return _UnApprovedCount;
            }
            set
            {
                _UnApprovedCount = value;
            }
        }
        public string ModuleTitle
        {
            get
            {
                return _ModuleTitle;
            }
            set
            {
                _ModuleTitle = value;
            }
        }
        public string TabName
        {
            get
            {
                return _TabName;
            }
            set
            {
                _TabName = value;
            }
        }
    }

    public class SimplifiedCategoryInfo
    {
        private int _CategoryId;
        private string _CategoryName;

        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                _CategoryId = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return _CategoryName;
            }
            set
            {
                _CategoryName = value;
            }
        }
    }

    public class ExistingInstance
    {
        private int _TabID;
        private int _ModuleID;
        private string _TabName;
        private string _ModuleTitle;

        public int TabId
        {
            get
            {
                return _TabID;
            }
            set
            {
                _TabID = value;
            }
        }

        public int ModuleId
        {
            get
            {
                return _ModuleID;
            }
            set
            {
                _ModuleID = value;
            }
        }

        public string TabName
        {
            get
            {
                return _TabName;
            }
            set
            {
                _TabName = value;
            }
        }

        public string ModuleTitle
        {
            get
            {
                return _ModuleTitle;
            }
            set
            {
                _ModuleTitle = value;
            }
        }

        public string ListText
        {
            get
            {
                return _TabName + "-" + _ModuleTitle;
            }
        }

        public string Listvalue
        {
            get
            {
                return _TabID.ToString() + "|" + _ModuleID.ToString();
            }
        }
    }

    public class RSSFeed
    {
        private int _FeedID;
        private int _PortalID;
        private int _ModuleID;
        private string _FeedName;
        private string _FeedSource;

        public RSSFeed()
        {
        }
        public RSSFeed(int PortalID, int ModuleId, string name, string url)
        {
            _PortalID = PortalID;
            _ModuleID = ModuleId;
            _FeedName = name;
            _FeedSource = url;
        }


        public int FeedID
        {
            get
            {
                return _FeedID;
            }
            set
            {
                _FeedID = value;
            }
        }

        public int PortalID
        {
            get
            {
                return _PortalID;
            }
            set
            {
                _PortalID = value;
            }
        }

        public int ModuleId
        {
            get
            {
                return _ModuleID;
            }
            set
            {
                _ModuleID = value;
            }
        }

        public string FeedName
        {
            get
            {
                return _FeedName;
            }
            set
            {
                _FeedName = value;
            }
        }

        public string FeedSource
        {
            get
            {
                return _FeedSource;
            }
            set
            {
                _FeedSource = value;
            }
        }
    }

    public class ArticleController : ISearchable, IPortable
    {
        private const int MAX_DESCRIPTION_LENGTH = 150;

        const string _spPrefix = "Articles_";
        const string _SharedTemplatePath = @"~\DesktopModules\Articles\Templates\";
        const string _PortalSpecificTemplatePath = @"~\Portals\{0}\ArticleTemplates\";

        public static bool CategoriesInstalled()
        {
            object gc = DotNetNuke.Common.Utilities.DataCache.GetCache("CategoriesInstalled");
            if (gc == null)
            {
                gc = DataProvider.Instance().ExecuteScalar<bool>("Articles_CategoriesInstalled");
                DotNetNuke.Common.Utilities.DataCache.SetCache("CategoriesInstalled", gc);
            }

            return System.Convert.ToBoolean(gc);
        }

        public ArrayList GetArticles(string SelectStatement)
        {
            ArrayList ar;
            IDataReader dr;

            // First Determine if a Select statement or a Stored Procedure
            if (SelectStatement.Contains("select"))
                dr = DataProvider.Instance().ExecuteSQL(SelectStatement);
            else
            {
                string procName;
                string @params = "";
                if (SelectStatement.IndexOf(' ') != -1)
                {
                    // parse out parameters
                    procName = SelectStatement.Substring(0, SelectStatement.IndexOf(' '));
                    @params = SelectStatement.Substring(SelectStatement.IndexOf(' '));
                }
                else
                    procName = SelectStatement;
                try
                {
                    if (@params == "")
                        dr = DataProvider.Instance().ExecuteReader(procName);
                    else
                        dr = DataProvider.Instance().ExecuteReader(procName, @params.Split(','));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + "SP:" + procName + "; Params:" + @params);
                }
            }

            ar = CBO.FillCollection(dr, typeof(ArticleInfo));
            dr.Close();
            return ar;
        }

        public ArrayList GetArticles(int PortalId, int ModuleId, int UserID, string MustHaveOneCategories, string MustHaveAllCategories, int MaxNumber, int Age, bool ShowAuthOnly, bool Featured, bool IgnorePublishDate, bool IgnoreExpired, string SortField)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticles", PortalId, ModuleId, UserID, MustHaveOneCategories, MustHaveAllCategories, MaxNumber, Age, ShowAuthOnly, Featured, IgnorePublishDate, IgnoreExpired, SortField), typeof(ArticleInfo));
        }

        public ArrayList GetArticlesWithFilter(int PortalId, int ModuleId, int UserID, string MustHaveOneCategories, string MustHaveAllCategories, int MaxNumber, int Age, bool ShowAuthOnly, bool Featured, bool IgnorePublishDate, bool IgnoreExpired, string SortField, string DynamicFilter)
        {
            DataSet ds;
            ds = DataProvider.Instance().ExecuteDataSet(_spPrefix + "GetArticles", PortalId, ModuleId, UserID, MustHaveOneCategories, MustHaveAllCategories, MaxNumber, Age, ShowAuthOnly, Featured, IgnorePublishDate, IgnoreExpired, SortField);


            return FillCollection(ds.Tables[0].Select(DynamicFilter));
        }

        public ArrayList FillCollection(DataRow[] drCollection)
        {
            ArrayList ar = new ArrayList();
            foreach (DataRow dr in drCollection)
            {
                ArticleInfo article = new ArticleInfo();
                article.ItemId = Null.SetNullInteger(dr["ItemID"]);
                article.Title = Null.SetNullInteger(dr["Title"]).ToString();
                article.UserId = Null.SetNullInteger(dr["UserID"]);
                article.PortalId = Null.SetNullInteger(dr["PortalID"]);
                article.ModuleId = Null.SetNullInteger(dr["ModuleId"]);
                article.SubHead = Null.SetNullInteger(dr["SubHead"]).ToString();
                article.Description = Null.SetNullInteger(dr["Description"]).ToString();
                // article.Keywords = Null.SetNull(dr("Keywords"), article.Keywords)
                article.Authed = Convert.ToBoolean(Null.SetNullInteger(dr["Authed"]));
                article.Featured = Convert.ToBoolean(Null.SetNullInteger(dr["Featured"]));
                article.Article = Null.SetNullInteger(dr["Article"]).ToString();
                article.ImageFile = Null.SetNullInteger(dr["ImageFile"]).ToString();
                article.ImageTitle = Null.SetNullInteger(dr["ImageTitle"]).ToString();
                // article.ImagePositionY = Null.SetNull(dr("ImagePositionY"), article.ImagePositionY)
                article.PublishDate = Convert.ToDateTime(Null.SetNullInteger(dr["PublishDate"]));
                article.ExpireDate = Convert.ToDateTime(Null.SetNullInteger(dr["ExpireDate"]));
                article.CreatedDate = Convert.ToDateTime(Null.SetNullInteger(dr["CreatedDate"]));
                article.LastModifiedDate = Convert.ToDateTime(Null.SetNullInteger(dr["LastModifiedDate"]));
                article.NumberOfViews = Null.SetNullInteger(dr["NumberOfViews"]);
                article.ItemIDPrev = Null.SetNullInteger(dr["ItemIDPrev"]);
                article.ItemIDNext = Null.SetNullInteger(dr["ItemIDNext"]);
                article.Codigo = Null.SetNullInteger(dr["Codigo"]).ToString();
                article.NroRevista = Null.SetNullInteger(dr["NroRevista"]).ToString();
                article.EnBiblioteca = Convert.ToBoolean(Null.SetNullInteger(dr["EnBiblioteca"]));
                ar.Add(article);
            }
            return ar;
        }
        public static object IsNull(object Field)
        {
            return Null.GetNull(Field, DBNull.Value);
        }

        public ArrayList GetArticlesByDateRange(int PortalId, int ModuleId, string MustHaveOneCategories, string MustHaveAllCategories, string searchTerm, DateTime StartDate, DateTime EndDate, string SortField)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticlesByDateRange", PortalId, ModuleId, MustHaveOneCategories, MustHaveAllCategories, searchTerm, StartDate, EndDate, SortField), typeof(ArticleInfo));
        }

        public ArrayList SearchArticles(int PortalId, string SearchTerm, bool AuthOnly, string SortField)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetSearchResults", PortalId, SearchTerm, AuthOnly, SortField), typeof(ArticleInfo));
        }

        public static string GetCategoryList(int ItemId)
        {
            string sCategoryList = "";
            if (CategoriesInstalled())
            {
                try
                {
                    IDataReader myDataReader;
                    myDataReader = DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticleCategories", ItemId);
                    while (myDataReader.Read())
                        sCategoryList += myDataReader["CategoryName"] + ", ";
                    if (sCategoryList.Length > 1)
                        sCategoryList = sCategoryList.Remove(sCategoryList.Length - 2, 2);
                    myDataReader.Close();
                }
                catch (Exception Ex)
                {
                    if (Ex.Message.Contains("Invalid object"))
                    {
                        // This may occur once if they install the Categories module after the Articles module and the cache doesn't get cleared
                        DotNetNuke.Common.Utilities.DataCache.RemoveCache("CategoriesInstalled");
                        DotNetNuke.Services.Exceptions.Exceptions.LogException(new Exception("Articles Error: CategoriesInstalled reported true when it was false. If you see multiple occurences of this error, please contact support@efficionconsulting.com", Ex));
                        return "";
                    }
                }
            }
            return sCategoryList;
        }

        public ArticleInfo GetArticle(int ItemId)
        {
            ArticleInfo ai;
            ai = (ArticleInfo)CBO.FillObject(DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticle", ItemId), typeof(ArticleInfo));

            if (CategoriesInstalled())
            {
                IDataReader dr;
                dr = DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticleCategories", ItemId);
                while (dr.Read())
                    ai.Categories += dr["CategoryID"] + ",";
                dr.Close();
            }

         
                IDataReader dr2;
                dr2 = DataProvider.Instance().ExecuteReader("Article_getRolesByArticleID", ItemId);
                while (dr2.Read())
                {
                    if (ai.Roles == "")
                        ai.Roles = dr2["roleid"].ToString();
                    else
                        ai.Roles += "," + dr2["roleid"];
                }
                dr2.Close();
            
            return ai;
        }
        public static ArrayList GetCategories(int PortalId)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader("Categories_GetCategories", PortalId), typeof(SimplifiedCategoryInfo));
        }

        public static ArrayList GetCategoriesLevel1(int PortalId)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader("Categories_GetCategoriesLevel1", PortalId), typeof(SimplifiedCategoryInfo));
        }

        public static ArrayList GetCategoriesLevel2(int PortalId, int CategoryID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader("Categories_GetCategoriesLevel2", PortalId, CategoryID), typeof(SimplifiedCategoryInfo));
        }

        public static ArrayList GetCategoryLevel1(int ItemID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetCategoryLevel1", ItemID), typeof(SimplifiedCategoryInfo));
        }

        public static ArrayList GetCategoryLevel2(int ItemID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetCategoryLevel2", ItemID), typeof(SimplifiedCategoryInfo));
        }

        public static void postArticleViewByUser(int user, int ItemID, string origen)
        {
            IDataReader dr;
            dr = DataProvider.Instance().ExecuteReader("Article_addVisited", user, ItemID, origen);
            dr.Read();
            dr.Close();
        }

        public static string GetContainerClass(int ItemID)
        {
            string ci;
            IDataReader dr;
            dr = DataProvider.Instance().ExecuteReader(_spPrefix + "GetContainerClass", ItemID);
            dr.Read();
            ci = dr["Class"].ToString();
            dr.Close();
            return ci;
        }

        public static string GetCategoryIcon(int ArticleId)
        {
            string ci;
            IDataReader dr;
            dr = DataProvider.Instance().ExecuteReader(_spPrefix + "GetCategoryIcon", ArticleId);
            dr.Read();
            ci = dr["IconFile"].ToString();
            dr.Close();
            return ci;
        }

        public static Int32 AddArticle(ArticleInfo objArticle)
        {
            return DataProvider.Instance().ExecuteScalar<int>(_spPrefix + "AddArticle", objArticle.PortalId, objArticle.ModuleId, objArticle.UserId, objArticle.Title, objArticle.SubHead, objArticle.Description, objArticle.Keywords, objArticle.Tags, objArticle.Productos, objArticle.Especialidades, objArticle.Authed, objArticle.Featured, objArticle.FeaturedHome, objArticle.Article, objArticle.Categories, objArticle.ImageFile, objArticle.ImageTitle, GetNull(objArticle.PublishDate), GetNull(objArticle.ExpireDate), objArticle.ImagePositionY, objArticle.ItemIDPrev, objArticle.ItemIDNext, objArticle.NroRevista, objArticle.Codigo, objArticle.ShowImage, objArticle.Roles, objArticle.EnBiblioteca);
        }

        public static void UpdateArticle(ArticleInfo objArticle)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "UpdateArticle", objArticle.ItemId, objArticle.UserId, objArticle.Title, objArticle.SubHead, objArticle.Description, objArticle.Keywords, objArticle.Tags, objArticle.Productos, objArticle.Especialidades, objArticle.Authed, objArticle.Featured, objArticle.FeaturedHome, objArticle.Article, objArticle.Categories, objArticle.ImageFile, objArticle.ImageTitle, GetNull(objArticle.PublishDate), GetNull(objArticle.ExpireDate), objArticle.ImagePositionY, objArticle.ItemIDPrev, objArticle.ItemIDNext, objArticle.NroRevista, objArticle.Codigo, objArticle.ShowImage, objArticle.Roles, objArticle.EnBiblioteca);
        }

        public static void DeleteArticle(int ItemId)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "DeleteArticle", ItemId);
        }

        public static void UpdateArticleView(int ItemId)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "UpdateArticleViews", ItemId);
        }

        private static object GetNull(object Field)
        {
            return Null.GetNull(Field, DBNull.Value);
        }


        // relacionados

        public ArrayList GetRelacionadosRevista(int ItemID, int UserID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticlesByNroRevista", ItemID, UserID), typeof(ArticleInfo));
        }

        public ArrayList GetNuevosProfesionales(int ItemID, int UserID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticlesNuevos", ItemID, UserID), typeof(ArticleInfo));
        }

        public ArrayList GetVistosProfesionales(int ItemID, int UserID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticlesVistos", ItemID, UserID), typeof(ArticleInfo));
        }

        public ArrayList GetRelacionados(int PortalID, int ItemID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetRelacionados", PortalID, ItemID), typeof(ArticleInfo));
        }

        public ArrayList GetRelacionadosByTag(int ItemID, int UserID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "getArticlesRelacionadosByTag", ItemID, UserID), typeof(ArticleInfo));
        }


        public void AddArticleRelacion(int ItemID, int ItemIDRel, int UserID)
        {
            DataProvider.Instance().ExecuteReader(_spPrefix + "AddArticleRelacion", ItemID, ItemIDRel, UserID);
        }

        public void DeleteArticleRelacion(int ItemID, int ItemIDRel)
        {
            DataProvider.Instance().ExecuteReader(_spPrefix + "DeleteArticleRelacion", ItemID, ItemIDRel);
        }

        public static bool ExisteArticle(int ItemId)
        {
            bool res;
            IDataReader sql;
            sql = DataProvider.Instance().ExecuteReader(_spPrefix + "GetArticle", ItemId);
            if (sql.Read())
                res = true;
            else
                res = false;
            sql.Close();
            return res;
        }

        public static string GetTagName(int tagid)
        {
            IDataReader sql;
            string tag;
            sql = DataProvider.Instance().ExecuteReader(_spPrefix + "GetTagByID", tagid);
            if (sql.Read())
            {
                sql.Read();
                tag = sql.GetValue(0).ToString();
            }
            else
                tag = "";
            sql.Close();
            return tag;
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

        // comments
        public static void AddComment(CommentInfo objComment)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "AddComment", objComment.ArticleId, objComment.Name, objComment.Email, objComment.Comment, objComment.Approved);
        }

        public static void AddCommentReply(int commentID, string sReply)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "AddCommentReply", commentID, sReply);
        }

        public static void UpdateComment(CommentInfo objComment)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "UpdateComment", objComment.CommentId, objComment.ArticleId, objComment.Name, objComment.Email, objComment.Comment, objComment.Approved);
        }

        public static ArrayList GetComments(int ArticleId)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetComments", ArticleId), typeof(CommentInfo));
        }

        public static int GetCommentsCount(int ArticleId)
        {
            IDataReader sql;
            int cant;
            sql = DataProvider.Instance().ExecuteReader(_spPrefix + "GetCommentsCount", ArticleId);
            if (sql.Read())
            {
                sql.Read();
                cant = Convert.ToInt32(sql.GetValue(0));
            }
            else
                cant = -1;
            sql.Close();
            return cant;
        }

        public static void DeleteComment(int commentID)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "DeleteComment", commentID);
        }

        public static void ApproveComment(int commentID)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "ApproveComment", commentID);
        }

        public static ArrayList GetUnApprovedComments(int ModuleId)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetUnApprovedComments", ModuleId), typeof(UnApprovedCommentInfo));
        }

        public static ArrayList GetSiteWideUnApprovedComments(int PortalId)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetSiteWideUnApprovedComments", PortalId), typeof(SiteWideUnApprovedCommentInfo));
        }
        // /comments

        public static Dictionary<string, string> GetArticleTemplates(string sFilter)
        {
            var arListItems = new Dictionary<string, string>();
            string[] sFileList;

            
            int PortalID = DotNetNuke.Entities.Portals.PortalController.Instance.GetCurrentPortalSettings().PortalId;

            // List Templates
            sFileList = Directory.GetFiles(System.Web.HttpContext.Current.Request.MapPath(_SharedTemplatePath), sFilter + "*.ascx");
          
          
            foreach (string sFileName in sFileList)
            {
                string sInnerFileName = sFileName.Substring(sFileName.LastIndexOf('\\') + 1);
                arListItems.Add(sInnerFileName.Replace(".ascx", "").Replace(sInnerFileName, ""), sInnerFileName);
            }

            string sPortalSpecificTemplatePath = System.Web.HttpContext.Current.Request.MapPath(string.Format(_PortalSpecificTemplatePath, PortalID.ToString()));
            // TODO: Uncomment this out, don't want to enable until the path is right
            // If Not Directory.Exists(sPortalSpecificTemplatePath) Then
            // Directory.CreateDirectory(sPortalSpecificTemplatePath)
            // End If
            if (Directory.Exists(sPortalSpecificTemplatePath))
            {
                sFileList = Directory.GetFiles(sPortalSpecificTemplatePath, sFilter + "*.ascx");
                foreach (var sFileName in sFileList)
                {
                    var sInnerFileName = sFileName.Substring(sFileName.LastIndexOf('\\') + 1);
                    arListItems.Add(sInnerFileName.Replace(".ascx", "").Replace(sInnerFileName, ""), sInnerFileName);
                }
            }

            return arListItems;
        }

        public static string GetArticleTemplatePath(string sTemplateName, string sPrefix)
        {
            string sRelativePath;

            string sSharedTemplatePath = _SharedTemplatePath + sPrefix + sTemplateName + ".ascx";
            if (sTemplateName == "")
                sRelativePath = _SharedTemplatePath + sPrefix + "Standard.ascx";
            else
            {
                string sPortalSpecificTemplatePath = _PortalSpecificTemplatePath + sPrefix + sTemplateName + ".ascx";
                sPortalSpecificTemplatePath = string.Format(sPortalSpecificTemplatePath, DotNetNuke.Entities.Portals.PortalController.Instance.GetCurrentPortalSettings().PortalId);
                if (File.Exists(HttpContext.Current.Request.MapPath(sPortalSpecificTemplatePath)))
                    sRelativePath = sPortalSpecificTemplatePath;
                else if (File.Exists(HttpContext.Current.Request.MapPath(sSharedTemplatePath)))
                    sRelativePath = sSharedTemplatePath;
                else
                {
                    DotNetNuke.Services.Log.EventLog.EventLogController el = new DotNetNuke.Services.Log.EventLog.EventLogController();
                    string s = string.Format("Error Loading Template: {0};{1};{2}", sTemplateName, HttpContext.Current.Request.MapPath(sPortalSpecificTemplatePath), HttpContext.Current.Request.MapPath(sSharedTemplatePath));
                    el.AddLog("Articles Module", s, DotNetNuke.Entities.Portals.PortalController.Instance.GetCurrentPortalSettings(), 0, DotNetNuke.Services.Log.EventLog.EventLogController.EventLogType.ADMIN_ALERT);

                    sRelativePath = _SharedTemplatePath + sPrefix + "Standard.ascx";
                }
            }
            return sRelativePath;
        }

        public static ArrayList GetExistingInstances(int PortalId, int ModuleId)
        {
            // Returns all existing instances of the Articles module, used for displaying the details in another module
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetExistingInstances", PortalId, ModuleId), typeof(ExistingInstance));
        }

        public static void SetupCustomPermissions()
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "SetupCustomPermissions");
        }

        public static void AddRSSFeed(ref RSSFeed feed)
        {
            int id;
            id = DataProvider.Instance().ExecuteScalar<int>(_spPrefix + "AddRSSFeed", feed.PortalID, feed.ModuleId, feed.FeedName, feed.FeedSource);
            feed.FeedID = id;
        }

        public static RSSFeed AddRSSFeed(int PortalId, int ModuleId, string feedName, string feedURL)
        {
            RSSFeed feed = new RSSFeed(PortalId, ModuleId, feedName, feedURL);
            feed.FeedID = DataProvider.Instance().ExecuteScalar<int>(_spPrefix + "AddRSSFeed", PortalId, ModuleId, feedName, feedURL);
            return feed;
        }
        public static void UpdateRSSFeed(ref RSSFeed feed)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "UpdateRSSFeed", feed.FeedID, feed.PortalID, feed.ModuleId, feed.FeedName, feed.FeedSource);
        }

        public static void DeleteRSSFeed(int feedId)
        {
            DataProvider.Instance().ExecuteScalar(_spPrefix + "DeleteRSSFeed", feedId);
        }
        public static ArrayList GetRSSFeeds(int PortalID, int ModuleID)
        {
            return CBO.FillCollection(DataProvider.Instance().ExecuteReader(_spPrefix + "GetRSSFeeds", PortalID, ModuleID), typeof(RSSFeed));
        }




        /// -----------------------------------------------------------------------------
        ///         ''' <summary>
        ///         ''' GetSearchItems implements the ISearchable Interface
        ///         ''' </summary>
        ///         ''' <remarks>
        ///         ''' </remarks>
        ///         ''' <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        ///         ''' <history>
        ///         ''' </history>
        ///         ''' -----------------------------------------------------------------------------
        public SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {
            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();
            ModuleController objModules = new ModuleController();
            ModuleInfo objModule = objModules.GetModule(ModInfo.ModuleID, ModInfo.TabID);
            Hashtable settings = objModules.GetTabModuleSettings(objModule.TabModuleID);

            int nModuleID = ModInfo.ModuleID;
            if (Convert.ToBoolean(settings["SiteWide"]))
                nModuleID = -1;
            string sCategories = settings["CategoryID"].ToString();
            bool bFeatured = Convert.ToBoolean(settings["Featured"]);

            ArrayList Articles = GetArticles(ModInfo.PortalID, nModuleID, -1, sCategories, "", 500, -1, true, bFeatured, false, false, "CreatedDate");

           
            foreach (ArticleInfo objArticle in Articles)
            {
                try
                {
                    SearchItemInfo SearchItem;
                    int CreatorId = Null.NullInteger;
                    CreatorId = objArticle.UserId;
                    string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(objArticle.Description, false), MAX_DESCRIPTION_LENGTH, "...");
                    int nFileID = -1;
                    if (objArticle.ImageFile == null)
                    {
                        if (objArticle.ImageFile.Length > 7)
                            nFileID = Convert.ToInt32(objArticle.ImageFile.Substring(7));
                    }

                    string tabid;
                    IDataReader dr = DataProvider.Instance().ExecuteReader(_spPrefix + "GetTabIDByItemID", objArticle.ItemId);
                    dr.Read();
                    tabid = dr["TabId"].ToString();
                    dr.Close();
                    string url_pp;
                    switch (tabid)
                    {
                        case "90":
                            {
                                url_pp = "/articulos/";
                                break;
                            }

                        case "140":
                            {
                                url_pp = "/bebe/semana-a-semana/";
                                break;
                            }

                        case "129":
                            {
                                url_pp = "/embarazo/semana-a-semana/";
                                break;
                            }

                        default:
                            {
                                url_pp = "/articulos/";
                                break;
                            }
                    }


                    // SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & objArticle.Title, HtmlUtils.Clean(strDescription, False), CreatorId, objArticle.CreatedDate, ModInfo.ModuleID, objArticle.ItemId.ToString, HttpUtility.HtmlDecode(objArticle.Title & " " & objArticle.SubHead & " " & objArticle.Description & " " & objArticle.Article & " " & objArticle.Keywords & " " & objArticle.Categories), "itemid=" & objArticle.ItemId.ToString & "&amid=" & nModuleID, nFileID)
                    SearchItem = new SearchItemInfo(objArticle.Title + "@@" + url_pp + objArticle.ItemId.ToString() + "-" + TransformTitle(objArticle.Title) + "@@" + Regex.Replace(HttpUtility.HtmlDecode(Regex.Replace(objArticle.Description, "<.*?>", "")), "<.*?>", ""), Regex.Replace(HttpUtility.HtmlDecode(Regex.Replace(strDescription, "<.*?>", "")), "<.*?>", ""), CreatorId, objArticle.CreatedDate, ModInfo.ModuleID, objArticle.ItemId.ToString(), HttpUtility.HtmlDecode(objArticle.Title + " " + objArticle.SubHead + " " + objArticle.Description + " " + objArticle.Article + " " + objArticle.Keywords + " " + objArticle.Categories), "/articulos", nFileID);
                    SearchItemCollection.Add(SearchItem);
                }
                catch (Exception ex)
                {
                    // ex.Message = "Articles.GetSearchItems: Exception adding Article to SearchItem table. Error Message: " & ex.Message
                    DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
                }
            }

            return SearchItemCollection;
        }

        /// -----------------------------------------------------------------------------
        ///         ''' <summary>
        ///         ''' ExportModule implements the IPortable ExportModule Interface
        ///         ''' </summary>
        ///         ''' <remarks>
        ///         ''' </remarks>
        ///         ''' <param name="ModuleID">The Id of the module to be exported</param>
        ///         ''' <history>
        ///         ''' </history>
        ///         ''' -----------------------------------------------------------------------------
        public string ExportModule(int ModuleID)
        {
            string strXML = "";

            // TODO: Export Requires testing and refinement.
            // Somehow we need to get the PortalID rather than passing in zero
            // Dim arrArticles As ArrayList = GetArticles(PortalID,ModuleID,"",500,-1,0,0,"",1,1)
            // TODO: This doesn't filter by category currently because categories may get different IDs... would need to associate by category name
            ArrayList arrArticles = GetArticles(0, ModuleID, -1, "", "", 500, -1, false, false, true, true, "CreatedDate");
            if (arrArticles.Count != 0)
            {
                strXML += "<articles>";
                
                foreach (ArticleInfo objArticle in arrArticles)
                {
                    strXML += "<article>";
                    // strXML += "<category>" & XMLUtils.XMLEncode(objArticle.CategoryName) & "</category>"
                    strXML += "<title>" + XmlUtils.XMLEncode(objArticle.Title) + "</title>";
                    strXML += "<subhead>" + XmlUtils.XMLEncode(objArticle.SubHead) + "</subhead>";
                    strXML += "<description>" + XmlUtils.XMLEncode(objArticle.Description) + "</description>";
                    strXML += "<keywords>" + XmlUtils.XMLEncode(objArticle.Keywords) + "</keywords>";
                    strXML += "<PublishDate>" + XmlUtils.XMLEncode(objArticle.PublishDate.ToString()) + "</PublishDate>";
                    strXML += "<expiredate>" + XmlUtils.XMLEncode(objArticle.ExpireDate.ToString()) + "</expiredate>";
                    strXML += "<authed>" + XmlUtils.XMLEncode(objArticle.Featured.ToString()) + "</authed>";
                    strXML += "<featured>" + XmlUtils.XMLEncode(objArticle.Featured.ToString()) + "</featured>";
                    strXML += "<article>" + XmlUtils.XMLEncode(objArticle.Article.ToString()) + "</article>";
                    strXML += "<imagefile>" + XmlUtils.XMLEncode(objArticle.ImageFile.ToString()) + "</imagefile>";
                    strXML += "</article>";
                }
                strXML += "</articles>";
            }

            return strXML;
        }

        /// -----------------------------------------------------------------------------
        ///         ''' <summary>
        ///         ''' ImportModule implements the IPortable ImportModule Interface
        ///         ''' </summary>
        ///         ''' <remarks>
        ///         ''' </remarks>
        ///         ''' <param name="ModuleID">The Id of the module to be imported</param>
        ///         ''' <history>
        ///         ''' </history>
        ///         ''' -----------------------------------------------------------------------------
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {
            
            System.Xml.XmlNode xmlArticles = DotNetNuke.Common.Globals.GetContent(Content, "articles");
            foreach (System.Xml.XmlNode xmlArticle in xmlArticles)
            {
                ArticleInfo objArticle = new ArticleInfo();
                objArticle.ModuleId = ModuleID;
                objArticle.Title = xmlArticle["title"].InnerText;
                objArticle.SubHead = xmlArticle["subhead"].InnerText;
                objArticle.Description = xmlArticle["description"].InnerText;
                objArticle.Keywords = xmlArticle["keywords"].InnerText;
                objArticle.Article = xmlArticle["article"].InnerText;
                objArticle.Authed = bool.Parse(xmlArticle["authed"].InnerText);
                objArticle.PublishDate = DateTime.Parse(xmlArticle["PublishDate"].InnerText);
                objArticle.ExpireDate = DateTime.Parse(xmlArticle["expiredate"].InnerText);
                objArticle.Featured = bool.Parse(xmlArticle["featured"].InnerText);
                objArticle.ImageFile = xmlArticle["imagefile"].InnerText;
                objArticle.UserId = UserId;
                AddArticle(objArticle);
            }
        }
    }

}