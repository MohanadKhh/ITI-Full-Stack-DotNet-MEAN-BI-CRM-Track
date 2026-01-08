import { Shape } from "./shape.js";

export class Rectangle extends Shape {
    #length;
    #width;
    constructor(color, length, width) {
        super(color)
        this.#length = length
        this.#width = width
    }

    calcArea() {
        return this.length * this.width
    }

    calcPerimeter() {
        return 2 * (this.length + this.width)
    }

    get length(){
        return this.#length
    }

    set length(newLen){
        this.#length = newLen
    }

    get width(){
        return this.#width
    }

    set width(newWid){
        this.#width = newWid
    }

    toString() {
        return `This is the Rectangle Object
Color: ${this.color}
Lenght: ${this.length}
Width: ${this.width}
Area: ${this.calcArea()}
Perimeter: ${this.calcPerimeter()}`
    }
}
