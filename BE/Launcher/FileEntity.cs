using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    public class FileEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Hash { get; set; }
    }
}
