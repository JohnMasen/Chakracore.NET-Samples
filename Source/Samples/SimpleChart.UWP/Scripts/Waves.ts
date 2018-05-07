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
    constructor(a:number,b:number) {
        this.a=a;
        this.b=b;
        
    }
    next(): number {
        this.index+=this.step;
        this.index=this.index % (Math.PI*2);
        return (Math.sin(this.a+this.b*this.index));
    }
}