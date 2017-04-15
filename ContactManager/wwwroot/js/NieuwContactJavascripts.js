"use strict";

var telefoonButtonCounter = 0;


function nieuweTelefoon() {
    var nieuweTelefoonNaamVeldString = "<input type=\"text\" name=\"telefoonNaam\" />";
    var nieuweTelefoonNummerVeldString = "<input type=\"text\" name=\"telefoonNummer\" />";

    var nieuweTelefoonVelden = document.createElement("p");
    nieuweTelefoonVelden.innerHTML = "Naam: " + nieuweTelefoonNaamVeldString + "Nummer: " + nieuweTelefoonNummerVeldString;



    var telefoonVeldenDiv = document.getElementById("telefoonVelden");


    insertAfter(nieuweTelefoonVelden, telefoonVeldenDiv.lastChild);

    telefoonButtonCounter++;


}

function insertAfter(newNode, referenceNode) {
    referenceNode.parentNode.insertBefore(newNode, referenceNode.nextSibling);
}