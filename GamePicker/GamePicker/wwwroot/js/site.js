// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('formInput').onfocus = function () {
    if (this.value === "Default text") { // Check if it's the default
        this.value = "";
    }
};