import { TriangleSignal } from "Waves";
export class app {
    constructor() {
        this.ref = new TriangleSignal(0, 1, 10);
    }
    next() {
        return this.ref.next();
    }
}
