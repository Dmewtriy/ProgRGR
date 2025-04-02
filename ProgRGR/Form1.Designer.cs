namespace ProgRGR
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            File = new ToolStripMenuItem();
            OpenFile = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            View = new ToolStripMenuItem();
            HexView = new ToolStripMenuItem();
            BinView = new ToolStripMenuItem();
            Find = new ToolStripMenuItem();
            StringFindTextBox = new ToolStripTextBox();
            Help = new ToolStripMenuItem();
            Content = new ToolStripMenuItem();
            About = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { File, View, Find, Help });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1196, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            File.DropDownItems.AddRange(new ToolStripItem[] { OpenFile, Exit });
            File.Name = "File";
            File.Size = new Size(69, 29);
            File.Text = "Файл";
            // 
            // OpenFile
            // 
            OpenFile.Name = "OpenFile";
            OpenFile.ShortcutKeys = Keys.Control | Keys.O;
            OpenFile.Size = new Size(226, 30);
            OpenFile.Text = "Открыть";
            OpenFile.Click += OpenFile_Click;
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.ShortcutKeys = Keys.Control | Keys.Q;
            Exit.Size = new Size(226, 30);
            Exit.Text = "Выход";
            // 
            // View
            // 
            View.DropDownItems.AddRange(new ToolStripItem[] { HexView, BinView });
            View.Name = "View";
            View.Size = new Size(56, 29);
            View.Text = "Вид";
            // 
            // HexView
            // 
            HexView.Name = "HexView";
            HexView.ShortcutKeys = Keys.Control | Keys.Shift | Keys.H;
            HexView.Size = new Size(297, 30);
            HexView.Text = "16-ичный";
            // 
            // BinView
            // 
            BinView.Name = "BinView";
            BinView.ShortcutKeys = Keys.Control | Keys.Shift | Keys.B;
            BinView.Size = new Size(297, 30);
            BinView.Text = "2-ичный";
            // 
            // Find
            // 
            Find.DropDownItems.AddRange(new ToolStripItem[] { StringFindTextBox });
            Find.Name = "Find";
            Find.Size = new Size(77, 29);
            Find.Text = "Найти";
            Find.Click += Find_Click;
            // 
            // StringFindTextBox
            // 
            StringFindTextBox.BorderStyle = BorderStyle.FixedSingle;
            StringFindTextBox.MaxLength = 10;
            StringFindTextBox.Name = "StringFindTextBox";
            StringFindTextBox.Size = new Size(100, 23);
            // 
            // Help
            // 
            Help.DropDownItems.AddRange(new ToolStripItem[] { Content, About });
            Help.Name = "Help";
            Help.Size = new Size(99, 29);
            Help.Text = "Помощь";
            // 
            // Content
            // 
            Content.Name = "Content";
            Content.Size = new Size(200, 30);
            Content.Text = "Содержание";
            // 
            // About
            // 
            About.Name = "About";
            About.Size = new Size(200, 30);
            About.Text = "О программе";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 622);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Двоичный просмотрщик файлов";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeHotkeys()
        {
            // Включаем обработку клавиш на форме
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверяем, нажата ли комбинация Ctrl+F
            if (e.Control && e.KeyCode == Keys.F)
            {
                Find.PerformClick();
                e.Handled = true; // Помечаем событие как обработанное
            }
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem File;
        private ToolStripMenuItem View;
        private ToolStripMenuItem OpenFile;
        private ToolStripMenuItem Exit;
        private ToolStripMenuItem HexView;
        private ToolStripMenuItem BinView;
        private ToolStripMenuItem Find;
        private ToolStripTextBox StringFindTextBox;
        private ToolStripMenuItem Help;
        private ToolStripMenuItem Content;
        private ToolStripMenuItem About;
    }
}