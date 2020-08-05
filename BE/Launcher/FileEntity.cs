using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    public class FileEntity
    {
        public FileEntity()
        {
            this.Files = new List<FileInfomaion>();
        }
        public long TotalSize { get; set; }
        public List<FileInfomaion> Files { get; set; }
    }

    public class FileInfomaion
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Hash { get; set; }
        public string Location { get; set; }
        public string Folder { get; set; }
    }
}
