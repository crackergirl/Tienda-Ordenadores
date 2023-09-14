using Microsoft.AspNetCore.Mvc;

namespace TiendaOrdenadoresDB.Views.ViewModels.ViewComponents
{
	public class SliderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return await Task.FromResult((IViewComponentResult)View("Default"));
        }
    }
}

