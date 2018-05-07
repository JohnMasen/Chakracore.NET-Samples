export class SinSignal {
    /**
     * output=sin(a+bx), x increas 1 radian each call
     */
    constructor(a, b) {
        this.index = 0;
        this.step = Math.PI / 180;
        this.a = a;
        this.b = b;
    }
    next() {
        this.index += this.step;
        this.index = this.index % (Math.PI * 2);
        return (Math.sin(this.a + this.b * this.index));
    }
}
