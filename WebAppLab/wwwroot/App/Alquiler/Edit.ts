

namespace AlquilerEdit {


    var Entity = $("#AppEdit").data("entity");

    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,

        },

        methods: {

            CalculoMontoTotalFn() {
                var total = ((this.Entity.Impuesto / 100) * this.Entity.Monto) + this.Entity.Monto;
                return total;
            },
            AlquilerServicio(entity) {
                
                if (entity.IdAlquiler == null) {
                    return App.AxiosProvider.AlquilerGuardar(entity);
                } else {
                    return App.AxiosProvider.AlquilerActualizar(entity);
                }
            },
            Save() {

                if (BValidateData(this.Formulario)) {

                    Loading.fire("Guardando");
                    //var test = this.CalculoMontoTotalFn();
                    //    test = this.CalculoMontoTotalCP;
                    this.AlquilerServicio(this.Entity).then(data => {

                        Loading.close();

                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardo sastifactoriamente!", icon: "success" })
                                .then(() => window.location.href = "Alquiler/Grid")
                        } else {
                            Toast.fire({ title: data.MsgError, icon: "error" });

                        }


                    }).catch(c => console.log(c));



                } else {
                    Toast.fire({ title: "Por favor complete los campos requeridos!", icon: "error" });
                }

            }


        },
        mounted() {


            CreateValidator(this.Formulario);

        },

        computed: {
            CalculoMontoTotalCP: function ():number {
                var total = ((this.Entity.Impuesto / 100) * this.Entity.Monto) + this.Entity.Monto;
                return total;
            }
        }

    });

    Formulario.$mount("#AppEdit")
}