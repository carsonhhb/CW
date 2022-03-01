//long begin = 1637560800000;
//long end = 1637564400000;
//long scan = 1637561867000;
//var r = (end - (begin < scan ? scan : begin)) / 1000;
////var s = "aIudU3vwy43FHZNcKU5NijPcmNPINOF8/tRs5m3igEYz3JjTyDThfP7UbOZt4oBGX1IJi9DIae78Mzo5i618VLlu6elBVvdJq3QbGtNX3tMptqPtKFt9Lt2DYlAlOTPEfG9PVtqa0BXXeEfCN/wbr7KZ8KjdojCwSV5rKQopxFfM2h32dfrvlDju0lkR9HVjPhbCAquUlspMkAAP6u2Mj72nclD0OJSj/T+v1rI30HPlPu6nXqXJxpWBDHKmVdri";

////Console.WriteLine(s.Length);

////var cipherText = @"89h9crRc9D8g8/TpXTPrLX8Eg0GTUxcOYVqx8zDuanBk/7CNFPeEErmZXnF4gD3iiael3o/C15VNYCIfBzk0vcDeBLCDF5cE6HbMw/TDlTbcRIWhVmjeEmGKELwlswedVduTquR34NAReXThFuz1uOiuXuEoMO7MqUYdUnIaBldkhi9u1x6svYEXtazUt7Aj9Lvr0YNk5e7KXzFgk0Js6BWDOWfJOXZ3Cs4B5y8nZGAZKvMGHhjb2ilAdfrHVJm0nmmkF+29poWot/BMpKFN6URVUYAZTtKjIALQZtIuojo5sMgdJGakDfNcJxSHiUHnIT89/3xkcr8AGovo3nNjPGqFBpMd48R0hFr2c0JclIVi4AAkEcqfuRSmS5CvMQjJI6CthmLpqgzHHPjS3vN7Ng==";
////Console.WriteLine(cipherText.Length);
//////Encoding.UTF8.GetBytes();
//var key = "UFLYT&&2021@#!_$"; //Encoding.UTF8.GetBytes("UFLYT&&2021@#!_$");
//var iv = Encoding.UTF8.GetString(new byte[] { 0x30, 0x31, 0x30, 0x32, 0x30, 0x33, 0x30, 0x34, 0x30, 0x35, 0x30, 0x36, 0x30, 0x37, 0x30, 0x38 });


////var json = cipherText.AESDecrypt(key, iv);
////var json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "a.json"));
////var EN = json.AESEncrypt(key, iv);

////DateTime.TryParse("2021-09-01 11:00:00", out DateTime begin);
////DateTime.TryParse("2021-09-01 12:00:00", out DateTime end);
////DateTime.TryParse("2021-09-29 11:55:00", out DateTime expair);
////Console.WriteLine((end-begin).TotalSeconds);

////Console.WriteLine(DateTime.Now);
////Console.WriteLine("1.23".Split("&")[0]);
////Console.WriteLine(DateTime.Now > expair);
////_ = DateTime.TryParse("2021-09-01 11:00:00", out DateTime dt);
////Console.WriteLine(dt.ToShortTimeString());
//// var str = File.ReadAllText(@"C:\Users\Carson\Desktop\RepairQrData.json");
////var str1 = File.ReadAllText(@"C:\Users\Carson\Desktop\RepairQrExpireData.json");
//var str2 = File.ReadAllText(@"C:\Users\Carson\Desktop\FlyQrData.json");
//// // // var str3 = File.ReadAllText(@"C:\Users\Carson\Desktop\JSON.txt");
//// // // var data = str.AESEncrypt(key, iv);
////var d2 = str1.AESEncrypt(key, iv);
//var d3 = str2.AESEncrypt(key, iv);
//var plainText = AESDecrypt("Y8MRfI8jzmD86ukq1GAS4hTyoP+Ky9TPSUsxQIvLsM61/R4ks2hq83i6M69d0IZOsjcRL2OS1woKAugLo7wHo2ngBKsrwT6CPWwF5msJWi6HyqufvenGclRO9c4S6zqTL+eEm1qEwL6sIqha3XWtPSIug5lMvj9ZY2+kvYVBptRkn4bgw+eHcFRtQXOEgAhzfthI3Wch/i8WYB29q9Cl+dg3eB8+A05fu41MfxiX39zI0jBAKAaYm6WT0UuNNmVpdTBpnKHFRsVKTncDVtlm1bWWyOI1pF/ka8BkrHboVNA=", key, iv);
//// System.Console.WriteLine(DateTime.Now.ToShortTimeString());
//// _ = DateTime.TryParse("20:00", out DateTime dt);
//// var now = DateTime.Now;
//// System.Console.WriteLine(now);
//// System.Console.WriteLine(dt);
//// System.Console.WriteLine(now > dt);
//// System.Console.WriteLine("");
////var d4 = str3.AESEncrypt(key, iv, len: 128);
////Console.WriteLine(d3.text.Length);
////Console.WriteLine(d4.text.Length);
////Console.WriteLine(str3.Length);
////Console.WriteLine(d4.text.Length);

