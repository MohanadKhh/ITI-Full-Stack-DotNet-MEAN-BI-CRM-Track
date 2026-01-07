function main(){
    do{
        var inputVal = prompt("What is the value you want to calculate its square root ?")
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
    while(isNaN(parseFloat(inputVal)) || parseFloat(inputVal) < 0)

    document.write("<h2>Square root of " + parseFloat(inputVal) + " is " + Math.sqrt(parseFloat(inputVal)) + "</h2>")

    console.log("Square root of " + parseFloat(inputVal) + " is " + Math.sqrt(parseFloat(inputVal)))    
}

main();
