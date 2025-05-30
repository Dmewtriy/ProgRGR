using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryViewer
{
    public class FileManager
    {
        private FileStream reader;
        private readonly List<Page> buffer = new List<Page>();
        private readonly int size;

        public FileManager(int size = 1000)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Размер страницы должен быть положительным числом.");
            }

            this.size = size;
        }

        public void Open(string path)
        {
            CloseFile();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл '{path}' не найден.");
            }

            reader = new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        public byte[] GetNewPage()
        {
            if (reader == null || !reader.CanRead)
            {
                throw new InvalidOperationException("Файл не открыт");
            }

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
            if (reader == null || !reader.CanRead)
            {
                throw new InvalidOperationException("Файл не открыт");
            }

            long position = index * size;
            if (position >= reader.Length)
            {
                return;
            }

            int remaining = (int)Math.Min(size, reader.Length - position);
            byte[] data = new byte[remaining];

            reader.Seek(position, SeekOrigin.Begin);
            reader.Read(data, 0, remaining);

            Page page = new Page(data, index);
            buffer.Add(page);
        }

        public void CloseFile()
        {
            if (reader != null)
            {
                reader.Close();
                reader = null;
                buffer.Clear();
            }
        }
    }
}
