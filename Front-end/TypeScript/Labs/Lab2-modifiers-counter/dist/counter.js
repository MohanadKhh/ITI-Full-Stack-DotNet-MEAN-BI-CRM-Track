export class Counter {
    constructor() {
        this._counterValue = 0;
    }
    increase() {
        this._counterValue++;
    }
    decrease() {
        this._counterValue--;
    }
    reset() {
        this._counterValue = 0;
    }
    get counterValue() {
        return this._counterValue;
    }
}
