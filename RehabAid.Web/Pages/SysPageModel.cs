using RehabAid.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using wCyber.Helpers.Identity;
using wCyber.Lib.FileStorage;
using System.Collections.Generic;
namespace RehabAid.Web.Pages
{
    [Authorize]
    public class SysPageModel : PageModel
    {

        static bool _IsDbCreated;

        RehabAidContext _db;
        protected RehabAidContext Db
        {
            get
            {
                if (_db == null)
                {
                    _db = Request.HttpContext.RequestServices.GetService<RehabAidContext>();
                    if (!_IsDbCreated)
                    {
                        try
                        {
                            _db.Database.Migrate();
                        }
                        catch { }
                        _IsDbCreated = true;
                    }
                }
                return _db;
            }
        }

        public Guid CurrentUserId => Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        User _currentUser;
        public User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    _currentUser = Db.User
                        .FirstOrDefault(c => c.Id == CurrentUserId);
                }
                return _currentUser;


               

            }
        }


        [ViewData]
        public string Title { get; protected set; }

        [ViewData]
        public string PageTitle { get; protected set; }


        IFileStore _filestore;
        protected IFileStore FileStore
        {
            get
            {
                if (_filestore == null) _filestore = Request.HttpContext.RequestServices.GetService<IFileStore>();
                return _filestore;
            }
        }





        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Title = this.GetType().Namespace.Substring(this.GetType().Namespace.LastIndexOf(".") + 1);
            base.OnPageHandlerExecuting(context);
        }

    }
}
