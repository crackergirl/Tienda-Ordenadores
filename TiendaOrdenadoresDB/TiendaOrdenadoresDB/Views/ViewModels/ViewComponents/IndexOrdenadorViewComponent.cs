using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresDB.Models;

namespace TiendaOrdenadoresDB.Views.ViewModels.ViewComponents
{
	public class IndexOrdenadorViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Ordenador> model)
        {

            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }
    }
}

