using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace EnDec_File
{
    partial class MainForm : Form
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Основні методи дешифрування
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Створення дешифрованого файлу на основі дублікату оригінального (зашифрованого) файлу відповідно до обраного методу дешифрування
        private void Btn_TrithSaveFileDec_Click(object sender, EventArgs e)
        {
            // Якщо користувач обрав дешифрування за лінійним методом
            if (CB_TrithDecMethod.SelectedIndex == 0)
            {
                // Задаємо значення коефіцієнтів A і B
                int A = 0;
                int B = 0;
                int.TryParse(TB_TrithDecCoef_A.Text, out A);
                int.TryParse(TB_TrithDecCoef_B.Text, out B);
                int n = 256; // Розмір алфавіту (кількість можливих значень байтів)

                // Вхідний та вихідний файли
                string inputFilePath = TB_TrithPathSaveFileDec.Text;
                string outputFilePath = Path.ChangeExtension(inputFilePath, ".lvrd");

                // Читаємо дані з вхідного файлу та записуємо їх в вихідний файл
                try
                {
                    using (FileStream inputStream = File.OpenRead(inputFilePath))
                    using (FileStream outputStream = File.Create(outputFilePath))
                    {
                        int position = 0; // Позиція байта у ряді байт
                        int byteRead; // Байт, який буде зчитаний з вхідного файлу

                        // Читаємо байти з вхідного файлу та застосовуємо дешифрування
                        while ((byteRead = inputStream.ReadByte()) != -1)
                        {
                            // Обчислюємо значення к (k = A * position + B)
                            int k = A * position + B;

                            // Обчислюємо нове значення байту (decryptedByte = (byteRead + n - k % n) % n)
                            int decryptedByte = (byteRead + n - k % n) % n;

                            // Записуємо дешифрований байт у вихідний файл
                            outputStream.WriteByte((byte)decryptedByte);

                            // Збільшуємо позицію для наступного байту
                            position++;
                        }
                    }

                    MessageBox.Show("File successfully decrypted and saved to: " + outputFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Якщо користувач обрав дешифрування за нелінійним методом
            else if (CB_TrithDecMethod.SelectedIndex == 1)
            {
                // Задаємо значення коефіцієнтів A, B і С
                int A = 0;
                int B = 0;
                int C = 0;
                int.TryParse(TB_TrithDecCoef_A.Text, out A);
                int.TryParse(TB_TrithDecCoef_B.Text, out B);
                int.TryParse(TB_TrithDecCoef_C.Text, out C);
                int n = 256; // Розмір алфавіту (кількість можливих значень байтів)

                // Вхідний та вихідний файли
                string inputFilePath = TB_TrithPathSaveFileDec.Text;
                string outputFilePath = Path.ChangeExtension(inputFilePath, ".lvrd");

                // Читаємо дані з вхідного файлу та записуємо їх в вихідний файл
                try
                {
                    using (FileStream inputStream = File.OpenRead(inputFilePath))
                    using (FileStream outputStream = File.Create(outputFilePath))
                    {
                        int position = 0; // Позиція байта у ряді байт
                        int byteRead; // Байт, який буде зчитаний з вхідного файлу

                        // Читаємо байти з вхідного файлу та застосовуємо дешифрування
                        while ((byteRead = inputStream.ReadByte()) != -1)
                        {
                            // Обчислюємо значення к (k = A * (position * position) + B * position + C)
                            int k = A * (position * position) + B * position + C;

                            // Обчислюємо нове значення байту (decryptedByte = (byteRead + n - k % n) % n)
                            int decryptedByte = (byteRead + n - k % n) % n;

                            // Записуємо дешифрований байт у вихідний файл
                            outputStream.WriteByte((byte)decryptedByte);

                            // Збільшуємо позицію для наступного байту
                            position++;
                        }
                    }

                    MessageBox.Show("File successfully decrypted and saved to: " + outputFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Якщо користувач обрав дешифрування за ключовим словом (гаслом)
            else if (CB_TrithDecMethod.SelectedIndex == 2)
            {
                // Зчитуємо значення ключового слова (Keyword)
                string keyword = TB_TrithDecKeyword.Text;

                // Вхідний та вихідний файли
                string inputFilePath = TB_TrithPathSaveFileDec.Text;
                string outputFilePath = Path.ChangeExtension(inputFilePath, ".lvrd");

                // Читаємо дані з вхідного файлу та записуємо їх в вихідний файл
                try
                {
                    using (FileStream inputStream = File.OpenRead(inputFilePath))
                    using (FileStream outputStream = File.Create(outputFilePath))
                    {
                        int position = 0; // Позиція байта у ряді байт
                        int n = 256; // Розмір алфавіту (кількість можливих значень байтів)

                        int byteRead; // Байт, який буде зчитаний з вхідного файлу

                        // Читаємо байти з вхідного файлу та застосовуємо дешифрування
                        while ((byteRead = inputStream.ReadByte()) != -1)
                        {
                            // Отримуємо ASCII-код кожного символу Keyword
                            int keywordIndex = position % keyword.Length;
                            int keywordCharCode = (int)keyword[keywordIndex];

                            // Обчислюємо значення к (k = ASCII код символу Keyword * position)
                            int k = keywordCharCode * position;

                            // Обчислюємо нове значення байту (y = (x + k) mod n)
                            int decryptedByte = (byteRead - k) % n;
                            // Використання тернарного оператора для боротьби з від'ємними значеннями символів
                            int x = decryptedByte < 0 ? (byteRead - k) + n : decryptedByte;

                            // Записуємо дешифрований байт у вихідний файл
                            outputStream.WriteByte((byte)x);

                            // Збільшуємо позицію для наступного байту
                            position++;
                        }
                    }
                    MessageBox.Show("File successfully decrypted and saved to: " + outputFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Якщо користувач не обрав жодного методу дешифрування
            else
            {
                MessageBox.Show("Obtain decryption method!"); // Виводиться дане повідомлення
            }
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Далі елементи візуалізації та логіки поведінки програми
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Візуальний ефект зміни значка курсору при наведенні курсору, утримуючи ПКМ з файлом.
        private void Panel_TrithFileDecrypt_DragEnter(object sender, DragEventArgs e)
        {
            SampleDragEnter(e);
        }

        // Активується при відпусканні курсору з файлом, шлях до файлу записується в «ТБ» і відкривається панель налаштувань збереження файлу.
        private void Panel_TrithFileDecrypt_DragDrop(object sender, DragEventArgs e)
        {
            //We get an array of strings with paths to the dragged files.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //Clearing the line
            TB_TrithPathSaveFileDec.Text = "";

            //We check that there is at least one file.
            if (files.Length > 0)
            {
                Panel_TrithFileDecrypt_Save.Enabled = true;
                Panel_TrithFileDecrypt_Save.Visible = true;

                TB_TrithPathSaveFileDec.Text = files[0];
            }
        }

        // Обрання файлу для дешифрування
        private void Btn_TrithOpenFileDec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Panel_TrithFileDecrypt_Save.Enabled = true;
                Panel_TrithFileDecrypt_Save.Visible = true;

                TB_TrithPathSaveFileDec.Text = openFileDialog.FileName;
            }
        }

        // Блокування строк (полей), що не використовуються при обраному методі дешифрування
        private void CB_TrithDecMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_TrithDecMethod.SelectedIndex == 0)
            {
                TB_TrithDecCoef_A.Text = "";
                TB_TrithDecCoef_A.BackColor = SystemColors.Window;
                TB_TrithDecCoef_A.ReadOnly = false;

                TB_TrithDecCoef_B.Text = "";
                TB_TrithDecCoef_B.BackColor = SystemColors.Window;
                TB_TrithDecCoef_B.ReadOnly = false;

                TB_TrithDecCoef_C.Text = "";
                TB_TrithDecCoef_C.BackColor = SystemColors.ScrollBar;
                TB_TrithDecCoef_C.ReadOnly = true;

                TB_TrithDecKeyword.Text = "";
                TB_TrithDecKeyword.BackColor = SystemColors.ScrollBar;
                TB_TrithDecKeyword.ReadOnly = true;
            }

            else if (CB_TrithDecMethod.SelectedIndex == 1)
            {
                TB_TrithDecCoef_A.Text = "";
                TB_TrithDecCoef_A.BackColor = SystemColors.Window;
                TB_TrithDecCoef_A.ReadOnly = false;

                TB_TrithDecCoef_B.Text = "";
                TB_TrithDecCoef_B.BackColor = SystemColors.Window;
                TB_TrithDecCoef_B.ReadOnly = false;

                TB_TrithDecCoef_C.Text = "";
                TB_TrithDecCoef_C.BackColor = SystemColors.Window;
                TB_TrithDecCoef_C.ReadOnly = false;

                TB_TrithDecKeyword.Text = "";
                TB_TrithDecKeyword.BackColor = SystemColors.ScrollBar;
                TB_TrithDecKeyword.ReadOnly = true;
            }

            else if (CB_TrithDecMethod.SelectedIndex == 2)
            {
                TB_TrithDecCoef_A.Text = "";
                TB_TrithDecCoef_A.BackColor = SystemColors.ScrollBar;
                TB_TrithDecCoef_A.ReadOnly = true;

                TB_TrithDecCoef_B.Text = "";
                TB_TrithDecCoef_B.BackColor = SystemColors.ScrollBar;
                TB_TrithDecCoef_B.ReadOnly = true;

                TB_TrithDecCoef_C.Text = "";
                TB_TrithDecCoef_C.BackColor = SystemColors.ScrollBar;
                TB_TrithDecCoef_C.ReadOnly = true;

                TB_TrithDecKeyword.Text = "";
                TB_TrithDecKeyword.BackColor = SystemColors.Window;
                TB_TrithDecKeyword.ReadOnly = false;
            }
        }

        // Відкриття панелі: "Panel_TrithFileDecrypt" та закриття усіх інших панелей даного методу дешифрування
        private void Btn_TrithDecryptFile_Click(object sender, EventArgs e)
        {
            Panel_TrithText.Visible = false;
            Panel_TrithText.Enabled = false;

            Panel_TrithFileDecrypt.Visible = true;
            Panel_TrithFileDecrypt.Enabled = true;

            Panel_TrithFileEncrypt.Visible = false;
            Panel_TrithFileEncrypt.Enabled = false;

            Panel_TrithAttack.Visible = false;
            Panel_TrithAttack.Enabled = false;

            CB_TrithDecMethod.SelectedIndex = 0;
        }

        // Перевірка, чи є введений символ числом для коефіцієнту: "А"
        private void TB_TrithDecCoef_A_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если не является, отменяем ввод
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        // Перевірка, чи є введений символ числом для коефіцієнту: "В"
        private void TB_TrithDecCoef_B_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если не является, отменяем ввод
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        // Перевірка, чи є введений символ числом для коефіцієнту: "С"
        private void TB_TrithDecCoef_C_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если не является, отменяем ввод
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        // Очищує строку: "Coefficient A", "TB_TrithDecCoef_A"
        private void Btn_TrithDecCoef_A_Clear_Click(object sender, EventArgs e)
        {
            TB_TrithDecCoef_A.Text = "";
        }

        // Очищує строку: "Coefficient B", "TB_TrithDecCoef_B"
        private void Btn_TrithDecCoef_B_Clear_Click(object sender, EventArgs e)
        {
            TB_TrithDecCoef_B.Text = "";
        }

        // Очищує строку: "Coefficient C", "TB_TrithDecCoef_C"
        private void Btn_TrithDecCoef_C_Clear_Click(object sender, EventArgs e)
        {
            TB_TrithDecCoef_C.Text = "";
        }

        // Очищує строку: "Keyword", "TB_TrithDecKeyword"
        private void Btn_TrithDecKeywordClear_Click(object sender, EventArgs e)
        {
            TB_TrithDecKeyword.Text = "";
        }

        // Закриває панель: "TRITHEMIUS CIPHER SAVE DECRYPT FILE", "Panel_TrithFileDecrypt_Save"
        private void Panel_TrithFileDecrypt_Save_Close_Click(object sender, EventArgs e)
        {
            Panel_TrithFileDecrypt_Save.Visible = false;
            Panel_TrithFileDecrypt_Save.Enabled = false;
        }
    }
}
