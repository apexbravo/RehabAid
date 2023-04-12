using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Guardian
{
    public class DetailsModel : SysPageModel
    {
        public Guardians Guardian { get; set; }
        public void OnGet(Guid id)
        {
            Guardian = Db.Guardians
                .Include(c => c.Facility)
                .Include(c => c.Patient)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
