using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace valentin_WebApiOef
{
    public class Path
    {
        public string PathName { get; set; }
        public Path()
        {
            string PathName = GetFilePath();
        }
        public string GetFilePath()
        {
            string path = Directory.GetCurrentDirectory();
            path = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"txt\"));
            return path;
        }
    }
}
