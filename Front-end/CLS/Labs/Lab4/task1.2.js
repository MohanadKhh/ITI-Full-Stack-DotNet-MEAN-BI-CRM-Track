function main(){
    do{
        var inputStr = prompt("Please, enter your string:")
        if(inputStr == null){
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
    while(!inputStr)

    do{
        var charSearch = prompt("Please, enter char you want to search on:")
        if(charSearch == null){
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
    while(!charSearch)   

    var count = 0;
    for (let i = 0; i < inputStr.length; i++) {
        if(inputStr[i].toLowerCase() == charSearch.toLowerCase()){
            count++;
        }
    }

    document.write("<h2>Number of letter (" + charSearch + ") in [" + inputStr + "] = " + count + "</h2>")

    console.log("Number of letter (" + charSearch + ") in [" + inputStr + "] = " + count)
}

main();