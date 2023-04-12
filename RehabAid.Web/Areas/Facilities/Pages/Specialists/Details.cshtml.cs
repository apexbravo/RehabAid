using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Specialists
{
    public class DetailsModel : SysPageModel
    {
        public Specialist Specialist { get; set; }
        public void OnGet(Guid id)
        {
            Specialist = Db.Specialist
                
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
