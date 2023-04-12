using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Patients
{
    public class Index1Model : SysPageModel 
    {

        public Patient Patient { get; set; }
        public void OnGet(Guid id)
        {
            Patient = Db.Patient
                .Include(c => c.Facility)
                .FirstOrDefault(c => c.Id == id);

        }
    }
}
