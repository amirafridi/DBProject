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

function addActedInValidation() {
    var movie = document.getElementById('movieField').value;
    var actor = document.getElementById('actorField').value;
    var charName = document.getElementById('charField').value;
    var pay = parseInt(document.getElementById('payField').value);
    var returnVal = true;
    if (!movie) {
        alert("Please enter a movie title");
        returnVal = false;
    }
    if (!actor) {
        alert("Please enter an actor");
        returnVal = false;
    }
    if (!charName) {
        alert("Please enter a character name");
        returnVal = false;
    }
    if (!Number.isInteger(pay) || pay < 0) {
        alert("Please enter a valid pay");
        returnVal = false;
    }

    return returnVal;
}

function addMovieValidation() {
    var returnVal = true;
    var title = document.getElementById('titleField').value;
    var producer = document.getElementById('producerField').value;
    var releaseYear = parseInt(document.getElementById('yearField').value);
    var runTime = parseInt(document.getElementById('timeField').value);
    var budget = parseInt(document.getElementById('budgetField').value);
    var gross = parseInt(document.getElementById('grossField').value);
    var rating = parseInt(document.getElementById('ratingField').value);

    if (!title) {
        alert("Please enter a movie title");
        returnVal = false;
    }
    if (!producer) {
        alert("Please enter a Producer");
        returnVal = false;
    }
    if (!Number.isInteger(releaseYear) || releaseYear < 1800 || releaseYear > 2018) {
        alert("Please enter a valid release year between 1800 & 2018");
        returnVal = false;
    }
    if (!Number.isInteger(runTime) || runTime < 0 || runTime > 300) {
        alert("Please enter a valid run time less than 300 minutes");
        returnVal = false;
    }
    if (!Number.isInteger(budget) || budget < 0) {
        alert("Please enter a valid budget (int only)");
        returnVal = false;
    }
    if (!Number.isInteger(gross) || gross < 0) {
        alert("Please enter a valid gross (int only)");
        returnVal = false;
    }
    if (!Number.isInteger(rating) || rating < 0 || rating > 10) {
        alert("Please enter a value between 1 and 10 for the rating");
        returnVal = false;
    }

    return returnVal;
}