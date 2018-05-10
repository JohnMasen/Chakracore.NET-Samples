export interface SignalGenerator
{
    next():number;

}

export class SinSignal implements SignalGenerator {
    index=0;
    step=Math.PI/180;
    a!:number;
    b!:number;
    /**
     * output=sin(a+bx), x increas 1 radian each call
     */
    constructor(a:number=0,b:number=1) {
        this.a=a;
        this.b=b;
        
    }
    next(): number {
        
        let result= (Math.sin(this.a+this.b*this.index)*0.5+0.5);
        this.index+=this.step;
        this.index=this.index % (Math.PI*2);
        return result;
    }
}

export class SquareSignal implements SignalGenerator {
    index=0;
    min!:number;
    max!:number;
    step!:number;
    isHigh=true;
    /**
     *
     */
    constructor(min:number,max:number,step:number) {
            this.min=min;
            this.max=max;
            this.step=step;
    }
    next(): number {
        if (this.index>=this.step) {
            this.isHigh=!this.isHigh;
            this.index=0;
        }
        else{
            this.index++;
        }
        return this.isHigh?this.max:this.min;
    }
}

export class TriangleSignal implements SignalGenerator{
    value!:number;
    min!:number;
    max!:number;
    delta!:number;
    isRaise=true;
    /**
     *
     */
    constructor(min:number=0,max:number=1,step:number=10) {
        this.delta=(max-min)/step;
        this.min=min;
        this.max=max;
        this.value=min;
    }
    next():number{
        let result=this.value;
        if (this.isRaise) {
            if (this.value+this.delta>=this.max) {
                this.value=this.max;
                this.isRaise=false;
            }
            else{
                this.value+=this.delta;
            }
        }
        else{
            if (this.value-this.delta<=this.min) {
                this.value=this.min;
                this.isRaise=true;
            }
            else{
                this.value-=this.delta;
            }
        }
        return this.value;
    }
}