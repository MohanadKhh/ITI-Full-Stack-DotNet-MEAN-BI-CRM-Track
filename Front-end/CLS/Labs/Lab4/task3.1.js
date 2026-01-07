function main(){
    do{
        var inputArrSize = prompt("Please, enter your array size:")
        if(inputArrSize == null){
            do{
                var cancelCheck = prompt("Do you really want to exit ? Y/N");
            }
            while(!['y','n'].includes(cancelCheck.toLowerCase()))
            
            if(cancelCheck.toLowerCase() == 'y'){
                alert("Program ended by user.");
                return;
            }    
        }
    }
    while(isNaN(parseInt(inputArrSize)))

    inputArrSize = parseInt(inputArrSize);
    var arrSize = inputArrSize;
    var arr = [];

    while(inputArrSize--){
        do{
            var inputVal = prompt("Array[" + (arrSize - inputArrSize) + "]: ");
            if(inputVal == null){
                do{
                    var cancelCheck = prompt("Do you really want to exit ? Y/N");
                }
                while(!['y','n'].includes(cancelCheck.toLowerCase()))
                
                if(cancelCheck.toLowerCase() == 'y'){
                    alert("Program ended by user.");
                    return;
                }    
            }
        }
        while(isNaN(parseFloat(inputVal)))
        arr.push(parseFloat(inputVal))
    }

    var addRes = 0;
    var mulRes = 1;
    var divRes = Math.pow(arr[0],2);
    var divFlag = true;

    for (let i = 0; i < arr.length; i++) {
        addRes += arr[i];
        mulRes *= arr[i];
        if(arr[i] == 0)
            divFlag = false;
        else
            divRes /= arr[i];
    }

    if(!divFlag){
        divRes = "undefined [can't divide by zero] !!";
    }

    document.write("<h2>Sum of array values = " + addRes + 
        "</h2><h2>Multiplication of array values = " + mulRes + 
        "</h2><h2>Division of array values = " + divRes + "</h2>")

    console.log("Sum of array values = " + addRes);
    console.log("Multiplication of array values = " + mulRes);
    console.log("Division of array values = " + divRes);
}

main();