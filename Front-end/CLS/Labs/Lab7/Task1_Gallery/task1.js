var imgArrUrl = ["./SlideShow/1.jpg", "./SlideShow/2.jpg",
                 "./SlideShow/3.jpg", "./SlideShow/4.jpg",
                  "./SlideShow/5.jpg", "./SlideShow/6.jpg"]

var myImg = document.getElementById("imgID")
var intervalFunc;
var currentImgIndex = getCurrImgIndex(myImg)

function getCurrImgIndex(myImg){
    for (let i = 0; i < imgArrUrl.length; i++) {
        if(myImg.src.includes(i))
            return i;
    }
}

function slideShow(){
    intervalFunc = setInterval(function () {
        myImg.src = imgArrUrl[(currentImgIndex + 1) % imgArrUrl.length];
        currentImgIndex++;
     }
     , 1500);
}

function stop(){
    clearInterval(intervalFunc);
}

function next(){
    if(currentImgIndex != (imgArrUrl.length - 1)){
        myImg.src = imgArrUrl[++currentImgIndex];
    }
}

function prev(){
    if(currentImgIndex != 0){
        myImg.src = imgArrUrl[--currentImgIndex];
    }
}

