"use strict";
var AlquilerEdit;
(function (AlquilerEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
        },
        methods: {
            CalculoMontoTotalFn: function () {
                var total = ((this.Entity.Impuesto / 100) * this.Entity.Monto) + this.Entity.Monto;
                return total;
            },
            AlquilerServicio: function (entity) {
                if (entity.IdAlquiler == null) {
                    return App.AxiosProvider.AlquilerGuardar(entity);
                }
                else {
                    return App.AxiosProvider.AlquilerActualizar(entity);
                }
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    //var test = this.CalculoMontoTotalFn();
                    //    test = this.CalculoMontoTotalCP;
                    this.AlquilerServicio(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardo sastifactoriamente!", icon: "success" })
                                .then(function () { return window.location.href = "Alquiler/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    }).catch(function (c) { return console.log(c); });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos!", icon: "error" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        },
        computed: {
            CalculoMontoTotalCP: function () {
                var total = ((this.Entity.Impuesto / 100) * this.Entity.Monto) + this.Entity.Monto;
                return total;
            }
        }
    });
    Formulario.$mount("#AppEdit");
})(AlquilerEdit || (AlquilerEdit = {}));
//# sourceMappingURL=Edit.js.map