namespace SBFD2EDSG_GUI
{
    partial class MainWindow
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
            this.program_title = new System.Windows.Forms.Label();
            this.open_file_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.output_textbox = new System.Windows.Forms.TextBox();
            this.description_label = new System.Windows.Forms.Label();
            this.copy_output_button = new System.Windows.Forms.Button();
            this.log_geneated_text_button = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.code_tab_page = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.output_code_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.code_tab_page.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // program_title
            // 
            this.program_title.AutoSize = true;
            this.program_title.Location = new System.Drawing.Point(13, 13);
            this.program_title.Name = "program_title";
            this.program_title.Size = new System.Drawing.Size(39, 13);
            this.program_title.TabIndex = 1;
            this.program_title.Text = "%title%";
            // 
            // open_file_button
            // 
            this.open_file_button.Location = new System.Drawing.Point(481, 95);
            this.open_file_button.Name = "open_file_button";
            this.open_file_button.Size = new System.Drawing.Size(121, 23);
            this.open_file_button.TabIndex = 2;
            this.open_file_button.Text = "Open file";
            this.open_file_button.UseVisualStyleBackColor = true;
            this.open_file_button.Click += new System.EventHandler(this.open_file_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.output_textbox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 194);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOGS";
            // 
            // output_textbox
            // 
            this.output_textbox.Location = new System.Drawing.Point(7, 20);
            this.output_textbox.Multiline = true;
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.ReadOnly = true;
            this.output_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output_textbox.Size = new System.Drawing.Size(404, 168);
            this.output_textbox.TabIndex = 0;
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.Location = new System.Drawing.Point(20, 40);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(74, 13);
            this.description_label.TabIndex = 4;
            this.description_label.Text = "%description%";
            // 
            // copy_output_button
            // 
            this.copy_output_button.Enabled = false;
            this.copy_output_button.Location = new System.Drawing.Point(481, 124);
            this.copy_output_button.Name = "copy_output_button";
            this.copy_output_button.Size = new System.Drawing.Size(121, 23);
            this.copy_output_button.TabIndex = 5;
            this.copy_output_button.Text = "Copy generated code";
            this.copy_output_button.UseVisualStyleBackColor = true;
            this.copy_output_button.Click += new System.EventHandler(this.copy_output_button_Click);
            // 
            // log_geneated_text_button
            // 
            this.log_geneated_text_button.AutoSize = true;
            this.log_geneated_text_button.Location = new System.Drawing.Point(481, 153);
            this.log_geneated_text_button.Name = "log_geneated_text_button";
            this.log_geneated_text_button.Size = new System.Drawing.Size(141, 30);
            this.log_geneated_text_button.TabIndex = 6;
            this.log_geneated_text_button.Text = "Show generated code\r\n(degrades performance.)";
            this.log_geneated_text_button.UseVisualStyleBackColor = true;
            this.log_geneated_text_button.CheckedChanged += new System.EventHandler(this.log_geneated_text_button_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.code_tab_page);
            this.tabControl1.Location = new System.Drawing.Point(16, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 236);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(435, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Logs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // code_tab_page
            // 
            this.code_tab_page.Controls.Add(this.groupBox2);
            this.code_tab_page.Location = new System.Drawing.Point(4, 22);
            this.code_tab_page.Name = "code_tab_page";
            this.code_tab_page.Padding = new System.Windows.Forms.Padding(3);
            this.code_tab_page.Size = new System.Drawing.Size(435, 210);
            this.code_tab_page.TabIndex = 1;
            this.code_tab_page.Text = "Code";
            this.code_tab_page.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.output_code_textbox);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 194);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Code";
            // 
            // output_code_textbox
            // 
            this.output_code_textbox.Enabled = false;
            this.output_code_textbox.Location = new System.Drawing.Point(7, 20);
            this.output_code_textbox.Multiline = true;
            this.output_code_textbox.Name = "output_code_textbox";
            this.output_code_textbox.ReadOnly = true;
            this.output_code_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output_code_textbox.Size = new System.Drawing.Size(404, 168);
            this.output_code_textbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.SlateBlue;
            this.label1.Location = new System.Drawing.Point(588, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "by Seve267";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 315);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.log_geneated_text_button);
            this.Controls.Add(this.copy_output_button);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.open_file_button);
            this.Controls.Add(this.program_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "%title%";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.code_tab_page.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label program_title;
        private System.Windows.Forms.Button open_file_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox output_textbox;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.Button copy_output_button;
        private System.Windows.Forms.CheckBox log_geneated_text_button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage code_tab_page;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox output_code_textbox;
        private System.Windows.Forms.Label label1;
    }
}

