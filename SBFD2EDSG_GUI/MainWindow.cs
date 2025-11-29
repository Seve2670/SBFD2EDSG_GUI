// v.1.1.0
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
        public static string output_buffer = String.Empty;
        public static int output_buffer_len = 0;
        private static int a_readcount = 0; // max 15

        public MainWindow()
        {
            InitializeComponent();
            program_title.Text = pb_program_name;
            this.Text = pb_program_name;
            output_textbox.Text += pb_program_name + " Initialized.\r\n";
            description_label.Text = "Sanny Builder Code Generator Tool: File Embedder tool (GUI)";
        }

        private void WRITE_LOG_TEXT_TO_OUTPUT(string input)
        {
            output_textbox.Text += input;
        }

        private void WRITELINE_LOG_TEXT_TO_OUTPUT(string input)
        {
            output_textbox.Text += input + "\r\n";
        }

        private void WRITE_CODE_LOG_TEXT_TO_OUTPUT(string input)
        {
            output_code_textbox.Text += input;
        }

        private void WRITELINE_CODE_LOG_TEXT_TO_OUTPUT(string input)
        {
            output_code_textbox.Text += input + "\r\n";
        }

        private void CLEAR_CODE_LOG_TEXT()
        {
            output_code_textbox.Text = String.Empty;
        }

        private void CLEAR_LOG_TEXT()
        {
            output_textbox.Text = String.Empty;
        }

        private void open_file_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string a_pb_filePath = openFileDialog.FileName;
                    string a_pb_fileName = openFileDialog.SafeFileName;

                    foreach (char c in a_pb_fileName)
                    {
                        if (c > 127)
                        {
                            WRITELINE_LOG_TEXT_TO_OUTPUT("Error, File name with containing a Unicode character is not supported.");
                            return;
                        }
                    }

                    try
                    {
                        using (FileStream a_tempfile = new FileStream(a_pb_filePath, FileMode.Open))
                        {
                            long a_temp_len = a_tempfile.Length;

                            if (a_temp_len >= 33344)
                            {
                                DialogResult mbox_temp_result = MessageBox.Show("The selected file size is larger than 32KB (Kilobytes),\r\nDo you want to continue?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (mbox_temp_result == DialogResult.No)
                                {
                                    a_pb_filePath = String.Empty;
                                    a_pb_fileName = String.Empty;
                                    a_temp_len = 0;
                                    a_tempfile.Close();
                                    return;
                                }
                            }

                            a_temp_len = 0;
                            a_tempfile.Close();
                        }

                    }
                    catch (Exception exp)
                    {
                        WRITELINE_LOG_TEXT_TO_OUTPUT("Exception occured:");
                        WRITELINE_LOG_TEXT_TO_OUTPUT(exp.Message);
                        return;
                    }


                    a_pb_filePath = String.Empty;
                    a_pb_fileName = String.Empty;

                    pb_filePath = openFileDialog.FileName;
                    pb_fileName = openFileDialog.SafeFileName;
                    WRITELINE_LOG_TEXT_TO_OUTPUT("File opened: " + pb_filePath);

                    if (!BEGIN_PROCESS(pb_filePath, pb_fileName))
                    {
                        WRITELINE_LOG_TEXT_TO_OUTPUT("Failed.");
                        return;
                    }

                    CLEAR_CODE_LOG_TEXT();
                    copy_output_button.Enabled = true;

                    if (log_geneated_text_button.Checked == true)
                    {
                        WRITELINE_CODE_LOG_TEXT_TO_OUTPUT(output_buffer);
                    }

                    regenerate_button.Enabled = true;
                    codeGenerated = true;

                }

            }
        }

        public bool BEGIN_PROCESS(string filePath, string fileName)
        {
            output_buffer = String.Empty;
            string a_output_buffer = String.Empty;
            a_readcount = 0;

            if (filter0_checkbox.Checked == true)
            {
                goto read_data;
            }

            a_output_buffer += ":" + fileName;

            // File name twister
            output_buffer = a_output_buffer.Replace('.', '_');
            output_buffer = output_buffer.Replace(' ', '_');
            output_buffer = output_buffer.Replace('\x27', '_'); // '
            output_buffer = output_buffer.Replace('\x3B', '_'); // ;
            output_buffer = output_buffer.Replace('\x2B', '_'); // +
            output_buffer = output_buffer.Replace('\x2D', '_'); // -
            output_buffer = output_buffer.Replace('\x3D', '_'); // =
            output_buffer = output_buffer.Replace('\x7B', '_'); // {
            output_buffer = output_buffer.Replace('\x5B', '_'); // [
            output_buffer = output_buffer.Replace('\x5D', '_'); // ]
            output_buffer = output_buffer.Replace('\x7D', '_'); // }
            output_buffer = output_buffer.Replace('\x28', '_'); // (
            output_buffer = output_buffer.Replace('\x29', '_'); // )
            output_buffer = output_buffer.Replace('\x21', '_'); // !
            output_buffer = output_buffer.Replace('\x40', '_'); // @
            output_buffer = output_buffer.Replace('\x23', '_'); // #
            output_buffer = output_buffer.Replace('\x24', '_'); // $
            output_buffer = output_buffer.Replace('\x25', '_'); // %
            output_buffer = output_buffer.Replace('\x5E', '_'); // ^
            output_buffer = output_buffer.Replace('\x26', '_'); // &
            output_buffer = output_buffer.Replace('\x60', '_'); // `
            output_buffer = output_buffer.Replace('\x7E', '_'); // ~

            output_buffer = _NEXT_LINE(output_buffer);
            output_buffer += "hex";
            output_buffer = _NEXT_LINE(output_buffer);

            read_data:
            string b_output_buffer = _READ_DATA_TO_STRING(filePath);

            if (b_output_buffer == "")
            {
                return false;
            }

            output_buffer += b_output_buffer;
            output_buffer = _NEXT_LINE(output_buffer);

            if (filter0_checkbox.Checked == true)
            {
                goto end_data;
            }

            output_buffer += "end";
            end_data:
            
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

                    // Data buffer
                    byte[] buffer = new byte[fileLen];

                    targetFile.Read(buffer, 0, (int)fileLen);

                    // Reading procedure, writing in the string output buffer.
                    // Reads slowest, 20KBps I guess.
                    // Reading speed, depending on the system speed.
                    for (int i = 0; i < fileLen; i++)
                    {
                        object a_buffer = buffer.GetValue(i);
                        int number = Convert.ToInt32(a_buffer);
                        string b_buffer;
                        b_buffer = String.Format("{0:X}", number);

                        if (a_readcount == 0)
                        {
                            hexStringBuffer += " ";
                        }

                        hexStringBuffer += b_buffer;
                        hexStringBuffer += " ";

                        if (a_readcount > 14)
                        {
                            hexStringBuffer += "\r\n";
                            a_readcount = -1;
                        }

                        a_readcount += 1;
                    }

                    // Finally.
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

        private string _NEXT_LINE(string output_buffer)
        {
            output_buffer += "\r\n";
            return output_buffer;
        }

        private void copy_output_button_Click(object sender, EventArgs e)
        {
            // Clipboard control
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

        private void regenerate_button_Click(object sender, EventArgs e)
        {
            if (!BEGIN_PROCESS(pb_filePath, pb_fileName))
            {
                WRITELINE_LOG_TEXT_TO_OUTPUT("Regenerate Failed.");
                codeGenerated = false;
                return;
            }

            CLEAR_CODE_LOG_TEXT();
            WRITE_CODE_LOG_TEXT_TO_OUTPUT(output_buffer);
            WRITELINE_LOG_TEXT_TO_OUTPUT("Regenerated.");
        }

        private void clear_logs_button_Click(object sender, EventArgs e)
        {
            CLEAR_LOG_TEXT();
        }
    }
}
