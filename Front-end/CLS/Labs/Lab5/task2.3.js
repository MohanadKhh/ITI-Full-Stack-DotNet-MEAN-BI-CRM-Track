function reverseParam(){
    var arr = [];
    for (let i = arguments.length - 1; i >= 0; i--) {
        arr.push(arguments[i]);
    }
    return arr;
}

document.write("<h2>The reversed parameters are :" + reverseParam(1,2,3,4,5,-5) + "</h2>")

console.log(reverseParam(1,2,3,4,5,-5))