using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehabAid.Data;
using RehabAid.Web.Pages;
using X.PagedList;

namespace RehabAid.Web.Areas.Facilities.Pages.Guardian
{
   
        public class IndexModel : SysListPageModel<Guardians>
        {
            public void OnGet(int? p, int? ps, string q)
            {
                var query = Db.Guardians.AsQueryable();

                if (!string.IsNullOrWhiteSpace(q))
                {
                    QueryString = q;
                    query = query.Where(c => c.FirstName.Contains(q));
                }
                List = query.OrderBy(c => c.FirstName).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
            }
        }
    }



