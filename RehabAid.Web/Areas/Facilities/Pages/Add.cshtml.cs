using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehabAid.Data;
using RehabAid.Web.Pages;
using System.Threading.Tasks;
using System;
using System.IO;
using wCyber.Helpers.Web;
using RehabAid.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehabAid.Lib;
using System.Linq;

namespace RehabAid.Web.Areas.Facilities.Pages
{
    public class AddModel : SysPageModel
    {
        [BindProperty]
        public TreatmentFacility TreatmentFacility { get; set; }
        public SelectList FacilityTypes { get; set; }

        [BindProperty]
        public IFormFile logo { get; set; }
        public void OnGet()
        {
            Title = PageTitle = "Add new Facility";
            FacilityTypes = new SelectList(Enum.GetValues(typeof(FacilityType))
                            .Cast<FacilityType>()
                            .Select(ft => new SelectListItem
                            {
                                Value = ((int)ft).ToString(),
                                Text = ft.ToString()
                            }), "Value", "Text");
        }

        public async Task<IActionResult> OnPost()
        {

            TreatmentFacility.Id = Guid.NewGuid();
            TreatmentFacility.CreatorId = CurrentUserId;
            TreatmentFacility.CreationDate = DateTime.UtcNow;

            if (logo != null && logo.Length > 0)
            {
                var attachments = TreatmentFacility.Attachments;
                var info = new FileInfo(logo.FileName);
                var attachment = new Attachment
                {
                    CreationDate = DateTime.UtcNow,
                    CreatorId = CurrentUserId,
                    Name = logo.FileName,
                    UniqueId = TreatmentFacility.Id,
                    Id = Guid.NewGuid(),
                    Size = (int)logo.Length,
                    Container = nameof(TreatmentFacility),
                    Extension = info.Extension,
                };
                attachments.Add(attachment);
                TreatmentFacility.AttachmentJson = attachments.ToJsonString();
                TreatmentFacility.LogoId = attachment.Id;
                await FileStore.UploadAsync(attachment.Container, attachment.UniqueId, $"{attachment.Id}{attachment.Extension}", logo.OpenReadStream().ToBytes());
                Db.Attachment.Add(attachment);
            }
            await Db.TreatmentFacility.AddAsync(TreatmentFacility);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { TreatmentFacility.Id });
        }
    }
}

