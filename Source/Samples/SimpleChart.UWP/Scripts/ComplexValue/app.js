import { TriangleSignal, SinSignal, SquareSignal } from "Waves";
export class app {
    constructor() {
        this.triangle = new TriangleSignal(0, 0.1, 5);
        this.sin = new SinSignal(0, 10);
        this.square = new SquareSignal(0.2, 0.5, 10);
    }
    next() {
        return this.triangle.next() + this.square.next() + this.sin.next() * 0.2;
    }
}
