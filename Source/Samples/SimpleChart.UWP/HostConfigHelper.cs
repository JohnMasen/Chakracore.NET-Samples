using ChakraCore.NET.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace SimpleChart.UWP
{
    /// <summary>
    /// temporary solution, will be removed after chakracore.net.hosting supports UWP SDK 17134
    /// </summary>
    static class HostConfigHelper
    {
        public static JavaScriptHostingConfig AddModuleFolder(this JavaScriptHostingConfig config, StorageFolder folder)
        {
            config.ModuleFileLoaders.Add((name) =>
            {
                var t = loadModuleFromFolderAsync(folder, name);
                t.Wait();
                return t.Result;
            });
            return config;
        }
        private static async Task<string> loadModuleFromFolderAsync(StorageFolder folder, string name)
        {
            return
                await loadModuleFromRootAsync(folder, null, $"{name}.js")
                ?? await loadModuleFromRootAsync(folder, name, $"{name}.js")
                ?? await loadModuleFromRootAsync(folder, name, "index.js");
        }

        private static async Task<string> loadModuleFromRootAsync(StorageFolder folder, string folderName, string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(folderName))
                {
                    folder = await folder.GetFolderAsync(folderName);
                }
                var file = await folder.GetFileAsync(fileName);
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
