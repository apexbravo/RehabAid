using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RehabAid.Data;
using RehabAid.Lib;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages
{
    [AllowAnonymous]
    public class AddReservationModel : SysPageModel
    {
        [BindProperty]
        public Reservation Reservation { get; set; }
        [BindProperty]

        public string name { get; set; }
        
        public void OnGet(Guid id)
        {
            
            TreatmentFacility treatmentFacility = Db.TreatmentFacility.FirstOrDefault(c => c.Id == id);
           name = treatmentFacility.Name;
            Title = PageTitle = "Add new Reservation for " + treatmentFacility.Name;


        }

        public async Task<IActionResult> OnPost(Guid id)
        {

            Reservation.Id = Guid.NewGuid();
            Reservation.FacilityId = id;
      
            Reservation.CreationDate = DateTime.UtcNow;
            Reservation.Status = (int)Status.Pending;

            //using (var httpClient = new HttpClient())
            //{
            //    var functionUrl = "http://localhost:7071/api/SendEmail";
            //    var requestBody = new
            //    {
            //        Email = Reservation.Email,
                  
            //    };
            //    var json = JsonConvert.SerializeObject(requestBody);
            //    var content = new StringContent(json, Encoding.UTF8, "application/json");
            //    var response = await httpClient.PostAsync(functionUrl, content);


            //}

            await Db.Reservation.AddAsync(Reservation);
            await Db.SaveChangesAsync();
          return  RedirectToPage("/Index", new { area = "" });

        }
    }
}
