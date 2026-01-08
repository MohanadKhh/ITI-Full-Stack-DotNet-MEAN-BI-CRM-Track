const nameInput = document.querySelector("#nameInput")
const priceInput = document.querySelector("#priceInput")
const authorName = document.querySelector("#authorName")
const authorEmail = document.querySelector("#authorEmail")

const nameSpanError = document.querySelector("#nameError")
const priceSpanError = document.querySelector("#priceError")
const authorNameError = document.querySelector("#authorNameError")
const emailSpanError = document.querySelector("#authorEmailError")

const title = document.querySelector("#title")

const submitBtn = document.querySelector(".submit__btn")

let inputName;
let inputPrice;
let inputAuthorName;
let inputAuthorEmail;

let books = []
let counter = Number(localStorage.getItem("bookNumbers")) || 0;

title.textContent = "Book " + Number(books.length + 1)

function nameValidation(e) {
    nameSpanError.textContent = "";

    if (nameInput.value.trim() === "") {
        e.preventDefault();
        nameSpanError.textContent = "Name required, can't be empty";
        return;
    }

    else if (!isNaN(nameInput.value)) {
        e.preventDefault();
        nameSpanError.textContent = "Name can't be numbers";
        return;
    }

    else if (nameInput.value.length < 3) {
        e.preventDefault();
        nameSpanError.textContent = "Name must be 3 characters or more";
    }

    else
        inputName = nameInput.value
}

function authorNameValidation(e) {
    authorNameError.textContent = "";

    if (authorName.value.trim() === "") {
        e.preventDefault();
        authorNameError.textContent = "Name required, can't be empty";
        return;
    }

    else if (!isNaN(authorName.value)) {
        e.preventDefault();
        authorNameError.textContent = "Name can't be numbers";
        return;
    }

    else if (authorName.value.length < 3) {
        e.preventDefault();
        authorNameError.textContent = "Name must be 3 characters or more";
    }

    else
        inputAuthorName = authorName.value
}

const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
function emailValidation(e) {
    emailSpanError.textContent = "";

    if (!emailRegex.test(authorEmail.value)) {
        e.preventDefault();
        emailSpanError.textContent = "Not valid Email";
        return;
    }

    else
        inputAuthorEmail = authorEmail.value
}

function priceValidation(e) {
    priceSpanError.textContent = ""

    if (!priceInput.value) {
        e.preventDefault();
        priceSpanError.textContent = "Price can't be empty or have special char";
        return;
    }

    else if (isNaN(priceInput.value)) {
        e.preventDefault();
        priceSpanError.textContent = "Price must be number";
        return;
    }

    else if (priceInput.value <= 0) {
        e.preventDefault();
        priceInput.value = 0
        priceSpanError.textContent = "Price must be more than 0";
        return;
    }

    else
        inputPrice = priceInput.value
}


submitBtn.addEventListener('click', function () {    
    if (inputName && inputPrice && inputAuthorName && inputAuthorEmail) {
        books.push({
            BookName: inputName,
            BookPrice: inputPrice,
            AuthorBookName: inputAuthorName,
            AuthorBookEmail: inputAuthorEmail,
        })

        if (!--counter) {
            localStorage.setItem("books", JSON.stringify(books));
            window.location.href = "./home.html"
        }
        else {
            title.textContent = "Book " + Number(books.length + 1)
            nameInput.value = "";
            priceInput.value = "";
            authorName.value = "";
            authorEmail.value = "";
        }
    }
})

