function frame(command) {
    var url = "http://command.com/window/" + command;
    var link = document.createElement('a');
    link.href = url;
    document.body.appendChild(link);
    link.click();
}

function toggleRestoreMaxButton(max) {
    var maxButton = document.getElementById('max-button');
    var restoreButton = document.getElementById('restore-button');
    if (max === 1) {
        maxButton.style.display = "none";
        restoreButton.style.display = "flex";
    } else {
        restoreButton.style.display = "none";
        maxButton.style.display = "flex";
    }
}