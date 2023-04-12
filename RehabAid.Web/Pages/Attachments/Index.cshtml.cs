using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehabAid.Data;
using X.PagedList;

namespace RehabAid.Web.Pages.Attachments
{
    [AllowAnonymous]
    public class IndexModel : SysListPageModel<Attachment>
    {
        public void OnGet(int? p, int? ps)
        {
            var query = Db.Attachment.AsQueryable();
            Title = PageTitle = "Attachments";
            List = query.OrderBy(c => c.CreationDate).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
        }
        public async Task<FileResult> OnGetImage(Guid? Id)
        {
            if (Id.HasValue)
            {
                var attachment = Db.Attachment.Find(Id);
                var data = await FileStore.DownloadAsync(attachment.Container, attachment.UniqueId, $"{Id}{attachment.Extension}");
                return File(data, MimeMapping.MimeUtility.GetMimeMapping(attachment.Name));
            }
            return File("~/images/placeholder.png", MimeMapping.MimeUtility.GetMimeMapping("dummy.png"));
        }
    }
}
