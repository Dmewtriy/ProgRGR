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
            string[] data = _fileController.GetDataBinary();

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
    }
}