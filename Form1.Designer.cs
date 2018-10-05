namespace Steam_Linker_2._0
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox_HostInput = new System.Windows.Forms.RichTextBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.button_info = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(480, 405);
            this.dataGridView1.TabIndex = 0;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(350, 10);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(118, 108);
            this.button_Search.TabIndex = 3;
            this.button_Search.Text = "Go";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.Button_Search_Click);
            // 
            // textBox_Key
            // 
            this.textBox_Key.Location = new System.Drawing.Point(38, 10);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(306, 20);
            this.textBox_Key.TabIndex = 4;
            this.textBox_Key.Text = "https://steamcommunity.com/dev/apikey";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_info);
            this.panel1.Controls.Add(this.richTextBox_HostInput);
            this.panel1.Controls.Add(this.label_Status);
            this.panel1.Controls.Add(this.textBox_Key);
            this.panel1.Controls.Add(this.button_Search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 137);
            this.panel1.TabIndex = 6;
            // 
            // richTextBox_HostInput
            // 
            this.richTextBox_HostInput.Location = new System.Drawing.Point(38, 36);
            this.richTextBox_HostInput.Name = "richTextBox_HostInput";
            this.richTextBox_HostInput.Size = new System.Drawing.Size(306, 82);
            this.richTextBox_HostInput.TabIndex = 6;
            this.richTextBox_HostInput.Text = "SteamID64,SteamID64,etc";
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(15, 121);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(49, 13);
            this.label_Status.TabIndex = 5;
            this.label_Status.Text = "All is well";
            // 
            // button_info
            // 
            this.button_info.Location = new System.Drawing.Point(12, 10);
            this.button_info.Name = "button_info";
            this.button_info.Size = new System.Drawing.Size(19, 23);
            this.button_info.TabIndex = 7;
            this.button_info.Text = "?";
            this.button_info.UseVisualStyleBackColor = true;
            this.button_info.Click += new System.EventHandler(this.button_info_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 542);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Steam Linker";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.RichTextBox richTextBox_HostInput;
        private System.Windows.Forms.Button button_info;
    }
}

