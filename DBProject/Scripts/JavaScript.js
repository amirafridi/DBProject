function addPersonValidation() {
    var name = document.getElementById('nameField').value;
    var rating = parseInt(document.getElementById('ratingField').value);
    var returnVal = true;
    if (!name) {
        alert("Please enter a name");
        returnVal = false;
    }
    if (!document.getElementById('m').checked && !document.getElementById('f').checked) {
        alert("Please select a gender");
        returnVal = false;
    }
    if (!Number.isInteger(rating) || rating < 0 || rating > 10) {
        alert("Please enter a value between 1 and 10 for the rating");
        returnVal = false;
    }
    return returnVal;
}