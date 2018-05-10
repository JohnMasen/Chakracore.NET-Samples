export class SinSignal {
    /**
     * output=sin(a+bx), x increas 1 radian each call
     */
    constructor(a = 0, b = 1) {
        this.index = 0;
        this.step = Math.PI / 180;
        this.a = a;
        this.b = b;
    }
    next() {
        let result = (Math.sin(this.a + this.b * this.index) * 0.5 + 0.5);
        this.index += this.step;
        this.index = this.index % (Math.PI * 2);
        return result;
    }
}
export class SquareSignal {
    /**
     *
     */
    constructor(min, max, step) {
        this.index = 0;
        this.isHigh = true;
        this.min = min;
        this.max = max;
        this.step = step;
    }
    next() {
        if (this.index >= this.step) {
            this.isHigh = !this.isHigh;
            this.index = 0;
        }
        else {
            this.index++;
        }
        return this.isHigh ? this.max : this.min;
    }
}
export class TriangleSignal {
    /**
     *
     */
    constructor(min = 0, max = 1, step = 10) {
        this.isRaise = true;
        this.delta = (max - min) / step;
        this.min = min;
        this.max = max;
        this.value = min;
    }
    next() {
        let result = this.value;
        if (this.isRaise) {
            if (this.value + this.delta >= this.max) {
                this.value = this.max;
                this.isRaise = false;
            }
            else {
                this.value += this.delta;
            }
        }
        else {
            if (this.value - this.delta <= this.min) {
                this.value = this.min;
                this.isRaise = true;
            }
            else {
                this.value -= this.delta;
            }
        }
        return this.value;
    }
}
