"use strict";
var AlquilerGrid;
(function (AlquilerGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro? ", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                //animacion
                Loading.fire("Borrando..");
                App.AxiosProvider.AlquilerEliminar(id).then(function (data) {
                    //cerrar animacion
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se elimino correctamente!", icon: "success" }).then(function () { return window.location.href = "Alquiler/Grid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    AlquilerGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(AlquilerGrid || (AlquilerGrid = {}));
//# sourceMappingURL=Grid.js.map