var result = true;

do{
    var inputStr = prompt("Please, enter your string:")
    if(inputStr == null){
        do{
            var cancelCheck = prompt("Do you really want to exit ? Y/N");
        }
        while(!['y','n'].includes(cancelCheck.toLowerCase()))
        
        if(cancelCheck.toLowerCase() == 'y'){
            alert("Program ended by user.");
            throw new Error("Program stopped by user."); // stops execution
        }
    }
}
while(!inputStr)
  
do{
    var caseFlag = prompt("Do you need to be case sensitive or not ? Y/N")
    if(inputStr == null){
        do{
            var cancelCheck = prompt("Do you really want to exit ? Y/N");
        }
        while(!['y','n'].includes(cancelCheck.toLowerCase()))
        
        if(cancelCheck.toLowerCase() == 'y'){
            alert("Program ended by user.");
            throw new Error("Program stopped by user."); // stops execution
        }
    }
}
while( !['y','n'].includes(caseFlag.toLowerCase()) )


if(caseFlag.toLowerCase() == 'y')
    caseFlag = 1;
else
    caseFlag = 0;


for (let i = 0; i < inputStr.length / 2; i++) {
    if(caseFlag){
        if(inputStr[i] !== inputStr[inputStr.length - i - 1]){
            result = false;
            break;
        }
    }
    else{
        if(inputStr[i].toLowerCase() !== inputStr[(inputStr.length - i) - 1].toLowerCase()){
            result = false;
            break;
        }
    }
}

document.write("<h2>_ Is string a palindrome ?</h2><h2>_ " + result + "</h2>")

console.log("Is string a palindrome ?\t" + result);