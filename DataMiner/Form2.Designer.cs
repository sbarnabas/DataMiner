namespace DataMiner
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBool = new System.Windows.Forms.Panel();
            this.rdBool2 = new System.Windows.Forms.RadioButton();
            this.rdBool1 = new System.Windows.Forms.RadioButton();
            this.lblBool = new System.Windows.Forms.Label();
            this.panelDate = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.panelString = new System.Windows.Forms.Panel();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.labelString = new System.Windows.Forms.Label();
            this.panelNumber = new System.Windows.Forms.Panel();
            this.textBoxNumber2 = new System.Windows.Forms.TextBox();
            this.textBoxNumber1 = new System.Windows.Forms.TextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelBool.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.panelString.SuspendLayout();
            this.panelNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 73);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(204, 224);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(296, 73);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(326, 224);
            this.listBox2.TabIndex = 2;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelBool);
            this.panel1.Controls.Add(this.panelDate);
            this.panel1.Controls.Add(this.panelString);
            this.panel1.Controls.Add(this.panelNumber);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(17, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 265);
            this.panel1.TabIndex = 3;
            // 
            // panelBool
            // 
            this.panelBool.Controls.Add(this.rdBool2);
            this.panelBool.Controls.Add(this.rdBool1);
            this.panelBool.Controls.Add(this.lblBool);
            this.panelBool.Location = new System.Drawing.Point(24, 84);
            this.panelBool.Name = "panelBool";
            this.panelBool.Size = new System.Drawing.Size(553, 154);
            this.panelBool.TabIndex = 1;
            // 
            // rdBool2
            // 
            this.rdBool2.AutoSize = true;
            this.rdBool2.Location = new System.Drawing.Point(280, 75);
            this.rdBool2.Name = "rdBool2";
            this.rdBool2.Size = new System.Drawing.Size(54, 24);
            this.rdBool2.TabIndex = 3;
            this.rdBool2.TabStop = true;
            this.rdBool2.Text = "No";
            this.rdBool2.UseVisualStyleBackColor = true;
            // 
            // rdBool1
            // 
            this.rdBool1.AutoSize = true;
            this.rdBool1.Location = new System.Drawing.Point(280, 45);
            this.rdBool1.Name = "rdBool1";
            this.rdBool1.Size = new System.Drawing.Size(62, 24);
            this.rdBool1.TabIndex = 2;
            this.rdBool1.TabStop = true;
            this.rdBool1.Text = "Yes";
            this.rdBool1.UseVisualStyleBackColor = true;
            // 
            // lblBool
            // 
            this.lblBool.AutoSize = true;
            this.lblBool.Location = new System.Drawing.Point(54, 56);
            this.lblBool.Name = "lblBool";
            this.lblBool.Size = new System.Drawing.Size(0, 20);
            this.lblBool.TabIndex = 1;
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.dateTimePicker2);
            this.panelDate.Controls.Add(this.dateTimePicker1);
            this.panelDate.Controls.Add(this.labelDate);
            this.panelDate.Location = new System.Drawing.Point(26, 84);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(553, 154);
            this.panelDate.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(321, 102);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(17, 102);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(40, 29);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(0, 20);
            this.labelDate.TabIndex = 1;
            // 
            // panelString
            // 
            this.panelString.Controls.Add(this.textBoxString);
            this.panelString.Controls.Add(this.labelString);
            this.panelString.Location = new System.Drawing.Point(23, 83);
            this.panelString.Name = "panelString";
            this.panelString.Size = new System.Drawing.Size(553, 154);
            this.panelString.TabIndex = 4;
            // 
            // textBoxString
            // 
            this.textBoxString.Location = new System.Drawing.Point(44, 93);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(477, 26);
            this.textBoxString.TabIndex = 2;
            // 
            // labelString
            // 
            this.labelString.AutoSize = true;
            this.labelString.Location = new System.Drawing.Point(40, 29);
            this.labelString.Name = "labelString";
            this.labelString.Size = new System.Drawing.Size(0, 20);
            this.labelString.TabIndex = 1;
            // 
            // panelNumber
            // 
            this.panelNumber.Controls.Add(this.textBoxNumber2);
            this.panelNumber.Controls.Add(this.textBoxNumber1);
            this.panelNumber.Controls.Add(this.labelNumber);
            this.panelNumber.Location = new System.Drawing.Point(24, 84);
            this.panelNumber.Name = "panelNumber";
            this.panelNumber.Size = new System.Drawing.Size(553, 154);
            this.panelNumber.TabIndex = 5;
            // 
            // textBoxNumber2
            // 
            this.textBoxNumber2.Location = new System.Drawing.Point(315, 90);
            this.textBoxNumber2.Name = "textBoxNumber2";
            this.textBoxNumber2.Size = new System.Drawing.Size(156, 26);
            this.textBoxNumber2.TabIndex = 3;
            // 
            // textBoxNumber1
            // 
            this.textBoxNumber1.Location = new System.Drawing.Point(11, 90);
            this.textBoxNumber1.Name = "textBoxNumber1";
            this.textBoxNumber1.Size = new System.Drawing.Size(156, 26);
            this.textBoxNumber1.TabIndex = 2;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(40, 29);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(0, 20);
            this.labelNumber.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Filter for...";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.Location = new System.Drawing.Point(431, 993);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "Done";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(21, 993);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Field";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Filter Criteria";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 714);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(600, 273);
            this.dataGridView1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 682);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Existing Filters";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(527, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 50);
            this.button3.TabIndex = 10;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(226, 993);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(199, 50);
            this.button4.TabIndex = 11;
            this.button4.Text = "Remove Filter";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 1096);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form2";
            this.Text = "Filter Data";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBool.ResumeLayout(false);
            this.panelBool.PerformLayout();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.panelString.ResumeLayout(false);
            this.panelString.PerformLayout();
            this.panelNumber.ResumeLayout(false);
            this.panelNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelBool;
        private System.Windows.Forms.Label lblBool;
        private System.Windows.Forms.RadioButton rdBool2;
        private System.Windows.Forms.RadioButton rdBool1;
        private System.Windows.Forms.Panel panelString;
        private System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.Label labelString;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panelNumber;
        private System.Windows.Forms.TextBox textBoxNumber2;
        private System.Windows.Forms.TextBox textBoxNumber1;
        private System.Windows.Forms.Label labelNumber;
    }
}