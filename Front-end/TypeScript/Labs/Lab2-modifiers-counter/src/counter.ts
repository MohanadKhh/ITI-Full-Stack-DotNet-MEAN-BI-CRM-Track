export class Counter {
    private _counterValue: number = 0;

    increase(): void {
        this._counterValue++;
    }

    decrease(): void {
        this._counterValue--;
    }

    reset(): void {
        this._counterValue = 0;
    }

    get counterValue() {
        return this._counterValue;
    }
}