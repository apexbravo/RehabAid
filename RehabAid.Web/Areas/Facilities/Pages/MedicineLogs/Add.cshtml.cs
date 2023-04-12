using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.MedicineLogs
{
    public class AddModel : SysPageModel
    {
        [BindProperty]
        public MedicineLog MedicineLog { get; set; }
        public SelectList Patients { get; set; }





        public void OnGet()
        {
            Title = PageTitle = "Add new Medicine";
            Patients = new SelectList(Db.Patient, nameof(Patient.Id), nameof(Patient.FirstName));



        }
        public async Task<IActionResult> OnPost()
        {

            MedicineLog.Id = Guid.NewGuid();
            MedicineLog.CreatorId = CurrentUserId;
            MedicineLog.CreationDate = DateTime.UtcNow;



            await Db.MedicineLog.AddAsync(MedicineLog);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { MedicineLog.Id });
        }
    }

}


