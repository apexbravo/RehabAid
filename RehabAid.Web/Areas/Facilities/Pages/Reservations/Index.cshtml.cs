using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehabAid.Data;
using RehabAid.Web.Pages;
using X.PagedList;

namespace RehabAid.Web.Areas.Facilities.Pages.Reservations
{
    public class IndexModel : SysListPageModel<Reservation>
    {
        public void OnGet(int? p, int? ps, string q)
        {
            var query = Db.Reservation.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                QueryString = q;
                query = query.Where(c => c.Name.Contains(q));
            }

            List = query.OrderBy(c => c.Name).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
        }
    }
}


