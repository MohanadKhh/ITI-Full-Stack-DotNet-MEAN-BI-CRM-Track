var rectangle = {
    width: 10,
    length: 30,

    area: function () {
        return this.length * this.width
    },

    perimeter: function () {
        return 2 * (this.length + this.width)
    },

    displayInfo: function () {
        console.log(`Width of rextangle: ${this.width}\nLength of rextangle: ${this.length}
Area of rextangle: ${this.area()}\nPerimeter of rextangle: ${this.perimeter()}\n`
        );
    }
}


rectangle.displayInfo();

rectangle.length = 5;
rectangle.width = 2;
rectangle.displayInfo();
