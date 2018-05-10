import { TriangleSignal } from "Waves";

export class app{
ref=new TriangleSignal(0,1,10);
    next():number{
        return this.ref.next();
    }
}