namespace ProgRGR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeHotkeys();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            // открытие файла
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