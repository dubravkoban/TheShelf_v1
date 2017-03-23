using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShelf.Containers;

namespace TheShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            //HtmlTemplate template = new HtmlTemplate();

            char[] cmrklja = { '¤' };
            byte[] bytes = Encoding.ASCII.GetBytes(cmrklja);

            Console.WriteLine(Convert.ToInt32(bytes[0]));
            Console.ReadKey();

            //var lines = new List<string>
            //{
            //    "first",
            //    "čmrklja",
            //    "third"
            //};

            //byte[] bytes = Encoding.ASCII.GetBytes(lines[0] + lines[1] + lines[2]);
            //MemoryStream stream1 = new MemoryStream(bytes);
            //using (FileStream fileStream = File.Create(@"C:\Temp\Tempy.txt"))
            //{
            //    stream1.Seek(0, SeekOrigin.Begin);
            //    stream1.WriteTo(fileStream);
            //}

            //using (var file = new FileStream(@"C:\Temp\test.txt", FileMode.OpenOrCreate))
            //using (StreamWriter stream = new StreamWriter(file))
            //{
            //    stream.WriteLine("bljeeeeeeeeee1");
            //    stream.WriteLine("bljeeeeeeeeee2");
            //    stream.WriteLine("bljeeeeeeeeee3");
            //    stream.WriteLine("¤");
            //}

            //var lines = File.ReadLines(@"C:\Temp\test.txt").Select(l => l.Replace("¤", "This has replaced čmrklja"));
            //File.WriteAllLines(@"C:\Temp\test.txt", lines);
        }
    }
}