﻿using Newtonsoft.Json;
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
            var pathUpdate = "/update/DATA";
            foreach (var dir in directories)
            {
                var totalSize = 0L;
                var files = Directory.GetFiles(dir.FullName, "*.*", SearchOption.AllDirectories)
                    .Select(x => new FileInfo(x))
                    .Select(x=>
                    {
                        using (var md5 = MD5.Create())
                        {
                            using(var stream = File.OpenRead(x.FullName))
                            {
                                Console.WriteLine(x.Name);
                                return new
                                {
                                    Path = $"{pathUpdate}/{dir.Name}{x.FullName.Replace(dir.FullName, "").Replace("\\", "/")}",
                                    Name = x.Name,
                                    Size = x.Length,
                                    Hash = md5.ComputeHash(stream),
                                    Location = x.FullName.Replace(dir.FullName + "\\", "").Replace("\\", "/"),
                                    Folder = x.FullName.Replace(dir.FullName + "\\", "").Replace("\\", "/").Replace("/" +x.Name,"")
                                };
                            }
                            
                        }
                        
                    })
                    ;
                foreach (var item in files)
                {
                    totalSize += item.Size;
                }
                result[dir.Name] = new {
                    TotalSize = totalSize,
                    Files = files
                };
            }
            using(var w = new StreamWriter("update.json"))
            {
                w.Write(JsonConvert.SerializeObject(result));
            }
        }
    }
}
