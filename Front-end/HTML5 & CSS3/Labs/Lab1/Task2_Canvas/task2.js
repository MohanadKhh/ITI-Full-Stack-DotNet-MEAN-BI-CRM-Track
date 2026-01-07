var myInput = document.querySelector("#picker")
var myButton = document.querySelector("button")
var myCanvas = document.querySelector("#canvasID")
var ctx = myCanvas.getContext("2d");
var colorInp
maxX = myCanvas.width;
maxY = myCanvas.height;

function randomInt(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

myInput.oninput = () => {
    colorInp = myInput.value;
    ctx.strokeStyle = colorInp
};

myButton.onclick = function(){
    ctx.clearRect(0, 0, myCanvas.width, myCanvas.height);
    for (let i = 0; i < randomInt(5,50); i++) {
        ctx.beginPath()
        ctx.arc(randomInt(0,maxX), randomInt(0,maxY), randomInt(5,20), 0, Math.PI * 2)
        ctx.stroke();
    }
}
