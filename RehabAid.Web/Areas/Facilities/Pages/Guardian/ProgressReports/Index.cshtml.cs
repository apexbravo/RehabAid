using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;
using RehabAid.Web.Pages.Auth;
using X.PagedList;

namespace RehabAid.Web.Areas.Facilities.Pages.Guardian.ProgressReports
{
    public class IndexModel : SysListPageModel<ProgressReport>
    {
        public void OnGet(int? p, int? ps, string q)
        {
            IQueryable<ProgressReport> query;
            if(User.IsGuardians())
            {
                query = Db.ProgressReport
          .Include(c => c.Guardian)
          .Include(c => c.Patient)
          .Include(c => c.MedicineLog)
          .AsQueryable().Where(c => c.GuardianId.ToString() == User.GetPortalId());
            }
            else
            {
                query = Db.ProgressReport
          .Include(c => c.Guardian)
          .Include(c => c.Patient)
          .Include(c => c.MedicineLog)
          .AsQueryable();
            }
       



            List = query.OrderBy(c => c.CreateDate).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
        }
    }
}