////Test.Start();

////Console.WriteLine(Regex.Replace("", "(\\d{3})\\d{4}(\\d{4})", "$1****$2"));

//// Test t1 = new Test();
//// Test t2 = new Test();
//// t1.M((buffer, msg) =>
//// {
////     Console.WriteLine($"t1-{msg}");
//// });

//// t2.M((b, m) =>
//// {
////     Console.WriteLine($"t2-{m}");
//// });

//// var task = new Task(() =>
//// {
////     for (int i = 0; i < 100; i++)
////     {
////         t1.Callback("task1");
////     }
//// });

//// var task2 = new Task(() =>
//// {
////     for (int i = 0; i < 100; i++)
////     {
////         t2.Callback("task2");
////     }
//// });

//// task.Start();
//// task2.Start();
//// System.Console.WriteLine("end");
////SetTimer();
//var max = new Random().Next(100, 1000);
//System.Console.WriteLine($"max:{max}");
//for (int i = 0; i < max; i++)
//{
//    System.Console.WriteLine($"i:{i}***ts:{DateTime.Now.DateToTimeStamp()}");
//    Thread.Sleep(1000 * 5);
//}
//System.Console.WriteLine("end");

//            var str = @"|00FE0004000130
//|00FE0004000230
//|00FE000000010001000130
//|00FE000000010002000130
//|00FE000000010003000130
//|00FE000000010004000130
//|00FE000000020001000130
//|00FE000000020002000130
//|00FE000000020003000130
//|00FE000000020004000130
//|00FE000000010001000230
//|00FE000000010002000230
//|00FE000000010003000230
//|00FE000000010004000230
//|00FE000000020001000230
//|00FE000000020002000230
//|00FE000000020003000230
//|00FE000000020004000230
//|00FE0001000130
//|00FE0001000230
//|00FE0001000330
//|00FE0001000130
//|00FE000210000520036030
//|00FE000301000020030030
//";

//            var listStr = str.Split("|", StringSplitOptions.RemoveEmptyEntries);

//var sb = new StringBuilder();
//foreach (var item in listStr)
//{
//    sb.AppendLine($"字符串：{item}-对应byte[]：");
//    var bytes = Encoding.UTF8.GetBytes(item);
//    foreach (var b in bytes)
//    {
//        sb.Append(b);
//    }
//}

//            var result = sb.ToString();
//CancellationToken ck=new CancellationToken();


//string strResult = "";
//byte[] data = Encoding.ASCII.GetBytes("00FE000100010001");

//for (int i = 0; i < data.Length; i++)
//{
//    strResult += data[i].ToString("X2");
//}
//var x = strResult;

// var stu = await t.GetStu();
// WriteLine($"主线程:Age值[{stu.Age}]_{Thread.CurrentThread.ManagedThreadId}_{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}");
// WriteLine("end");