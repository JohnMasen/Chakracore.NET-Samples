import { SinSignal } from "Waves";

export class app {
    ref=new SinSignal(0,10);
    next(){
        return this.ref.next();
    }
}