﻿
function extraerDato(valor, texto, lista) {
    document.getElementById(texto).value = valor;
    $(lista).empty();
    $(lista).hide();
}

function mostrarLista(texto, lista) {
    var cont = false;
    $.get("http://localhost:50336/Models/Model1.edmx", function (data) {

        $(lista).empty();


        var lines = data.split("\n");
        var value = $(texto).val();
        var valor = value.toLowerCase();

        var texto2 = texto.replace("#", "");

        $.each(lines, function (n, elem) {
            var col = elem.split(',"');

            if (col[1] != "" && typeof col[1] != 'undefined' && col[2] != "" && typeof col[2] != 'undefined' && col[4] != "" && typeof col[4] != 'undefined') {
                var column = col[1].replace('"', '');
                var column2 = col[2].replace('"', '');
                var column4 = col[4].replace('"', '');
                var columna = column.toLowerCase();
                var columna2 = column2.toLowerCase();
                var columna4 = column4.toLowerCase();

                if ($(texto).val().length >= 1 && columna != valor) {
                    if (columna.startsWith(valor) || columna2.startsWith(valor) || columna4.startsWith(valor)) {
                        $(lista).show();

                        //$(lista).append('<option value="' + column + '">');
                        $(lista).append('<p onclick=\'extraerDato("' + column + '","' + texto2 + '","' + lista + '")\'>' + column4 + " " + column + '</p>');
                        //$(lista).append('<p onclick=\'extraerDato("' + column + '","' + texto2 + '","' + lista + '")\'>' + col + '</p>');



                    }

                }
                else {
                    $(lista).hide();
                }
            }

        });




    });


}

$("#texto1").keyup(function () {
    mostrarLista("#texto1", "#Lista");
});


$("#texto2").keyup(function () {
    lista = mostrarLista("#texto2", "#Lista2");

});

$("#texto1_ingles").keyup(function () {
    mostrarLista("#texto1_ingles", "#Lista_ingles");
});


$("#texto2_ingles").keyup(function () {
    lista = mostrarLista("#texto2_ingles", "#Lista2_ingles");

}); 