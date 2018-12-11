function changeEvent(bool) {
    document.getElementById("IsAdd").value = bool;
    if (!document.getElementById("modify").classList.contains("in")) {
        if (bool) {
            document.getElementById("removeButton").style.display = "none";
            document.getElementById("modifyTitle").innerText = "Bevétel";
        }
        else {
            document.getElementById("addButton").style.display = "none";
            document.getElementById("modifyTitle").innerText = "Kivétel";
        }
    }
    else {
        if (bool) {
            document.getElementById("removeButton").style.display = "";
        }
        else {
            document.getElementById("addButton").style.display = "";
        }
    }
}
