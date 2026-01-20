import { Component, EventEmitter, Output, output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { validate } from '@angular/forms/signals';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule],
  templateUrl: './register.html',
  styles: ``,
})
export class Register {
  @Output() sendData = new EventEmitter();
  inputSt : student = {name:"", age:"", email:"", gpa:""};

  myForm = new FormGroup({
    stName : new FormControl("", [Validators.required, Validators.minLength(3)]),
    stAge : new FormControl(null, [Validators.required, Validators.min(10), Validators.max(80)]),
    stEmail : new FormControl("", [Validators.required, Validators.email]),
    stGPA : new FormControl(null, [Validators.required, Validators.min(0), Validators.max(4)])
  })

  get nameValue(){
    return this.myForm.controls.stName.value ?? ""
  }

  get ageValue(){
    return this.myForm.controls.stAge.value ?? ""
  }

  get emailValue(){
    return this.myForm.controls.stEmail.value ?? ""
  }

  get gpaValue(){
    return this.myForm.controls.stGPA.value ?? ""
  }

  add(){
    if(this.myForm.valid){
      this.inputSt.name = this.nameValue
      this.inputSt.age = this.ageValue
      this.inputSt.email = this.emailValue
      this.inputSt.gpa = this.gpaValue
      this.sendData.emit(this.inputSt)
      this.myForm.reset();
    }
  }
}
