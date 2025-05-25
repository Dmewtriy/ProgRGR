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
            DialogResult res = MessageBox.Show("�� ������������� ������ ������� ����������?", "����� �� ����������", MessageBoxButtons.YesNo);
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
            // ���� ��� �����, ���������� 0
            if (dataGridView1.RowCount == 0)
                return 0;

            // ���� ������ ��� ������ (��� ������������� � �������), ���������� 0
            if (dataGridView1.DisplayedRowCount(true) >= dataGridView1.RowCount)
                return 0;

            // �������� ������� ������� �������
            int scrollOffset = dataGridView1.FirstDisplayedScrollingRowIndex;

            // ����� ���������� �����, ������� ����� ����������
            int scrollRange = dataGridView1.RowCount - dataGridView1.DisplayedRowCount(true);

            // ��������� ������� ���������
            double percentage = (double)scrollOffset / scrollRange * 100;

            // ��������� �� 2 ������ ����� �������
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

        private void Content_Click(object sender, EventArgs e)
        {
            string text = "Как пользоваться программой:\r\n\r\n1. Открытие файла  \r\n   - Нажмите \"Файл → Открыть\" (Ctrl+O)  \r\n   - Выберите файл для просмотра  \r\n\r\n2. Просмотр данных  \r\n   - Переключайтесь между HEX/Binary через меню \"Вид\"  \r\n   - Используйте колесо мыши или полосу прокрутки для навигации  \r\n\r\n3. Поиск  \r\n   - \"Правка → Найти\" (Ctrl+F) — поиск строки с указанным адресом  \r\n   - Поддерживаются HEX и Binary строки\r\n\r\nГорячие клавиши:  \r\n- Ctrl+O — открыть файл  \r\n- Ctrl+F — поиск  \r\n- Ctrl+Q — выход  \r\n- Ctrl+Shift+H/B — переключить вид (HEX/Binary)  \r\n";
            MessageBox.Show(text, "Справка по использованию", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        private void About_Click(object sender, EventArgs e)
        {
            string text = "Программа для просмотра файлов в шестнадцатеричном (HEX) и двоичном (Binary) формате.\r\n\r\nВозможности:\r\n- Открытие файлов любого типа\r\n- Просмотр содержимого в HEX/Binary\r\n\r\nАвторы: Dmewtiy, Tairchik  \r\nВерсия: 1.0  \r\n\r\nGitHub: [ссылка на репозиторий, если есть]  \r\nКонтакты: [email/сайт]  ";
            MessageBox.Show(text, "Hex/Binary File Viewer v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}