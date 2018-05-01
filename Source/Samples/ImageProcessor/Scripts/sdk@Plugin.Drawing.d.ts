export interface Point {
    X: number;
    Y: number;
}
export interface Size {
    Width: number;
    Height: number;
}
export interface Rectangle extends Point, Size {
}
export interface ISpritBatch {
    Begin(blend: number, effect: INativeEffect): void;
    End(): void;
    DrawText(position: Point, text: string, font: Font, color: string, penWidth: number): void;
    DrawLines(points: Array<Point>, color: string, penWidth: number): void;
    DrawEclipse(position: Point, region: Size, color: string, penWidth: number, isFill: boolean): void;
    DrawImage(position: Point, size: Size, texture: ITexture, opacity: number): void;
    DrawRectangle(rect: Rectangle, color: string, penWidth: number, isFill: boolean): void;
    DrawTriangle(a: Point, b: Point, c: Point, color: string, penWidth: number, isFill: boolean): void;
    Fill(color: string, region: Rectangle): void;
    Translate(value: Point): void;
    Scale(value: Point): void;
    Rotate(angel: number): void;
    PushMatrix(): number;
    PopMatrix(): number;
    ResetMatrix(): void;
}
export interface ITexture {
    GetSize(): Size;
}
export interface IDrawingSurface {
    CreateSpritBatch(): ISpritBatch;
    GetCurrentProfile(): string;
    SaveToTexture(): ITexture;
}
export interface Font {
    Name: string;
    Size: number;
}
export declare enum BlendModeEnum {
    Normal = 0,
    Multiply = 1,
    Add = 2,
    Substract = 3,
    Screen = 4,
    Darken = 5,
    Lighten = 6,
    Overlay = 7,
    HardLight = 8,
    Src = 9,
    Atop = 10,
    Over = 11,
    In = 12,
    Out = 13,
    Dest = 14,
    DestAtop = 15,
    DestOver = 16,
    DestIn = 17,
    DestOut = 18,
    Clear = 19,
    Xor = 20,
}
export declare function GetDrawingSurface(size: Size, expetectProfileName: string): DrawingSurface;
export declare function LoadTexture(name: string): ITexture;
export declare function IsProfileSupported(profileName: string): boolean;
export declare function LoadFont(filename: string): Font;
export declare function MeasureTextBound(text: string, font: Font): Rectangle;
export declare function LoadEffect(name: string): IEffect;
export declare class Color {
    readonly value: string;
    constructor(hex: string);
}
export interface IEffect {
    Name: string;
    Config: object;
}
export interface INativeEffect {
    Name: string;
    ConfigJson: string;
}
export declare class SpritBatch {
    private reference;
    constructor(source: ISpritBatch);
    Begin(blend: BlendModeEnum, effect?: IEffect): void;
    End(): void;
    DrawText(position: Point, text: string, font: Font, color: Color, penWidth?: number): void;
    DrawLine(points: Array<Point>, color: Color, penWidth?: number): void;
    DrawRectangle(rect: Rectangle, color: Color, penWidth?: number, isFill?: boolean): void;
    DrawTriangle(a: Point, b: Point, c: Point, color: Color, penWidth?: number, isFill?: boolean): void;
    DrawEclipse(position: Point, size: Size, color: Color, penWidth?: number, isFill?: boolean): void;
    DrawImage(position: Point, size: Size, texture: ITexture, opacity: number): void;
    Fill(color: Color, region: Rectangle): void;
    Translate(value: Point): void;
    Scale(value: Point): void;
    Rotate(angel: number): void;
    PushMatrix(): number;
    PopMatrix(): number;
    ResetMatrix(): void;
}
export declare class DrawingSurface {
    private reference;
    constructor(source: IDrawingSurface);
    CreateSpritBatch(): SpritBatch;
    GetCurrentProfile(): string;
}
