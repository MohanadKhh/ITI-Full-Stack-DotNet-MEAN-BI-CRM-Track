function cloneSpan(){
    var mySpan = document.getElementById("spanID");
    mySpanClone = mySpan.cloneNode(true);
    mySpanClone.style.backgroundColor = "rgb("+ Math.floor(Math.random() * 256) + ","
                                             + Math.floor(Math.random() * 256) + "," 
                                             + Math.floor(Math.random() * 256) +")";
    document.getElementById("Container").appendChild(mySpanClone);
}