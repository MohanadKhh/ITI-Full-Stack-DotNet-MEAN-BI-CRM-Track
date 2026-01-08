//Task 1
console.log("Task 1");
let a = 3, b = 5;
console.log(`a=${a} | b=${b}`);
[a, b] = [b, a]
console.log("Afer Swapping");
console.log(`a=${a} | b=${b}`);

//Task2
console.log("\nTask 2");
function min_max(...args) {
    let min = args[0]
    let max = args[0]
    args.forEach(el => {
        if (el > max) {
            max = el
        }
        if (el < min) {
            min = el
        }
    });
    console.log(`min value = ${min} | max value = ${max}`);
}

min_max(2, -5, 100, -66, 999, 1000, 5, 0)

//Task3
console.log("\nTask 3.1");
var fruits = ["apple", "strawberry", "banana", "orange", "mango"]
var stringFlag = fruits.every(el => typeof el === "string")
console.log(`is all arrays strings ? ${stringFlag}`);

console.log("\nTask 3.2");
var startWithA = fruits.some(el => el[0] == "a")
console.log(`is any element start with 'a' ? ${startWithA}`);

console.log("\nTask 3.3");
var filteredArr = fruits.filter(el => el[0] == "b" || el[0] == "s")
console.log(`Elements started with 'b' or 's': ${filteredArr}`);

console.log("\nTask 3.4");
var likedArr = fruits.map(el => "I like " + el)
likedArr.forEach(el => console.log(el))