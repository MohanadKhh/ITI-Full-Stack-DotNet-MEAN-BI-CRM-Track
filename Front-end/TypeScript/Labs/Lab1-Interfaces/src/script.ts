// 01-Create an interface for a Student with:
// - id (number)
// - name (string)
// - email (string, optional)
// - isActive (boolean)
// - grades (array of numbers)


// 02-Create functions that:
// 1. Add a new student (returns void)
// 2. Calculate average grade for a student (returns number)
// 3. Get student status based on average grade (returns string)
//    - >= 90: "Excellent"
//    - >= 70: "Good"
//    - >= 50: "Average"
//    - < 50: "Needs improvement"


// EX:
//  Adding student: Alice Johnson
//  Average grade: 85.75
//  Performance: Good

//  Adding student: Bob Smith
// 1 Average grade: 48.33
//  Performance: Needs improvement

interface StudentInterface {
    id: number;
    name: string;
    email?: string;
    isActive: boolean;
    grades: number[];

    avgGrades(): number;
    getStStatus(): string;
}

class Student implements StudentInterface {
    id: number;
    name: string;
    email?: string;
    isActive: boolean;
    grades: number[];

    constructor(id: number, name: string, email: string | "no email", isActive: boolean, grades: number[]) {
        this.name = name;
        this.id = id;
        this.email = email;
        this.isActive = isActive;
        this.grades = grades;
    }

    avgGrades(): number {
        return this.grades.reduce((sum, n) => sum + n, 0) / this.grades.length;
    }
    getStStatus(): string {
        let stAvgGrade = this.avgGrades()
        if (stAvgGrade >= 90)
            return "Excellent"
        else if (stAvgGrade >= 70)
            return "Good"
        else if (stAvgGrade >= 50)
            return "Average"
        else
            return "Needs improvement"
    }
}

let st1 = new Student(1, "Alice Johnson", "Alice@kokk.com", true, [50, 30, 40, 80])
console.log(`Student Name: ${st1.name}\nAverage grade: ${st1.avgGrades()}\nPerformance: ${st1.getStStatus()}`);

let st2 = new Student(2, "Honda Elsha2y", "Honda@kokk.com", true, [90, 90, 100, 80])
console.log(`Student Name: ${st2.name}\nAverage grade: ${st2.avgGrades()}\nPerformance: ${st2.getStStatus()}`);

