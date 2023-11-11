using AngleOk.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Models.ViewComonents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var isAdminArea = ViewContext.RouteData.Values["area"]?.ToString() == "Admin";

            if (isAdminArea)
                return Task.FromResult((IViewComponentResult)View("AdminSidebar"));

            return Task.FromResult((IViewComponentResult)View("Default", dataManager.Advertisements.GetAll()));
        }
    }
}
