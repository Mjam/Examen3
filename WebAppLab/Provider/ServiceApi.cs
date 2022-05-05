using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAppLab
{
    public class ServiceApi
    {
        private readonly HttpClient client;

        public ServiceApi(HttpClient client)
        {
            this.client = client;
        }

        #region Clientes
        public async Task<IEnumerable<ClientesEntity>> ClientesGet()
        {
            var result = await client.ServicioGetAsync<IEnumerable<ClientesEntity>>("api/Clientes");

            return result;

        }

       

        public async Task<ClientesEntity> ClientesGetById(int id)
        {
            var result = await client.ServicioGetAsync<ClientesEntity>("Clientes/" + id);

            if (result.CodeError is not 0) throw new Exception(result.MsgError);

            return result;

        }
        #endregion


        #region Agencias
        public async Task<IEnumerable<AgenciaEntity>> AgenciaGetLista()
        {
            var result = await client.ServicioGetAsync<IEnumerable<AgenciaEntity>>("api/Agencia/Lista");

            return result;

        }
        #endregion

        #region Usuario

        public async Task<UsuariosEntity> UsuarioLogin(UsuariosEntity entity)
        {
            var result = await client.ServicioPostAsync<UsuariosEntity>("api/Usuarios/Login", entity);

            return result;

        }

        #endregion


        #region Alquiler
        public async Task<IEnumerable<AlquilerEntity>> AlquilerGet()
        {
            var result = await client.ServicioGetAsync<IEnumerable<AlquilerEntity>>("api/Alquiler");

            return result;

        }

        public async Task<AlquilerEntity> AlquilerGetById(int id)
        {
            var result = await client.ServicioGetAsync<AlquilerEntity>("api/Alquiler/" + id);

            if (result.CodeError is not 0) throw new Exception(result.MsgError);

            return result;

        }

        #endregion

        #region Vehiculos
        public async Task<IEnumerable<VehiculoEntity>> VehiculoGetLista()
        {
            var result = await client.ServicioGetAsync<IEnumerable<VehiculoEntity>>("api/Vehiculo/Lista");

            return result;

        }
        #endregion

    }
}
