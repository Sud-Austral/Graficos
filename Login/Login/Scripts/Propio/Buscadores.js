function BuscadorGenerico(search, tabla) {
    //$("#searchCategoria").keyup(function () {
    $(search).keyup(function () {
        _this = this;
        //alert("Hola");
        //alert($("#CATEGORIA_id option").text())
        // Show only matching TR, hide rest of them
        //$.each($("#CATEGORIA_id option"), function () {
        $.each($(tabla + " option"), function () {
            var texto = $(this).text().toLowerCase();
            texto = texto.replace("á", "a").replace("é", "e").replace("í", "i").replace("ó", "o").replace("ú", "u");

            //alert($(this).text().toLowerCase().indexOf($(_this).val().toLowerCase()));
            //if ($(this).text().toLowerCase().indexOf($(_this).val().toLowerCase()) === -1)
            if (texto.indexOf($(_this).val().toLowerCase()) === -1)
                $(this).hide();
            else
                $(this).show();
        });
    });

}



$(document).ready(function () {
    BuscadorGenerico("#searchCategoria", "#CATEGORIA_id");
    BuscadorGenerico("#searchParametro", "#PARAMETRO_id");
    
    
});

