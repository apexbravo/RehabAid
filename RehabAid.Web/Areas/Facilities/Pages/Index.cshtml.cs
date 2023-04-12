using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;
using X.PagedList;

namespace RehabAid.Web.Areas.Facilities.Pages
{
    public class IndexModel : SysListPageModel<TreatmentFacility>
    {
        public void OnGet(int? p, int? ps, string q)
        {
            var query = Db.TreatmentFacility.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                QueryString = q;
                query = query.Where(c => c.Name.Contains(q));
            }

            List = query.OrderBy(c => c.Name).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
        }
    }
}
