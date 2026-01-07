import { Shape } from "./shape.js";

export class Square extends Shape {
    constructor(color, side) {
        super(color)
        this.side = side
    }

    calcArea() {
        return this.side ** 2;
    }

    calcPerimeter() {
        return 4 * this.side;
    }

    toString() {
        return `This is the Square Object
Color: ${this.color}
Side: ${this.side}
Area: ${this.calcArea()}
Perimeter: ${this.calcPerimeter()}`
    }
}