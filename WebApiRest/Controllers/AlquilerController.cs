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
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService alquilerService;

        public AlquilerController(IAlquilerService alquilerService)
        {
            this.alquilerService = alquilerService;
        }




        [HttpGet]
        public async Task<IEnumerable<AlquilerEntity>> Get()
        {
            try
            {
                return await alquilerService.Get();
            }
            catch (Exception ex)
            {

                return new List<AlquilerEntity>();
            }
        }

      
        public async Task<AlquilerEntity> GetById(int id)
        {
            try
            {
                return await alquilerService.GetById(new AlquilerEntity { IdAlquiler = id });
            }
            catch (Exception ex)
            {

                return new AlquilerEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }


        [HttpPost]
        public async Task<DBEntity> Create(AlquilerEntity entity)
        {
            try
            {
                return await alquilerService.Create(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpPut]
        public async Task<DBEntity> Update(AlquilerEntity entity)
        {
            try
            {
                return await alquilerService.Update(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }


        [HttpDelete("{id}")]
        public async Task<DBEntity> Delete(int id)
        {
            try
            {
                return await alquilerService.Delete(new AlquilerEntity() { IdAlquiler = id });
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }



    }
}
