using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
namespace WebAppLab.Pages.Alquiler
{
    public class GridModel : PageModel
    {
        private readonly ServiceApi service;

        public GridModel(ServiceApi service)
        {
            this.service = service;
        }
        public IEnumerable<AlquilerEntity> GridList { get; set; } = new List<AlquilerEntity>();
        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await service.AlquilerGet();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }


    }
}
