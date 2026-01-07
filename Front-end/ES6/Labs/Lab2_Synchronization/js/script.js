const usersContainer = document.querySelector(".user__names")
const postsContainer = document.querySelector(".user__posts")

async function getUsers() {
    try {
        const res = await fetch("https://jsonplaceholder.typicode.com/users");
        const data = await res.json();
        for (const user of data) {
            usersContainer.insertAdjacentHTML("beforeend",
                `<div onclick="showPosts(this)" id="${user.id}" class="bg-teal-700 text-white px-5 py-3 rounded-xl text-center hover:scale-105">${user.name}</div>`
            );
        }
        console.log(data);
    } catch (err) {
        console.error("Fetch error:", err);
    }
}

function showPosts(btn) {
    postsContainer.textContent=""
    async function getPosts() {
        try {
            const res = await fetch("https://jsonplaceholder.typicode.com/posts?userId=" + btn.id);
            const data = await res.json();
            for (const user of data) {
                postsContainer.insertAdjacentHTML("beforeend",
                    `<div class="flex flex-col gap-3 p-4 rounded-2xl border border-slate-600 bg-slate-900/80 shadow-lg min-h-50">
                    <div class="bg-amber-200 text-black px-5 py-3 rounded-xl text-center">${user.title}</div>
                    <div class="bg-slate-900 text-white px-5 py-3 rounded-xl text-center">${user.body}</div>
                    </div>`
                );
            }
        } catch (err) {
            console.error("Fetch error:", err);
        }
    }
    getPosts()
}


getUsers();
