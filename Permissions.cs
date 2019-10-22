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
using DotNetNuke.Security.Permissions;
using DotNetNuke.Entities.Modules;
using System.Collections;
namespace Christoc.Modules.NewArticles
{
    public class Permissions
    {
        // Constants 
        public const string PERMISSIONCODE = "Efficion_Articles";

        // private variables 
        // Private _ViewDetails As Boolean
        private bool _Approve;
        private bool _EditOthers;
        private bool _ModerateComments;

        public Permissions(DotNetNuke.Entities.Modules.ModuleInfo mi)
        {
            ModulePermissionCollection permCollection = mi.ModulePermissions;
            // _ViewDetails = ModulePermissionController.HasModulePermission(permCollection, "ViewDetails")
            _Approve = ModulePermissionController.HasModulePermission(permCollection, "Approve");
            _EditOthers = ModulePermissionController.HasModulePermission(permCollection, "EditOthers");

            Hashtable settings = mi.ModuleSettings;
            var sModerateCommentRoles = System.Convert.ToString(settings["ModerateCommentRoles"]);
            if (sModerateCommentRoles == null)
            {
                if (DotNetNuke.Security.PortalSecurity.IsInRoles(sModerateCommentRoles))
                    _ModerateComments = true;
            }
        }

        // Public ReadOnly Property ViewDetails() As Boolean
        // Get
        // Return _ViewDetails
        // End Get
        // End Property
        public bool Approve
        {
            get
            {
                return _Approve;
            }
        }
        public bool EditOthers
        {
            get
            {
                return _EditOthers;
            }
        }
        public bool ModerateComments
        {
            get
            {
                return _ModerateComments;
            }
        }
    }
}