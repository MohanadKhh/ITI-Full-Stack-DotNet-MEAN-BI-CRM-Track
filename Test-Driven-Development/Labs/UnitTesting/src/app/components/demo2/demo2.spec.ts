import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Demo2 } from './demo2';

describe('Demo2', () => {
  let component: Demo2;
  let fixture: ComponentFixture<Demo2>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Demo2]
    })
      .compileComponents();

    fixture = TestBed.createComponent(Demo2);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });


  /****************************************************************************** */
  // reverseString test cases
  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should remove internal spaces before reversing', () => {
    expect(component.reverseString('hello world')).toBe('dlrowolleh');
  });

  it('should remove external spaces before reversing', () => {
    expect(component.reverseString(' hello ')).toBe('olleh');
  });

  it('should remove external and internal spaces before reversing', () => {
    expect(component.reverseString(' hello world ')).toBe('dlrowolleh');
  });

  it('should return an empty string for whitespace only input', () => {
    expect(component.reverseString('   ')).toBe('');
  });

  // Additional reverseString test cases
  it('should handle single character', () => {
    expect(component.reverseString('a')).toBe('a');
  });

  it('should handle numbers in string', () => {
    expect(component.reverseString('123 456')).toBe('654321');
  });

  it('should handle special characters and spaces', () => {
    expect(component.reverseString('hello! world@')).toBe('@dlrow!olleh');
  });

  it('should handle empty string', () => {
    expect(component.reverseString('')).toBe('');
  });

  /****************************************************************************** */
  // maxNumber test cases
  it('should return max numbers from an array', () => {
    expect(component.maxNumber([1, 2, 3, 4, 5])).toBe(5);
  });

  it('should return null for an empty array', () => {
    expect(component.maxNumber([])).toBeNull();
  });

  it('should return max numbers from an array with negative numbers', () => {
    expect(component.maxNumber([-1, -2, -3, -4, -5])).toBe(-1);
  });

  it('should return max numbers from an array with decimal positive and negative numbers', () => {
    expect(component.maxNumber([1.5, -2.3, 3.7, -4.1, -5.9, 0])).toBe(3.7);
  });

  // Additional maxNumber test cases
  it('should handle single element array', () => {
    expect(component.maxNumber([42])).toBe(42);
  });

  it('should handle duplicates of max value', () => {
    expect(component.maxNumber([5, 5, 3, 1])).toBe(5);
  });

  it('should handle zero in array', () => {
    expect(component.maxNumber([0, -1, -5])).toBe(0);
  });

  it('should handle large numbers', () => {
    expect(component.maxNumber([1000000, 999999, 1000001])).toBe(1000001);
  });

  /****************************************************************************** */
  // removeDuplicates test cases
  it('should return the array with duplicates removed', () => {
    expect(component.removeDuplicates([1, 2, 3, 3, 4, 4, 5])).toEqual([1, 2, 3, 4, 5]);
  });

  it('should return the empty array with empty array', () => {
    expect(component.removeDuplicates([])).toEqual([]);
  });

  it('should return the correct array with array with one value duplicated', () => {
    expect(component.removeDuplicates([1, 1, 1, 1])).toEqual([1]);
  });

  // Additional removeDuplicates test cases
  it('should handle string duplicates', () => {
    expect(component.removeDuplicates(['a', 'b', 'a', 'c', 'b'])).toEqual(['a', 'b', 'c']);
  });

  it('should handle mixed type duplicates', () => {
    expect(component.removeDuplicates([1, '1', 2, '2', 1, '1'])).toEqual([1, '1', 2, '2']);
  });

  it('should handle array with no duplicates', () => {
    expect(component.removeDuplicates([1, 2, 3, 4])).toEqual([1, 2, 3, 4]);
  });

  it('should handle null and undefined', () => {
    expect(component.removeDuplicates([1, null, 1, undefined, null])).toEqual([1, null, undefined]);
  });

  /****************************************************************************** */
  //password Validation Edge Cases
  it('should return true for a valid password', () => {
    expect(component.validatePassword('Password123')).toBe(true);
  });

  it('should return false for password without uppercase letter', () => {
    expect(component.validatePassword('password123')).toBe(false);
  });

  it('should return false for password without lowercase letter', () => {
    expect(component.validatePassword('PASSWORD123')).toBe(false);
  });

  it('should return false for password without numeric character', () => {
    expect(component.validatePassword('Passworddd')).toBe(false);
  });

  it('should return false for password less than 8 characters', () => {
    expect(component.validatePassword('Pass123')).toBe(false);
  });

  // Additional validatePassword test cases
  it('should return true for exactly 8 characters with uppercase, lowercase, and number', () => {
    expect(component.validatePassword('Abcdef12')).toBe(true);
  });

  it('should return true for password with more than 8 characters', () => {
    expect(component.validatePassword('VeryLongPassword123')).toBe(true);
  });

  it('should return false for password with only uppercase and numbers', () => {
    expect(component.validatePassword('PASSWORD1')).toBe(false);
  });

  it('should return false for password with spaces', () => {
    expect(component.validatePassword('Pass Word1')).toBe(false);
  });

  it('should return false for password with special characters but missing requirements', () => {
    expect(component.validatePassword('pass@word!')).toBe(false);
  });

  it('should return true for password with special characters if it meets requirements', () => {
    expect(component.validatePassword('Pass@word1')).toBe(true);
  });

});
