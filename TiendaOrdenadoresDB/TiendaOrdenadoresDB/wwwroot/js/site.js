// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Obtener la URL actual
    var currentUrl = window.location.href;

    // Recorrer cada enlace en la barra de navegación
    $('.navbar-nav .nav-link').each(function () {
        var linkUrl = $(this).attr('href');

        // Comparar la URL actual con la URL del enlace
        if (currentUrl.indexOf(linkUrl) !== -1) {
            $(this).addClass('active'); // Agregar la clase "active" al enlace correspondiente
        }
    });
});