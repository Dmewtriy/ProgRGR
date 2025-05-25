using BinaryViewer;

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
        public event Action<string> Errors;
        private FileManager fileManager; 
        public FileController()
        {
            fileManager = new FileManager();
        }

        public void Open(string path)
        {
            fileManager.Open(path);
        }

        public List<DataRow> GetDataHex(int row, int column, int numberBase)
        {
            byte[] data = fileManager.GetNewPage();
            List<DataRow> hex = new List<DataRow>();
            int dataIndex = 0;

            if (data.Length == 0)
            {
                return hex;
            }
            if (column == -1) row++;
            int countRows = (int) Math.Ceiling(data.Length / 16.0);
            DataRow dataRow;

            for (int i = 0; i < countRows; i++)
            {
                dataRow = new DataRow();
                dataRow.numberRow = Convert.ToString(i + row, numberBase).PadLeft(10, '0').ToUpper() + "0";

                int endIndex = Math.Min(dataIndex + 16, data.Length);

                if (i == 0 && column > 0)
                {
                    endIndex -= column;
                    if (endIndex >= data.Length)
                        continue;
                }


                for (int j = dataIndex; j < endIndex; j++)
                {
                    dataRow.data.Add(Convert.ToString(data[j], numberBase).PadLeft(2, '0').ToUpper());
                    dataIndex++;
                }

                hex.Add(dataRow);
            }


            return hex;
        }
        public void Close()
        {
            fileManager.CloseFile();
        }
    }
}
