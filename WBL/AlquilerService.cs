using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IAlquilerService
    {
        Task<DBEntity> Create(AlquilerEntity entity);
        Task<DBEntity> Delete(AlquilerEntity entity);
        Task<IEnumerable<AlquilerEntity>> Get();
        Task<AlquilerEntity> GetById(AlquilerEntity entity);
        Task<DBEntity> Update(AlquilerEntity entity);
    }

    public class AlquilerService : IAlquilerService
    {
        private readonly IDataAccess sql;

        public AlquilerService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCRUD
        public async Task<IEnumerable<AlquilerEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<AlquilerEntity,ClientesEntity,VehiculoEntity>("dbo.AlquilerObtener","ClientesId,VehiculoId");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }



        public async Task<AlquilerEntity> GetById(AlquilerEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<AlquilerEntity>("dbo.AlquilerObtener", new
                {
                    entity.IdAlquiler
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(AlquilerEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.AlquilerInsertar", new
                {
                    entity.ClientesId,
                    entity.VehiculoId,
                    entity.FechaInicio,
                    entity.FechaFin,
                    entity.Monto,
                    entity.Impuesto,
                   Total=(entity.Monto*(entity.Impuesto/100))+entity.Monto,
                    entity.Observaciones,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(AlquilerEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.AlquilerActualizar", new
                {
                    entity.IdAlquiler,
                    entity.ClientesId,
                    entity.VehiculoId,
                    entity.FechaInicio,
                    entity.FechaFin,
                    entity.Monto,
                    entity.Impuesto,
                    Total = (entity.Monto * (entity.Impuesto / 100)) + entity.Monto,
                    entity.Observaciones,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Delete(AlquilerEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.AlquilerEliminar", new
                {
                    entity.IdAlquiler,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
            #endregion
        }
    }
}
