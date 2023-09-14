using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresDB.Models;

namespace TiendaOrdenadoresDB.Views.ViewModels.ViewComponents
{
	public class IndexComponenteViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Componente> model)
        {

            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }
    }
}

