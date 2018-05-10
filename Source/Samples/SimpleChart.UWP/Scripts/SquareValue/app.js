import { SquareSignal } from "Waves";
export class app {
    constructor() {
        this.ref = new SquareSignal(0, 1, 10);
    }
    next() {
        return this.ref.next();
    }
}
