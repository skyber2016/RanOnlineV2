using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PA.Caching;
using RanOnlineCore.Framework;
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
        private GlobalConfig GlobalConfig { get; set; }
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
        public static ObjectContext CreateContext(BaseController controller, GlobalConfig config)
        {
            return new ObjectContext(controller, config);
        }

        private BaseController _controller;
        //private IDbInfoRepository _repo;

        private ObjectContext(BaseController controller, GlobalConfig config)
        {
            this.GlobalConfig = config;
            _controller = controller;
            //this.RanUser = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            //this.RanGame = new SqlConnection(ConfigurationManager.ConnectionStrings["connectRanGame"].ConnectionString);
            this.RanMaster = new SqlConnection(this.GlobalConfig.RanMaster);
            //_repo = ServiceLocator.Current.GetInstance<IDbInfoRepository>();
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        public string UrlFriend(string input)
        {
            var array = new string[] {  "(", ")", "/", "\\", "[", "]" };
            input =  this.RemoveUnicode(input.ToLower());
            foreach (var item in array)
            {
                input = input.Replace(item, "");
            }
            return input.Replace(" ","-");
        }
    }
}
