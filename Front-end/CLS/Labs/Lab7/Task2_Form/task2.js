var myName = document.getElementById("name")
var myAge = document.getElementById("age")
var myEmail = document.getElementById("email")
var myTable = document.querySelector(".styled-table tbody")

var nameSpanError = document.getElementById("nameValidationError")
var ageSpanError = document.getElementById("ageValidationError")
var emailSpanError = document.getElementById("emailValidationError")

var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

var inputName = ""
var inputAge = ""
var inputEmail = ""


function nameValidation(e) {
    nameSpanError.textContent = "";

    if (myName.value.trim() === "") {
        e.preventDefault();
        nameSpanError.textContent = "Name required, can't be empty";
        return;
    }

    else if (!isNaN(myName.value)) {
        e.preventDefault();
        nameSpanError.textContent = "Name can't be numbers";
        return;
    }

    else if (myName.value.length < 3) {
        e.preventDefault();
        nameSpanError.textContent = "Name must be 3 characters or more";
    }

    else
        inputName = myName.value;
}


function ageValidation(e){
    ageSpanError.textContent = ""

    if(!myAge.value){
        e.preventDefault();
        ageSpanError.textContent = "Age required, can't be empty";
        return;
    }

    else if(isNaN(myAge.value)){
        e.preventDefault();
        ageSpanError.textContent = "Age must be number";
        return;        
    }

    else if(myAge.value < 11 || myAge.value > 120){
        e.preventDefault();
        ageSpanError.textContent = "Age must be between 10 to 120";
        return;  
    }

    else if(!Number.isInteger(Number(myAge.value))){
        e.preventDefault();
        ageSpanError.textContent = "Age must be integer number";
        return;  
    }

    else
        inputAge = myAge.value

}

function emailValidation(e){
    emailSpanError.textContent = "";

    if(!emailRegex.test(myEmail.value)){
        e.preventDefault();
        emailSpanError.textContent = "Not valid Email";
        return; 
    }

    else
        inputEmail = myEmail.value
}

function addUser(){
    var newRow = myTable.insertRow();
    if(inputName == "" || inputAge == "" || inputEmail == ""){
        return
    }

    newRow.insertCell(0).textContent = inputName;
    newRow.insertCell(1).textContent = inputAge;
    newRow.insertCell(2).textContent = inputEmail;

    inputName = ""
    inputAge = ""
    inputEmail = ""
}

function clearTable(){
    while (myTable.rows.length > 0) {
        myTable.deleteRow(0);
    }

    inputName = ""
    inputAge = ""
    inputEmail = ""
}