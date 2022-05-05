using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using WBL;
namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService )
        {
            this.vehiculoService = vehiculoService;
        }

        [HttpGet("Lista")]
        public async Task<IEnumerable<VehiculoEntity>> GetLista()
        {
            try
            {
                return await vehiculoService.GetLista();
            }
            catch (Exception ex)
            {

                return new List<VehiculoEntity>();
            }
        }
    }
}
