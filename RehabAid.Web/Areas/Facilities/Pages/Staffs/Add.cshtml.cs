using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Staffs
{
    public class AddModel : SysPageModel
    {
        [BindProperty]
        public Staff Staff { get; set; }





        public void OnGet()
        {
            Title = PageTitle = "Add new Staff ";

        }
        public async Task<IActionResult> OnPost()
        {

            Staff.Id = Guid.NewGuid();
            Staff.CreatorId = CurrentUserId;
            Staff.CreationDate = DateTime.UtcNow;



            await Db.Staff.AddAsync(Staff);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { Staff.Id });
        }
    }

}


