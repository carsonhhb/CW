using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;
using System.Speech.Synthesis;
using System.Timers;
using System.Threading;
using System.Data.Entity;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.Entity.Core.Common;
using System.Data.Common;
using System.Net.Mail;
using System.Text.RegularExpressions;
using NPOI.XSSF.UserModel;
using Magicodes.ExporterAndImporter.Excel;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Core.Extension;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using System.Configuration;

using Baidu.Aip.Face;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using static System.Console;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    public static class Program
    {
        private static IDictionary<string, string> _Headers = new Dictionary<string, string>();
        static Test t = new Test();

        


        static void Main()
        {

            

            Read();
        }


        struct MyStruct
        {

        }

        public static DateTime TimeStampToDate(this long thisValue)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dt = dt.AddMilliseconds(thisValue);
            dt = dt.ToLocalTime();
            return dt;
        }

        private static System.Timers.Timer aTimer;
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
        }


        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始向量</param>
        /// <param name="padding">填充模式</param>
        /// <param name="mode">加密模式</param>
        /// <returns></returns>
        public static (bool isOk, string text) AESDecrypt(this string source, string key, string iv = "", PaddingMode padding = PaddingMode.PKCS7, CipherMode mode = CipherMode.CBC)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] textBytes = Convert.FromBase64String(source);
                byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

                byte[] useKeyBytes = new byte[16];
                byte[] useIvBytes = new byte[16];

                if (keyBytes.Length > useKeyBytes.Length)
                    Array.Copy(keyBytes, useKeyBytes, useKeyBytes.Length);
                else
                    Array.Copy(keyBytes, useKeyBytes, keyBytes.Length);

                if (ivBytes.Length > useIvBytes.Length)
                    Array.Copy(ivBytes, useIvBytes, useIvBytes.Length);
                else
                    Array.Copy(ivBytes, useIvBytes, ivBytes.Length);

                Aes aes = Aes.Create();
                aes.KeySize = 256;//秘钥的大小，以位为单位,128,256等
                aes.BlockSize = 128;//支持的块大小
                aes.Padding = padding;//填充模式
                aes.Mode = mode;
                aes.Key = useKeyBytes;
                aes.IV = useIvBytes;//初始化向量，如果没有设置默认的16个0

                ICryptoTransform decryptoTransform = aes.CreateDecryptor();
                byte[] resultBytes = decryptoTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

                return (true, Encoding.UTF8.GetString(resultBytes));
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始向量</param>
        /// <param name="padding">填充模式</param>
        /// <param name="mode">加密模式</param>
        /// <returns></returns>
        public static (bool isOk, string text) AESEncrypt(this string source, string key, string iv = "", PaddingMode padding = PaddingMode.PKCS7, CipherMode mode = CipherMode.CBC, int len = 256)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] textBytes = Encoding.UTF8.GetBytes(source);
                byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

                byte[] useKeyBytes = new byte[16];
                byte[] useIvBytes = new byte[16];

                if (keyBytes.Length > useKeyBytes.Length)
                    Array.Copy(keyBytes, useKeyBytes, useKeyBytes.Length);
                else
                    Array.Copy(keyBytes, useKeyBytes, keyBytes.Length);

                if (ivBytes.Length > useIvBytes.Length)
                    Array.Copy(ivBytes, useIvBytes, useIvBytes.Length);
                else
                    Array.Copy(ivBytes, useIvBytes, ivBytes.Length);

                Aes aes = Aes.Create();
                aes.KeySize = len;//秘钥的大小，以位为单位,128,256等
                aes.BlockSize = 128;//支持的块大小
                aes.Padding = padding;//填充模式
                aes.Mode = mode;
                aes.Key = useKeyBytes;
                aes.IV = useIvBytes;//初始化向量，如果没有设置默认的16个0

                ICryptoTransform cryptoTransform = aes.CreateEncryptor();
                byte[] resultBytes = cryptoTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

                return (true, Convert.ToBase64String(resultBytes));
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }

    public static class A
    {
        public static TimeSpan DateToTimeStamp(this DateTime thisValue)
        {
            return thisValue.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        }
    }

    public class B
    {
        public X Type { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }
    }

    public enum X
    {
        A = 10,
        B = 11,
        C = 12
    }




}
