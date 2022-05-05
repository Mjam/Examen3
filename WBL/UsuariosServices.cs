using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IUsuariosServices
    {
        Task<UsuariosEntity> Login(UsuariosEntity entity);
        Task<DBEntity> Registrar(UsuariosEntity entity);
    }

    public class UsuariosServices : IUsuariosServices
    {
        private readonly IDataAccess sql;

        public UsuariosServices(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region MetodosCRUD

        public async Task<UsuariosEntity> Login(UsuariosEntity entity)
        {
            try
            {
                var result = await sql.QueryFirstAsync<UsuariosEntity>("dbo.Login", new
                {
                    entity.Usuario,
                    entity.Contrasena
                });

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public async Task<DBEntity> Registrar(UsuariosEntity entity)
        {

            try
            {
                var result = await sql.ExecuteAsync("dbo.UsuarioRegistrar", new
                {
                    entity.Usuario,
                    entity.Nombre,
                    entity.Contrasena
                });

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
