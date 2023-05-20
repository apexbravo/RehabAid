using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages.Auth;

namespace RehabAid.Web.Pages
{

    public class DashboardModel : SysPageModel
    {
        public Guardians Guardian { get; set; }
        public Staff Staff { get; set; }

        public Specialist Specialist { get; set; }
        public Guid userportalId { get; set; }
        
        
        public IActionResult OnGet()
        {

            if(User.IsGuardians())
            {
                Guardian = Db.Guardians
               .Include(c => c.Facility)
               .Include(c => c.Patient)
               .FirstOrDefault(c => c.Id == CurrentUser.GuardianId);
                userportalId = Guardian.Id;

                return RedirectToPage("./Patients/Details", new { area = "Facilities", id = Guardian.PatientId });
            }
            else if(User.IsSpecialist())
            {
                Specialist = Db.Specialist

                .FirstOrDefault(c => c.Id == CurrentUser.SpecialistId);
                userportalId = Specialist.Id;
            }
            else if(User.IsStaff())
            {
                Staff = Db.Staff

               .FirstOrDefault(c => c.Id == CurrentUser.StaffId);
                userportalId = Staff.Id;

            }

            return Page();
        }
    }
}
