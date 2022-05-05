using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
namespace WebAppLab.Pages.MarcaVehiculo
{
    public class EditModel : PageModel
    {
        private readonly IMarcaVehiculoService marcaVehiculoService;

        public EditModel(IMarcaVehiculoService marcaVehiculoService)
        {
            this.marcaVehiculoService = marcaVehiculoService;
        }

        [BindProperty(SupportsGet =true)]
        public int? id { get; set; }

        [BindProperty]
        public MarcaVehiculoEntity Entity { get; set; } = new MarcaVehiculoEntity();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {
                    Entity = await marcaVehiculoService.GetById(new() { MarcaVehiculoId=id });
                }

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                if (Entity.MarcaVehiculoId.HasValue)
                {
                    //Actualizar
                    var result = await marcaVehiculoService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);

                    TempData["Msg"] = "Se Actualizo Correctamente";

                }
                else
                {
                    //Nuevo registro

                    var result = await marcaVehiculoService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);

                    TempData["Msg"] = "Se Agrego Correctamente";
                }

                return RedirectToPage("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
        






    }
}
