//Shape Class
function Shape(_color) {
    if (this.constructor === Shape) {
        throw ("you can't create shape object");
    }

    this.color = _color
    Shape.incShapeCounter()
}

Shape.shapeCounter = 0
Shape.incShapeCounter = function () {
    this.shapeCounter++;
}
Shape.prototype.area = function () { }
Shape.prototype.perimeter = function () { }


//Rectangle Class
function Rectangle(_color, _length, _width) {
    Shape.call(this, _color)
    this.length = _length
    this.width = _width
    if (this.constructor === Rectangle){
        Rectangle.incRecCounter()
    }
    if (Rectangle.recCounter > 1) {
        throw ("you can create only one rectangle");
    }
}

Rectangle.recCounter = 0
Rectangle.incRecCounter = function () {
    Rectangle.recCounter++;
}

Rectangle.prototype = Object.create(Shape.prototype)
Rectangle.prototype.constructor = Rectangle

Rectangle.prototype.area = function () {
    return this.length * this.width
}

Rectangle.prototype.perimeter = function () {
    return 2 * (this.length + this.width)
}


//Square Class
function Square(_color, _side) {
    Rectangle.call(this, _color, _side, _side)
    Square.incSqCounter()

    if (Square.sqCounter > 1) {
        throw ("you can create only one square");
    }
}

Square.sqCounter = 0
Square.incSqCounter = function () {
    this.sqCounter++;
}

Square.prototype = Object.create(Rectangle.prototype)
Square.prototype.constructor = Square

// var sh = new Shape("colored")
var rec = new Rectangle("black", 5, 10)
var sq = new Square("red", 5)

console.log(rec.area(), rec.perimeter())
console.log(sq.area(), sq.perimeter())

console.log(`Shapes objects is: ${Shape.shapeCounter}`);
console.log(`Rectangle objects is: ${Rectangle.recCounter}`);
console.log(`Square objects is: ${Square.sqCounter}`);
