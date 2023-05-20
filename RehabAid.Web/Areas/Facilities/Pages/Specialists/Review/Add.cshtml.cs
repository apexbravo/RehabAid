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
using RehabAid_WebML.Model;


namespace RehabAid.Web.Areas.Facilities.Pages.Specialists.Review
{
    public class AddModel : SysPageModel
    {
       
        public SelectList TimeOfSessions { get; set; }

        [BindProperty]

        public SpecialistReview SpecialistReview { get; set; }

        public Patient Patient { get; set; }

        public void OnGet(Guid id, Guid specialistId)
        {
            Patient = Db.Patient.FirstOrDefault(c => c.Id == id);
            Title = PageTitle = "Specialist Review";
            TimeOfSessions = new SelectList(Enum.GetValues(typeof(TimeOfSessionEnum))
                            .Cast<TimeOfSessionEnum>()
                            .Select(ft => new SelectListItem
                            {
                                Value = ((int)ft).ToString(),
                                Text = ft.ToString()
                            }), "Value", "Text");
        }

        public async Task<IActionResult> OnPost(Guid id, Guid specialistId)
        {
            SentimentType sentiment = 0;
            SpecialistReview.Id = Guid.NewGuid();
            SpecialistReview.CreationDate = DateTime.Now;
            SpecialistReview.CreatorId = CurrentUserId;
            SpecialistReview.PatientId = id;
            SpecialistReview.SpecialistId = specialistId;

            TimeOfSessionEnum time = SpecialistReview.TimeOfSession;

            ModelInput input = new ModelInput()
            {
                Selected_text = SpecialistReview.Review,
                Time_of_session = time.ToString(),
            };

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
switch (result.Prediction)
{
    case "positive":
        sentiment = SentimentType.positively;
        break;
    case "negative":
        sentiment = SentimentType.negatively;
        break;
    case "neutral":
        sentiment = SentimentType.fairly;
        break;
    default:
        // handle the case where the sentiment value doesn't match any enum value
        break;
}

SpecialistReview.SentimentId = (int)sentiment;
            

            await Db.SpecialistReview.AddAsync(SpecialistReview);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { SpecialistReview.Id });
        }
        }
}
