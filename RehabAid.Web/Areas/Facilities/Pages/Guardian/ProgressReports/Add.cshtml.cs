using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Guardian.ProgressReports
{
    public class AddModel : SysPageModel
    {

   
        public SelectList patients { get; set; }
        [BindProperty]

        public ProgressReport ProgressReport { get; set; }

        public Patient Patient { get; set; }
        public MedicineLog MedicineLog { get; set; }

        public void OnGet(Guid id, Guid GuardianId)
        {
            Patient = Db.Patient.FirstOrDefault(c => c.Id == id);
            Title = PageTitle = "Progress Report";
            //TimeOfSessions = new SelectList(Enum.GetValues(typeof(TimeOfSessionEnum))
            //                .Cast<TimeOfSessionEnum>()
            //                .Select(ft => new SelectListItem
            //                {
            //                    Value = ((int)ft).ToString(),
            //                    Text = ft.ToString()
            //                }), "Value", "Text");
            patients = new SelectList(Db.Patient, nameof(Patient.Id), nameof(Patient.Fullname));
        }

        public async Task<IActionResult> OnPost(Guid id, Guid GuardianId, Guid MedicineLogId)
        {
            var Guardian = Db.Guardians.Include(c => c.Patient)
                .FirstOrDefault(c => c.PatientId == ProgressReport.PatientId);
            var Medicine = Db.MedicineLog.FirstOrDefault(c => c.PatientId == ProgressReport.PatientId);

            //SentimentType sentiment;
            ProgressReport.Id = Guid.NewGuid();
            ProgressReport.CreateDate = DateTime.Now;
            ProgressReport.CreatorId = CurrentUserId;
            ProgressReport.MedicineLogId = Medicine.Id;
            ProgressReport.GuardianId = Guardian.Id;
     


            //TimeOfSessionEnum time = SpecialistReview.TimeOfSession;

            //ModelInput input = new ModelInput()
            //{
            //    Selected_text = SpecialistReview.Review,
            //    Time_of_session = time.ToString(),
            //};

            //// Load model and predict output of sample data
            //ModelOutput result = ConsumeModel.Predict(input);
            //bool success = Enum.TryParse(result.Prediction, true, out sentiment);
            //if (success)
            //{
            //    SpecialistReview.SentimentId = (int)sentiment;
            //}
            //else
            //{
            //    // handle the case where the string value doesn't match any enum value
            //}


            await Db.ProgressReport.AddAsync(ProgressReport);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { ProgressReport.Id });
        }
    }
}
