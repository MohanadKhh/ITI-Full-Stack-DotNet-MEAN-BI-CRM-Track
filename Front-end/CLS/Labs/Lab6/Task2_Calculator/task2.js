var input = ""

function recieveInput(inp){
    input += inp.innerText;  // or inp.textContent
    document.getElementById("result").innerText = input; // show in calculator screen
}

function equal(){
    try{
        var res = eval(input)
        if(res == "Infinity")
            res = "Math error"
        document.getElementById("result").innerText = res; // show in calculator screen
    }
    catch(e){
        document.getElementById("result").innerText = "Can't evaluate this input, Please try again"; // show in calculator screen
        input=""
    }
}

function clearCalc(){
    input = ""
    document.getElementById("result").innerText = input; // show in calculator screen
}