do{
    input = prompt("Please, Enter value:");
}
while(!input || isNaN(input))
    
var sum = +input;

while(sum<=100 && input!=0){
    do{
        input = prompt("Please, Enter value:");
    }
    while(!input || isNaN(input))
    sum += +input
}

if(sum>100){
    sum -= +input;
}
console.log(sum);

document.write("<h2>Sum of values = "+ sum +"</h1>");