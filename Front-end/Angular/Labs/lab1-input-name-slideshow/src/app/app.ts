import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NameInput } from './components/name-input/name-input';
import { Slideshow } from './components/slideshow/slideshow';

@Component({
  selector: 'app-root',
  imports: [NameInput, Slideshow],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('lab1-input-name-slideshow');
}
