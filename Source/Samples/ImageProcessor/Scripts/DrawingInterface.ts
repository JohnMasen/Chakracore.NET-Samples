import { ITexture } from "sdk@Plugin.Drawing";

export 
    interface DrawingApp {
    Init();
    Draw(texture:ITexture);
}
