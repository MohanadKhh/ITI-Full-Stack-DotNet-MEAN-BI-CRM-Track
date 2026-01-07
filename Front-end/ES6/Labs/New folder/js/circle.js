import { Shape } from "./shape.js";

export class Circle extends Shape {
    constructor(color, radius) {
        super(color)
        this.radius = radius
    }

    calcArea() {
        return Math.PI * (this.radius ** 2);
    }

    calcPerimeter() {
        return 2 * Math.PI * this.radius;
    }

    toString() {
        return `This is the Circle Object
Color: ${this.color}
Radius: ${this.radius}
Area: ${this.calcArea()}
Perimeter: ${this.calcPerimeter()}`
    }
}