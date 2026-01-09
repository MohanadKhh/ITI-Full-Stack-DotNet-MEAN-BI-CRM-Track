import { Counter } from "./counter.js";
const increaseBtn = document.querySelector("#increaseBtn");
const resetBtn = document.querySelector("#resetBtn");
const decreaseBtn = document.querySelector("#decreaseBtn");
const counterVal = document.querySelector("#counterValue");
let counter = new Counter();
if (increaseBtn && counterVal) {
    increaseBtn.addEventListener("click", function () {
        counter.increase();
        counterVal.textContent = String(counter.counterValue);
    });
}
if (decreaseBtn && counterVal) {
    decreaseBtn.addEventListener("click", function () {
        counter.decrease();
        counterVal.textContent = String(counter.counterValue);
    });
}
if (resetBtn && counterVal) {
    resetBtn.addEventListener("click", function () {
        counter.reset();
        counterVal.textContent = String(counter.counterValue);
    });
}
