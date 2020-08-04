using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            var totalSize = 0L;
            foreach (var dir in directories)
            {
                var files = Directory.GetFiles(dir.FullName, "*.*", SearchOption.AllDirectories)
                    .Select(x => new FileInfo(x))
                    .Select(x=>
                    {
                        using (var md5 = MD5.Create())
                        {
                            using(var stream = File.OpenRead(x.FullName))
                            {
                                Console.WriteLine(x.Name);
                                totalSize += x.Length;
                                return new
                                {
                                    Path = x.FullName.Replace(dir.FullName, "").Replace("\\", "/"),
                                    Name = x.Name,
                                    Size = x.Length,
                                    Hash = md5.ComputeHash(stream)
                                };
                            }
                            
                        }
                        
                    })
                    ;
                result[dir.Name] = files;
            }
            result["TotalSize"] = totalSize;
            using(var w = new StreamWriter("update.json"))
            {
                w.Write(JsonConvert.SerializeObject(result));
            }
        }
    }
}
