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
            Find.ShowDropDown();
            StringFindTextBox.Focus();
        }
    }
}