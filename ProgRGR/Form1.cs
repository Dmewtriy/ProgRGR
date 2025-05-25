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
            _formController.Errors += ShowError;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (_formController.OpenFile())
            {
            dataGridView1.Rows.Clear();
                DisplayData(_formController.SelectedView);
                flag = true;
        }
        }

        private void DisplayData(int view)
        {
            (int lastRow, int lastColumnIndex) = GetLastRowAndColumnIndex();
            List<DataRow> data = _formController.GetData(lastRow, lastColumnIndex, view);
            string numberRow = Convert.ToString(lastRow, view).PadLeft(10, '0').ToUpper() + "0";
            if (data.Count == 0)
                return;
            
            dataGridView1.SuspendLayout();

            List<DataRow> data = _fileController.GetDataHex(lastRow, lastColumnIndex);
            int currentRow;

            if (data.Count == 0) return;

            foreach (var dataRow in data)
            {

                // Проверяем, есть ли в DataGridView строка с таким номером
                bool isExistingRow = dataRow.numberRow == numberRow && lastRow != 0;
                DataGridViewRow row;

                if (isExistingRow)
                {
                    row = dataGridView1.Rows[lastRow];
                    lastColumnIndex++;

                    // Заполняем данные, начиная с последней пустой ячейки
                    for (int i = 0; i < dataRow.data.Count && lastColumnIndex + i < row.Cells.Count; i++)
                    {
                        row.Cells[lastColumnIndex + i].Value = dataRow.data[i];
                    }
                }
                else
                {
                    // Создаём новую строку
                    row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = dataRow.numberRow;

                    // Заполняем данные с начала (или с lastColumnIndex, если это продолжение)
                    int startColumn = 1;
                    for (int i = 0; i < dataRow.data.Count && startColumn + i < row.Cells.Count; i++)
                    {
                        row.Cells[startColumn + i].Value = dataRow.data[i];
                    }

                    dataGridView1.Rows.Add(row);
                }
            }

            dataGridView1.ResumeLayout();
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