"use strict";

var telefoonButtonCounter = 0;

function nieuweTelefoon() {
    const nieuweTelefoonNaamVeldString = "<input type=\"text\" name=\"telefoonsNamen\" />";
    const nieuweTelefoonNummerVeldString = "<input type=\"text\" name=\"telefoonNummers\" />";
    const nieuweTelefoonVelden = document.createElement("p");
    nieuweTelefoonVelden.innerHTML = "Naam: " + nieuweTelefoonNaamVeldString + "Nummer:  " + nieuweTelefoonNummerVeldString;
    const telefoonVeldenDiv = document.getElementById("telefoonVelden");
    insertAfter(nieuweTelefoonVelden, telefoonVeldenDiv.lastChild);
    telefoonButtonCounter++;


}

const toonContactPersonen = function () {
    const zoekString = $('#zoekveld').val();
    var contactLijstDiv = $('<div id="contactLijst"></div>');

    $.get("/Nieuw/Personen?naam=" + zoekString, function (data, status) {
        const personen = data;
        console.log(personen.length + "resultaten gevonden");

        for (let i = 0; i < personen.length; i++) {
            const tableRow = $('<p><input type="radio" name="contactPersoonId" value="' + personen[i].id + '"> ' + personen[i].naam + '</p>');
            contactLijstDiv.append(tableRow);
        }
    });
    $("#contactLijst").replaceWith(contactLijstDiv);
};

function insertAfter(newNode, referenceNode) {
    referenceNode.parentNode.insertBefore(newNode, referenceNode.nextSibling);
}

$(document).ready(function () {
    $(".datumKiezer").datepicker();
    $("#zoekveld").keydown(toonContactPersonen);

});