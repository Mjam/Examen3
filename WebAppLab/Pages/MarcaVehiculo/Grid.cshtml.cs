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
    public class GridModel : PageModel
    {
        private readonly IMarcaVehiculoService marcaVehiculoService;

        public GridModel(IMarcaVehiculoService marcaVehiculoService)
        {
            this.marcaVehiculoService = marcaVehiculoService;
        }


        public IEnumerable<MarcaVehiculoEntity> GridList { get; set; } = new List<MarcaVehiculoEntity>();


        public string Mensaje { get; set; } = "";


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");

                GridList = await marcaVehiculoService.Get();


                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                   

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
                var result = await marcaVehiculoService.Delete( new() { 
                
                 MarcaVehiculoId=id
                });

                if (result.CodeError!=0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se elimino correctamente!";


                return Redirect("Grid");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        //public void OnPost()
        //{

        //}

        //public void OnPut()
        //{

        //}


        //public void OnDelete()
        //{

        //}
    }
}
