var myHeader = document.getElementById("header");
var myImg = document.getElementById("imgID");
var myList = document.getElementById("navigation");

myList.style.display = "flex"
myList.style.marginTop = "250px"
myList.style.justifyContent = "center"

myImg.style.width = "100%"
myImg.style.height = "100%"
myImg.style.objectFit = "cover"

var myFooter = myHeader.cloneNode(true);
document.body.appendChild(myFooter);

myHeader.style.position = "fixed"
myHeader.style.top = "0"
myHeader.style.right = "0"
myHeader.style.height = "200px"
myHeader.style.width = "200px"

myFooter.style.position = "fixed"
myFooter.style.bottom = "0"
myFooter.style.left = "0"
myFooter.style.height = "200px"
myFooter.style.width = "200px"