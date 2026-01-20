import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Register } from "./component/register/register";
import { Students } from "./component/students/students";

@Component({
  selector: 'app-root',
  imports: [Register, Students],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('lab3-forms-validators');
  recievedSt: student = { name: "", age: "", email: "", gpa: "" }

  recieveData(data: any) {
    this.recievedSt = { name: data.name, age: data.age, email: data.email, gpa: data.gpa }
  }
}
