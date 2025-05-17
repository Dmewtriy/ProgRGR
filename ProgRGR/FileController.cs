using BinaryViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgRGR
{
    public class DataRow : ICloneable
    {
        public string numberRow;
        public List<string> data;
        public DataRow() 
        {
            data = new List<string>();
        }

        public object Clone()
        {
            return new DataRow
            {
                numberRow = this.numberRow,
                data = new List<string>(this.data)
            };
        }
    }
    public class FileController
    {
        private FileManager fileManager; 
        public FileController()
        {
            fileManager = new FileManager();
        }

        public void Open(string path)
        {
            fileManager.Open(path);
        }

        public List<DataRow> GetDataHex(int row, int column)
        {
            byte[] data = fileManager.GetNewPage();
            List<DataRow> hex = new List<DataRow>();
            
            int countRows = (int) Math.Ceiling(data.Length / 16.0);
            DataRow dataRow;

            for (int i = 0; i < countRows; i++)
            {
                dataRow = new DataRow();
                dataRow.numberRow = Convert.ToString(i + row, 16).PadLeft(10, '0').ToUpper() + "0";
                if (i == 0)
                {
                    for (int j = column; j < 16; j++)
                    {
                        dataRow.data.Add(Convert.ToString(data[j - column], 16).PadLeft(2, '0').ToUpper());
                    }
                }
                else if (i == countRows - 1)
                {
                    int remainder = data.Length - i * 16 == 0 ? 16 : data.Length - i * 16;

                    for (int j = 0; j < remainder; j++)
                    {
                        dataRow.data.Add(Convert.ToString(data[i * 16 + j], 16).PadLeft(2, '0').ToUpper());
                    }
                }
                else
                {
                    for (int j = 0; j < 16; j++)
                    {
                        dataRow.data.Add(Convert.ToString(data[i * 16 + j - (16 - column == 16 ? 0 : 16 - column)], 16).PadLeft(2, '0').ToUpper());
                    }
                }
                hex.Add(dataRow);
            }


            return hex;
        }

        public string[] GetDataBinary()
        {
            byte[] data = fileManager.GetNewPage();

            string[] binary = new string[data.Length + (int)Math.Ceiling(data.Length / 16.0)];
            int counter = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                if (i % 17 == 0)
                {
                    binary[i] = Convert.ToString(i / 17, 16).PadLeft(10, '0').ToUpper() + "0";
                    continue;
                }
                binary[i] = Convert.ToString(data[counter], 2).PadLeft(8, '0').ToUpper();
                counter++;
            }

            return binary;
        }

        public void Close()
        {
            fileManager.CloseFile();
        }
    }
}
