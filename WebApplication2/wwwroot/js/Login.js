$(document).ready(function () {
    $("#DivLogin").animate({
        height: 'toggle'
    }, 'slow');
    $(".BodyLogin").hide();
    $('.BodyLogin').show(600);
    $(".BodyLogin").fadeOut(200);
    $(".BodyLogin").fadeIn(300);

});


function Login() {
    var Usuario = $("#txtUsuario").val();
    var password = $("#txtPassword").val();


    var validar = 0;

    validar = validar + ValidarCampo("#txtUsuario");
    validar = validar + ValidarCampo("#txtPassword");

    if (validar != 0) {
        swal("Campos vacios", "Tiene campos vacios, por favor validar", "warning");
        return;

    }


    $.ajax({
        type: "GET",
        url: '/Login/IniciarSesion',
        data: {
            Usuario: Usuario, Password: password
        },
        async: true,
        //beforeSend: function () {

        //    $('#btnLogin').button('loading');

        //},
        success: function (resultado) {
            console.log(resultado);
            if (resultado == 'OK') {
                location.href = '/Home/Index';
                $("input").val("");
                swal("Correcto", "Usuario encontrado", "success");

            }
            else {
                swal("Valide", "Usuario no encontrado/INACTIVO", "error");
                $("#txtPasswordLogin").focus();
            }



        },
        complete: function () { // Set our complete callback, adding the .hidden class and hiding the spinner.
            $('#btnLogin').button('reset');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            swal("Usuario no encontrado", "Valide información", "error");
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
