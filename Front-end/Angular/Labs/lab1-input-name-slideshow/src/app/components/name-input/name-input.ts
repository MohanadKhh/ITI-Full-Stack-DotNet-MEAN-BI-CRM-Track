import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-name-input',
  imports: [FormsModule],
  templateUrl: './name-input.html',
  styleUrl: './name-input.css',
})
export class NameInput {
  name = ""

  clear(){
    this.name=""
  }
}
