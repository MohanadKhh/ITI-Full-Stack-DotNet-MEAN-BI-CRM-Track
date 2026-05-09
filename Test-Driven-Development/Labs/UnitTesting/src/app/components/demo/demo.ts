import { Component } from '@angular/core';

@Component({
  selector: 'app-demo',
  imports: [],
  templateUrl: './demo.html',
  styleUrl: './demo.css',
})
export class Demo {
  isPositive(value: number): boolean {
    return value > 0;
  }

  countCharacters(value: string): number {
    return value.length;
  }

  removeSpaces(value: string): string {
    return value.replace(/\s+/g, '');
  }
}
