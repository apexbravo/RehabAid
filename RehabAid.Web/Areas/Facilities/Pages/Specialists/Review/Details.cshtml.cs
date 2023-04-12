using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Specialists.Review
{
    public class DetailsModel : SysPageModel
    {
        public SpecialistReview Review { get; set; }
        public void OnGet(Guid id)
        {
            Title = PageTitle = "Specialist Review";
            Review = Db.SpecialistReview
                .Include(c => c.Patient)
                .Include(c => c.Specialist)
                .FirstOrDefault(c => c.Id == id);


        }
    }
}
