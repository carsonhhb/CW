using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class Base : IDisposable
    {
        public Base()
            => Console.WriteLine($"An instance of {GetType().Name} is created");
        public void Dispose()
        => Console.WriteLine($"An instance of {GetType().Name} is disposed");
    }

    public interface IFoo { }

    public interface IBar { }

    public interface IBaz { }

    public interface IFileManageer
    {
        void ShowStructure(Action<int, string> render);
        Task<string> ReadContentAsync(string path);
    }

    public interface IFooBar<T, T1> { }

    public class Foo : Base, IFoo { }

    public class Foo1 : Base, IFoo { }

    public class Bar : Base, IBar { }

    public class Baz : Base, IBaz { }

    public class FooBar<T, T1> : IFooBar<T, T1>
    {
        public IFoo Foo { get; }
        public IBar Bar { get; }

        public FooBar(IFoo foo, IBar bar)
        {
            Foo = foo;
            Bar = bar;
        }
    }

    public class FileManageer : IFileManageer
    {
        private readonly IFileProvider _fileProvider;

        public FileManageer(IFileProvider fileProvider) => _fileProvider = fileProvider;

        public async Task<string> ReadContentAsync(string path)
        {
            ChangeToken.OnChange(()=>_fileProvider.Watch(""), ()=> { });
            byte[] buffer;
            using (var stream = _fileProvider.GetFileInfo(path).CreateReadStream())
            {
                buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, buffer.Length);
            }
            return Encoding.Default.GetString(buffer);

            
        }

        public void ShowStructure(Action<int, string> render)
        {
            int indent = -1;
            Render("");

            void Render(string subPath)
            {
                indent++;
                var directoryContents = _fileProvider.GetDirectoryContents(subPath);
                foreach (var fileInfo in directoryContents)
                {
                    render(indent, fileInfo.Name);
                    if (fileInfo.IsDirectory)
                    {
                        Render($@"{subPath}\{fileInfo.Name}".TrimStart('\\'));
                    }
                }
            }
        }
    }
}
