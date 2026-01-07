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
            var inputVal = prompt("Array[" + (arrSize - inputArrSize) + "]: ")
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

    var ascArr = [];
    var decArr = [];
    for (let i = 0; i < arr.length; i++) {
        ascArr.push(arr[i]);
        decArr.push(arr[i]);
    }

    for (let i = 0; i < ascArr.length - 1; i++) {
        var minIndex = i;
        for (let j = i+1; j < ascArr.length; j++) {
            if(ascArr[minIndex] > ascArr[j]){
                minIndex = j
            }
        }
        var temp = ascArr[minIndex];
        ascArr[minIndex] = ascArr[i];
        ascArr[i] = temp;
    }

    for (let i = 0; i < decArr.length - 1; i++) {
        var maxIndex = i;
        for (let j = i+1; j < decArr.length; j++) {
            if(decArr[maxIndex] < decArr[j]){
                maxIndex = j
            }
        }
        var temp = decArr[maxIndex];
        decArr[maxIndex] = decArr[i];
        decArr[i] = temp;
    }

    document.write("<h2>Original values of array: " + arr + 
        "</h2><h2>Array after ascending: " + ascArr + 
        "</h2><h2>Array after decending: " + decArr + "</h2>")
        
    console.log("Original array: " + arr)
    console.log("Ascending array: " + ascArr)
    console.log("Decending array: " + decArr)
}

main();
