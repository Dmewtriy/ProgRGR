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
            DisplayData();
        }

        private void DisplayData()
        {
            int lastRow = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            int lastColumnIndex;
            if (lastRow == -1)
            {
                lastColumnIndex = 0;
                lastRow = 0;
            }
            else
            {
                var row = dataGridView1.Rows[lastRow];
                lastColumnIndex = -1;
                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    if (row.Cells[col].Value == null)
                    {
                        lastColumnIndex = col - 1;
                        break;
                    }
                }
            }
            

            List<DataRow> data = _fileController.GetDataHex(lastRow, lastColumnIndex);
            int currentRow;

            if (data.Count == 0) return;

            foreach (var dataRow in data)
            {

                currentRow = Convert.ToInt32(dataRow.numberRow.Substring(0, dataRow.numberRow.Length - 1), 16);

                if (currentRow == lastRow)
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        dataGridView1.Rows.Add();
                    }
                    dataGridView1.Rows[currentRow].Cells[0].Value = dataRow.numberRow;

                    for (int j = lastColumnIndex; j < 16; j++)
                    {
                        dataGridView1.Rows[currentRow].Cells[j + 1].Value = dataRow.data[j - lastColumnIndex];
                    }
                }
                else
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[currentRow].Cells[0].Value = dataRow.numberRow;

                    if (currentRow == data.Count - 1)
                    {
                        int l = 0;
                    }
                    for (int element = 0; element < dataRow.data.Count; element++)
                    {
                        dataGridView1.Rows[currentRow].Cells[element + 1].Value = dataRow.data[element];
                    }
                }
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

        private bool flag = true;
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                double scrollPercentage = GetVerticalScrollPercentage();
                if (scrollPercentage > 70 && flag == true)
                {
                    int count = dataGridView1.Rows.Count;
                    DisplayData();

                    if (count == dataGridView1.Rows.Count)
                    {
                        flag = false;
                    }
                }
                if (flag == false)
                {
                    _fileController.Close();
                }
            }
        }
    }
}