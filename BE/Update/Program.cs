using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("RUNNING....");
                var pathData = "DATA";
                if (!Directory.Exists(pathData))
                {
                    Directory.CreateDirectory(pathData);
                }
                var result = new Dictionary<string, object>();
                var directories = Directory
                    .GetDirectories(pathData)
                    .Select(x => new DirectoryInfo(x))
                    ;
                var pathUpdate = "/update/DATA";
                foreach (var dir in directories)
                {
                    var totalFile = 1;
                    var totalSize = 0L;
                    var files = Directory.GetFiles(dir.FullName, "*.*", SearchOption.AllDirectories)
                        .Select(x => new FileInfo(x))
                        .Select(x =>
                        {
                            using (var md5 = MD5.Create())
                            {
                                using (var stream = File.OpenRead(x.FullName))
                                {
                                    var pathFile = x.DirectoryName.Replace(dir.FullName, "").Replace("\\", "/");
                                    if (pathFile.StartsWith("/"))
                                    {
                                        pathFile = pathFile.Remove(0, 1);
                                    }
                                    if (x.Extension == ".zip")
                                    {
                                        using (var zip = new ZipArchive(File.OpenRead(x.FullName), ZipArchiveMode.Read))
                                        {
                                            totalFile = zip.Entries.Count;
                                        }
                                    }
                                    return new
                                    {
                                        Path = $"{pathUpdate}/{dir.Name}{x.FullName.Replace(dir.FullName, "").Replace("\\", "/")}",
                                        Name = x.Name,
                                        Size = x.Length,
                                        Hash = x.IsReadOnly ? BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToUpperInvariant() : null,
                                        Location = x.FullName.Replace(dir.FullName + "\\", "").Replace("\\", "/"),
                                        Folder = pathFile
                                    };
                                }

                            }

                        })
                        ;
                    foreach (var item in files)
                    {
                        totalSize += item.Size;
                    }
                    result[dir.Name] = new
                    {
                        TotalSize = totalSize,
                        TotalFile = totalFile,
                        Files = files
                    };
                }
                using (var w = new StreamWriter("update.json"))
                {
                    w.Write(JsonConvert.SerializeObject(result));
                }
                using (var w = new StreamWriter("Launcher.json"))
                {
                    w.Write(Hash("Launcher.exe"));
                }
                Console.WriteLine("SUCCESS");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("DONE");

        }
        private static string Hash(string filename)
        {
            if (!File.Exists(filename))
            {
                return "";
            }
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                }
            }
        }
    }
}
