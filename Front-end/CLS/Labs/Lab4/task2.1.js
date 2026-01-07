function main(){
    do{
        var inputRad = prompt("What is the value of your circle's radius ?")
        if(inputRad == null){
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
    while(isNaN(parseFloat(inputRad)) || parseFloat(inputRad) < 0)

    document.write("<h2>Total area of circle is " + 2 * parseFloat(inputRad) * Math.PI + "</h2>")
    
    console.log("Total area of circle is " + 2 * parseFloat(inputRad) * Math.PI)
}

main();