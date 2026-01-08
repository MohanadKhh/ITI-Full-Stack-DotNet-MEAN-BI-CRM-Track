let books = JSON.parse(localStorage.getItem("books")) || [];

const tableBody = document.querySelector("#tableBody")

const priceInput = document.querySelector("#priceInput")
const authorName = document.querySelector("#authorName")
const authorEmail = document.querySelector("#authorEmail")

const priceSpanError = document.querySelector("#priceError")
const authorNameError = document.querySelector("#authorNameError")
const emailSpanError = document.querySelector("#authorEmailError")

let inputName;
let inputPrice;
let inputAuthorName;
let inputAuthorEmail;

let counter = 1;
let rowIndex;

for (const book of books) {
    tableBody.insertAdjacentHTML("beforeend",
        `<tr class="hover:bg-base-300">
            <th>${counter}</th>
            <td>${book.BookName}</td>
            <td>${book.BookPrice}</td>
            <td>${book.AuthorBookName}</td>
            <td>${book.AuthorBookEmail}</td>
            <td class="flex gap-5">
                <button onclick="editRow(this)" class="btn btn-sm btn-info text-white">Edit</button>
                <button onclick="deleteRow(this)" class="btn btn-sm btn-error text-white">Delete</button>
            </td>
        </tr>`
    );
    counter++;
}

function editRow(btn) {
    const row = btn.closest("tr");
    rowIndex = row.querySelector("th").textContent;
    const columns = row.querySelectorAll("td");
    let bookName = columns[0].textContent
    columns[0].textContent = ""
    columns[0].insertAdjacentHTML("beforeend", `<input id="nameInput" value=${bookName} type="text" onblur="nameValidation(event)">
                                                <div><span id="nameError" class="text-red-900"></span></div>`)
    let bookPrice = columns[1].textContent
    columns[1].textContent = ""
    columns[1].insertAdjacentHTML("beforeend", `<input id="priceInput" value=${bookPrice} type="number" onblur="priceValidation(event)">
                                                <div><span id="priceError" class="text-red-900"></span></div>`)
    let authorName = columns[2].textContent
    columns[2].textContent = ""
    columns[2].insertAdjacentHTML("beforeend", `<input id="authorName" value=${authorName} type="text" onblur="authorNameValidation(event)">
                                                <div><span id="authorNameError" class="text-red-900"></span></div>`)
    let authorEmail = columns[3].textContent
    columns[3].textContent = ""
    columns[3].insertAdjacentHTML("beforeend", `<input id="authorEmail" value=${authorEmail} type="email" onblur="emailValidation(event)">
                                                <div><span id="authorEmailError" class="text-red-900"></span></div>`)
    columns[4].textContent = ""
    columns[4].insertAdjacentHTML("beforeend", `<button onclick="saveRow(this)" class="btn btn-sm btn-success text-white">Save</button>
                                                <button onclick="cancelEdit(this)" class="btn btn-sm btn-error text-white">Cancel</button>`)
    console.log("Editing row:", th.textContent);
}

function nameValidation(e) {
    const nameInput = document.querySelector("#nameInput")
    const nameSpanError = document.querySelector("#nameError")
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
    const authorName = document.querySelector("#authorName")
    const authorNameError = document.querySelector("#authorNameError")
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
    const authorEmail = document.querySelector("#authorEmail")
    const emailSpanError = document.querySelector("#authorEmailError")
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
    const priceInput = document.querySelector("#priceInput")
    const priceSpanError = document.querySelector("#priceError")
    priceSpanError.textContent = ""

    if (!priceInput.value) {
        e.preventDefault();
        priceSpanError.textContent = "Price required, can't be empty";
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

function saveRow(btn) {
    const row = btn.closest("tr");
    rowIndex = row.querySelector("th").textContent;
    if (inputName && inputPrice && inputAuthorName && inputAuthorEmail) {
        books[rowIndex - 1] = {
            BookName: inputName,
            BookPrice: inputPrice,
            AuthorBookName: inputAuthorName,
            AuthorBookEmail: inputAuthorEmail,
        }
        localStorage.setItem("books", JSON.stringify(books));
        window.location.reload()
    }
}

function cancelEdit() {
    window.location.reload()
}

function deleteRow(btn) {
    const row = btn.closest("tr");
    rowIndex = row.querySelector("th").textContent;
    books.splice(rowIndex - 1, 1);
    localStorage.setItem("books", JSON.stringify(books));
    window.location.reload()
}