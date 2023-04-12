using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Guardian
{
    public class AddModel : SysPageModel
    {
        [BindProperty]
        public Guardians Guardian { get; set; }

        public SelectList TreatmentFacilities { get; set; }
        public SelectList Patients { get; set; }


        public void OnGet()
        {
            Title = PageTitle = "Add new ";
            TreatmentFacilities = new SelectList(Db.TreatmentFacility, nameof(TreatmentFacility.Id), nameof(TreatmentFacility.Name));
            Patients = new SelectList(Db.Patient, nameof(Patient.Id), nameof(Patient.FirstName));

        }
        public async Task<IActionResult> OnPost()
        {
            Guardian.Id = Guid.NewGuid();
            


            await Db.Guardians.AddAsync(Guardian);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { Guardian.Id });

        }
    }
}
