using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RehabAid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabAid.Web.Pages
{
    [AllowAnonymous]
    public class IndexModel : SysPageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<TreatmentFacility> TreatmentFacilities { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            TreatmentFacilities = Db.TreatmentFacility.ToList();
        }
    }
}
