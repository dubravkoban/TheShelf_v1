using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShelf.Containers
{
    public class HtmlTemplate
    {
        private string _filePath = ConfigurationManager.AppSettings["FilePath"];
        private int _byteCount = 0;

        public HtmlTemplate()
        {
            MemoryStream mStream = null;
            FileStream fStream = null;

            try
            {
                ITag tag = new HtmlTag();
                InsertTags(fStream, mStream, tag);

                tag = new HeadTag();
                InsertTags(fStream, mStream, tag);

                tag = new BodyTag();
                InsertTags(fStream, mStream, tag);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mStream.Dispose();
                fStream.Dispose();
            }
        }

        private FileStream InsertTags(FileStream fStream, MemoryStream mStream, ITag tag)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"{tag.OpeningTag} ¤ {tag.ClosingTag}");
            mStream = new MemoryStream(bytes);

            if (!File.Exists(_filePath))
            {
                fStream = File.Create(_filePath);

                mStream.Seek(0, SeekOrigin.Begin);
                mStream.WriteTo(fStream);

                _byteCount = bytes.Count();
            }
            else
            {
                // need to find a way to replace the crmklja value (63) inside fStream with value of bytes variable

                byte[] buffer = null;
                fStream.Read(buffer, 0, _byteCount);
            }
            
            return fStream;

            //if (File.Exists(_filePath))
            //{
            //    IEnumerable<string> lines = File.ReadLines(_filePath).Select(l => l.Replace("¤", tag.OpeningTag + "¤" + tag.ClosingTag));
            //    File.WriteAllLines(_filePath, lines);
            //}
            //else
            //{
            //    IEnumerable<string> lines = new List<string>
            //    {
            //        tag.OpeningTag,
            //        "¤",
            //        tag.ClosingTag
            //    };

            //    File.WriteAllLines(_filePath, lines);
            //}
        }
    }

    internal class HtmlTag : ITag
    {
        public string OpeningTag { get; set; }
        public string ClosingTag { get; set; }

        public HtmlTag()
        {
            OpeningTag = "<html>";
            ClosingTag = "</html>";
        }
    }

    internal class HeadTag : ITag
    {
        public string OpeningTag { get; set; }
        public string ClosingTag { get; set; }

        public HeadTag()
        {
            OpeningTag = "<head>";
            ClosingTag = "</head>";
        }
    }

    internal class BodyTag : ITag
    {
        public string OpeningTag { get; set; }
        public string ClosingTag { get; set; }

        public BodyTag()
        {
            OpeningTag = "<body>";
            ClosingTag = "</body>";
        }
    }

    interface ITag
    {
        string OpeningTag { get; set; }
        string ClosingTag { get; set; }
    }
}
