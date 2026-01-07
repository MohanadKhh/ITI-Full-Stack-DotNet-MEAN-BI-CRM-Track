function twoParam(x,y){
    if(!x || !y || arguments.length != 2)
        throw "Function must have two parameters"
    else
        console.log("Pass")
}

twoParam(6,3)