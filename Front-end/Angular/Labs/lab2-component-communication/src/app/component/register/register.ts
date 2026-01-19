import { Component, EventEmitter, Output, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { email } from '@angular/forms/signals';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  stName = ""
  stAge = ""
  stEmail = ""
  stGPA = ""

  @Output() sendDataEvt = new EventEmitter()

  signUp(evt: Event) {
    this.sendDataEvt.emit({ name: this.stName, age: this.stAge, email: this.stEmail, gpa: this.stGPA })
    this.stName = ""
    this.stAge = ""
    this.stEmail = ""
    this.stGPA = ""
  }
}
