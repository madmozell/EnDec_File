using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace EnDec_File
{
    partial class MainForm : Form
    {
        //Completed !!!
        //When clicked, it opens: "Panel_CaesarFileEncrypt" - for encrypting files of any format.
        private void Btn_CaesarEncryptFile_Click(object sender, EventArgs e)
        {
            Panel_CaesarFileEncrypt.Visible = true;
            Panel_CaesarFileEncrypt.Enabled = true;

            Panel_CaesarFileDecrypt.Visible = false;
            Panel_CaesarFileDecrypt.Enabled = false;

            Panel_CaesarText.Visible = false;
            Panel_CaesarText.Enabled = false;
        }

        //Completed !!!
        //Method for encrypting a file based on shifting the bytes of the file using the file path and key (offset).
        private void CaesarEncryptFile(string file_path, string key)
        {
            try
            {
                //Checking whether the value of the variable "key" can be successfully converted to an integer (int).
                if (int.TryParse(key, out int shift))
                {
                    //Reading all bytes from a source file
                    byte[] fileBytes = File.ReadAllBytes(file_path);

                    //Applying a Caesar cipher to every byte
                    for (int i = 0; i < fileBytes.Length; i++)
                    {
                        //"fileBytes[i]" - cast to byte type.
                        //Increments the value of a byte in the fileBytes array by the value of the shift variable, which will be added to each byte in the array.
                        fileBytes[i] = (byte)(fileBytes[i] + shift);
                    }
                    //Getting the path to the encrypted file
                    string encryptedFilePath = Path.ChangeExtension(file_path, ".lvre");
                    //Writing encrypted bytes to a new file
                    File.WriteAllBytes(encryptedFilePath, fileBytes);
                }
                else
                {
                    MessageBox.Show("Cannot convert entered text to number.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        //Completed !!!
        //The visual effect of changing the cursor icon when hovering the cursor while holding RMB with a file.
        private void Panel_CaesarFileEncrypt_DragEnter(object sender, DragEventArgs e)
        {
            SampleDragEnter(e);
        }

        //Completed !!!
        //When you release the cursor with the file, the file path is written to "TB" and the file saving settings panel opens.
        private void Panel_CaesarFileEncrypt_DragDrop(object sender, DragEventArgs e)
        {
            //We get an array of strings with paths to the dragged files.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //Clearing the line
            TB_CaesarPathSaveFileEnc.Text = "";

            //We check that there is at least one file.
            if (files.Length > 0)
            {
                Panel_CaesarSaveFileEnc.Enabled = true;
                Panel_CaesarSaveFileEnc.Visible = true;

                TB_CaesarPathSaveFileEnc.Text = files[0];
            }
        }

        //Completed !!!
        //When you press the button, the file selection explorer opens, the file path is written to "TB" and the file saving settings panel opens.
        private void Btn_CaesarOpenFileEnc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Panel_CaesarSaveFileEnc.Enabled = true;
                Panel_CaesarSaveFileEnc.Visible = true;

                TB_CaesarPathSaveFileEnc.Text = openFileDialog.FileName;
            }
        }

        //Completed !!!
        //When you press the button, the file is encrypted and saved using the method: "CaesarEncryptAllFile"
        private void Btn_SaveEncFile_Click(object sender, EventArgs e)
        {
            CaesarEncryptFile(TB_CaesarPathSaveFileEnc.Text, TB_CaesarKeyEnc.Text);
        }

        //Completed !!!
        //When you click the button, the settings panel for saving the encrypted file closes.
        private void Btn_CaesarCloseSaveFileEnc_Click(object sender, EventArgs e)
        {
            Panel_CaesarSaveFileEnc.Visible = false;
            Panel_CaesarSaveFileEnc.Enabled = false;
        }
    }
}