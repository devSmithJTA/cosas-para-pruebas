$(document).ready(function () {
    $(document).on('hidden.bs.modal', '.modal', function () {
        $('.modal:visible').length && $(document.body).addClass('modal-open');
        //$('.btn').prop('disabled', false);
    });
    //ListaVentas();
    //$("#tblServicioDinamico").hide();
    ListaClientes();
    ListaFacturas();
    ListaProcesoProveedor();
    ListaUsuarios();
    console.log("Estoy dentro");
});
//Funciones Ventas
function ListaVentas() {
    $.ajax({
        type: "GET",
        url: '/Ventas/ListaVentas',
        async: true,
        beforeSend: function () {
            $("#divListaVentas").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divListaVentas").html(resultado);
            $('#tblVentas').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });
        },
        complete: function () {



        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "lista", "error");
        }
    });
}
function DetalleVentas(Id) {
    $("#ModalVentas").modal("show");
    $.ajax({
        type: "GET",
        url: '/Ventas/DetalleVentas',
        data: { Id: Id },
        async: true,
        beforeSend: function () {
            $("#divModalCliente").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divDetalleVentas").html(resultado);
            masmenos();
        },
        complete: function () {



        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "detalle", "error");
        }
    });
}
function DetalleVentasDinamica(row) {
    var ProcesoId = $(row).parents('tr').find("td").eq(0).html();
    var TiposPrendaId = $(row).parents('tr').find("td").eq(1).html();
    var TelasId = $(row).parents('tr').find("td").eq(2).html();
    var AdicionId = $(row).parents('tr').find("td").eq(3).html();
    var Observacion = $(row).parents('tr').find("td").eq(4).html();
    var FechaCreacion = $(row).parents('tr').find("td").eq(5).html();
    var FechaModificacion = $(row).parents('tr').find("td").eq(6).html();
    var UsuarioIdCreo = $(row).parents('tr').find("td").eq(7).html();
    var ProcesoDescripcion = $(row).parents('tr').find("td").eq(9).html();
    var TiposPrendaDescripcion = $(row).parents('tr').find("td").eq(10).html();
    var TelasDescripcion = $(row).parents('tr').find("td").eq(11).html();
    var Color = $(row).parents('tr').find("td").eq(12).html();
    var AdicionDescripcion = $(row).parents('tr').find("td").eq(13).html();
    var Cantidad = $(row).parents('tr').find("td").eq(14).html();
    var Precio = $(row).parents('tr').find("td").eq(15).html();
    var Ventas = new Object();
    Ventas.ProcesoId = ProcesoId;
    Ventas.TiposPrendaId = TiposPrendaId;
    Ventas.TelasId = TelasId;
    Ventas.AdicionId = AdicionId;
    Ventas.Observacion = Observacion;
    Ventas.FechaCreacion = FechaCreacion;
    Ventas.FechaModificacion = FechaModificacion;
    Ventas.UsuarioIdCreo = UsuarioIdCreo;
    Ventas.Color = Color;
    Ventas.Cantidad = Cantidad;
    Ventas.Precio = Precio;
    $("#ModalVentas").modal("show");
    $.ajax({
        type: "POST",
        url: '/Ventas/DetalleVentasDinamicas',
        data: { ventas: Ventas, procesoDescripcion: ProcesoDescripcion, tiposPrendaDescripcion: TiposPrendaDescripcion, telasDescripcion: TelasDescripcion, adicionDescripcion: AdicionDescripcion },
        async: true,
        beforeSend: function () {
            $("#divModalCliente").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divDetalleVentas").html(resultado);
            masmenos();
        },
        complete: function () {



        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "detalle", "error");
        }
    });
}
//function GuardarVenta() {
//    var date = new Date();
//    var Estado = true;
//    var Id = $("#hdnId").val();
//    var FacturaId = 001;
//    var ProcesoId = $("#txtProceso").val().substring(0, 1);
//    var TiposPrendaId = $("#txtPrenda").val().substring(0, 1);
//    var TelasId = $("#txtTela").val().substring(0, 1);
//    var Color = $("#txtColor").val();
//    var AdicionId = $("#txtAdicion").val().substring(0, 1);
//    var Cantidad = $("#txtCantidad").val();
//    var Observacion = $("#txtObservacion").val();
//    var Precio = $("#txtPrecio").val();
//    var FechaCreacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
//    var FechaModificacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
//    var UsuarioIdCreo = 1;
//    var Venta = {
//        'Id':Id,
//        'Estado': Estado,
//        'FacturaId': FacturaId,
//        'ProcesoId': ProcesoId,
//        'TiposPrendaId': TiposPrendaId,
//        'TelasId': TelasId,
//        'Color': Color,
//        'AdicionId': AdicionId,
//        'Cantidad': Cantidad,
//        'Observacion': Observacion,
//        'Precio': Precio,
//        'FechaCreacion': FechaCreacion,
//        'FechaModificacion': FechaModificacion,
//        'UsuarioIdCreo': UsuarioIdCreo
//    }
//    $.ajax({
//        type: "POST",
//        url: "Ventas/GuardarVentas",
//        data: Venta,
//        async: true,
//        success: function (resultado) {
//            ListaVentas();
//            DetalleVentas(resultado);
//        }
//    });
//}
function RegistrarVenta() {
    var valores = "";
    var Data = [];
    var Agregar = true;
    $('#tblAdjuntosServicio tr').each(function () {
        var pk = $(this).find("td").eq(0).html();
        var Adjunto = new Object();
        if (pk != null) {
            Adjunto.NombreArchivo = pk;
            Data.push(Adjunto);
            Data.forEach(function (item) {
                if (item.NombreArchivo == NombreArchivo) {
                    Agregar = false;
                }
            });
        }
    });
    if (Agregar) {
        var date = new Date();
        var Estado = true;
        var Id = $("#hdnId").val();
        var indiceProceso = $("#txtProceso").val().indexOf("|");
        var ProcesoId = $("#txtProceso").val().substring(0, indiceProceso);
        var ProcesoDescripcion = $("#txtProceso").val().substring(indiceProceso + 1).trim();
        var indicePrenda = $("#txtPrenda").val().indexOf("|");
        var TiposPrendaId = $("#txtPrenda").val().substring(0, indicePrenda);
        var TiposPrendaDescripcion = $("#txtPrenda").val().substring(indicePrenda + 1).trim();
        var indiceTelas = $("#txtTela").val().indexOf("|");
        var TelasId = $("#txtTela").val().substring(0, indiceTelas);
        var TelasDescripcion = $("#txtTela").val().substring(indiceTelas + 1).trim();
        var Color = $("#txtColor").val();
        var indiceAdicion = $("#txtAdicion").val().indexOf("|");
        var AdicionId = $("#txtAdicion").val().substring(0, indiceAdicion);
        var AdicionDescripcion = $("#txtAdicion").val().substring(indiceAdicion + 1).trim();
        var Cantidad = $("#txtCantidad").val();
        var Observacion = $("#txtObservacion").val();
        var Precio = $("#txtPrecio").val();
        var FechaCreacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
        var FechaModificacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
        var UsuarioIdCreo = 1;
        var btnQuitarAdjunto = "    <a onclick='QuitarVentaDinamica(this)' class='btn btn-danger text-white'> Eliminar </a>";
        var btnObservacion = "  <a onclick='DetalleVentasDinamica(this)'  class='btn btn-info'> Consultar </a>";
        var Row = "<tr><td style='display:none;'>" + ProcesoId + "</td>"
            + "<td style='display:none;'>" + TiposPrendaId + "</td>"
            + "<td style='display:none;'>" + TelasId + "</td>"
            + "<td style='display:none;'>" + AdicionId + "</td>"
            + "<td style='display:none;'>" + Observacion + "</td>"
            + "<td style='display:none;'>" + FechaCreacion + "</td>"
            + "<td style='display:none;'>" + FechaModificacion + "</td>"
            + "<td style='display:none;'>" + UsuarioIdCreo + "</td>"
            + "<td>" + Id + "</td>"
            + "<td>" + ProcesoDescripcion + "</td>"
            + "<td>" + TiposPrendaDescripcion + "</td>"
            + "<td>" + TelasDescripcion + "</td>"
            + "<td>" + Color + "</td>"
            + "<td>" + AdicionDescripcion + "</td>"
            + "<td>" + Cantidad + "</td>"
            + "<td>" + Precio + "</td>"
            + "<td>" + btnQuitarAdjunto + "</td>"
            + "<td>" + btnObservacion + "</td>"
            + "</tr>";
        $("#tblServicioDinamico>tbody").append(Row);
    }
}
function GuardarFacturaVentas() {
    var date = new Date();
    var Factura = new Object();
    var validar = 0;
    validar = validar + ValidarCampo("#txtCliente");
    validar = validar + ValidarCampo("#txtEntrega");
    validar = validar + ValidarCampo("#txtPrecioTotal");
    if (validar!=0) {
        swal("Campos vacíos", "Tiene campos vacíos, por favor validar", "warning")
    }
    var indice = $("#txtCliente").val().indexOf("|");
    var ClienteId = $("#txtCliente").val().substring(0, indice);
    var DiasEntrega = $("#txtEntrega").val();
    var PrecioTotal = $("#txtPrecioTotal").val();
    Factura.ClnId = ClienteId;
    Factura.PrecioTotal = PrecioTotal;
    Factura.DiasEntrega = DiasEntrega;
    Factura.FechaCreacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    //Factura.UsrIdCreo = 1;
    var Ventas = [];
    $('#tblServicioDinamico >tbody > tr').each(function () {
        var ProcesoId = $(this).find("td").eq(0).html();
        var TiposPrendaId = $(this).find("td").eq(1).html();
        var TelasId = $(this).find("td").eq(2).html();
        var AdicionId = $(this).find("td").eq(3).html();
        var Observacion = $(this).find("td").eq(4).html();
        var FechaCreacion = $(this).find("td").eq(5).html();
        var FechaModificacion = $(this).find("td").eq(6).html();
        var UsuarioIdCreo = $(this).find("td").eq(7).html();
        var Color = $(this).find("td").eq(12).html();
        var Cantidad = $(this).find("td").eq(14).html();
        var Precio = $(this).find("td").eq(15).html();
        var Venta = new Object();
        Venta.ProcesoId = ProcesoId;
        Venta.TiposPrendaId = TiposPrendaId;
        Venta.TelasId = TelasId;
        Venta.AdicionId = AdicionId;
        Venta.Observacion = Observacion;
        Venta.FechaCreacion = FechaCreacion;
        Venta.FechaModificacion = FechaModificacion;
        Venta.UsuarioIdCreo = UsuarioIdCreo;
        Venta.Color = Color;
        Venta.Cantidad = Cantidad;
        Venta.Precio = Precio;
        Ventas.push(Venta);
    });
    $.ajax({
        type: "POST",
        url: "Ventas/GuardarVentas",
        data: { factura: Factura, ventas: Ventas },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", errorThrown, "error");
        },
        success: function (resultado) {
            swal("Hecho", "Factura creada con éxito", "success");
            $.ajax({
                type: "POST",
                url: "Factura/PVBotonImprimir",
                data: { idFactura: resultado },
                success: function (resultado) {

                    $("#divBotonFactura").html(resultado);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    swal("Error", errorThrown, "error");
                }
            });
        }
    });
}
function QuitarVentaDinamica(row) {
    var NombreArchivo = $(row).parents('tr').find("td").eq(0).html();
    NombreArchivo = NombreArchivo.trim();
    $(row).parents('tr').first().remove();
    //var AdjuntosGuardar = $("#txtAdjuntosGuardarSeguimientoFuente").val();
    //AdjuntosGuardar = replaceAll(AdjuntosGuardar, NombreArchivo + "|", "");
    //$("#txtAdjuntosGuardarSeguimientoFuente").val(AdjuntosGuardar);
}
//Funciones Factura
function DetalleFactura(Id) {
    $("#ModalFactura").modal("show");
    var precioTotal = 0;
    var Prendas = [];
    var Telas = [];
    $('#tblServicioDinamico >tbody > tr').each(function () {
        var TiposPrendaId = $(this).find("td").eq(1).html();
        var TelasId = $(this).find("td").eq(2).html();
        var Precio = $(this).find("td").eq(15).html();
        precioTotal = precioTotal + parseInt(Precio)
        Prendas.push(TiposPrendaId);
        Telas.push(TelasId);
    });
    var Factura = new Object();
    Factura.PrecioTotal = precioTotal;
    $.ajax({
        type: "POST",
        url: '/Factura/DetalleFactura',
        data: { factura: Factura, prendas: Prendas, telas: Telas },
        async: true,
        beforeSend: function () {
            $("#divModalCliente").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divDetalleFactura").html(resultado);
        },
        complete: function () {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "detalle", "error");
        }
    });
}
function MostrarFactura(Id) {
    $("#ModalMostrarFactura").modal("show");
    $.ajax({
        type: "GET",
        url: "Factura/MostrarFactura",
        data: { idFactura: Id },
        async: true,
        beforeSend: function () {
            $("#divListaVentas").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divMostrarFactura").html(resultado);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "lista", "error");
        }
    });
}
function ListaFacturas() {
    $.ajax({
        type: "GET",
        url: "Factura/ListaFactura",
        async: true,
        beforeSend: function () {
            $("#divListaVentas").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divListaFacturas").html(resultado);
            $('#tblFactura').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "lista", "error");
        }
    });
}
//Funciones Cliente
function ListaClientes() {
    $.ajax({
        type: "GET",
        url: "Cliente/ListaClientes",
        async: true,
        beforeSend: function () {
            $("#divListaVentas").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divListaCliente").html(resultado);
            $('#tblCliente').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "lista", "error");
        }
    });
}
function DetalleCliente(Id) {
    var Cliente = new Object();
    Cliente.Id = Id;
    $("#ModalClientes").modal("show");
    $.ajax({
        type: "GET",
        url: '/Cliente/DetalleCliente',
        data: Cliente,
        async: true,
        beforeSend: function () {
            $("#divModalCliente").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divDetalleCliente").html(resultado);
            masmenos();
        },
        complete: function () {



        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "detalle", "error");
        }
    });
}
function GuardarCliente() {
    var validar = 0;
    validar = validar + ValidarCampo("#txtNombre");
    validar = validar + ValidarCampo("#txtTpoIdn");
    validar = validar + ValidarCampo("#txtCelular");
    validar = validar + ValidarCampo("#txtIdentificacion");
    validar = validar + ValidarCampo("#txtemail");
    if (validar != 0) {
        swal("Campos vacíos", "Tiene campos vacíos, por favor validar", "warning");
    } else {
        var date = new Date();
        var Id = $("#hdnId").val();
        var NombreCompleto = $("#txtNombre").val();
        var TipoIdnId = $("#txtTpoIdn").val().substring(0, 1);
        var Identificacion = $("#txtIdentificacion").val();
        var Celular = $("#txtCelular").val();
        var FechaCreacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
        var FechaModificacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
        //var UsrIdCreo = 1;
        var Email = $("#txtemail").val();
        var Cliente = {
            'Id': Id,
            'TipoIdnId': TipoIdnId,
            'Identificacion': Identificacion,
            'NombreCompleto': NombreCompleto,
            'Celular': Celular,
            'Email': Email,
            'FechaCreacion': FechaCreacion,
            'FechaModificacion': FechaModificacion,
            //'UsrIdCreo': UsrIdCreo
        }
        $.ajax({
            type: "POST",
            url: 'Cliente/GuardarCliente',
            data: Cliente,
            async: true,
            success: function (resultado) {
                TomarFoto();
                DetalleCliente(resultado);
                swal("Hecho", "Dato registrado con éxito", "success");
            }
        });
    }
}
//Funciones generales
function masmenos() {
    $("#btnmas").click(
        function () {
            var cantidad = 1;
            var valor = $("#txtCantidad").val();
            if (valor == "") {
                $("#txtCantidad").val(cantidad);
            } else {
                cantidad = parseInt(valor) + cantidad;
                $("#txtCantidad").val(cantidad);
            }
        });
    $("#btnmenos").click(
        function () {
            var cantidad = 1;
            var valor = $("#txtCantidad").val();
            if (valor != "") {
                var valordos = parseInt(valor);
                if (valordos > 0) {
                    console.log("es mayor");
                    cantidad = parseInt(valordos) - cantidad;
                    $("#txtCantidad").val(cantidad);
                }
            }
        });
}
function Eliminar(Id) {
    $.ajax({
        type: "GET",
        url: '/Ventas/EliminarVentas',
        data: { Id: Id },
        async: true,
        beforeSend: function () {
            $("#divModalCliente").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            ListaVentas();
        },
        complete: function () {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "detalle", "error");
        }
    });
}
//Funciones Proveedor
function ListaProcesoProveedor() {
    $.ajax({
        type: "GET",
        url: '/ProcesoProveedor/ListaProcesoProveedor',
        async: true,
        beforeSend: function () {
            $("#divListaProcesoProveedor").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divListaProcesoProveedor").html(resultado);
            $('#tblProcesoProveedor').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });
        },
        complete: function () {



        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "lista", "error");
        }
    });
}
function DetalleProcesoProveedor(Id) {
    $("#ModalDetalleProceso").modal("show");
    $.ajax({
        type: "GET",
        url: '/DetalleProcesoProveedor/DetalleProcesoProveedor',
        data: { Id: Id },
        async: true,
        //beforeSend: function () {
        //    $("#ModalDetalleProceso").html(
        //        '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        //},
        success: function (resultado) {
            $("#divDetalleProceso").html(resultado);
            masmenos();
        },
        complete: function () {



        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "detalle", "error");
        }
    });
}
function RegistrarProcesoProveedor() {
    var valores = "";
    var Data = [];
    var Agregar = true;
    $('#tblProcesoServicio tr').each(function () {
        var pk = $(this).find("td").eq(0).html();
        var Adjunto = new Object();
        if (pk != null) {
            Adjunto.NombreArchivo = pk;
            Data.push(Adjunto);
            Data.forEach(function (item) {
                if (item.NombreArchivo == NombreArchivo) {
                    Agregar = false;
                }
            });
        }
    });
    if (Agregar) {
        var date = new Date();
        var Estado = true;
        var Id = $("#hdnId").val();
        var indiceProceso = $("#txtProceso").val().indexOf("|");
        var TipoProcesoId = $("#txtProceso").val().substring(0, indiceProceso);
        var TipoProcesoDescripcion = $("#txtProceso").val().substring(indiceProceso + 1).trim();
        var Cantidad = $("#txtCantidad").val();
        var Precio = $("#txtPrecio").val();
        var FechaCreacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
        var UsuarioIdCreo = 1;
        var btnQuitarAdjunto = "    <a onclick='QuitarVentaDinamica(this)' class='btn btn-danger text-white'> Eliminar </a>";
        var btnObservacion = "  <a onclick='DetalleVentasDinamica(this)'  class='btn btn-info'> Consultar </a>";
        var Row = "<tr><td style='display:none;'>" + TipoProcesoId + "</td>"
            + "<td style='display:none;'>" + FechaCreacion + "</td>"
            + "<td style='display:none;'>" + UsuarioIdCreo + "</td>"
            + "<td>" + Id + "</td>"
            + "<td>" + TipoProcesoDescripcion + "</td>"
            + "<td>" + Cantidad + "</td>"
            + "<td>" + Precio + "</td>"
            + "<td>" + btnQuitarAdjunto + "</td>"
            + "<td>" + btnObservacion + "</td>"
            + "</tr>";
        $("#tblProveedorDinamico>tbody").append(Row);
    }
}
function ProcesoProveedor(Id) {
    $("#ModalProcesoProveedor").modal("show");
    var precioTotal = 0;
    $('#tblProveedorDinamico >tbody > tr').each(function () {
        var Precio = $(this).find("td").eq(6).html();
        precioTotal = precioTotal + parseInt(Precio)
        console.log("SI");
    });
    var ProcesoProveedor = new Object();
    ProcesoProveedor.Id = Id;
    ProcesoProveedor.PrecioTotal = precioTotal;
    $.ajax({
        type: "POST",
        url: '/ProcesoProveedor/DetalleProcesoProveedor',
        data: { procesoProveedor: ProcesoProveedor },
        async: true,
        //beforeSend: function () {
        //    $("#divModalCliente").html(
        //        '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        //},
        success: function (resultado) {
            $("#divProcesoProveedor").html(resultado);
        },
        complete: function () {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "detalle", "error");
        }
    });
}
function GuardarProcesoProveedor() {
    var date = new Date();
    var ProcesoProveedor = new Object();
    var validar = 0;
    validar = validar + ValidarCampo("#txtPrecioTotal");
    if (validar!=0) {
        swal("Campos vacíos", "Tiene campos vacíos, por favor validar", "warning")
    }
    var PrecioTotal = $("#txtPrecioTotal").val();
    ProcesoProveedor.PrecioTotal = PrecioTotal;
    ProcesoProveedor.FechaFacturacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    //ProcesoProveedor.UsrIdCreo = 1;
    var ListDetalles = [];
    $('#tblProveedorDinamico >tbody > tr').each(function () {
        var ProcesoId = $(this).find("td").eq(0).html();
        var FechaCreacion = $(this).find("td").eq(1).html();
        var UsuarioIdCreo = $(this).find("td").eq(2).html();
        var Cantidad = $(this).find("td").eq(5).html();
        var Precio = $(this).find("td").eq(6).html();
        var DetalleProcesoProveedor = new Object();
        DetalleProcesoProveedor.TipoProcesoProveedorId = ProcesoId;
        DetalleProcesoProveedor.FechaCreacion = FechaCreacion;
        DetalleProcesoProveedor.Cantidad = Cantidad;
        DetalleProcesoProveedor.UsrIdCreo = UsuarioIdCreo;
        DetalleProcesoProveedor.Precio = Precio;
        ListDetalles.push(DetalleProcesoProveedor);
    });
    $.ajax({
        type: "POST",
        url: "ProcesoProveedor/GuardarProcesoProveedor",
        data: { procesoProveedor: ProcesoProveedor, listDetalle: ListDetalles },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", errorThrown, "error");
        },
        success: function (resultado) {
            swal("Hecho", "Factura creada con éxito", "success");
            $.ajax({
                type: "POST",
                url: "Factura/PVBotonImprimir",
                data: { idFactura: resultado },
                success: function (resultado) {

                    $("#divBotonFactura").html(resultado);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    swal("Error", errorThrown, "error");
                }
            });
        }
    });
}
function MostrarProcesoProveedor(Id) {
    $("#ModalMostrarProceso").modal("show");
    $.ajax({
        type: "GET",
        url: "ProcesoProveedor/MostrarProcesoProveedor",
        data: { idFactura: Id },
        async: true,
        beforeSend: function () {
            $("#divListaVentas").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divMostrarProceso").html(resultado);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "lista", "error");
        }
    });
}
//Funciones Usuarios
function ListaUsuarios() {
    $.ajax({
        type: "GET",
        url: "Usuarios/ListarUsuario",
        async: true,
        beforeSend: function () {
            $("#divModalUsuarios").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divListaUsuarios").html(resultado);
            $('#tblUsuarios').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "lista", "error");
        }
    });
}
function DetalleUsuarios(Id) {
    var Usuarios = new Object();
    Usuarios.Id = Id;
    $("#ModalUsuarios").modal("show");
    $.ajax({
        type: "GET",
        url: '/Usuarios/DetalleUsuario',
        data: Usuarios,
        async: true,
        beforeSend: function () {
            $("#divModalUsuarios").html(
                '<div class="row"><div class="col-sm-4"></div><div class="col-sm-4" style="text-align: center;"><img src="/Imagenes/Configuracion/cargando.gif"/></div><div class="col-sm-4"></div></div>');
        },
        success: function (resultado) {
            $("#divDetalleUsuarios").html(resultado);
        },
        complete: function () {



        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Error", "detalle", "error");
        }
    });
}
function GuardarUsuarios() {
    var date = new Date();
    var validar = 0;
    validar = validar + ValidarCampo("#txtNombre");
    validar = validar + ValidarCampo("#txtApellido");
    validar = validar + ValidarCampo("#txtusuario");
    validar = validar + ValidarCampo("#txtpassword");
    validar = validar + ValidarCampo("#txtTpoIdn");
    validar = validar + ValidarCampo("#txtIdentificacion");
    if (validar!=0) {
        swal("Campos vacíos", "Tiene campos vacíos, por favor validar", "warning")
    }
    var Id = $("#hdnId").val();
    var Nombre = $("#txtNombre").val();
    var Apellido = $("#txtApellido").val();
    var Usuario = $("#txtusuario").val();
    var Password = $("#txtpassword").val();
    var TipoIdnId = $("#txtTpoIdn").val().substring(0, 1);
    var Identificacion = $("#txtIdentificacion").val();
    var FechaCreacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    var FechaModificacion = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    //var UsrIdCreo = 1;
    //var usrIdModifico = 1;
    var usuarios = {
        'Id': Id,
        'TipoIdentificacion': TipoIdnId,
        'Identificacion': Identificacion,
        'Nombres': Nombre,
        'Apellidos': Apellido,
        'Usuario': Usuario,
        'Password': Password,
        'FechaCreacion': FechaCreacion,
        'FechaModificacion': FechaModificacion,
        //'UsuarioCreacion': UsrIdCreo,
        //'UsuarioModificacion': usrIdModifico
    }
    $.ajax({
        type: "POST",
        url: 'Usuarios/GuardarUsuarios',
        data: usuarios,
        async: true,
        success: function (resultado) {
            DetalleUsuario(resultado);
            swal("Hecho", "Dato registrado con éxito", "success");
        }
    });
}
function ValidarCampo(campo) {
    var val = 0;
    if ($(campo).val() == "" || $(campo).val() == "0" || $(campo).val() == null) {

        $(campo).css("border-color", "#FF0000");
        val = 1;
        //console.log(campo);
        //  $(campo).focus();
    } else {

        $(campo).css("border-color", "#EBEBEB");

    }

    return val;
}