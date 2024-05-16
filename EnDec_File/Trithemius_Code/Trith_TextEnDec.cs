using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Linq;

namespace EnDec_File
{
    partial class MainForm : Form
    {
        // Основні методи шифрування та дешифрування

        //Метод для відкриття панелі з елементами управління: "Panel_TrithText"
        private void Btn_TrithText_Click(object sender, EventArgs e)
        {
            Panel_TrithText.Visible = true;
            Panel_TrithText.Enabled = true;

            Panel_TrithFileDecrypt.Visible = false;
            Panel_TrithFileDecrypt.Enabled = false;

            Panel_TrithFileEncrypt.Visible = false;
            Panel_TrithFileEncrypt.Enabled = false;

            Panel_TrithAttack.Visible = false;
            Panel_TrithAttack.Enabled = false;

            Reading_UserDictionary(CB_TrithAlphabetText);
            CB_TrithTextMethod.SelectedIndex = 0;
        }

        // Метод для зашифрування та дешифрування тексту за користувацьким словником. Спрацьовує при натисканні кнопки: "CALCULATE".
        private void TrythTextEnDec(TextBox User_text, TextBox Out_Enc, TextBox OutDec, TextBox coef_A, TextBox coef_B, TextBox coef_C, TextBox Keyword)
        {
            string alphabet = "";

            Select_UserAlphabet(ref alphabet, CB_TrithAlphabetText);

            int alphabetLength = alphabet.Length / 2; // Довжина словника або кількість символів словника або потужність користувацького словника

            // Якщо користувач обрав шифрування/дешифрування за лінійним методом 
            if (CB_TrithTextMethod.SelectedIndex == 0)
            {
                // Перетворення текствого значення в ціле число, що ввів користувач у коефіцієнт: "А" та "В"
                int.TryParse(coef_A.Text, out int A);
                int.TryParse(coef_B.Text, out int B);

                ///////////////////////////////////////////
                // ШИФРУВАННЯ ЗА 2 КОЕФІЦІЄНТАМИ
                ///////////////////////////////////////////

                Out_Enc.Text = ""; // Очищення текстового поля для додавання зашифрованих символів
                int p = 0; // Позиція символу у повідомленні
                try
                {
                    // Перебір елементів (символів) рядка "User_text"
                    foreach (char symbol in User_text.Text)
                    {
                        if (alphabet.Contains(symbol))
                        {
                            int x = alphabet.IndexOf(char.ToLower(symbol)); // Порядковий номер символу в словнику (у нижньому регістрі)
                            int k = A * p + B; // Розрахунок кроку зміщення "k"
                            int y = (x + k) % alphabetLength; // Розрахунок номеру символу у користувацькому словнику
                            char encSymbol = alphabet[y]; // Отримання зашифрованого символу

                            // Відновлюємо регістр зашифрованого символу
                            encSymbol = char.IsUpper(symbol) ? char.ToUpper(encSymbol) : char.IsLower(symbol) ? char.ToLower(encSymbol) : encSymbol;

                            Out_Enc.Text += encSymbol; // Додавання зашифрованого символу до результату
                        }
                        else
                        {
                            Out_Enc.Text += symbol; // Якщо символу немає у словнику, додаємо символ без змін
                        }
                        p++; // Наступний символ у повідомленні.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }


                ///////////////////////////////////////////
                // ДЕШИФРУВАННЯ ЗА 2 КОЕФІЦІЄНТАМИ
                ///////////////////////////////////////////

                OutDec.Text = ""; // Очищення текстового поля для додавання дешифрованих символів
                p = 0; // Позиція символу у повідомленні

                try 
                {
                    foreach (char symbol in Out_Enc.Text)
                    {
                        if (alphabet.Contains(symbol))
                        {
                            int y = alphabet.IndexOf(char.ToLower(symbol)); // Порядковий номер символу в словнику (у нижньому регістрі)
                            int k = A * p + B; // Розрахунок кроку зміщення "k"
                            int x = (y + alphabetLength - k % alphabetLength) % alphabetLength; // Розрахунок номеру символу у користувацькому словнику
                            char encSymbol = alphabet[x]; // Отримання дешифрованого символу

                            // Відновлюємо регістр зашифрованого символу
                            encSymbol = char.IsUpper(symbol) ? char.ToUpper(encSymbol) : char.IsLower(symbol) ? char.ToLower(encSymbol) : encSymbol;

                            OutDec.Text += encSymbol; // Додавання дешифрованого символу до результату
                        }
                        else
                        {
                            OutDec.Text += symbol; // Якщо символу немає у словнику, додаємо символ без змін
                        }
                        p++; // Наступний символ у повідомленні.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }

            // Якщо користувач обрав шифрування/дешифрування за нелінійним методом 
            else if (CB_TrithTextMethod.SelectedIndex == 1)
            {
                int.TryParse(coef_A.Text, out int A); // Перетворення текствого значення в ціле число, що ввів користувач у коефіцієнт: "А"
                int.TryParse(coef_B.Text, out int B); // Перетворення текствого значення в ціле число, що ввів користувач у коефіцієнт: "В"
                int.TryParse(coef_C.Text, out int C); // Перетворення текствого значення в ціле число, що ввів користувач у коефіцієнт: "С"


                ///////////////////////////////////////////
                // ШИФРУВАННЯ ЗА 3 КОЕФІЦІЄНТАМИ
                ///////////////////////////////////////////

                Out_Enc.Text = ""; // Очищення текстового поля для додавання зашифрованих символів
                int p = 0; // Позиція символу у повідомленні

                try 
                {
                    // Перебір елементів (символів) рядка "User_text"
                    foreach (char symbol in User_text.Text)
                    {
                        if (alphabet.Contains(symbol))
                        {
                            int x = alphabet.IndexOf(char.ToLower(symbol)); // Порядковий номер символу в словнику (у нижньому регістрі)
                            int k = A * (p * p) + B * p + C; // Розрахунок кроку зміщення "k"
                            int y = (x + k) % alphabetLength; // Розрахунок номеру символу у користувацькому словнику
                            char encSymbol = alphabet[y]; // Отримання зашифрованого символу

                            // Відновлюємо регістр зашифрованого символу
                            encSymbol = char.IsUpper(symbol) ? char.ToUpper(encSymbol) : char.IsLower(symbol) ? char.ToLower(encSymbol) : encSymbol;

                            Out_Enc.Text += encSymbol; // Додавання зашифрованого символу до результату
                        }
                        else
                        {
                            Out_Enc.Text += symbol; // Якщо символу немає у словнику, додаємо символ без змін
                        }
                        p++; // Наступний символ у повідомленні.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
                

                ///////////////////////////////////////////
                // ДЕШИФРУВАННЯ ЗА 3 КОЕФІЦІЄНТАМИ
                ///////////////////////////////////////////

                OutDec.Text = ""; // Очищення текстового поля для додавання дешифрованих символів
                p = 0; // Позиція символу у повідомленні

                try 
                {
                    // Перебір елементів (символів) рядка "User_text"
                    foreach (char symbol in Out_Enc.Text)
                    {
                        if (alphabet.Contains(symbol))
                        {
                            int y = alphabet.IndexOf(char.ToLower(symbol)); // Порядковий номер символу в словнику (у нижньому регістрі)
                            int k = A * (p * p) + B * p + C; // Розрахунок кроку зміщення "k"
                            int x = (y + alphabetLength - k % alphabetLength) % alphabetLength; // Розрахунок номеру символу у користувацькому словнику
                            char encSymbol = alphabet[x]; // Отримання дешифрованого символу

                            // Відновлюємо регістр зашифрованого символу
                            encSymbol = char.IsUpper(symbol) ? char.ToUpper(encSymbol) : char.IsLower(symbol) ? char.ToLower(encSymbol) : encSymbol;

                            OutDec.Text += encSymbol; // Додавання зашифрованого символу до результату
                        }
                        else
                        {
                            OutDec.Text += symbol; // Якщо символу немає у словнику, додаємо символ без змін
                        }
                        p++; // Наступний символ у повідомленні.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }

            // Якщо користувач обрав шифрування/дешифрування за ключовим словом (гаслом)
            else if (CB_TrithTextMethod.SelectedIndex == 2)
            {
                int Key_Length = Keyword.Text.Length; // Довжина символів ключового слова

                ///////////////////////////////////////////
                // ШИФРУВАННЯ ЗА ГАСЛОМ
                ///////////////////////////////////////////

                Out_Enc.Text = ""; // Очищення текстового поля для додавання зашифрованих символів
                int Key_index = 0; // Порядковий номер символу ключового слова

                try
                {
                    // Перебір символів у користувацькому повідомленні (тексті)
                    foreach (char symbol in User_text.Text)
                    {
                        if (alphabet.Contains(symbol))
                        {
                            bool isUpperCase = char.IsUpper(symbol); // Перевірка регістру вихідного символу
                            char currentSymbol = char.ToLower(symbol); // Переводимо символ у нижній регістр для зручності роботи з індексами

                            int Text_index = alphabet.IndexOf(currentSymbol); // Порядковий номер символу в словнику (у нижньому регістрі)
                            int Keyword_index = alphabet.IndexOf(char.ToLower(Keyword.Text[Key_index % Key_Length])); // Визначення індексу символа ключа
                            int new_index = (Text_index + Keyword_index) % alphabetLength; // Обчислення нового індексу
                            char encSymbol = alphabet[new_index]; // Отримання зашифрованого символу

                            // Відновлюємо регістр зашифрованого символу
                            encSymbol = char.IsUpper(symbol) ? char.ToUpper(encSymbol) : char.IsLower(symbol) ? char.ToLower(encSymbol) : encSymbol;

                            Out_Enc.Text += encSymbol; // Додавання зашифрованого символу до результату
                        }
                        else
                        {
                            Out_Enc.Text += symbol; // Якщо символу немає у словнику, додаємо символ без змін
                        }
                        Key_index++; // Наступний символ ключового слова
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }



                ///////////////////////////////////////////
                // ДЕШИФРУВАННЯ ЗА ГАСЛОМ
                ///////////////////////////////////////////

                OutDec.Text = ""; // Очищення текстового поля для додавання дешифрованих символів
                Key_index = 0; // Порядковий номер символу ключового слова

                try
                {
                    // Перебір символів у користувацькому повідомленні (тексті)
                    foreach (char symbol in Out_Enc.Text)
                    {
                        if (alphabet.Contains(symbol))
                        {
                            bool isUpperCase = char.IsUpper(symbol); // Перевірка регістру вихідного символу
                            char currentSymbol = char.ToLower(symbol); // Переводимо символ у нижній регістр для зручності роботи з індексами

                            int Text_index = alphabet.IndexOf(currentSymbol); // Порядковий номер символу в словнику (у нижньому регістрі)
                            int Keyword_index = alphabet.IndexOf(char.ToLower(Keyword.Text[Key_index % Key_Length])); // Визначення індексу символа ключа
                            int new_index = (Text_index - Keyword_index) % alphabetLength; // Обчислення нового індексу
                            int x = new_index < 0 ? (Text_index - Keyword_index) + alphabetLength : new_index; // Використання тернарного оператора для боротьби з від'ємними значеннями символів
                            char encSymbol = alphabet[x]; // Отримання дешифрованого символу

                            // Відновлюємо регістр зашифрованого символу
                            encSymbol = char.IsUpper(symbol) ? char.ToUpper(encSymbol) : char.IsLower(symbol) ? char.ToLower(encSymbol) : encSymbol;

                            OutDec.Text += encSymbol; // Додавання дешифрованого символу до результату
                        }
                        else
                        {
                            OutDec.Text += symbol; // Якщо символу немає у словнику, додаємо символ без змін
                        }
                        Key_index++; // Наступний символ ключового слова
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }

            // Якщо користувач не обрав жодного методу шифрування/дешифрування
            else
            {
                MessageBox.Show("Obtain encryption method!"); // Виводиться дане повідомлення
            }
        }





        // Далі елементи візуалізації та логіки поведінки програми

        //Підвищує розмір шрифту на +2 у.п.
        private void Btn_TrithFontPlus_Click(object sender, EventArgs e)
        {
            TB_TrithUserText.Font = new Font(TB_TrithUserText.Font.FontFamily, TB_TrithUserText.Font.Size + 2);
            TB_TrithResEnc.Font = new Font(TB_TrithResEnc.Font.FontFamily, TB_TrithResEnc.Font.Size + 2);
            TB_TrithResDec.Font = new Font(TB_TrithResDec.Font.FontFamily, TB_TrithResDec.Font.Size + 2);
        }

        //Зменшує розмір шрифту на -2 у.п.
        private void Btn_TrithFontMinus_Click(object sender, EventArgs e)
        {
            TB_TrithUserText.Font = new Font(TB_TrithUserText.Font.FontFamily, TB_TrithUserText.Font.Size - 2);
            TB_TrithResEnc.Font = new Font(TB_TrithResEnc.Font.FontFamily, TB_TrithResEnc.Font.Size - 2);
            TB_TrithResDec.Font = new Font(TB_TrithResDec.Font.FontFamily, TB_TrithResDec.Font.Size - 2);
        }

        //Completed !!!
        //The effect when dragging (hovering the cursor with a file) on an element...
        private void TB_TrithUserText_DragEnter(object sender, DragEventArgs e)
        {
            SampleDragEnter(e);
        }

        //Completed !!!
        //When you release the RMB with a file, the file text is written to the element: "TB_CaesarUserText"
        private void TB_TrithUserText_DragDrop(object sender, DragEventArgs e)
        {
            try 
            {
                //We get a list of dragged files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                //We check that the first file has the extension .txt.
                if (files.Length > 0 && Path.GetExtension(files[0]).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    //Reading the contents of the file.
                    string file_text = File.ReadAllText(files[0]);
                    TB_TrithUserText.Text = file_text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        // Метод для відкриття текстових файлів та автоматичне копіювання тексту в TextBox
        private void Btn_TrithOpenFile_Click(object sender, EventArgs e)
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
                        TB_TrithUserText.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Метод для зашифрування та дешифрування тексту за користувацьким словником. Спрацьовує при натисканні кнопки: "CALCULATE".
        private void Btn_TrithCalculateUserText_Click(object sender, EventArgs e)
        {
            TrythTextEnDec(TB_TrithUserText, TB_TrithResEnc, TB_TrithResDec, TB_TrithTextCoef_A, TB_TrithTextCoef_B, TB_TrithTextCoef_C, TB_TrithTextKeyword);
        }

        // Блокування полів, що не використовуються в 
        private void CB_TrithTextMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_TrithTextMethod.SelectedIndex == 0)
            {
                TB_TrithTextCoef_A.Text = "";
                TB_TrithTextCoef_A.BackColor = SystemColors.Window;
                TB_TrithTextCoef_A.ReadOnly = false;

                TB_TrithTextCoef_B.Text = "";
                TB_TrithTextCoef_B.BackColor = SystemColors.Window;
                TB_TrithTextCoef_B.ReadOnly = false;

                TB_TrithTextCoef_C.Text = "";
                TB_TrithTextCoef_C.BackColor = SystemColors.ScrollBar;
                TB_TrithTextCoef_C.ReadOnly = true;

                TB_TrithTextKeyword.Text = "";
                TB_TrithTextKeyword.BackColor = SystemColors.ScrollBar;
                TB_TrithTextKeyword.ReadOnly = true;
            }

            else if (CB_TrithTextMethod.SelectedIndex == 1)
            {
                TB_TrithTextCoef_A.Text = "";
                TB_TrithTextCoef_A.BackColor = SystemColors.Window;
                TB_TrithTextCoef_A.ReadOnly = false;

                TB_TrithTextCoef_B.Text = "";
                TB_TrithTextCoef_B.BackColor = SystemColors.Window;
                TB_TrithTextCoef_B.ReadOnly = false;

                TB_TrithTextCoef_C.Text = "";
                TB_TrithTextCoef_C.BackColor = SystemColors.Window;
                TB_TrithTextCoef_C.ReadOnly = false;

                TB_TrithTextKeyword.Text = "";
                TB_TrithTextKeyword.BackColor = SystemColors.ScrollBar;
                TB_TrithTextKeyword.ReadOnly = true;
            }

            else if (CB_TrithTextMethod.SelectedIndex == 2)
            {
                TB_TrithTextCoef_A.Text = "";
                TB_TrithTextCoef_A.BackColor = SystemColors.ScrollBar;
                TB_TrithTextCoef_A.ReadOnly = true;

                TB_TrithTextCoef_B.Text = "";
                TB_TrithTextCoef_B.BackColor = SystemColors.ScrollBar;
                TB_TrithTextCoef_B.ReadOnly = true;

                TB_TrithTextCoef_C.Text = "";
                TB_TrithTextCoef_C.BackColor = SystemColors.ScrollBar;
                TB_TrithTextCoef_C.ReadOnly = true;

                TB_TrithTextKeyword.Text = "";
                TB_TrithTextKeyword.BackColor = SystemColors.Window;
                TB_TrithTextKeyword.ReadOnly = false;
            }
        }

        // Прибирання символів з текстових полів
        private void Btn_TrithTextClear_Click(object sender, EventArgs e)
        {
            TB_TrithUserText.Text = "";
            TB_TrithResEnc.Text = "";
            TB_TrithResDec.Text = "";
        }

        //Перевірка, чи є введений символ числом для коефіцієнту: "А"
        private void TB_TrithTextCoef_A_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если не является, отменяем ввод
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        //Перевірка, чи є введений символ числом для коефіцієнту: "В"
        private void TB_TrithTextCoef_B_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Якщо символ не є числом або спеціальним символом, відміна введення
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        //Перевірка, чи є введений символ числом для коефіцієнту: "С"
        private void TB_TrithTextCoef_C_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Якщо символ не є числом або спеціальним символом, відміна введення
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        //Збереження зашифрованого тексту "TextBox" в окремий файл
        private void Btn_TrithEncResSaveText_Click(object sender, EventArgs e)
        {
            // Відкриваємо діалогове вікно для збереження файлу
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save text file";
            saveFileDialog.ShowDialog();

            // Якщо користувач вибрав файл і натиснув "Зберегти"
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    // Створюємо або перезаписуємо файл із текстом із TextBox
                    File.WriteAllText(saveFileDialog.FileName, TB_TrithResEnc.Text);
                    MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Збереження дешифрованого тексту "TextBox" в окремий файл
        private void Btn_TrithDecResSaveText_Click(object sender, EventArgs e)
        {
            // Відкриваємо діалогове вікно для збереження файлу
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save text file";
            saveFileDialog.ShowDialog();

            // Якщо користувач вибрав файл і натиснув "Зберегти"
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    // Створюємо або перезаписуємо файл із текстом із TextBox
                    File.WriteAllText(saveFileDialog.FileName, TB_TrithResDec.Text);
                    MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Копіювання змісту зашифрованого тексту
        private void Btn_TrithEncCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TB_TrithResEnc.Text);
        }

        // Копіювання змісту дешифрованого тексту
        private void Btn_TrithDecCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TB_TrithResDec.Text);
        }

        // Прибирання підказки для користувача про можливості: "TB_TrithUserText"
        private void TB_TrithUserText_Enter(object sender, EventArgs e)
        {
            //Event handler when entering a TextBox
            if (TB_TrithUserText.Text == "Enter text manually or drag and drop a .txt file ...")
            {
                TB_TrithUserText.Text = ""; //Clear the text if it is equal to "Enter text"
            }
        }

        // Підказка для користувача про можливості: "TB_TrithUserText"
        private void TB_TrithUserText_Leave(object sender, EventArgs e)
        {
            //Event handler when exiting a TextBox.
            if (string.IsNullOrWhiteSpace(TB_TrithUserText.Text))
            {
                //We restore the text if it is empty.
                TB_TrithUserText.Text = "Enter text manually or drag and drop a .txt file ...";
            }
        }
    }
}