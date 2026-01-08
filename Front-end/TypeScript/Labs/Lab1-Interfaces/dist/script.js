// 01-Create an interface for a Student with:
// - id (number)
// - name (string)
// - email (string, optional)
// - isActive (boolean)
// - grades (array of numbers)
class Student {
    constructor(id, name, email, isActive, grades) {
        this.name = name;
        this.id = id;
        this.email = email;
        this.isActive = isActive;
        this.grades = grades;
    }
    avgGrades() {
        return this.grades.reduce((sum, n) => sum + n, 0) / this.grades.length;
    }
    getStStatus() {
        let stAvgGrade = this.avgGrades();
        if (stAvgGrade >= 90)
            return "Excellent";
        else if (stAvgGrade >= 70)
            return "Good";
        else if (stAvgGrade >= 50)
            return "Average";
        else
            return "Needs improvement";
    }
}
let st1 = new Student(1, "Alice Johnson", "Alice@kokk.com", true, [50, 30, 40, 80]);
console.log(`Student Name: ${st1.name}\nAverage grade: ${st1.avgGrades()}\nPerformance: ${st1.getStStatus()}`);
let st2 = new Student(2, "Honda Elsha2y", "Honda@kokk.com", true, [90, 90, 100, 80]);
console.log(`Student Name: ${st2.name}\nAverage grade: ${st2.avgGrades()}\nPerformance: ${st2.getStStatus()}`);
