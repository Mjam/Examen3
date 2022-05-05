

namespace AlquilerGrid {






    export function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro? ", "Eliminar", "warning", "#3085d6", "#d33")
            .then(result => {
                if (result.isConfirmed) {
                    //animacion
                    Loading.fire("Borrando..");

                    App.AxiosProvider.AlquilerEliminar(id).then(data => {
                        //cerrar animacion
                        Loading.close();

                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se elimino correctamente!", icon: "success" }).then(() => window.location.href = "Alquiler/Grid");
                        } else {
                            Toast.fire({ title: data.MsgError, icon: "error" })
                        }


                    });

                }

            });


    }

    $("#GridView").DataTable();

}