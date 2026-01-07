var myAudio = document.querySelector("audio")
var progress = document.querySelector("#audioRange")
var myVolume = document.querySelector("#soundRange")

var audioArr = ["./audio/افلا ينظرون.mpeg", "./audio/الا تنصروه.mpeg", "./audio/الذين آمنوا.mpeg", "./audio/ان الله الله لا يخفى عليه.mpeg"]


myAudio.addEventListener("loadedmetadata", () => {
    progress.max = Math.floor(myAudio.duration);
});

myAudio.addEventListener("timeupdate", () => {
    progress.value = Math.floor(myAudio.currentTime);
});

myAudio.addEventListener("volumechange", () => {
    myVolume.value = myAudio.muted ? 0 : Number(myAudio.volume);
});

function play(){
    myAudio.play()
}

function pause(){
    myAudio.pause();
}

function replay(){
    myAudio.currentTime = 0;
}

function audioVolume(inp){
    myAudio.volume = inp.value
}

function audioRange(inp){
    if(inp.value <= myAudio.duration)
        myAudio.currentTime = inp.value
}

function changeAudio(td){
    switch (td.innerText.trim()) {
        case "افلا ينظرون الى الابل":
            myAudio.src = audioArr[0];
            myAudio.play();
            break;

        case "الا تنصروه فقد نصره الله":
            myAudio.src = audioArr[1];
            myAudio.play();
            break;

        case "الذين آمنوا و تطمئن قلوبهم":
            myAudio.src = audioArr[2];
            myAudio.play();
            break;

        case "ان الله الله لا يخفى عليه شئ":
            myAudio.src = audioArr[3];
            myAudio.play();
            break;
            
        default:
            break;
    }
}