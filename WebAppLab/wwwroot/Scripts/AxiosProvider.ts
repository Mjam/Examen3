
namespace App.AxiosProvider   {

    //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );


    export const AgenciaEliminar = (id) => axios.delete<DBEntity>("Agencia/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const AgenciaGuardar = (entity) => axios.post<DBEntity>("Agencia/Edit", entity).then(({ data }) => data);

    export const AgenciaChanceProvincia = (entity) => axios.post<any[]>("Agencia/Edit?handler=ChangeProvincia",entity).then(({ data }) => data);

    export const AgenciaChanceCanton = (entity) => axios.post<any[]>("Agencia/Edit?handler=ChangeCanton", entity).then(({ data }) => data);



    

    export const ClientesGuardar = (entity) => ServiceApi.post<DBEntity>("api/Clientes",entity).then(({ data }) => data);

    export const ClientesActualizar = (entity) => ServiceApi.put<DBEntity>("api/Clientes", entity).then(({ data }) => data);


    

    export const UsuarioRegistrar = (entity) => ServiceApi.post<DBEntity>("api/Usuarios/Registrar", entity).then(({ data }) => data);


    export const UsuarioLogin = (entity) => axios.post<DBEntity>("Login" + entity).then(({ data }) => data);




    export const AlquilerEliminar = (id) => ServiceApi.delete<DBEntity>("api/Alquiler/" + id).then(({ data }) => data);

    export const AlquilerGuardar = (entity) => ServiceApi.put<DBEntity>("api/Alquiler", entity).then(({ data }) => data);

    export const AlquilerActualizar = (entity) => ServiceApi.put<DBEntity>("api/Alquiler", entity).then(({ data }) => data);
}




