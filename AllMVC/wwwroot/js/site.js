
window.onload = function () {

    var selection = document.getElementsByClassName("category-selection")[0];

    var newcat = document.getElementsByClassName("new-category")[0];

    if (selection.addEventListener) {
        selection.addEventListener("change", function () {
            if (selection.value === '0') {
                newcat.className = "input-group col-5 new-category show";
            }
            else {
                newcat.className = "input-group col-5 new-category hide"
            }

            console.log(selection.value);

            console.log(typeof selection.nodeValue);
        });

        console.log("trfjtgvkhbjlnkl");
    }
    else if (selection.attachEvent) {
        selection.attachEvent("onchange", function () {
            if (selection.value === '0') {
                newcat.className = "input-group col-5 new-category show";
            }
            else {
                newcat.className = "input-group col-5 new-category hide"
            }

            console.log(selection.value);

            console.log(typeof selection.nodeValue);
        });
        console.log("trfjtgvkhbjlnkl");
    }
    else {
        selection.onchange = function () {
            if (selection.value === '0') {
                newcat.className = "input-group col-5 new-category show";
            }
            else {
                newcat.className = "input-group col-5 new-category hide"
            }

            console.log(selection.nodeValue);

            console.log(typeof selection.nodeValue);
        }

    }

    var catNameInput = document.getElementsByClassName("category-name-area")[0];
    var updateBtn = document.getElementsByClassName("btn-update");

    var f = function () {

        updateBtn.disabled = false;
        if (catNameInput.value === "") {
            updateBtn.disabled = true;
        }
        console.log(updateBtn.disabled);
        console.log(typeof updateBtn.disabled);

    }

    if (catNameInput.addEventListener) {
        catNameInput.addEventListener("change", f)
    } else if (catNameInput.attachEvent) {
        catNameInput.attachEvent("onchange", f);
    }
    else {
        catNameInput.onchange = f;
    }
}