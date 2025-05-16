namespace ProgRGR
{
    public partial class Form1 : Form
    {
        private readonly FormController _formController;
        private FileController _fileController;
        public Form1(FormController controller)
        {
            InitializeComponent();
            InitializeHotkeys();
            _formController = controller;
            _fileController = new FileController();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var filePath = _formController.OpenFileDialog();
            _fileController.Open(filePath);
            string[] data = _fileController.GetDataHex();

            int column = 0, index = 0;
            for (int i = 0; i < data.Length; i++)
            {
                column = i % 17;
                if (column == 0)
                {
                    dataGridView1.Rows.Add();
                }
                index = i / 17;
                dataGridView1.Rows[index].Cells[column].Value = data[i];
            }
        }

        private void DisplayData(string[] data)
        {
            int lastRow = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            var row = dataGridView1.Rows[lastRow];
            int lastColumnIndex = -1;
            for (int col = 0; col < dataGridView1.Columns.Count; col++)
            {
                if (row.Cells[col].Value == null)
                {
                    lastColumnIndex = col;
                    break;
                }
            }
            int column = 0, index = 0;
            for (int i = 0; i < data.Length; i++)
            {
                column = (lastColumnIndex + i) % 17;
                if (column == 0)
                {
                    dataGridView1.Rows.Add();
                }
                index = lastRow + i / 17;
                dataGridView1.Rows[index].Cells[column].Value = data[i];
            }
        }

        private void FormClose(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите закрыть приложение?", "Выход из приложения", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            StringFindTextBox.Text = string.Empty;
            Find.ShowDropDown();
            StringFindTextBox.Focus();
        }

        private void Find_DropDownClosed(object sender, EventArgs e)
        {
            StringFindTextBox.Text = "Ctrl+F";
        }

        private void StringFindTextBox_Click(object sender, EventArgs e)
        {
            StringFindTextBox.Text = string.Empty;
        }

        private double GetVerticalScrollPercentage()
        {
            // Если нет строк, возвращаем 0
            if (dataGridView1.RowCount == 0)
                return 0;

            // Если видимы все строки (нет необходимости в скролле), возвращаем 0
            if (dataGridView1.DisplayedRowCount(true) >= dataGridView1.RowCount)
                return 0;

            // Получаем текущую позицию скролла
            int scrollOffset = dataGridView1.FirstDisplayedScrollingRowIndex;

            // Общее количество строк, которые можно прокрутить
            int scrollRange = dataGridView1.RowCount - dataGridView1.DisplayedRowCount(true);

            // Вычисляем процент прокрутки
            double percentage = (double)scrollOffset / scrollRange * 100;

            // Округляем до 2 знаков после запятой
            return Math.Round(percentage, 2);
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                double scrollPercentage = GetVerticalScrollPercentage();
                if (scrollPercentage > 70)
                {
                    string[] data = _fileController.GetDataHex();

                    DisplayData(data);
                }
            }
        }
    }
}