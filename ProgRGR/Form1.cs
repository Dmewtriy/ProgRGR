namespace ProgRGR
{
    public partial class Form1 : Form
    {
        private readonly FormController _controller;
        public Form1(FormController controller)
        {
            InitializeComponent();
            InitializeHotkeys();
            _controller = controller;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            var filePath = _controller.OpenFileDialog();
            int column = 0, index = 0;
            for (int i = 0; i < 20; i++)
            {
                column = i % 17;
                if (column == 0)
                {
                    dataGridView1.Rows.Add();
                }
                index = i / 17;
                var row = dataGridView1.Rows[index];
                switch (column)
                {
                    // номер строки
                    case 0:
                        row.Cells[column].Value = index;
                        break;
                    default:
                        row.Cells[column].Value = i; 
                        break;
                }
            }
        }

        private void FormClose(object sender, EventArgs e)
        {
            Close();
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