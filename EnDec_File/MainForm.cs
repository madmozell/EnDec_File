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
            Check_UserDictionary("User_Dictionary.txt");

            //Trithemius cipher is selected by default
            CB_EncryptMethod.SelectedIndex = 1;
        }

        //Completed !!!
        //Checking for the presence of a user file "User_Dictionary.txt" in the directory.
        private void Check_UserDictionary(string file_username)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file_username);

            if (File.Exists(filePath)) return;

            DialogResult result = MessageBox.Show("The user file: \"User_Dictionary.txt\" was not found in the directory. Do you want to create?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    sw.WriteLine("-----");
                    sw.WriteLine("Russian");
                    sw.WriteLine("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя\n");
                    sw.WriteLine("-----");
                    sw.WriteLine("0123456789");
                    sw.WriteLine("01234567890123456789");
                }
                MessageBox.Show("File: \"User_Dictionary.txt\", successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating: \"User_Dictionary.txt\" file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Completed !!!
        // Додавання усіх назв алфавіту то вибору в елемент: "ComboBox alphabets"
        private void Reading_UserDictionary(System.Windows.Forms.ComboBox alphabets) 
        {
            try
            {
                //We clear all the elements that are in the ComboBox.
                alphabets.Items.Clear();

                using (StreamReader reader = new StreamReader("User_Dictionary.txt"))
                {
                    string all_line;
                    while ((all_line = reader.ReadLine()) != null)
                    {
                        //If the string contains the delimiter: "-----"
                        if (all_line.Contains("-----"))
                        {
                            //Read the next line after the delimiter
                            string alphabet_line = reader.ReadLine();
                            if (alphabet_line != null)
                            {
                                //Add the following line to the ComboBox
                                alphabets.Items.Add(alphabet_line);
                            }
                        }
                    }
                    //By default we set the offset to zero - no encryption.
                    alphabets.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        // Зчитування символів алфавіту та запис їх у змінну: "alphabet"
        private void Select_UserAlphabet(ref string alphabet, System.Windows.Forms.ComboBox selected_alphabet)
        {
            using (StreamReader reader = new StreamReader("User_Dictionary.txt"))
            {
                string all_line;

                while ((all_line = reader.ReadLine()) != null)
                {
                    //If the string contains the delimiter "-----".
                    if (all_line.Contains("-----"))
                    {
                        //Read the next line after the delimiter.
                        string select_alphabet = reader.ReadLine();

                        if (select_alphabet != null)
                        {
                            //We check if the following line matches the selected element: "ComboBox".
                            if (select_alphabet == selected_alphabet.SelectedItem.ToString())
                            {
                                //We save the line after the found line into the "alphabet" variable.
                                alphabet = reader.ReadLine();
                                break;
                            }
                        }
                    }
                }
            }
        }

        //Completed !!!
        //Select the encryption method: "Cesar", "Trithemius", "Gamma", "DES", "TripleDes", "AES" ciphers.
        private void CB_EncryptMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CB_EncryptMethod.SelectedIndex)
            {
                case 0:
                    //**** Caesar elements ****
                    Panel_СaesarMainBtn.Visible = true; Panel_СaesarMainBtn.Enabled = true;
                    Panel_CaesarFileEncrypt.Visible = true; Panel_CaesarFileEncrypt.Enabled = true;


                    //Trithemius elements
                    Panel_TrithMainBtn.Visible = false; Panel_TrithMainBtn.Enabled = false;
                    Panel_TrithFileEncrypt.Visible = false; Panel_TrithFileEncrypt.Enabled = false;
                    Panel_TrithFileDecrypt.Visible = false; Panel_TrithFileDecrypt.Enabled = false;
                    Panel_TrithText.Visible = false; Panel_TrithText.Enabled = false;


                    //Gamma elements



                    //DES elements / TripleDes elements



                    //AES elements



                    //Coming Soon (panel)
                    PanelComingSoon.Visible = false;
                    break;

                case 1:
                    //Caesar elements
                    Panel_СaesarMainBtn.Visible = false; Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false; Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false; Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false; Panel_CaesarText.Enabled = false;


                    //**** Trithemius elements ****
                    Panel_TrithMainBtn.Visible = true; Panel_TrithMainBtn.Enabled = true;
                    Panel_TrithFileEncrypt.Visible = true; Panel_TrithFileEncrypt.Enabled = true;

                    //Gamma elements



                    //DES elements / TripleDes elements



                    //AES elements



                    //Coming Soon (panel)
                    PanelComingSoon.Visible = false;
                    break;

                case 2:
                    //Caesar elements
                    Panel_СaesarMainBtn.Visible = false; Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false; Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false; Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false; Panel_CaesarText.Enabled = false;

                    //Trithemius elements
                    Panel_TrithMainBtn.Visible = false; Panel_TrithMainBtn.Enabled = false;
                    Panel_TrithFileEncrypt.Visible = false; Panel_TrithFileEncrypt.Enabled = false;
                    Panel_TrithFileDecrypt.Visible = false; Panel_TrithFileDecrypt.Enabled = false;
                    Panel_TrithText.Visible = false; Panel_TrithText.Enabled = false;


                    //**** Gamma elements ****



                    //DES elements / TripleDes elements



                    //AES elements



                    //Coming Soon (panel)
                    PanelComingSoon.Visible = true;
                    break;

                case 3:
                    //Caesar elements
                    Panel_СaesarMainBtn.Visible = false; Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false; Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false; Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false; Panel_CaesarText.Enabled = false;

                    //Trithemius elements
                    Panel_TrithMainBtn.Visible = false; Panel_TrithMainBtn.Enabled = false;
                    Panel_TrithFileEncrypt.Visible = false; Panel_TrithFileEncrypt.Enabled = false;
                    Panel_TrithFileDecrypt.Visible = false; Panel_TrithFileDecrypt.Enabled = false;
                    Panel_TrithText.Visible = false; Panel_TrithText.Enabled = false;

                    //Gamma elements



                    //**** DES elements / TripleDes elements ****



                    //AES elements



                    //Coming Soon (panel)
                    PanelComingSoon.Visible = true;
                    break;

                case 4:
                    //Caesar elements
                    Panel_СaesarMainBtn.Visible = false; Panel_СaesarMainBtn.Enabled = false;
                    Panel_CaesarFileEncrypt.Visible = false; Panel_CaesarFileEncrypt.Enabled = false;
                    Panel_CaesarFileDecrypt.Visible = false; Panel_CaesarFileDecrypt.Enabled = false;
                    Panel_CaesarText.Visible = false; Panel_CaesarText.Enabled = false;

                    //Trithemius elements
                    Panel_TrithMainBtn.Visible = false; Panel_TrithMainBtn.Enabled = false;
                    Panel_TrithFileEncrypt.Visible = false; Panel_TrithFileEncrypt.Enabled = false;
                    Panel_TrithFileDecrypt.Visible = false; Panel_TrithFileDecrypt.Enabled = false;
                    Panel_TrithText.Visible = false; Panel_TrithText.Enabled = false;


                    //Gamma elements



                    //DES elements / TripleDes elements



                    //**** AES elements ****



                    //Coming Soon (panel)
                    PanelComingSoon.Visible = true;
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