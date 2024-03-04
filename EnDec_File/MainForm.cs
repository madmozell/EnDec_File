using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnDec_File
{
    partial class MainForm : Form
    {
        //Completed !!!
        //Static class with entry point (method "Main()")
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }

        //Completed !!!
        //When initializing form components, a check is made for the presence of a user file: "Caesar_User_Dictionary.txt" in the directory.
        private MainForm()
        {
            InitializeComponent();
            Check_UserFile("Caesar_User_Dictionary.txt");
        }

        //Completed !!!
        //Checking for the presence of a user file "Caesar_User_Dictionary.txt" in the directory.
        private void Check_UserFile(string file_username)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file_username);

            if (File.Exists(filePath)) return;

            DialogResult result = MessageBox.Show("The user file was not found in the directory. Do you want to create?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("You can add your own alphabet to this file. To add your own alphabet, you need to write the following lines to the file:");
                    sw.WriteLine("1. Announce the creation of the alphabet;");
                    sw.WriteLine("2. Write the names of your alphabet: \"English\";");
                    sw.WriteLine("3. Write down all the characters of the alphabet, taking into account upper and lower case: \"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\";\n");
                    sw.WriteLine("-----");
                    sw.WriteLine("English");
                    sw.WriteLine("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\n");
                    sw.WriteLine("-----");
                    sw.WriteLine("Ukrainian");
                    sw.WriteLine("АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгґдеєжзиіїйклмнопрстуфхцчшщьюя\n");
                }
                MessageBox.Show("File: Caesar_User_Dictionary.txt, successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating Caesar_User_Dictionary.txt file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Completed !!!
        //Select the encryption method: "Cesar", "Trithemius", "Gamma", "DES", "TripleDes", "AES" ciphers.
        private void CB_EncryptMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CB_EncryptMethod.SelectedIndex)
            {
                case 0:
                    //PanelComingSoon.Visible = false;
                    Panel_СaesarMainBtn.Visible = true;
                    Panel_СaesarMainBtn.Enabled = true;
                    Panel_CaesarFileEncrypt.Visible = true;
                    Panel_CaesarFileEncrypt.Enabled = true;
                    break;
                case 1:
                    Panel_СaesarMainBtn.Visible = false;
                    Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false;
                    Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false;
                    Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false;
                    Panel_CaesarText.Enabled = false;
                    //PanelComingSoon.Visible = true;
                    break;
                case 2:
                    Panel_СaesarMainBtn.Visible = false;
                    Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false;
                    Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false;
                    Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false;
                    Panel_CaesarText.Enabled = false;
                    //PanelComingSoon.Visible = true;
                    break;
                case 3:
                    Panel_СaesarMainBtn.Visible = false;
                    Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false;
                    Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false;
                    Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false;
                    Panel_CaesarText.Enabled = false;
                    //PanelComingSoon.Visible = true;
                    break;
                case 4:
                    Panel_СaesarMainBtn.Visible = false;
                    Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false;
                    Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false;
                    Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false;
                    Panel_CaesarText.Enabled = false;
                    //PanelComingSoon.Visible = true;
                    break;
                case 5:
                    Panel_СaesarMainBtn.Visible = false;
                    Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false;
                    Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false;
                    Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false;
                    Panel_CaesarText.Enabled = false;
                    //PanelComingSoon.Visible = true;
                    break;
            }
        }

        //Completed !!!
        //Display a message with information about the author.
        private void Btn_AuthorInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dnipro University of Technology\r\n\r\nPerformed by:\r\nstudent of group 125m-23-1\r\nBryla K.S.\r\n\r\nDnipro – 2024", "AUTHOR INFORMATION");
        }

        private void LLbl_Version_LinkClicked(object sender, EventArgs e) 
        {
            Process.Start("https://github.com/madmozell/EnDec_File");
        }

        //Completed !!!
        //Effects when dragging (hovering the cursor with a file) onto an element...
        private void SampleDragEnter(DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }
}