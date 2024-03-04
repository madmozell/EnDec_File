using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnDec_File
{
    partial class MainForm : Form
    {
        //A variable that displays the characters of the selected alphabet.
        string all_char_alphabet;

        //Completed !!!
        //A method for storing hand-written ciphertext.
        private void CaesarSaveTextToFile(string save_text)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                //Setting SaveFileDialog Options.
                saveFileDialog.Title = "Save text file";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 1;

                //Open the file saving window and wait for the user to select a save location.
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //Getting the path to the selected save location.
                    string saveFilePath = saveFileDialog.FileName;

                    //Getting text from TextBox.
                    string textBoxText = save_text;

                    try
                    {
                        //Save the text to a file.
                        File.WriteAllText(saveFilePath, $"{textBoxText}");

                        //Open the MessageBox with confirmation of saving.
                        MessageBox.Show($"The file was successfully saved to:\n{saveFilePath}", "Saving complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Completed !!!
        //The method is used in the event: when the visibility of an element changes: "Panel_CaesarSaveFileEnc"
        private void ReadingUserDictionaryAlphabet()
        {
            try
            {
                //We clear all the elements that are in the ComboBox.
                CB_CaesarSelectAlphabet.Items.Clear();

                using (StreamReader reader = new StreamReader("Caesar_User_Dictionary.txt"))
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
                                CB_CaesarSelectAlphabet.Items.Add(alphabet_line);
                            }
                        }
                    }
                    //By default we set the offset to zero - no encryption.
                    CB_CaesarSelectAlphabet.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        //Completed !!!
        //Adds elements for offset based on the selected alphabet in the list by method to the element: "Panel_CaesarConvert".
        private void Caesar_CipherCalculateText()
        {
            //Assigning a string variable the value (text) of the selected alphabet.
            char[] originalChars = TB_CaesarUserText.Text.ToCharArray();

            //Clearing all elements on the panel: "Panel_CaesarConvert"
            Panel_CaesarConvert.Controls.Clear();

            //Variable to store the current alphabet
            string alphabet;

            using (StreamReader reader = new StreamReader("Caesar_User_Dictionary.txt"))
            {
                string all_line;

                while ((all_line = reader.ReadLine()) != null)
                {
                    //If the string contains the delimiter "-----".
                    if (all_line.Contains("-----"))
                    {
                        //Read the next line after the delimiter.
                        string selected_alphabet = reader.ReadLine();

                        if (selected_alphabet != null)
                        {
                            //We check if the following line matches the selected element: "ComboBox".
                            if (selected_alphabet == CB_CaesarSelectAlphabet.SelectedItem.ToString())
                            {
                                //We save the line after the found line into the "alphabet" variable.
                                alphabet = reader.ReadLine();

                                //Element options: Label and TextBox.
                                int X = 5;
                                int Y = 10;
                                int label_Width = 80;
                                int label_Height = 25;
                                int TB_Width = 435;
                                int TB_Height = 25;

                                //Fixed creation of Label and TextBox elements and filling of encryptedText.
                                for (int i = 0; i < alphabet.Length / 2; i++)
                                {
                                    char[] encryptedChars = new char[originalChars.Length];

                                    for (int q = 0; q < originalChars.Length; q++)
                                    {
                                        char currentChar = originalChars[q];
                                        int index = alphabet.IndexOf(currentChar);
                                        all_char_alphabet = alphabet;

                                        if (index != -1)
                                        {
                                            //Calculating the Caesar Cipher Index using ternary operators.
                                            /*The variable: "encryptedIndex" is assigned the result of an arithmetic operation.
                                             * "index" is the index of the current character in the alphabet, to which the variable is added: "i".
                                             * Then we take the remainder of the sum (%) of the sum of the variables: "index" + "i" by the length of the array: "alphabet" 
                                             * to ensure cyclic access to the elements of the alphabet when the sum exceeds the length of the alphabet.
                                             * The result is then assigned to the encryptedIndex variable.*/
                                            int encryptedIndex = (index + i) % alphabet.Length;
                                            //To the variable: "encryptedChar" we assign a character from the alphabet, which is located at the index: "encryptedIndex".
                                            char encryptedChar = alphabet[encryptedIndex];
                                            //Determine whether the encrypted character will be uppercase or lowercase, depending on the original character: "currentChar".
                                            encryptedChars[q] = char.IsUpper(currentChar) ? char.ToUpper(encryptedChar) : char.IsLower(currentChar) ? char.ToLower(encryptedChar) : encryptedChar;
                                        }
                                        else
                                        {
                                            //The symbol is not found in the alphabet, we leave it unchanged.
                                            encryptedChars[q] = currentChar;
                                        }
                                    }
                                    string[] encryptedText = new string[alphabet.Length];
                                    encryptedText[i] = new string(encryptedChars);

                                    //Creating and customizing up a Label.
                                    Label label = new Label
                                    {
                                        Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                                        ForeColor = SystemColors.ControlDarkDark,
                                        Name = $"Lbl_Shift{i}",
                                        Text = $"ROT {i}:",
                                        Size = new Size(label_Width, label_Height),
                                        Location = new Point(X, Y + i * (label_Height + 5)), //5 - distance between elements.
                                        TextAlign = ContentAlignment.MiddleLeft
                                    };
                                    //Adding an element to the panel.
                                    Panel_CaesarConvert.Controls.Add(label);

                                    //Creating and customizing a TextBox.
                                    System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox
                                    {
                                        Font = new Font("Times New Roman", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204))),
                                        Multiline = true,
                                        ReadOnly = true,
                                        ScrollBars = ScrollBars.Vertical,
                                        Name = $"TB_Converse{i}",
                                        Text = encryptedText[i],
                                        Size = new Size(TB_Width, TB_Height),
                                        Location = new Point(label_Width + 5, Y + i * (TB_Height + 5)) //5 - distance between elements.
                                    };
                                    //Adding an element to the panel.
                                    Panel_CaesarConvert.Controls.Add(textBox);
                                }
                            }
                        }
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Completed !!!
        //When clicked, it opens: "Panel_CesarText" - for manually writing text and executes the method: "ReadingUserDictionaryAlphabet".
        private void Btn_CaesarText_Click(object sender, EventArgs e)
        {
            Panel_CaesarText.Visible = true;
            Panel_CaesarText.Enabled = true;

            Panel_CaesarFileDecrypt.Visible = false;
            Panel_CaesarFileDecrypt.Enabled = false;

            Panel_CaesarFileEncrypt.Visible = false;
            Panel_CaesarFileEncrypt.Enabled = false;

            ReadingUserDictionaryAlphabet();
        }

        //Completed !!!
        //The effect when dragging (hovering the cursor with a file) on an element...
        private void TB_CaesarUserText_DragEnter(object sender, DragEventArgs e)
        {
            SampleDragEnter(e);
        }

        //Completed !!!
        //When you release the RMB with a file, the file text is written to the element: "TB_CaesarUserText"
        private void TB_CaesarUserText_DragDrop(object sender, DragEventArgs e)
        {
            //We get a list of dragged files.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //We check that the first file has the extension .txt.
            if (files.Length > 0 && Path.GetExtension(files[0]).Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                //Reading the contents of the file.
                string file_text = File.ReadAllText(files[0]);
                TB_CaesarUserText.Text = file_text;
            }
        }

        //Completed !!!
        //A visual effect that displays tooltip text in an element: "TB_CaesarUserText"
        private void TB_CaesarUserText_Enter(object sender, EventArgs e)
        {
            //Event handler when entering a TextBox
            if (TB_CaesarUserText.Text == "Enter text manually or drag and drop a .txt file ...")
            {
                TB_CaesarUserText.Text = ""; //Clear the text if it is equal to "Enter text"
            }
        }
        private void TB_CaesarUserText_Leave(object sender, EventArgs e)
        {
            //Event handler when exiting a TextBox.
            if (string.IsNullOrWhiteSpace(TB_CaesarUserText.Text))
            {
                //We restore the text if it is empty.
                TB_CaesarUserText.Text = "Enter text manually or drag and drop a .txt file ...";
            }
        }

        //Completed !!!
        //Increase custom text font.
        private void Btn_IncreaseFontSize_Click(object sender, EventArgs e)
        {
            TB_CaesarUserText.Font = new Font(TB_CaesarUserText.Font.FontFamily, TB_CaesarUserText.Font.Size + 2);
        }

        //Completed !!!
        //Reduce custom text font size.
        private void Btn_DecreaseFontSize_Click(object sender, EventArgs e)
        {
            TB_CaesarUserText.Font = new Font(TB_CaesarUserText.Font.FontFamily, TB_CaesarUserText.Font.Size - 2);
        }

        //Completed !!!
        //Selecting a text file to read and copy text into the field: "TB_CaesarUserText"
        private void Btn_CaesarOpenFile_Click(object sender, EventArgs e)
        {
            //Event handler when the "Open file" button is clicked.
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //Setting OpenFileDialog Options.
                openFileDialog.Title = "Select text file to read";

                //Open File Explorer and wait for the user to select a file.
                DialogResult openFileResult = openFileDialog.ShowDialog();

                if (openFileResult == DialogResult.OK)
                {
                    try
                    {
                        // Display a MessageBox to ask the user for the desired encoding.
                        DialogResult encodingResult = MessageBox.Show("In which encoding do you want to read the file?\n\nYES - 1251,\nNO - UTF8", "Select Encoding", MessageBoxButtons.YesNoCancel);

                        if (encodingResult == DialogResult.Cancel)
                        {
                            // User cancelled the operation.
                            return;
                        }

                        //Getting the path to the selected file.
                        string selectedFilePath = openFileDialog.FileName;
                        // Choosing the encoding based on the user's selection.
                        Encoding selectedEncoding = encodingResult == DialogResult.Yes ? Encoding.GetEncoding(1251) : Encoding.UTF8;
                        // Reading the file using the selected encoding.
                        string fileContent = File.ReadAllText(selectedFilePath, selectedEncoding);

                        // Setting the contents of the file in the TextBox.
                        TB_CaesarUserText.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Completed !!!
        //Calculate all offsets of the entered text and display offset options on the screen.
        private void Btn_CaesarCalculate_Click(object sender, EventArgs e)
        {
            Caesar_CipherCalculateText();
        }

        //Completed !!!
        //When clicked, the settings panel for saving encrypted user text opens.
        private void Btn_CaesarSave_Click(object sender, EventArgs e)
        {
            Caesar_CipherCalculateText();

            Panel_CaesarSavingText.Enabled = true;
            Panel_CaesarSavingText.Visible = true;

            CB_CaesarSelectConverse.Items.Clear();

            Lbl_17.Text = CB_CaesarSelectAlphabet.SelectedItem.ToString();

            for (int i = 0; i <= (all_char_alphabet.Length - 1) / 2; i++)
            {
                CB_CaesarSelectConverse.Items.Add($"ROT {i}:");
            }
            CB_CaesarSelectConverse.SelectedIndex = 0;
        }

        //Completed !!!
        //When changing the ComboBox index, the text with the selected offset in the selected alphabet is displayed.
        private void CB_CaesarSelectConverse_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_CaesarCipherSave.Text = "";
            string textBoxName = $"TB_Converse{CB_CaesarSelectConverse.SelectedIndex}";
            Control[] foundControls = Panel_CaesarConvert.Controls.Find(textBoxName, true);

            if (foundControls.Length > 0 && foundControls[0] is System.Windows.Forms.TextBox textBox)
            {
                TB_CaesarCipherSave.Text = textBox.Text;
            }
            else
            {
                TB_CaesarCipherSave.Text = "";
                MessageBox.Show("There is no text with this offset (shift)...");
            }
        }

        //Completed !!!
        //Saves the text from the "TB_CaesarCipherSave" element to a .txt file
        private void Btn_CaesarSaveFile_Click(object sender, EventArgs e)
        {
            CaesarSaveTextToFile(TB_CaesarCipherSave.Text);
        }

        //Completed !!!
        //When clicked, the panel for saving the offset of the typed custom text in the selected alphabet closes.
        private void Btn_CaesarCloseSavingTextPanel_Click(object sender, EventArgs e)
        {
            Panel_CaesarSavingText.Enabled = false;
            Panel_CaesarSavingText.Visible = false;
        }
    }
}