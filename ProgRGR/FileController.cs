using BinaryViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgRGR
{
    internal class FileController
    {
        private FileManager fileManager; 

        public FileController(string path)
        {
            fileManager = new FileManager();
            fileManager.Open(path);
        }

        public string[] GetDataHex()
        {
            byte[] data = fileManager.GetNewPage();

            string[] hex = new string[data.Length + (int) Math.Ceiling(data.Length / 16.0)];

            for (int i = 0; i < hex.Length; i++)
            {
                if (i % 17 == 0)
                {
                    hex[i] = Convert.ToString(i / 17, 16).PadLeft(10, '0').ToUpper() + "0";
                    continue;
                }
                hex[i] = Convert.ToString(data[i], 16).PadLeft(2, '0').ToUpper();
            }

            return hex;
        }

        public string[] GetDataBinary()
        {
            byte[] data = fileManager.GetNewPage();

            string[] binary = new string[data.Length + (int)Math.Ceiling(data.Length / 16.0)];

            for (int i = 0; i < binary.Length; i++)
            {
                if (i % 17 == 0)
                {
                    binary[i] = Convert.ToString(i / 17, 16).PadLeft(10, '0').ToUpper() + "0";
                    continue;
                }
                binary[i] = Convert.ToString(data[i], 2).PadLeft(8, '0').ToUpper();
            }

            return binary;
        }

        public void Close()
        {
            fileManager.CloseFile();
        }
    }
}
