import { CommonModule } from '@angular/common';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-students',
  imports: [CommonModule],
  templateUrl: './students.html',
  styles: ``,
})
export class Students implements OnChanges {
  @Input() newStudent: student = { name: "", age: "", email:"", gpa:""}
  studentsArr: student[] = []

  ngOnChanges(changes: SimpleChanges): void {    
    if (changes["newStudent"].firstChange === false) {
      this.studentsArr.push(this.newStudent)
    }
  }
}
