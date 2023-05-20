using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Guardian.ProgressReports
{
    public class DetailsModel : SysPageModel
    {
        public ProgressReport TherapyReview { get; set; }
        public void OnGet(Guid id)
        {
            Title = PageTitle = "Progress Report";
            TherapyReview = Db.ProgressReport
                .Include(c => c.Patient)
                .Include(c => c.Guardian)
                .Include(c => c.MedicineLog)
                .FirstOrDefault(c => c.Id == id);


        }
    }
}
