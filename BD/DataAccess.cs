using Dapper;
using Dapper.Mapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration config;

        public DataAccess(IConfiguration _Config)
        {
            config = _Config;

        }

        public SqlConnection DbConnection => new SqlConnection(
            new SqlConnectionStringBuilder(config.GetConnectionString("Conn")).ConnectionString
           );

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<dynamic>> QueryAsync(string sp, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    //var list = result.Select(r => new DBEntity{ 
                    //    CodeError=r.MarcaVehiculoId,
                    //    MsgError=r.Descripcion

                    //});

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<IEnumerable<A>> QueryAsync<A, B>(string sp, string split, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<A, B>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout, splitOn: split);

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<A>> QueryAsync<A, B, C>(string sp, string split, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<A, B, C>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout, splitOn: split);

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<A>> QueryAsync<A, B, C, D>(string sp, string split, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<A, B, C, D>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout, splitOn: split);

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<A>> QueryAsync<A, B, C, D, E>(string sp, string split, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<A, B, C, D, E>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout, splitOn: split);

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<A>> QueryAsync<A, B, C, D, E, H>(string sp, string split, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<A, B, C, D, E, H>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout, splitOn: split);

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<A>> QueryAsync<A, B, C, D, E, H, I>(string sp, string split, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<A, B, C, D, E, H, I>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout, splitOn: split);

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        public async Task<T> QueryFirstAsync<T>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryFirstOrDefaultAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> ExecuteAsync(string sp, object Param = null, int? Timeout = null)
        {
            try
            {

                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = await exec.ExecuteReaderAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    await result.ReadAsync();


                    return new()
                    {
                        CodeError = result.GetInt32(0),
                        MsgError = result.GetString(1)
                    };

                }
            }
            catch (Exception)
            {

                throw;
            }
        }





    }
}
