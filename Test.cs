using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Test
    {
        private Action<byte[], string> _callback;


        public void M(Action<byte[], string> callback)
        {
            _callback = callback;
        }

        public void Callback(string name)
        {
            _callback.Invoke(new byte[] { 1, 2, 3, 4, 5 }, name);
        }

        public async Task<Stu> GetStu()
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"GetStuStart:{Thread.CurrentThread.ManagedThreadId}_{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}");

            });



            await Task.Run(() =>
            {
                Console.WriteLine($"GetStuEnd:{Thread.CurrentThread.ManagedThreadId}_{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}");
            });
            return new Stu();
            //return await Task.Run(Func);
        }

        public Stu Func()
        {
            Console.WriteLine($"GetStuStart:{Thread.CurrentThread.ManagedThreadId}_{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}");
            Thread.Sleep(5000);

            Console.WriteLine($"GetStuEnd:{Thread.CurrentThread.ManagedThreadId}_{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}");
            return new Stu();
        }
    }

    public class Stu
    {
        public int Age { get; set; } = 20;
    }
}
