using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;
namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService clientesService;

        public ClientesController(IClientesService clientesService)
        {
            this.clientesService = clientesService;
        }



        [HttpGet]
        public async Task<IEnumerable<ClientesEntity>> Get()
        {
            try
            {
                return await clientesService.Get();
            }
            catch (Exception ex)
            {

                return new List<ClientesEntity>() ;
            }
        }


        [HttpGet("Lista")]
        public async Task<IEnumerable<ClientesEntity>> GetLista()
        {
            try
            {
                return await clientesService.Get();
            }
            catch (Exception ex)
            {

                return new List<ClientesEntity>();
            }
        }

        [HttpGet("{id}")]
        public async Task<ClientesEntity> GetById(int id)
        {
            try
            {
                return await clientesService.GetById(new ClientesEntity { ClientesId=id });
            }
            catch (Exception ex)
            {

                return new ClientesEntity { CodeError=ex.HResult,MsgError=ex.Message };
            }
        }


        [HttpPost]
        public async Task<DBEntity> Create(ClientesEntity entity)
        {
            try
            {
                return await clientesService.Create(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpPut]
        public async Task<DBEntity> Update(ClientesEntity entity)
        {
            try
            {
                return await clientesService.Update(entity);
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
                return await clientesService.Delete(new ClientesEntity() { ClientesId=id } );
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }





    }
}
