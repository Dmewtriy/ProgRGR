namespace ProgRGR
{
    public class FormController
    {
        public event Action<string> Errors;
        private FileController fileController;
        private int selectedView = 16;
        public string openedFile = string.Empty;
        public int SelectedView
        {
            get
            {
                return selectedView;
            }
            set
            {
                if (value == 16 || value == 2)
                {
                    selectedView = value;
                }
                else
                {
                    selectedView = 16;
                }
            }
        }
        public FormController() 
        {
            fileController = new FileController();
        }

        public bool OpenFile(string path = null)
        {
            if (path == null)
            {
                path = GetFileName();
                if (path == string.Empty) return false;
                openedFile = path;
            }
            else
            {
                path = openedFile;
            }
            try
            {
                fileController.Open(path);
                return true;
            }
            catch
            {
                Errors?.Invoke("Ошибка при открытии файла. Попробуйте ещё раз.");
                return false;
            }
        }

        public List<DataRow> GetData(int row, int column, int view)
        {
            return fileController.GetDataHex(row, column, view);
        }

        public void Close()
        {
            fileController.Close();
        }

        private string GetFileName()
        {
            string path = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
            }
            return path;
        }
    }
}
