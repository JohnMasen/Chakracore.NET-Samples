using ChakraCore.NET.Hosting;
using ChakraCore.NET.Plugin.Drawing.ImageSharp;
using SixLabors.ImageSharp;
using System;
using System.IO;
using static Common.ConfigParser;
namespace ImageProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = Parse<Config>(args);
            JavaScriptHostingConfig hostConfig = new JavaScriptHostingConfig();
            hostConfig.AddModuleFolder(config.ScriptFolder);

            ImageSharpDrawingInstaller engine = new ImageSharpDrawingInstaller();
            engine.SetTextureRoot(config.ScriptFolder);
            engine.SetFontRoot(config.ScriptFolder);

            hostConfig.AddPlugin(engine);
            var app = JavaScriptHosting.Default.GetModuleClass<DrawingApp>(config.ModuleName, config.ClassName, hostConfig);
            app.Init();
            var files= Directory.EnumerateFiles(config.ImageFolder, "*.jpg");
            DirectoryInfo directory = new DirectoryInfo(config.OutputFolder);
            foreach (var file in files)
            {
                Console.Write($"Processing "+file+"...");
                var img = Image.Load<Rgba32>(file);
                app.Draw(new ImageSharpTexture(img));
                string outputFile = Path.Combine(config.OutputFolder,Path.GetFileName(file));
                using (FileStream fs=new FileStream(outputFile,FileMode.Create))
                {
                    engine.LastDrawingSurface.Image.SaveAsJpeg(fs);
                }
                Console.WriteLine("done");
            }
            


            Console.WriteLine("Process complete, Press enter to exit");
            Console.Read();
        }

        
    }
}
