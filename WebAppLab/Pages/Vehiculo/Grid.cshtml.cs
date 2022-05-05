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
    public class GridModel : PageModel
    {
        private readonly IVehiculoService vehiculoService;

        public GridModel(IVehiculoService vehiculoService)
        {
            this.vehiculoService = vehiculoService;
        }

        public IEnumerable<VehiculoEntity> GridList { get; set; } = new List<VehiculoEntity>();

        public string Mensaje { get; set; } = "";
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await vehiculoService.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"].ToString();

                }
                TempData.Clear();
                return Page();


            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await vehiculoService.Delete(new()
                {
                       VehiculoId = id
                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                Mensaje = "Se elimino correctamente";


                TempData["Msg"] = "Se elimino correctamente";

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
