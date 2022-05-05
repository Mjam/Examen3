using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IClientesService
    {
        Task<DBEntity> Create(ClientesEntity entity);
        Task<DBEntity> Delete(ClientesEntity entity);
        Task<IEnumerable<ClientesEntity>> Get();
        Task<ClientesEntity> GetById(ClientesEntity entity);
        Task<IEnumerable<ClientesEntity>> GetLista();
        Task<DBEntity> Update(ClientesEntity entity);
    }

    public class ClientesService : IClientesService
    {

        private readonly IDataAccess sql;

        public ClientesService(IDataAccess _sql)
        {
            sql = _sql;
        }
        #region MetodosCRUD

        public async Task<IEnumerable<ClientesEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ClientesEntity, AgenciaEntity>
                    ("dbo.ClientesObtener","");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }

      
        public async Task<ClientesEntity> GetById(ClientesEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ClientesEntity>("dbo.ClientesObtener", new
                {
                    entity.ClientesId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(ClientesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClientesInsertar", new
                {
                    entity.NombreCompleto,
                    entity.Direccion,
                    entity.Telefono,
                    entity.AgenciaId,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(ClientesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClientesActualizar", new
                {
                    entity.ClientesId,
                    entity.NombreCompleto,
                    entity.Direccion,
                    entity.Telefono,
                    entity.AgenciaId,
                    entity.Estado,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Delete(ClientesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClientesEliminar", new
                {
                    entity.ClientesId,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region MyRegion
        public async Task<IEnumerable<ClientesEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ClientesEntity>("dbo.ClientesLista");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        #endregion

    }
}
