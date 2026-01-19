import { Component, signal } from '@angular/core';
import { Register } from "./component/register/register";
import { Students } from "./component/students/students";

@Component({
  selector: 'app-root',
  imports: [Register, Students],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('lab2-component-communication');
  students: student[] = []

  getData(data: any) {
    if(data.name && data.age){
      this.students.push(data)
    }
    console.log(this.students);
  }
}