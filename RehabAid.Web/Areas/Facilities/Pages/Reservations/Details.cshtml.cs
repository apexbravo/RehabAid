using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RehabAid.Data;
using RehabAid.Lib;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Reservations
{
    public class DetailsModel : SysPageModel
    {
        public Reservation Reservation { get; set; }
        public void OnGet(Guid id)
        {
            Reservation = Db.Reservation

                .FirstOrDefault(c => c.Id == id);
        }

        public async Task OnGetApproveAsync(Guid id)
        {

            Reservation = Db.Reservation
            .FirstOrDefault(c => c.Id == id);

            var Facility = Db.TreatmentFacility.FirstOrDefault(c => c.Id == Reservation.FacilityId);

            var sfd = id;

            Reservation.Status = (int)Status.Accepted;
            Db.SaveChanges();

            using (var httpClient = new HttpClient())
            {
                var functionUrl = "http://localhost:7071/api/SendEmail";
                var requestBody = new
                {
                    Email = Reservation.Email,
                    Facility = Facility.Name,
                    MessageType = (int)EmailType.Accept,



                };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(functionUrl, content);


            }


        }

        public async Task OnGetDenyAsync(Guid id)
        {
            Reservation = Db.Reservation
            .FirstOrDefault(c => c.Id == id);

            var Facility = Db.TreatmentFacility.FirstOrDefault(c => c.Id == Reservation.FacilityId);

            var sfd = id;
            Reservation.Status = (int)Status.Rejected;
            Db.SaveChanges();
            using (var httpClient = new HttpClient())
            {
                var functionUrl = "http://localhost:7071/api/SendEmail";
                var requestBody = new
                {
                    Email = Reservation.Email,
                    Facility = Facility.Name,
                    MessageType = (int)EmailType.Accept,



                };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(functionUrl, content);


            }
        }
    }
}
