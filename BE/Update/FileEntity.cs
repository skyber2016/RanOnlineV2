using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileEntity
{
    public long TotalSize { get; set; }
    public IEnumerable<FileInfomaion> Files { get; set; }
}

public class FileInfomaion
{
    public string Name { get; set; }
    public string Path { get; set; }
    public long Size { get; set; }
    public string Hash { get; set; }
}
