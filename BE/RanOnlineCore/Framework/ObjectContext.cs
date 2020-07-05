using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PA.Caching;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Framework
{
    public class ObjectContext
    {
        public readonly Guid RequestId = Guid.NewGuid();
        public IDbConnection RanUser { get; set; }
        public IDbConnection RanMaster { get; set; }
        public IDbConnection RanGame { get; set; }
        private string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public ICacheManager cache
        {
            get
            {
                return MemoryCacheManager.Instance;
            }
        }
        public string EncryptPassword(string text)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().Substring(0,19);
            }
        }
        public string Encrypt(object obj)
        {
            var text = JsonConvert.SerializeObject(obj);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        public string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
        public static ObjectContext CreateContext(ControllerBase controller)
        {
            return new ObjectContext(controller);
        }

        private ControllerBase _controller;
        //private IDbInfoRepository _repo;

        private ObjectContext(ControllerBase controller)
        {
            _controller = controller;
            //this.RanUser = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            //this.RanGame = new SqlConnection(ConfigurationManager.ConnectionStrings["connectRanGame"].ConnectionString);
            //this.RanMaster = new SqlConnection(ConfigurationManager.ConnectionStrings["connectRanMaster"].ConnectionString);
            //_repo = ServiceLocator.Current.GetInstance<IDbInfoRepository>();
        }
    }
}
