import { DrawingApp } from "DrawingInterface";
import { ITexture, GetDrawingSurface, BlendModeEnum } from "sdk@Plugin.Drawing";


export class resize implements DrawingApp {
    Init() {
        
    }
    Draw(texture: ITexture) {
        let sourceSize=texture.GetSize();
        let targetSize={Width:sourceSize.Width/2,Height:sourceSize.Height/2};
        let surface=GetDrawingSurface(targetSize,"0.1");
        let sb=surface.CreateSpritBatch();
        sb.Begin(BlendModeEnum.Normal);
        sb.DrawImage({X:0,Y:0},targetSize,texture,1);
        sb.End();
    }
}