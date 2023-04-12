using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace RehabAid.Web.Pages
{
    public class SysListPageModel<T> : SysPageModel where T : class
    {
        [ViewData]
        public string SearchPlaceholder { get; protected set; }
        [ViewData]
        public string QueryString { get; protected set; }
        public IPagedList<T> List { get; protected set; }
        protected int DefaultPageSize { get; set; } = 50;
    }
}
