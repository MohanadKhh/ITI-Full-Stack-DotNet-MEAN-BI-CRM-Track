import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Demo } from './demo';

describe('Demo', () => {
  let component: Demo;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Demo]
    })
      .compileComponents();

    const fixture: ComponentFixture<Demo> = TestBed.createComponent(Demo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should return true for positive numbers', () => {
    expect(component.isPositive(5)).toBeTruthy();
  });

  it('should return true for decimal positive numbers', () => {
    expect(component.isPositive(0.5)).toBeTruthy();
  });

  it('should return false for zero and negative numbers', () => {
    expect(component.isPositive(0)).toBeFalsy();
    expect(component.isPositive(-3)).toBeFalsy();
  });

  it('should count all characters in a string', () => {
    expect(component.countCharacters('Angular')).toBe(7);
  });

  it('should count spaces as characters', () => {
    expect(component.countCharacters('a b c')).toBe(5);
  });

  it('should return zero for an empty string', () => {
    expect(component.countCharacters('')).toBe(0);
  });

  it('should trim leading and trailing spaces', () => {
    expect(component.removeSpaces('  hello world  ')).toBe('helloworld');
  });

  it('should remove internal spaces too', () => {
    expect(component.removeSpaces('  hello   world  ')).toBe('helloworld');
  });

  it('should return an empty string for whitespace only input', () => {
    expect(component.removeSpaces('   ')).toBe('');
  });
});
