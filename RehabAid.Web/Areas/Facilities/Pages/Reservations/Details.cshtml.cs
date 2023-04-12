using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehabAid.Data;
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
    }
}
