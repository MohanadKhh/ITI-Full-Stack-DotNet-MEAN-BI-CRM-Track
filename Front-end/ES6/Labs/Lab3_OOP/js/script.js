import { Rectangle } from "./rectangle.js";
import { Square } from "./square.js";
import { Circle } from "./circle.js";
import { Shape } from "./shape.js";

let shape = new Shape("White")
console.log(shape.toString());

let rec = new Rectangle("black", 10, 5)
console.log(rec.toString());

let sq = new Square("red", 10, 5)
console.log(sq.toString());

let cir = new Circle("green", 10, 5)
console.log(cir.toString());


//private fields and access them with getter and setter
console.log("Test Setter and Getter with priv fields in rectangle object");

console.log("Old Length = " + rec.length);
console.log("Old Width = " + rec.width);

rec.length = 20
rec.width = 30

console.log("New Length = " + rec.length);
console.log("New Length = " + rec.width);

console.log(rec.toString());
