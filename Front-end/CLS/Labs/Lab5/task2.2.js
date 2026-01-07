function add(){
    var sum = 0;
    for (let i = 0 ; i < arguments.length ; i++) {
        if(typeof arguments[i] !== "number"){
            throw "Can't add with parametes arn't numeric"
            return;
        }
        sum += arguments[i];
    }
    return sum;
}

console.log(add(5,5,5,5,"5"))