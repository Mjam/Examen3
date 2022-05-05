using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebAppLab.Pages.Alquiler
{
    public class EditModel : PageModel
    {
        private readonly ServiceApi service;

        public EditModel(ServiceApi service)
        {
            this.service = service;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public AlquilerEntity Entity { get; set; } = new AlquilerEntity();


        public IEnumerable<ClientesEntity> ClienteLista { get; set; } = new List<ClientesEntity>();

        public IEnumerable<VehiculoEntity> VehiculoLista { get; set; } = new List<VehiculoEntity>();




        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await service.AlquilerGetById(id.Value);
                }


                ClienteLista = await service.ClientesGetLista();

                VehiculoLista = await service.VehiculoGetLista();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }


    }
}
