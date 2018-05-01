using ChakraCore.NET;
using ChakraCore.NET.Hosting;
using ChakraCore.NET.Plugin.Drawing;
using ChakraCore.NET.Plugin.Drawing.ImageSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessor
{
    class DrawingApp : IJSValueWrapper
    {
        private JSValue value;
        public void SetValue(JSValue value)
        {
            this.value = value;
        }

        public void Init()
        {
            value.CallMethod("Init");
        }

        public void Draw(ImageSharpTexture texture)
        {
            value.CallMethod<ImageSharpTexture>("Draw", texture);
        }
    }
}
