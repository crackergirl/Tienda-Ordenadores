using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresDB.ViewModels;

namespace MenuViewComponent.Views.ViewComponents
{
    public class LinksViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(LinksInfo model)
        {

            return await Task.FromResult((IViewComponentResult)View("Default",model));
        }
    }
}

