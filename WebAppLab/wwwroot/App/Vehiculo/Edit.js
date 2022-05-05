"use strict";
var VehiculoEdit;
(function (VehiculoEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
        },
        methods: {
            RefrescarValidaciones: function () {
                var _this = this;
                setTimeout(function () {
                    BValidateData(_this.Formulario);
                }, 200);
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(VehiculoEdit || (VehiculoEdit = {}));
//# sourceMappingURL=Edit.js.map