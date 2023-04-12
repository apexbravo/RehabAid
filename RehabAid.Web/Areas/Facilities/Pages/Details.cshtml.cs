using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages
{
    [AllowAnonymous]
    public class DetailsModel : SysPageModel
    {
        public TreatmentFacility TreatmentFacility { get; set; }
        public void OnGet(Guid id)
        {
            TreatmentFacility = Db.TreatmentFacility
                .Include(c => c.Logo)
                .Include(c => c.Patient)
                .FirstOrDefault(c => c.Id == id);


        }


    }
}
