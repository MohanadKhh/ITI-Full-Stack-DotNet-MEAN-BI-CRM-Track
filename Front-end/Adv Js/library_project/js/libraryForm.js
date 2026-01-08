let bookNumbers = 0;
const bookInput = document.querySelector("#bookInput")
const errorMsg = document.querySelector("#errorMsg")
const submitBtn = document.querySelector(".submit__btn")

bookInput.addEventListener('input', function () {
    if (bookInput.value < 1) {
        errorMsg.innerText = "Must be 1 or more"
        bookInput.value = 1
    }
    else {
        errorMsg.innerText = ""
        const bookNumbers = bookInput.value;
        localStorage.setItem('bookNumbers', bookNumbers);
        console.log(bookNumbers);
    }
});

submitBtn.addEventListener('click', function(){
    window.location.href = "bookForm.html"
})