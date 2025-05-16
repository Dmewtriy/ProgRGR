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