using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IMarcaVehiculoService
    {
        Task<DBEntity> Create(MarcaVehiculoEntity entity);
        Task<DBEntity> Delete(MarcaVehiculoEntity entity);
        Task<IEnumerable<MarcaVehiculoEntity>> Get();
        Task<MarcaVehiculoEntity> GetById(MarcaVehiculoEntity entity);
        Task<IEnumerable<MarcaVehiculoEntity>> GetLista();
        Task<DBEntity> Update(MarcaVehiculoEntity entity);
    }

    public class MarcaVehiculoService : IMarcaVehiculoService
    {
        private readonly IDataAccess sql;

        public MarcaVehiculoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCRUD
        public async Task<IEnumerable<MarcaVehiculoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<MarcaVehiculoEntity>("dbo.MarcaVehiculoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<MarcaVehiculoEntity> GetById(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<MarcaVehiculoEntity>("dbo.MarcaVehiculoObtener", new
                {
                    entity.MarcaVehiculoId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.MarcaVehiculoInsertar", new
                {
                    entity.Descripcion,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaVehiculoActualizar", new
                {
                    Id= entity.MarcaVehiculoId,
                    entity.Descripcion,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Delete(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.MarcaVehiculoEliminar", new
                {
                    Id= entity.MarcaVehiculoId,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<IEnumerable<MarcaVehiculoEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<MarcaVehiculoEntity>("dbo.MarcaVehiculoLista");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

#endregion
    }
}
