var student = {
    name: "Mohanad",
    track: "PD",
    branch: "Ismailia",

    getGrade: function () {
        return grade = 5 * 5;
    },

    getSetGen: function () {
        var _this = this;

        (function () {
            var dataMap = new Map();
            for (const key in _this) {
                dataMap.set(key, _this[key])

                if (typeof dataMap.get(key) != "function") {        //if comment this line will include object methods
                    Object.defineProperty(_this, key, {
                        get: function () {
                            console.log(`Calling get ${key} function`);
                            return dataMap.get(key);
                        },
                        set: function (newValue) {
                            console.log(`Calling set ${key} function`);
                            dataMap.set(key, newValue)
                        },

                        configurable: true,
                        enumerable: true,

                    });
                }      //if closed curl bracket
            }
        })()
    }
}

var user = {
    name: "Ali",
    age: 23,

    getCourse: function () {
        return "Advanced JS"
    }
}

console.log(student.name);
student.name = "Loay";
console.log(student.name);

student.getSetGen()
console.log(student.name);
student.name = "hamada";
console.log(student.name);

console.log(student.track);
student.track = "UI";
console.log(student.track);

console.log(student.branch);
student.branch = "Smart Village";
console.log(student.branch);

console.log(student.getGrade())
student.getGrade = function () {
    return grade = 10 * 10;
}
console.log(student.getGrade())

console.log(user.name);
user.name = "hamada"
console.log(user.name);

student.getSetGen.call(user)
// var fnc = student.getSetGen.bind(user)
// fnc()

console.log(user.name)
user.name = "omar"
console.log(user.name)

console.log(user.age);
user.age = "25"
console.log(user.age)

console.log(user.getCourse())
console.log(user.getCourse)
user.getCourse = function () {
    return "Advanced Hamada"
}
console.log(user.getCourse())
console.log(user.getCourse)