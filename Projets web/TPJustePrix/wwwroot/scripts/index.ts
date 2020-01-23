document.addEventListener("DOMContentLoaded", () => {
  // Cette méthode sera exécutée à la fin du chargement de la page
  // Je disposerai de tous les éléments
  var nombreAleatoire: number;
  var nombreMaxEssais: number;

  document.getElementById("form-config")!.addEventListener("submit", e => {
    // L'évènement se déclenche lorsque le formulaire est valide.
    var nombreMax = (document.getElementById(
      "input-nombreMaximum"
    ) as HTMLInputElement).valueAsNumber;
    nombreMaxEssais = (document.getElementById(
      "input-nombreEssaisMax"
    ) as HTMLInputElement).valueAsNumber;

    nombreAleatoire = Math.floor(Math.random() * nombreMax);
    console.log(nombreAleatoire);

    document.getElementById("surface-config")!.className = "invisible";
    document.getElementById("surface-jeu")!.className = "";

    document
      .getElementById("input-nombreTente")!
      .setAttribute("max", nombreMax.toString());

    e.preventDefault();
  });

  document.getElementById("form-jeu")!.addEventListener("submit", e => {
    var nombreTente = (document.getElementById(
      "input-nombreTente"
    ) as HTMLInputElement).valueAsNumber;

    var tbody = document.getElementById("tbody-resultats")!;

    if (nombreTente == nombreAleatoire) {
      document.getElementById("surface-jeu")!.className = "invisible";
      document.getElementById("surface-gagne")!.className = "";
    } else {
      //
      // VERSION SANS JQUERY
      //
      document.getElementById("table-resultats")!.className = "table";

      // Créé la ligne
      var tr = document.createElement("tr");

      // Créé la cellule, l'ajoute à la ligne
      var td1 = document.createElement("td");
      td1.innerHTML = nombreTente.toString();
      tr.appendChild(td1);

      var td2 = document.createElement("td");
      td2.innerHTML = `${new Date().getHours()}:${new Date().getMinutes()}:${new Date().getSeconds()}`;
      tr.appendChild(td2);

      var td3 = document.createElement("td");
      td3.innerHTML =
        nombreTente > nombreAleatoire ? "Trop grand" : "Trop petit";
      tr.appendChild(td3);

      //Ajoute la ligne à la table
      tbody.appendChild(tr);

      // Réinitialisation de la zone de l'input
      (document.getElementById("input-nombreTente") as HTMLInputElement).value = "";
      (document.getElementById("input-nombreTente") as HTMLInputElement).focus();
    }

    e.preventDefault();

    var nombreEssais = tbody.children.length;

    if (nombreEssais >= nombreMaxEssais) {
      document.getElementById("surface-jeu")!.className = "invisible";
      document.getElementById("surface-perdu")!.className = "";
    }
  });

  var boutonsRejouer = document.querySelectorAll(".bouton-rejouer")!
  boutonsRejouer.forEach(element => {

    element.addEventListener("click", () => {
      //window.location.reload();

      document.getElementById("surface-gagne")!.className = "invisible";
      document.getElementById("surface-perdu")!.className = "invisible";
      document.getElementById("surface-config")!.className = "";

      (document.getElementById("input-nombreTente") as HTMLInputElement).value = ""
      document.getElementById("table-resultats")!.className = "invisible";
      document.getElementById("tbody-resultats")!.innerHTML = "";

    })

  });

});
