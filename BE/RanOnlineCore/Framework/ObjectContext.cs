using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PA.Caching;
using RanOnlineCore.Framework;
using RanOnlineCore.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ZaloDotNetSDK;

namespace Framework
{
    public class ObjectContext
    {
        public GlobalConfig GlobalConfig { get; set; }
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
        public ZaloClient ZaloClient { get; set; }
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
        public T Decrypt<T>(string cipher)
        {
            string json = "";
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
                        json =  UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static ObjectContext CreateContext(BaseController controller, GlobalConfig config)
        {
            
            return new ObjectContext(controller, config);
        }
        private GlobalConfig MappingConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            IConfigurationRoot configuration = builder.Build();
            var localConfig = configuration.GetSection("GlobalConfig").GetChildren();
            return new GlobalConfig
            {
                ZaloAccessToken = localConfig.FirstOrDefault(x => x.Key == nameof(GlobalConfig.ZaloAccessToken))?.Value,
                RanMaster = localConfig.FirstOrDefault(x => x.Key == nameof(GlobalConfig.RanMaster))?.Value,
                RanUser = localConfig.FirstOrDefault(x => x.Key == nameof(GlobalConfig.RanUser))?.Value,
                RabbitHost = localConfig.FirstOrDefault(x => x.Key == nameof(GlobalConfig.RabbitHost))?.Value,
                RabbitPassword = localConfig.FirstOrDefault(x => x.Key == nameof(GlobalConfig.RabbitPassword))?.Value,
                RabbitPort = int.Parse(localConfig.FirstOrDefault(x => x.Key == nameof(GlobalConfig.RabbitPort))?.Value),
                RabbitUsername = localConfig.FirstOrDefault(x => x.Key == nameof(GlobalConfig.RabbitUsername))?.Value,
            };
        }
        private BaseController _controller;

        private ObjectContext(BaseController controller, GlobalConfig config)
        {
            if (config == null)
            {
                this.GlobalConfig = MappingConfig();
            }
            else
            {
                this.GlobalConfig = config;
            }
            this.ZaloClient = new ZaloClient(this.GlobalConfig.ZaloAccessToken);
            _controller = controller;
            this.RanUser = new SqlConnection(this.GlobalConfig.RanUser);
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


        public string MD5Encode(string input, int? maxLength = null)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                if(maxLength == null)
                {
                    return sb.ToString();
                }
                else
                {
                    return sb.ToString().Substring(0, maxLength.Value);
                }
            }
        }
        private const string initVector = "tu89geji340t89u2";

        private const int keysize = 256;
        public  string Encrypt(string Text, string Key)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(Text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] Encrypted = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(Encrypted);
        }

        public string Decrypt(string EncryptedText, string Key)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] DeEncryptedText = Convert.FromBase64String(EncryptedText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(DeEncryptedText);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[DeEncryptedText.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        public RoleEnum GetRole(string role)
        {
            if(role == RoleEnum.ADMIN.ToString())
            {
                return RoleEnum.ADMIN;
            }
            return RoleEnum.USER;
        }
        public DateTime CreateExpired()
        {
            return DateTime.Now.AddDays(1);
        }
    }
}
