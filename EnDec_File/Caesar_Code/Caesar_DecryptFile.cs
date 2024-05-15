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
        //When clicked, it opens: "Panel_CaesarFileDecrypt" - for decrypting files of any format.
        private void Btn_CaesarDecryptFile_Click(object sender, EventArgs e)
        {
            Panel_CaesarFileDecrypt.Visible = true;
            Panel_CaesarFileDecrypt.Enabled = true;

            Panel_CaesarFileEncrypt.Visible = false;
            Panel_CaesarFileEncrypt.Enabled = false;

            Panel_CaesarText.Visible = false;
            Panel_CaesarText.Enabled = false;
        }

        //Completed !!!
        //A method to decrypt a file based on a byte shift of the file, using the file path and key (offset).
        private void CaesarDecryptFile(string file_path, string key)
        {
            //If the user chose the "brute force" option, then this code is executed:
            if (CheckBox_CaesarEnumerateAllCipher.Checked == true)
            {
                try
                {
                    byte[] fileBytes = File.ReadAllBytes(file_path);
                    string decryptedFolder = Path.Combine(Path.GetDirectoryName(file_path), "Caesar_Decrypted_File");
                    Directory.CreateDirectory(decryptedFolder); //Creating a folder if it doesn't exist.

                    for (int shift = 0; shift < 256; shift++) //Enumerating all possible shifts.
                    {
                        byte[] decryptedBytes = new byte[fileBytes.Length]; //An array of bytes is created that contains the decrypted data, and the size of this array corresponds to the size of the source file.

                        for (int i = 0; i < fileBytes.Length; i++)//A loop that goes through each byte of the source file.
                        {
                            //Each byte of the original file is encrypted by subtracting a shift.
                            //A modulus operation is applied to ensure that the result remains in the range 0 to 255.
                            //The decrypted byte is stored in the corresponding array position.
                            decryptedBytes[i] = (byte)((fileBytes[i] - shift + 256) % 256);
                        }
                        //The path to save the decrypted file is generated.
                        //Options for decrypted files are located in the "decryptedFolder" folder.
                        string decryptedFilePath = Path.Combine(decryptedFolder, Path.GetFileNameWithoutExtension(file_path) + $"_{shift}" + ".lvrd");
                        File.WriteAllBytes(decryptedFilePath, decryptedBytes);
                    }
                }
                //Error processing...
                catch (Exception ex)
                {
                    MessageBox.Show("Error decrypting file: " + ex.Message);
                }
            }
            //Otherwise, if the user knows the key to the encrypted file, then the following code is executed:
            else
            {
                try
                {
                    if (int.TryParse(key, out int shift))
                    {
                        //Reading all bytes from an encrypted file
                        byte[] fileBytes = File.ReadAllBytes(file_path);

                        //Applying a reverse Caesar cipher to every byte
                        for (int i = 0; i < fileBytes.Length; i++)
                        {
                            fileBytes[i] = (byte)(fileBytes[i] - shift);
                        }
                        //Getting the path to the decrypted file
                        string decryptedFilePath = Path.ChangeExtension(file_path, ".lvrd");
                        //Writing decrypted bytes to a new file
                        File.WriteAllBytes(decryptedFilePath, fileBytes);
                    }
                    else
                    {
                        MessageBox.Show("The entered text cannot be converted to a number.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error decrypting file: " + ex.Message);
                }
            }
        }

        //Completed !!!
        //The visual effect of changing the cursor icon when hovering the cursor while holding RMB with a file.
        private void Panel_CaesarFileDecrypt_DragEnter(object sender, DragEventArgs e)
        {
            SampleDragEnter(e);
        }

        //Completed !!!
        //When you release the cursor with the file, the file path is written to "TB" and the file saving settings panel opens.
        private void Panel_CaesarFileDecrypt_DragDrop(object sender, DragEventArgs e)
        {
            //We get an array of strings with paths to the dragged files.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //Clearing the line ()
            TB_CaesarPathSaveFileDecrypt.Text = "";

            //We check that there is at least one file.
            if (files.Length > 0)
            {
                Panel_CaesarSaveFileDec.Enabled = true;
                Panel_CaesarSaveFileDec.Visible = true;

                TB_CaesarPathSaveFileDecrypt.Text = files[0];
            }
        }

        //Completed !!!
        //When you press the button, the file selection explorer opens, the file path is written to "TB" and the file saving settings panel opens.
        private void Btn_CaesarOpenFileDec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Panel_CaesarSaveFileDec.Enabled = true;
                Panel_CaesarSaveFileDec.Visible = true;

                TB_CaesarPathSaveFileDecrypt.Text = openFileDialog.FileName;
            }
        }

        //Completed !!!
        //When pressed, it activates the function of searching through all file decryption options.
        private void CheckBox_CaesarEnumerateAllCipher_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_CaesarEnumerateAllCipher.Checked == true)
            {
                TB_CaesarKeyDecrypt.ReadOnly = true;
                TB_CaesarKeyDecrypt.Text = "Looping through all offsets...";
            }
            else
            {
                TB_CaesarKeyDecrypt.ReadOnly = false;
                TB_CaesarKeyDecrypt.Text = "";
            }
        }

        //Completed !!!
        //When you press the button, the file is decrypted and saved using the method: "CaesarEncryptAllFile"
        private void Btn_SaveDecFile_Click(object sender, EventArgs e)
        {
            CaesarDecryptFile(TB_CaesarPathSaveFileDecrypt.Text, TB_CaesarKeyDecrypt.Text);
        }

        //Completed !!!
        //When you press the button, the settings panel for saving the decrypted file closes.
        private void Btn_CaesarCloseSaveFileDec_Click(object sender, EventArgs e)
        {
            Panel_CaesarSaveFileDec.Enabled = false;
            Panel_CaesarSaveFileDec.Visible = false;
        }
    }
}