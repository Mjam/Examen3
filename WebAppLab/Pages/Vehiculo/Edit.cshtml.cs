using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebAppLab.Pages.Vehiculo
{
    public class EditModel : PageModel
    {
        private readonly IVehiculoService vehiculoService;
        private readonly IMarcaVehiculoService marcaVehiculoService;

        public EditModel(IVehiculoService vehiculoService,IMarcaVehiculoService marcaVehiculoService)
        {
            this.vehiculoService = vehiculoService;
            this.marcaVehiculoService = marcaVehiculoService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public VehiculoEntity Entity { get; set; } = new VehiculoEntity();



        public IEnumerable<MarcaVehiculoEntity> MarcaVehiculoLista { get; set; } = new List<MarcaVehiculoEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await vehiculoService.GetById(new() { VehiculoId = id });
                }

                MarcaVehiculoLista = await marcaVehiculoService.GetLista();

                return Page();

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (Entity.VehiculoId.HasValue)
                {
                    //Actualizar
                    var result = await vehiculoService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);

                    TempData["Msg"] = "Se actualizó Correctamente";
                }
                else
                {
                    //Nuevo
                    var result = await vehiculoService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);

                    TempData["Msg"] = "Se agrego Correctamente";
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
