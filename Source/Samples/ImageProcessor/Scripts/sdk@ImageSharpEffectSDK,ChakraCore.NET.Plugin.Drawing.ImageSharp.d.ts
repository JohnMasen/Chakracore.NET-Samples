import { IEffect } from 'sdk@Plugin.Drawing';
export declare function LoadImageSharpEffect<T extends IEffect>(c: {
    new (): T;
}): T;
export declare class ImageSharpEffectBase<T extends object> implements IEffect {
    Name: string;
    constructor(name: string);
    Config: T;
}
export interface BlurEffectConfig {
    sigma: number;
}
export declare class BlurEffect extends ImageSharpEffectBase<BlurEffectConfig> {
    constructor();
}
