var defaultMarble = "./marbels/marble1.jpg"
var AnimatedMarble = "./marbels/marble2.jpg"
var myContainer = document.getElementById("marbleContatiner")

var currentIndex = 1;

var interval = setInterval(loading, 500); // runs every 1 second

function loading(){
    var currImg = document.getElementById("marble" + currentIndex)    
    var nextImg = document.getElementById("marble" + ((currentIndex % 5) + 1))
    nextImg.src = AnimatedMarble
    currImg.src = defaultMarble
    currentIndex = (currentIndex % 5) + 1
}

myContainer.addEventListener("mouseenter", function(){
    clearInterval(interval)
})

myContainer.addEventListener("mouseleave", function(){
    interval = setInterval(loading, 500); // runs every 1 second
})
 