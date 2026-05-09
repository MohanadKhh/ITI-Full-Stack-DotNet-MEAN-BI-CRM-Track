import { Component } from '@angular/core';

@Component({
  selector: 'app-demo2',
  imports: [],
  templateUrl: './demo2.html',
  styleUrl: './demo2.css',
})
export class Demo2 {
  reverseString(value: string): string {
    var trimmedValue = value.replace(/\s+/g, '');
    var trimmedValueArr = trimmedValue.split('')
    return trimmedValueArr.reverse().join('');
  }

  maxNumber(arr: number[]): number | null {
    if (arr.length === 0) {
      return null;
    }
    else {
      return Math.max(...arr);
    }
  }

  removeDuplicates(arr: any[]): any[] {
    var uniqueArr = [...new Set(arr)];
    return uniqueArr;
  }

  validatePassword(password: string): boolean {
    const hasUpperCase = /[A-Z]/.test(password);
    const hasLowerCase = /[a-z]/.test(password);
    const hasDigits = /\d/.test(password);
    const isValidLength = password.length >= 8;
    const noSpaces = !/\s/.test(password);
    return hasUpperCase && hasLowerCase && hasDigits && isValidLength && noSpaces;
  }
}
