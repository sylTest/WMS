﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using System.Security.Principal;
using Microsoft.Practices.Unity;
using THOK.Authority.Bll.Interfaces;

namespace THOK.Security
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FormsAuthorizeAttribute : AuthorizeAttribute
    {
        [Dependency]
        private IUserService UserService { get; set; }
        [Dependency]
        private IRoleService RoleService { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User == null || !(filterContext.HttpContext.User.Identity is FormsIdentity) || !filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "LogOn" }, { "returnUrl", filterContext.HttpContext.Request.Url.PathAndQuery } });
            }
            else
            {
                string strFunctionID = filterContext.HttpContext.Request.Params["FunID"];
                Roles += "," + RoleService.FindRolesForFunction(strFunctionID);
                Users += ",Administrator," + UserService.FindUsersForFunction(strFunctionID);

                base.OnAuthorization(filterContext);
                if (filterContext.Result is HttpUnauthorizedResult)
                {
                    filterContext.Result = new RedirectResult("/Home/Unauthorized");
                }
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
            var users = SplitString(Users);
            var roles = SplitString(Roles);

            if (!((roles.Length > 0) && !roles.Any<string>(new Func<string, bool>(user.IsInRole))))
            {
                return true;
            }
            if (!((users.Length > 0) && !users.Contains<string>(user.Identity.Name, StringComparer.OrdinalIgnoreCase)))
            {
                return true;
            }
            return false;
        }

        internal static string[] SplitString(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return new string[0];
            }
            return (from piece in original.Split(new char[] { ',' })
                    let trimmed = piece.Trim()
                    where !string.IsNullOrEmpty(trimmed)
                    select trimmed).ToArray<string>();
        }
    }
}