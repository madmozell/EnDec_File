using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Linq;
using System.Security.Policy;
using System.Diagnostics;

namespace EnDec_File
{
    partial class MainForm : Form
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Основні методи для взлому шифру Тритеміуса
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TrithHack(TextBox Dec_text, TextBox Enc_text, TextBox coef_A, TextBox coef_B, TextBox coef_C, TextBox Keyword)
        {
            // Створюємо об'єкт Stopwatch для вимірювання часу та запускаємо відлік
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Ініціалізуємо змінну, що буде містити усі символи алфавіту
            string alphabet = "";
            // Ініціалізуємо змінну, що містить кількість ітерацій підбору значень для взлому ключа
            int iterations = 0;

            Select_UserAlphabet(ref alphabet, CB_TrithAlphabetHack);

            int alphabetLength = alphabet.Length / 2; // Довжина словника або кількість символів словника або потужність користувацького словника

            // Ініціалізуємо змінні (коефіцієнти та строку ключового слова/гасла)
            int A = 0; int B = 0; int C = 0;

            // Якщо користувач обрав лінійний метод 
            if (CB_TrithHackMethod.SelectedIndex == 0)
            {
                int p = 0; // Позиція символу у повідомленні
                try
                {
                    // Перебір символів користувацького тексту тексту
                    foreach (char symbol in Dec_text.Text)
                    {
                        // Увімкнення циклу: "while"
                        while (true)
                        {
                            // Додаємо ітерацію до лічильника
                            iterations++;
                            // Пошук символу у користувацькому словнику (алфавіті)
                            if (alphabet.Contains(symbol))
                            {
                                int x = alphabet.IndexOf(symbol) % alphabetLength; // Порядковий номер символу в словнику (алфавіті)

                                // Якщо здійснюється пошук першого символу користувацького тексту
                                if (p == 0)
                                {
                                    // Знаходження коефіцієнту: "В"
                                    B = (alphabet.IndexOf(char.ToLower(Enc_text.Text[0])) - alphabet.IndexOf(char.ToLower(Dec_text.Text[0]))) % alphabetLength;
                                }

                                int k = A * p + B; // Розрахунок кроку зміщення "k"
                                int y = (x + k) % alphabetLength; // Розрахунок номеру символу у користувацькому словнику
                                int enc_symbol = alphabet.IndexOf(char.ToLower(Enc_text.Text[p])) % alphabetLength; // Беремо відповідний за черговістю зашифрований символ

                                // Якщо порядковий номер знайденого символу == відповідному зашифрованому символу
                                if (y == enc_symbol)
                                {
                                    // Переходимо до наступного незашифрованого символу
                                    p++;
                                    // Виходимо з циклу: "while"
                                    break;
                                }
                                // Якщо порядковий номер знайденого символу != відповідному зашифрованому символу
                                else
                                {
                                    // Збільшуємо на 1 коефіцієнт та продовжуємо знаходити коефіцієнт: "А"
                                    A = (A + 1) % alphabetLength;
                                }
                            }
                            // Якщо даного символу немає у користувацькому словнику (алфавіті)
                            else
                            {
                                // Переходимо до наступного символу
                                p++;
                                // Виходимо з циклу: "while"
                                break;
                            }
                        }
                    }
                    // Виводимо у текстові поля знайдені коефіцієнти та статистику
                    coef_A.Text = A.ToString();
                    coef_B.Text = B.ToString();
                    Lbl_53.Text = iterations.ToString() + "   iterations";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }

            // Якщо користувач обрав нелінійний метод 
            else if (CB_TrithHackMethod.SelectedIndex == 1)
            {
                int p = 0; // Позиція символу у повідомленні
                try
                {
                    // Перебір символів користувацького тексту
                    foreach (char symbol in Dec_text.Text)
                    {
                        // Увімкнення циклу: "while"
                        while (true)
                        {
                            // Додаємо ітерацію до лічильника
                            iterations++;
                            // Пошук символу у користувацькому словнику (алфавіті)
                            if (alphabet.Contains(symbol))
                            {
                                int x = alphabet.IndexOf(symbol) % alphabetLength; // Порядковий номер символу в словнику (алфавіті)

                                // Якщо здійснюється пошук першого символу користувацького тексту
                                if (p == 0)
                                {
                                    // Знаходження коефіцієнту: "С"
                                    C = (alphabet.IndexOf(char.ToLower(Enc_text.Text[0])) - alphabet.IndexOf(char.ToLower(Dec_text.Text[0]))) % alphabetLength;
                                }

                                int k = A * (p * p) + B * p + C; // Розрахунок кроку зміщення "k"
                                int y = (x + k) % alphabetLength; // Розрахунок номеру символу у користувацькому словнику
                                int enc_symbol = alphabet.IndexOf(char.ToLower(Enc_text.Text[p])) % alphabetLength; // Беремо відповідний за черговістю зашифрований символ

                                // Якщо порядковий номер знайденого символу == відповідному зашифрованому символу
                                if (y == enc_symbol)
                                {
                                    // Переходимо до наступного незашифрованого символу
                                    p++;
                                    // Виходимо з циклу: "while"
                                    break;
                                }
                                // Якщо порядковий номер знайденого символу != відповідному зашифрованому символу
                                else
                                {
                                    // Збільшуємо коефіцієнт: "А" на +1
                                    A++;
                                    // Якщо коефіцієнт: "А" більше чи дорівнює кількості символів користувацького алфавіту
                                    if ((A + 1) >= alphabetLength)
                                    {
                                        // Обнулюємо коефіцієнт: "А"
                                        A = 0;
                                        // Додаємо до коефіцієнту: "В" +1
                                        B++;
                                    }
                                }
                            }
                            // Якщо даного символу немає у користувацькому словнику (алфавіті)
                            else
                            {
                                // Переходимо до наступного символу
                                p++;
                                // Виходимо з циклу: "while"
                                break;
                            }
                        }
                    }
                    // Виводимо у текстові поля знайдені коефіцієнти та статистику
                    coef_A.Text = A.ToString();
                    coef_B.Text = B.ToString();
                    coef_C.Text = C.ToString();
                    Lbl_53.Text = iterations.ToString() + "   iterations";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }

            // Якщо користувач обрав метод за ключовим словом
            else if (CB_TrithHackMethod.SelectedIndex == 2)
            {
                Keyword.Text = "";
                int p = 0; // Позиція символу у повідомленні
                try
                {
                    // Перебір символів користувацького тексту тексту
                    foreach (char symbol in Dec_text.Text)
                    {
                        // Якщо символ користувацького тексту є в користувацькому алфавіті
                        if (alphabet.Contains(symbol))
                        {
                            int enc_symbol = alphabet.IndexOf(char.ToLower(Enc_text.Text[p])) % alphabetLength; // Знаходимо відповідний за черговістю індекс зашифрованого символу
                            int original = alphabet.IndexOf(symbol) % alphabetLength; // Знаходимо індекс незашифрованого символу
                            int key = (enc_symbol - original + alphabetLength) % alphabetLength; // Обчислення індексу ключового слова в словнику (алфавіті)
                            Keyword.Text += alphabet[key]; // Відображаємо символ ключового слова за індексом (порядком) у словнику
                            p++; // Переходимо до наступного слова
                        }
                        // Інакше пропускаємо даний символ
                        else
                        {
                            // Передаємо невідомий символ у ключове слово (гасло)
                            Keyword.Text += symbol;
                            // Переходимо до наступного символу
                            p++;
                        }
                        // Додаємо ітерацію до лічильника
                        iterations++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }
            // Якщо користувач не обрав жодного методу
            else
            {
                MessageBox.Show("Obtain encryption method!"); // Виводиться дане повідомлення
            }
            //Зупинка вимірювання часу
            stopwatch.Stop();
            // Отримання часового проміжку
            TimeSpan elapsedTime = stopwatch.Elapsed;
            // Виводимо на екран статистику
            Lbl_53.Text = iterations.ToString() + "   iterations";
            // Кількість часу, що знадобилося для знаходження ключа
            Lbl_55.Text = $"{elapsedTime.TotalSeconds}   seconds";
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Далі елементи візуалізації та логіки поведінки програми
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Відкриття панелі: "Panel_TrithFileEncrypt" та закриття усіх інших панелей даного методу шифрування
        private void Btn_TrithCipherAttack_Click(object sender, EventArgs e)
        {
            Panel_TrithText.Visible = false;
            Panel_TrithText.Enabled = false;

            Panel_TrithFileDecrypt.Visible = false;
            Panel_TrithFileDecrypt.Enabled = false;

            Panel_TrithFileEncrypt.Visible = false;
            Panel_TrithFileEncrypt.Enabled = false;

            Panel_TrithAttack.Visible = true;
            Panel_TrithAttack.Enabled = true;

            Reading_UserDictionary(CB_TrithAlphabetHack);
            CB_TrithHackMethod.SelectedIndex = 0;
        }

        // The effect when dragging and writing file contents to text field
        private void TB_TrithHackTextOne_DragEnter(object sender, DragEventArgs e)
        {
            SampleDragEnter(e);
        }
        private void TB_TrithHackTextOne_DragDrop(object sender, DragEventArgs e)
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
                    TB_TrithHackTextOne.Text = file_text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        // Підказка для користувача про можливості: "TB_TrithHackTextOne"
        private void TB_TrithHackTextOne_Enter(object sender, EventArgs e)
        {
            //Event handler when entering a TextBox
            if (TB_TrithUserText.Text == "Enter text manually or drag and drop a .txt file ...")
            {
                TB_TrithHackTextOne.Text = ""; //Clear the text if it is equal to "Enter text"
            }
        }
        private void TB_TrithHackTextOne_Leave(object sender, EventArgs e)
        {
            //Event handler when exiting a TextBox.
            if (string.IsNullOrWhiteSpace(TB_TrithHackTextOne.Text))
            {
                //We restore the text if it is empty.
                TB_TrithHackTextOne.Text = "Enter text manually or drag and drop a .txt file ...";
            }
        }

        // The effect when dragging and writing file contents to text field
        private void TB_TrithHackTextTwo_DragEnter(object sender, DragEventArgs e)
        {
            SampleDragEnter(e);
        }
        private void TB_TrithHackTextTwo_DragDrop(object sender, DragEventArgs e)
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
                    TB_TrithHackTextTwo.Text = file_text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        // Підказка для користувача про можливості: "TB_TrithHackTextTwo"
        private void TB_TrithHackTextTwo_Enter(object sender, EventArgs e)
        {
            //Event handler when entering a TextBox
            if (TB_TrithUserText.Text == "Enter text manually or drag and drop a .txt file ...")
            {
                TB_TrithHackTextTwo.Text = ""; //Clear the text if it is equal to "Enter text"
            }
        }
        private void TB_TrithHackTextTwo_Leave(object sender, EventArgs e)
        {
            //Event handler when exiting a TextBox.
            if (string.IsNullOrWhiteSpace(TB_TrithHackTextTwo.Text))
            {
                //We restore the text if it is empty.
                TB_TrithHackTextTwo.Text = "Enter text manually or drag and drop a .txt file ...";
            }
        }

        // Візуалізація елементів шифру, значення яких знаходиться методом підбору
        private void CB_TrithHackMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_TrithHackMethod.SelectedIndex == 0)
            {
                TB_TrithHackCoef_A.Text = "";
                TB_TrithHackCoef_A.BackColor = SystemColors.Window;

                TB_TrithHackCoef_B.Text = "";
                TB_TrithHackCoef_B.BackColor = SystemColors.Window;

                TB_TrithHackCoef_C.Text = "";
                TB_TrithHackCoef_C.BackColor = SystemColors.ScrollBar;

                TB_TrithHackKeyword.Text = "";
                TB_TrithHackKeyword.BackColor = SystemColors.ScrollBar;
            }

            else if (CB_TrithHackMethod.SelectedIndex == 1)
            {
                TB_TrithHackCoef_A.Text = "";
                TB_TrithHackCoef_A.BackColor = SystemColors.Window;

                TB_TrithHackCoef_B.Text = "";
                TB_TrithHackCoef_B.BackColor = SystemColors.Window;

                TB_TrithHackCoef_C.Text = "";
                TB_TrithHackCoef_C.BackColor = SystemColors.Window;

                TB_TrithHackKeyword.Text = "";
                TB_TrithHackKeyword.BackColor = SystemColors.ScrollBar;
            }

            else if (CB_TrithHackMethod.SelectedIndex == 2)
            {
                TB_TrithHackCoef_A.Text = "";
                TB_TrithHackCoef_A.BackColor = SystemColors.ScrollBar;

                TB_TrithHackCoef_B.Text = "";
                TB_TrithHackCoef_B.BackColor = SystemColors.ScrollBar;

                TB_TrithHackCoef_C.Text = "";
                TB_TrithHackCoef_C.BackColor = SystemColors.ScrollBar;

                TB_TrithHackKeyword.Text = "";
                TB_TrithHackKeyword.BackColor = SystemColors.Window;
            }
        }

        // Очищення текстових полей користувацького вводу
        private void Btn_TrithHackClearText_Click(object sender, EventArgs e)
        {
            TB_TrithHackTextOne.Text = "";
            TB_TrithHackTextTwo.Text = "";
        }

        // Кнопка для активізації методу атаки на шифр Тритеміуса
        private void Btn_TrithHack_Click(object sender, EventArgs e)
        {
            TrithHack(TB_TrithHackTextOne, TB_TrithHackTextTwo, TB_TrithHackCoef_A, TB_TrithHackCoef_B, TB_TrithHackCoef_C, TB_TrithHackKeyword);
        }
    }
}
