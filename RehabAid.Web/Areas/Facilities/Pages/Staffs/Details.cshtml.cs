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
    public class DetailsModel : SysPageModel
    {
        public Staff Staff { get; set; }
        public void OnGet(Guid id)
        {
            Staff = Db.Staff

                .FirstOrDefault(c => c.Id == id);
        }
    }
}
