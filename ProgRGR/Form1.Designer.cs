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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            dataGridView1 = new DataGridView();
            Offset = new DataGridViewTextBoxColumn();
            value0 = new DataGridViewTextBoxColumn();
            value1 = new DataGridViewTextBoxColumn();
            value2 = new DataGridViewTextBoxColumn();
            valeu3 = new DataGridViewTextBoxColumn();
            value4 = new DataGridViewTextBoxColumn();
            value5 = new DataGridViewTextBoxColumn();
            value6 = new DataGridViewTextBoxColumn();
            value7 = new DataGridViewTextBoxColumn();
            value8 = new DataGridViewTextBoxColumn();
            value9 = new DataGridViewTextBoxColumn();
            valueA = new DataGridViewTextBoxColumn();
            valueB = new DataGridViewTextBoxColumn();
            valueC = new DataGridViewTextBoxColumn();
            valueD = new DataGridViewTextBoxColumn();
            valueE = new DataGridViewTextBoxColumn();
            valueF = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            Exit.Click += FormClose;
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
            Find.DropDownClosed += Find_DropDownClosed;
            Find.Click += Find_Click;
            // 
            // StringFindTextBox
            // 
            StringFindTextBox.AutoToolTip = true;
            StringFindTextBox.BorderStyle = BorderStyle.FixedSingle;
            StringFindTextBox.MaxLength = 10;
            StringFindTextBox.Name = "StringFindTextBox";
            StringFindTextBox.Size = new Size(100, 23);
            StringFindTextBox.Text = "Ctrl+F";
            StringFindTextBox.ToolTipText = "\r\n";
            StringFindTextBox.Click += StringFindTextBox_Click;
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Offset, value0, value1, value2, valeu3, value4, value5, value6, value7, value8, value9, valueA, valueB, valueC, valueD, valueE, valueF });
            dataGridView1.Location = new Point(12, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.RowTemplate.ReadOnly = true;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(1103, 574);
            dataGridView1.TabIndex = 1;
            dataGridView1.Scroll += dataGridView1_Scroll;
            // 
            // Offset
            // 
            Offset.HeaderText = "Адрес";
            Offset.Name = "Offset";
            Offset.ReadOnly = true;
            Offset.Resizable = DataGridViewTriState.False;
            Offset.SortMode = DataGridViewColumnSortMode.NotSortable;
            Offset.Width = 53;
            // 
            // value0
            // 
            value0.HeaderText = "00";
            value0.Name = "value0";
            value0.ReadOnly = true;
            value0.Resizable = DataGridViewTriState.False;
            value0.SortMode = DataGridViewColumnSortMode.NotSortable;
            value0.Width = 31;
            // 
            // value1
            // 
            value1.HeaderText = "01";
            value1.Name = "value1";
            value1.ReadOnly = true;
            value1.Resizable = DataGridViewTriState.False;
            value1.SortMode = DataGridViewColumnSortMode.NotSortable;
            value1.Width = 31;
            // 
            // value2
            // 
            value2.HeaderText = "02";
            value2.Name = "value2";
            value2.ReadOnly = true;
            value2.Resizable = DataGridViewTriState.False;
            value2.SortMode = DataGridViewColumnSortMode.NotSortable;
            value2.Width = 31;
            // 
            // valeu3
            // 
            valeu3.HeaderText = "03";
            valeu3.Name = "valeu3";
            valeu3.ReadOnly = true;
            valeu3.Resizable = DataGridViewTriState.False;
            valeu3.SortMode = DataGridViewColumnSortMode.NotSortable;
            valeu3.Width = 31;
            // 
            // value4
            // 
            value4.HeaderText = "04";
            value4.Name = "value4";
            value4.ReadOnly = true;
            value4.Resizable = DataGridViewTriState.False;
            value4.SortMode = DataGridViewColumnSortMode.NotSortable;
            value4.Width = 31;
            // 
            // value5
            // 
            value5.HeaderText = "05";
            value5.Name = "value5";
            value5.ReadOnly = true;
            value5.Resizable = DataGridViewTriState.False;
            value5.SortMode = DataGridViewColumnSortMode.NotSortable;
            value5.Width = 31;
            // 
            // value6
            // 
            value6.HeaderText = "06";
            value6.Name = "value6";
            value6.ReadOnly = true;
            value6.Resizable = DataGridViewTriState.False;
            value6.SortMode = DataGridViewColumnSortMode.NotSortable;
            value6.Width = 31;
            // 
            // value7
            // 
            value7.HeaderText = "07";
            value7.Name = "value7";
            value7.ReadOnly = true;
            value7.Resizable = DataGridViewTriState.False;
            value7.SortMode = DataGridViewColumnSortMode.NotSortable;
            value7.Width = 31;
            // 
            // value8
            // 
            value8.HeaderText = "08";
            value8.Name = "value8";
            value8.ReadOnly = true;
            value8.Resizable = DataGridViewTriState.False;
            value8.SortMode = DataGridViewColumnSortMode.NotSortable;
            value8.Width = 31;
            // 
            // value9
            // 
            value9.HeaderText = "09";
            value9.Name = "value9";
            value9.ReadOnly = true;
            value9.Resizable = DataGridViewTriState.False;
            value9.SortMode = DataGridViewColumnSortMode.NotSortable;
            value9.Width = 31;
            // 
            // valueA
            // 
            valueA.HeaderText = "0A";
            valueA.Name = "valueA";
            valueA.ReadOnly = true;
            valueA.Resizable = DataGridViewTriState.False;
            valueA.SortMode = DataGridViewColumnSortMode.NotSortable;
            valueA.Width = 32;
            // 
            // valueB
            // 
            valueB.HeaderText = "0B";
            valueB.Name = "valueB";
            valueB.ReadOnly = true;
            valueB.Resizable = DataGridViewTriState.False;
            valueB.SortMode = DataGridViewColumnSortMode.NotSortable;
            valueB.Width = 31;
            // 
            // valueC
            // 
            valueC.HeaderText = "0C";
            valueC.Name = "valueC";
            valueC.ReadOnly = true;
            valueC.Resizable = DataGridViewTriState.False;
            valueC.SortMode = DataGridViewColumnSortMode.NotSortable;
            valueC.Width = 32;
            // 
            // valueD
            // 
            valueD.HeaderText = "0D";
            valueD.Name = "valueD";
            valueD.ReadOnly = true;
            valueD.Resizable = DataGridViewTriState.False;
            valueD.SortMode = DataGridViewColumnSortMode.NotSortable;
            valueD.Width = 33;
            // 
            // valueE
            // 
            valueE.HeaderText = "0E";
            valueE.Name = "valueE";
            valueE.ReadOnly = true;
            valueE.Resizable = DataGridViewTriState.False;
            valueE.SortMode = DataGridViewColumnSortMode.NotSortable;
            valueE.Width = 30;
            // 
            // valueF
            // 
            valueF.HeaderText = "0F";
            valueF.Name = "valueF";
            valueF.ReadOnly = true;
            valueF.Resizable = DataGridViewTriState.False;
            valueF.SortMode = DataGridViewColumnSortMode.NotSortable;
            valueF.Width = 30;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 622);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Двоичный просмотрщик файлов";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
            if (e.Control && e.KeyCode == Keys.Q)
            {
                this.Close();
                e.Handled = true; // Помечаем событие как обработанное
            }
            // Сдвиг изображения на одну строку
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {

                e.Handled = true;
            }
            // Сдвиг изображения на одну страницу
            if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
            {

                e.Handled = true;
            }
            // Отображение первой страницы
            if (e.KeyCode == Keys.Home)
            {

                e.Handled = true;
            }
            // Отображение последней страницы
            if (e.KeyCode == Keys.End)
            {

                e.Handled = true;
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
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Offset;
        private DataGridViewTextBoxColumn value0;
        private DataGridViewTextBoxColumn value1;
        private DataGridViewTextBoxColumn value2;
        private DataGridViewTextBoxColumn valeu3;
        private DataGridViewTextBoxColumn value4;
        private DataGridViewTextBoxColumn value5;
        private DataGridViewTextBoxColumn value6;
        private DataGridViewTextBoxColumn value7;
        private DataGridViewTextBoxColumn value8;
        private DataGridViewTextBoxColumn value9;
        private DataGridViewTextBoxColumn valueA;
        private DataGridViewTextBoxColumn valueB;
        private DataGridViewTextBoxColumn valueC;
        private DataGridViewTextBoxColumn valueD;
        private DataGridViewTextBoxColumn valueE;
        private DataGridViewTextBoxColumn valueF;
    }
}