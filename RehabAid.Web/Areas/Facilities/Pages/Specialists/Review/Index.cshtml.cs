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
namespace RehabAid.Web.Areas.Facilities.Pages.Specialists.Review
{
    public class IndexModel : SysListPageModel<SpecialistReview>
    {
        public void OnGet(int? p, int? ps, string q)
        {
            var query = Db.SpecialistReview
                .Include(c => c.Specialist )
                .Include(c => c.Patient)
                .AsQueryable();

            

            List = query.OrderBy(c => c.CreationDate).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
        }
    }
}
