var student = {
    name: "Mohanad",
    track: "PD",
    branch: "Ismailia",

    getGrade: function () {
        return grade = 5 * 5;
    },

    /*
    getSetGen: function () {
        (function () {
            for (const key in student) {
                let data = student[key]

                if (typeof data != "function") {
                    Object.defineProperty(student, key, {
                        get: function () {
                            console.log(`Calling get ${key} function`);
                            return data;
                        },
                        set: function (newValue) {
                            console.log(`Calling set ${key} function`);
                            data = newValue
                        },

                        configurable: true,
                        enumerable: true,

                    });
                }
            }
        })()
    }
    */


    /*
    getSetGen: function () {
        (function () {
            var keys = Object.keys(student).filter(k => typeof student[k] != "function")
            for (const key of keys){
                let data = student[key]

                Object.defineProperty(student, key, {
                    get: function () {
                        console.log(`Calling get ${key} function`);
                        return data;
                    },
                    set: function (newValue) {
                        console.log(`Calling set ${key} function`);
                        data = newValue
                    },

                    configurable: true,
                    enumerable: true,

                });
            }
        })()
    }
    */

    getSetGen: function () {
        (function () {
            var dataMap = new Map();
            for (const key in student) {
                dataMap.set(key, student[key])

                if (typeof dataMap.get(key) != "function") {        //if comment this line will include object methods
                    Object.defineProperty(student, key, {
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

