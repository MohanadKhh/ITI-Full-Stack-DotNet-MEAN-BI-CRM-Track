do{
    var userName = prompt("Please, Enter Your Name:")
}
while(typeof userName != "string" || !userName || !isNaN(userName) || userName.length <= 2)

document.write("<p><b><u>Name:</u> </b>" + userName + "</p>")

do{
    var bdYear = prompt("Please, Enter Your BD Year:")
}
while(!bdYear || isNaN(bdYear) || bdYear >= 2010 || bdYear<1900)

document.write("<p><b><u>Birth year:</u> </b>" + bdYear + "</p>")

age = 2025-bdYear
document.write("<p><b><u>Age:</u> </b>" + age + "</p>")
