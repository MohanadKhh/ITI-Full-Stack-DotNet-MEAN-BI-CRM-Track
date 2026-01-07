function boxConstructor(_material, _height, _width, _length) {
    this.material = _material

    this.height = _height
    this.width = _width
    this.length = _length
    this.volume = function () {
        return this.height * this.width * this.length
    }

    this.content = []
    this.numOfBooks = function () {
        return this.content.length
    }
    this.addBook = function (book) {
        this.content.push(book)
        console.log(`Added book with title ${book.title}`);
    }

    this.deleteBookByTitle = function (_title) {
        this.content = this.content.filter(book => book.title != _title)
        console.log(`Deleted book with title ${_title}`);
    }

    this.deleteBookByType = function (_type) {
        if (this.content.filter(book => book.type == _type)) {
            this.content = this.content.filter(book => book.type != _type)
            console.log(`Deleted books with type ${_type}`);
        }
        else {
            console.log("Not Found");
        }
        // var oldContenLen = this.content.length
        // if (this.content.length == oldContenLen) {
        //     console.log("Not Found");

        // }
        // else {
        //     this.content = this.content.filter(book => book.type != _type)
        //     console.log(`Deleted books with type ${_type}`);
        // }
    }

    this.diplayBox = function () {
        console.log("Display Box:", this.content);
    }
}

function bookConstructor(_title, _type, _numofChapters, _author, _numofPages, _publisher, _numofCopies) {
    this.title = _title
    this.type = _type
    this.numofChapters = _numofChapters
    this.author = _author
    this.numofPages = _numofPages
    this.publisher = _publisher
    this.numofCopies = _numofCopies
}


var box = new boxConstructor("cartoon", 10, 5, 5);
var book1 = new bookConstructor("Clean Code", "Programming", 17, "Robert C. Martin", 464, "Pearson", 1)
var book2 = new bookConstructor("El Moaaser", "Science", 8, "Ali", 150, "XYZ", 3)
var book3 = new bookConstructor("EL Adwaa", "Science", 12, "Mohanad", 220, "ABC", 5)
var book4 = new bookConstructor("Oliver Twist", "Novel", 12, "Mohanad", 220, "ABC", 5)



console.log(`Number of books in box is ${box.numOfBooks()}`);
box.addBook(book1)
box.addBook(book2)
box.addBook(book3)
box.addBook(book4)
console.log(`Number of books in box is ${box.numOfBooks()}`);

box.diplayBox();
box.deleteBookByTitle("Clean Code")
box.diplayBox();

box.deleteBookByType("Science")
box.diplayBox();


