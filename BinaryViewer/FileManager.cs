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
            if (reader != null)
            {
                CloseFile();
            }
            
            reader = new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        public byte[] GetNewPage() 
        {
            Page lastPage = buffer.Last();

            if (lastPage == null)
            {
                ReadAndPushToBuffer(0);
            }
            else
            {
                if (size * lastPage.Index + 1 < reader.Length)
                {
                    ReadAndPushToBuffer(lastPage.Index + 1);
                }
                else
                {

                }
            }

            return buffer.Last().Data;
        }

        private void ReadAndPushToBuffer(long index)
        {
            if (size * index < reader.Length)
            {
                byte[] data = new byte[size];

                Reader.Seek(index * size, SeekOrigin.Begin);
                Reader.Read(data, 0, size);

                Page page = new Page(data, index);
                buffer.Add(page);
            }
            else
            {
                int tempSize = (int) reader.Length % size;
                byte[] data = new byte[tempSize];

                Reader.Seek(index * size, SeekOrigin.Begin);
                Reader.Read(data, 0, tempSize);

                Page page = new Page(data, index);
                buffer.Add(page);
            }
            
        }

        public void CloseFile()
        {
            Reader.Close();
            reader = null;
        }

        private FileStream Reader
        {
            get 
            {
                if (reader == null || reader.CanRead == false) 
                {
                    throw new Exception("Файл не открыт");
                }

                return reader; 
            }
        }

    }
}
