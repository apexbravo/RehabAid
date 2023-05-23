using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;
using wCyber.Helpers.Web;

namespace RehabAid.Web.Areas.Facilities.Pages.Patients
{
    public class Index1Model : SysPageModel 
    {
        public List<SpecialistReview> TherapistReviews { get; set; }
        private readonly JsonSerializerOptions _jsonOptions;
        public Patient Patient { get; set; }


        public string TherapistReviewsJson { get; set; }
        public Index1Model()
        {

            // Create JsonSerializerOptions with ReferenceHandler.Preserve
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
        }

        public async Task OnGetAsync(Guid id)
        {
   

            Patient = Db.Patient
                .Include(c => c.Facility)
                .Include(c => c.SpecialistReview).ThenInclude(c => c.Specialist)
                .Include(c => c.ProgressReport).ThenInclude(c => c.MedicineLog)
                .FirstOrDefault(c => c.Id == id);
            var therapistReviews = await Db.SpecialistReview
          .Where(review => review.PatientId == id)
          .Select(review => new
          {
              review.Id,
              review.SpecialistId,
              review.PatientId,
              review.Review,
              review.SentimentId,
              review.CreatorId,
              review.CreationDate,
              review.TimeOfSessionId,
              review.AgeOfPatientId
          })
          .ToListAsync();
            // Serialize therapistReviews to JSON with ReferenceHandler.Preserve
            TherapistReviewsJson = therapistReviews.ToJsonString();



        }
    }
}
