using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehabAid.Data;
using RehabAid.Lib;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Patients
{
    public class AddModel : SysPageModel
    {
        [BindProperty]
        public Patient Patient { get; set; }

        public SelectList Gender { get; set; }
        public SelectList TreatmentFacilities { get; set; }

        public void OnGet()
        {
            Title = PageTitle = "Add new Patient";
            Gender = new SelectList(Enum.GetValues(typeof(Gender))
                           .Cast<Gender>()
                           .Select(ft => new SelectListItem
                           {
                               Value = ((int)ft).ToString(),
                               Text = ft.ToString()
                           }), "Value", "Text");
            TreatmentFacilities = new SelectList(Db.TreatmentFacility, nameof(TreatmentFacility.Id), nameof(TreatmentFacility.Name));

        }
        public async Task<IActionResult> OnPost()
        {
            Patient.Id = Guid.NewGuid();
            Patient.CreatorId = CurrentUserId;
            Patient.CreationDate = DateTime.UtcNow;
            await Db.Patient.AddAsync(Patient);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { Patient.Id });

        }
    }
}
