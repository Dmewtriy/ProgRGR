using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    public class FileManager
    {
        private FileStream reader;
        private List<Page> buffer = new List<Page>();
        private int size;

        public FileManager(int size = 1000)
        {
            this.size = size;
        }

        public void Open(string path)
        {
            CloseFile();
            
            reader = new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        public byte[] GetNewPage() 
        {
            int lastLen = buffer.Count;
            if (buffer.Count == 0)
            {
                ReadAndPushToBuffer(0);
            }
            else
            {
                Page lastPage = buffer.Last();
                ReadAndPushToBuffer(lastPage.Index + 1);

            }
            if (lastLen != buffer.Count)
            {
                return buffer.Last().Data;
            }
            return new byte[] { };
        }

        private void ReadAndPushToBuffer(long index)
        {
            if (reader == null || reader.CanRead == false)
            {
                throw new Exception("Файл не открыт");
            }
            if (size * (index + 1) <= reader.Length)
            {
                byte[] data = new byte[size];

                reader.Seek(index * size, SeekOrigin.Begin);
                reader.Read(data, 0, size);

                Page page = new Page(data, index);
                buffer.Add(page);
            }
            else if (size * index <= reader.Length)
            {
                int tempSize = (int)reader.Length % size;
                byte[] data = new byte[tempSize];

                reader.Seek(index * size, SeekOrigin.Begin);
                reader.Read(data, 0, tempSize);

                Page page = new Page(data, index);
                buffer.Add(page);
            }
        }

        public void CloseFile()
        {
            if (reader != null)
            {
                reader.Close();
                buffer.Clear();
            }
        }
    }
}
