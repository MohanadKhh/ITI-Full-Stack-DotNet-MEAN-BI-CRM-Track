do{
    var myDate = prompt("Please, enter date:")
}
while (!/^(0?[1-9]|1[0-2])\/(0?[1-9]|[12][0-9]|3[01])\/\d{4}$/.test(myDate));

var days = ["Sunday","Monday", "Tuesday","Wednesday","Thursday","Friday","Saturday"]

function getDayName(date){
    var myDate = new Date(date)

    var day = myDate.getDay()
    
    return days[day]
}

document.write("<h2>The day of your date is " + getDayName(myDate) + "</h2>")
console.log(getDayName(myDate));