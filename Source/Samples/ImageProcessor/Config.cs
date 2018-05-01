using System;
using System.Collections.Generic;
using System.Text;
using Common;
namespace ImageProcessor
{
    class Config
    {
        [ConfigKey("input")]
        public string ImageFolder { get; set; }

        [ConfigKey("output")]
        public string OutputFolder { get; set; }

        [ConfigKey("scriptFolder")]
        public string ScriptFolder { get; set; }

        [ConfigKey("module")]
        public string ModuleName { get; set; }

        [ConfigKey("class")]
        public string ClassName { get; set; }

        public Config()
        {
            ImageFolder = "input";
            OutputFolder = "output";
        }
    }
}
