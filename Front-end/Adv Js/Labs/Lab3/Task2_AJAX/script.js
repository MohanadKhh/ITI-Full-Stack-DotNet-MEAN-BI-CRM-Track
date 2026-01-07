var xhr = new XMLHttpRequest()

xhr.open("get", "https://jsonplaceholder.typicode.com/posts")
xhr.send()

xhr.addEventListener("readystatechange", function () {
    if (xhr.readyState == 4 && xhr.status === 200) {
        var data = JSON.parse(xhr.response)
        processData(data)
        console.log(data);
    }
})

function processData(data) {
    var card = document.querySelector(".card__container")
    for (const post of data) {
        card.insertAdjacentHTML(
            "beforeend",
            `
            <div class="card w-96 bg-base-100 card-sm shadow-lg h-50">
                <div class="card-body">
                    <h2 class="card-title">${post.title}</h2>
                    <p>${post.body}</p>
                </div>
            </div>
            `
        );
    }
}