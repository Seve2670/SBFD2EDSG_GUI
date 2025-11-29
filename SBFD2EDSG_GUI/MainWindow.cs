using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SBFD2EDSG_GUI
{
    public partial class MainWindow : Form
    {
        public static string pb_program_name = "SBFD2EDSG_GUI";
        public string pb_filePath = String.Empty;
        public string pb_fileName = String.Empty;
        public static bool codeGenerated = false;

        public MainWindow()
        {
            InitializeComponent();
            program_title.Text = pb_program_name;
            this.Text = pb_program_name;
            output_textbox.Text += pb_program_name + " Initialized.\r\n";
            description_label.Text = "Sanny Builder Tool: File Data To Embedded Code Script Generator (GUI)";
            output_code_textbox.Text = "'Show generated code' option is disabled.\r\nAutomatically cleared this log when enabled.";
        }

        private void WRITE_LOG_TEXT_TO_OUTPUT(string input)
        {
            output_textbox.Text += input;
            Console.Write(output_textbox.Text);
        }

        private void WRITELINE_LOG_TEXT_TO_OUTPUT(string input)
        {
            output_textbox.Text += input + "\r\n";
            Console.WriteLine(output_textbox.Text);
        }

        private void WRITE_CODE_LOG_TEXT_TO_OUTPUT(string input)
        {
            output_code_textbox.Text += input;
            Console.Write(output_code_textbox.Text);
        }

        private void WRITELINE_CODE_LOG_TEXT_TO_OUTPUT(string input)
        {
            output_code_textbox.Text += input + "\r\n";
            Console.WriteLine(output_code_textbox.Text);
        }

        private void open_file_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pb_filePath = openFileDialog.FileName;
                    pb_fileName = openFileDialog.SafeFileName;
                    WRITELINE_LOG_TEXT_TO_OUTPUT("File opened: " + pb_filePath);

                    //LoadingForm loadingForm = new LoadingForm();
                    ///loadingForm.ShowDialog();

                    if (!BEGIN_PROCESS(pb_filePath, pb_fileName))
                    {
                        WRITELINE_LOG_TEXT_TO_OUTPUT("Failed, Empty file.");
                    }

                    copy_output_button.Enabled = true;

                    if (log_geneated_text_button.Checked == true)
                    {
                        WRITELINE_CODE_LOG_TEXT_TO_OUTPUT(output_buffer);
                    }

                    codeGenerated = true;
                    //loadingForm.

                }

            }
        }

        public static string output_buffer;
        public static int output_buffer_len;
        private static int count; // max 15

        public bool BEGIN_PROCESS(string filePath, string fileName)
        {
            string a_output_buffer = String.Empty;
            a_output_buffer += ":" + fileName;
            output_buffer = a_output_buffer.Replace('.', '_');
            output_buffer = _NEXT_LINE(output_buffer);
            output_buffer += "hex";
            output_buffer = _NEXT_LINE(output_buffer);
            string b_output_buffer = _READ_DATA_TO_STRING(filePath);

            if (b_output_buffer == "")
            {
                return false;
            }

            output_buffer += b_output_buffer;
            output_buffer = _NEXT_LINE(output_buffer);
            output_buffer += "end";

            
            //WRITELINE_LOG_TEXT_TO_OUTPUT(output_buffer);
            return true;
        }

        private string _READ_DATA_TO_STRING(string filePath)
        {
            string hexStringBuffer = String.Empty;

            try
            {
                using (FileStream targetFile = new FileStream(filePath, FileMode.Open))
                {
                    #region ...Reading procedure code
                    long fileLen = targetFile.Length;
                    // File buffer
                    byte[] buffer = new byte[fileLen];

                    targetFile.Read(buffer, 0, (int)fileLen);

                    

                    for (int i = 0; i < fileLen; i++)
                    {
                        object a_buffer = buffer.GetValue(i);
                        int number = Convert.ToInt32(a_buffer);
                        string b_buffer;
                        b_buffer = String.Format("{0:X}", number);

                        if (count == 0)
                        {
                            hexStringBuffer += " ";
                        }

                        hexStringBuffer += b_buffer;
                        hexStringBuffer += " ";

                        if (count > 14)
                        {
                            hexStringBuffer += "\r\n";
                            count = -1;
                        }

                        count += 1;
                    }

                    targetFile.Close();
                    
                    #endregion
                }
                
            }
            catch (Exception e)
            {
                WRITELINE_LOG_TEXT_TO_OUTPUT("Exception occured:");
                WRITELINE_LOG_TEXT_TO_OUTPUT(e.Message);
            }

            return hexStringBuffer;
        }

        static string StringToHex(string input)
        {
            // Convert string to byte array
            byte[] byteArray = Encoding.UTF8.GetBytes(input);

            // Convert byte array to hexadecimal string
            StringBuilder hexBuilder = new StringBuilder();
            foreach (byte b in byteArray)
            {
                hexBuilder.Append(b.ToString("X2")); // X2 ensures two-digit representation
            }

            return hexBuilder.ToString();
        }

        private string _NEXT_LINE(string output_buffer)
        {
            output_buffer += "\r\n";
            return output_buffer;
        }

        private void copy_output_button_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(output_buffer);
        }

        private void log_geneated_text_button_CheckedChanged(object sender, EventArgs e)
        {
            if (log_geneated_text_button.Checked == false)
            {
                output_code_textbox.Text = "'Show generated code' option is disabled.\r\nAutomatically cleared this log when enabled.";
                output_code_textbox.Enabled = false;
                return;
            }

            if (codeGenerated == true)
            {
                output_code_textbox.Text = String.Empty;
                WRITE_CODE_LOG_TEXT_TO_OUTPUT(output_buffer);
                output_code_textbox.Enabled = true;
                return;
            }

            output_code_textbox.Text = String.Empty;
            output_code_textbox.Enabled = true;
        }
    }
}
