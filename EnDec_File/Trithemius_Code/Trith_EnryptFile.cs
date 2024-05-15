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
        // Основні методи шифрування
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Створення шифрованого файлу на основі дублікату оригінального (незашифрованого) файлу відповідно до обраного методу шифрування
        private void Btn_TrithSaveFileEnc_Click(object sender, EventArgs e)
        {
            // Якщо користувач обрав шифрування за лінійним методом
            if (CB_TrithEncMethod.SelectedIndex == 0)
            {
                // Задаємо значення коефіцієнтів A і B
                int A = 0;
                int B = 0;
                int.TryParse(TB_TrithEncCoef_A.Text, out A);
                int.TryParse(TB_TrithEncCoef_B.Text, out B);
                int n = 256; // Розмір алфавіту (кількість можливих значень байтів)

                // Вхідний та вихідний файли
                string inputFilePath = TB_TrithPathSaveFileEnc.Text;
                string outputFilePath = Path.ChangeExtension(inputFilePath, ".lvre");

                // Читаємо дані з вхідного файлу та записуємо їх в вихідний файл
                try
                {
                    using (FileStream inputStream = File.OpenRead(inputFilePath))
                    using (FileStream outputStream = File.Create(outputFilePath))
                    {
                        int position = 0; // Позиція байта у ряді байт
                        int byteRead; // Байт, який буде зчитаний з вхідного файлу

                        // Читаємо байти з вхідного файлу та застосовуємо шифрування
                        while ((byteRead = inputStream.ReadByte()) != -1)
                        {
                            // Обчислюємо значення к (k = A * position + B)
                            int k = A * position + B;

                            // Обчислюємо нове значення байту (y = (x + k) mod n)
                            int encryptedByte = (byteRead + k) % n;

                            // Записуємо зашифрований байт у вихідний файл
                            outputStream.WriteByte((byte)encryptedByte);

                            // Збільшуємо позицію для наступного байту
                            position++;
                        }
                    }

                    MessageBox.Show("File successfully encrypted and saved to: " + outputFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Якщо користувач обрав шифрування за нелінійним методом
            else if (CB_TrithEncMethod.SelectedIndex == 1) 
            {
                // Задаємо значення коефіцієнтів A, B і С
                int A = 0;
                int B = 0;
                int C = 0;
                int.TryParse(TB_TrithEncCoef_A.Text, out A);
                int.TryParse(TB_TrithEncCoef_B.Text, out B);
                int.TryParse(TB_TrithEncCoef_C.Text, out C);
                int n = 256; // Розмір алфавіту (кількість можливих значень байтів)

                // Вхідний та вихідний файли
                string inputFilePath = TB_TrithPathSaveFileEnc.Text;
                string outputFilePath = Path.ChangeExtension(inputFilePath, ".lvre");

                // Читаємо дані з вхідного файлу та записуємо їх в вихідний файл
                try
                {
                    using (FileStream inputStream = File.OpenRead(inputFilePath))
                    using (FileStream outputStream = File.Create(outputFilePath))
                    {
                        int position = 0; // Позиція байта у ряді байт
                        int byteRead; // Байт, який буде зчитаний з вхідного файлу

                        // Читаємо байти з вхідного файлу та застосовуємо шифрування
                        while ((byteRead = inputStream.ReadByte()) != -1)
                        {
                            // Обчислюємо значення к (k = A * (position * position) + B * position + C)
                            int k = A * (position * position) + B * position + C;

                            // Обчислюємо нове значення байту (y = (x + k) mod n)
                            int encryptedByte = (byteRead + k) % n;

                            // Записуємо зашифрований байт у вихідний файл
                            outputStream.WriteByte((byte)encryptedByte);

                            // Збільшуємо позицію для наступного байту
                            position++;
                        }
                    }

                    MessageBox.Show("File successfully encrypted and saved to: " + outputFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Якщо користувач обрав шифрування за ключовим словом (гаслом)
            else if (CB_TrithEncMethod.SelectedIndex == 2) 
            {
                // Зчитуємо значення ключового слова (Keyword)
                string keyword = TB_TrithEncKeyword.Text;

                // Вхідний та вихідний файли
                string inputFilePath = TB_TrithPathSaveFileEnc.Text;
                string outputFilePath = Path.ChangeExtension(inputFilePath, ".lvre");

                // Читаємо дані з вхідного файлу та записуємо їх в вихідний файл
                try
                {
                    using (FileStream inputStream = File.OpenRead(inputFilePath))
                    using (FileStream outputStream = File.Create(outputFilePath))
                    {
                        int position = 0; // Позиція байта у ряді байт
                        int n = 256; // Розмір алфавіту (кількість можливих значень байтів)

                        int byteRead; // Байт, який буде зчитаний з вхідного файлу

                        // Читаємо байти з вхідного файлу та застосовуємо шифрування
                        while ((byteRead = inputStream.ReadByte()) != -1)
                        {
                            // Отримуємо ASCII-код кожного символу Keyword
                            int keywordIndex = position % keyword.Length;
                            int keywordCharCode = (int)keyword[keywordIndex];

                            // Обчислюємо значення к (k = ASCII код символу Keyword * position)
                            int k = keywordCharCode * position;

                            // Обчислюємо нове значення байту (y = (x + k) mod n)
                            int encryptedByte = (byteRead + k) % n;

                            // Записуємо зашифрований байт у вихідний файл
                            outputStream.WriteByte((byte)encryptedByte);

                            // Збільшуємо позицію для наступного байту
                            position++;
                        }
                    }
                    MessageBox.Show("File successfully encrypted and saved to: " + outputFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Якщо користувач не обрав жодного методу шифрування
            else
            {
                MessageBox.Show("Obtain encryption method!"); // Виводиться дане повідомлення
            }
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Далі елементи візуалізації та логіки поведінки програми
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Візуальний ефект зміни значка курсору при наведенні курсору, утримуючи ПКМ з файлом.
        private void Panel_TrithFileEncrypt_DragEnter(object sender, DragEventArgs e)
        {
            SampleDragEnter(e);
        }

        // Активується при відпусканні курсору з файлом, шлях до файлу записується в «ТБ» і відкривається панель налаштувань збереження файлу.
        private void Panel_TrithFileEncrypt_DragDrop(object sender, DragEventArgs e)
        {
            //We get an array of strings with paths to the dragged files.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //Clearing the line
            TB_TrithPathSaveFileEnc.Text = "";

            //We check that there is at least one file.
            if (files.Length > 0)
            {
                Panel_TrithFileEncrypt_Save.Enabled = true;
                Panel_TrithFileEncrypt_Save.Visible = true;

                TB_TrithPathSaveFileEnc.Text = files[0];
            }
        }

        // Обрання файлу для шифрування
        private void Btn_TrithOpenFileEnc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Panel_TrithFileEncrypt_Save.Enabled = true;
                Panel_TrithFileEncrypt_Save.Visible = true;

                TB_TrithPathSaveFileEnc.Text = openFileDialog.FileName;
            }
        }

        // Блокування строк (полей), що не використовуються при обраному методі шифрування
        private void CB_TrithEncMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_TrithEncMethod.SelectedIndex == 0) 
            {
                TB_TrithEncCoef_A.Text = "";
                TB_TrithEncCoef_A.BackColor = SystemColors.Window;
                TB_TrithEncCoef_A.ReadOnly = false;

                TB_TrithEncCoef_B.Text = "";
                TB_TrithEncCoef_B.BackColor = SystemColors.Window;
                TB_TrithEncCoef_B.ReadOnly = false;

                TB_TrithEncCoef_C.Text = "";
                TB_TrithEncCoef_C.BackColor = SystemColors.ScrollBar;
                TB_TrithEncCoef_C.ReadOnly = true;

                TB_TrithEncKeyword.Text = "";
                TB_TrithEncKeyword.BackColor = SystemColors.ScrollBar;
                TB_TrithEncKeyword.ReadOnly = true;
            }

            else if (CB_TrithEncMethod.SelectedIndex == 1) 
            {
                TB_TrithEncCoef_A.Text = "";
                TB_TrithEncCoef_A.BackColor = SystemColors.Window;
                TB_TrithEncCoef_A.ReadOnly = false;

                TB_TrithEncCoef_B.Text = "";
                TB_TrithEncCoef_B.BackColor = SystemColors.Window;
                TB_TrithEncCoef_B.ReadOnly = false;

                TB_TrithEncCoef_C.Text = "";
                TB_TrithEncCoef_C.BackColor = SystemColors.Window;
                TB_TrithEncCoef_C.ReadOnly = false;

                TB_TrithEncKeyword.Text = "";
                TB_TrithEncKeyword.BackColor = SystemColors.ScrollBar;
                TB_TrithEncKeyword.ReadOnly = true;
            }

            else if (CB_TrithEncMethod.SelectedIndex == 2)
            {
                TB_TrithEncCoef_A.Text = "";
                TB_TrithEncCoef_A.BackColor = SystemColors.ScrollBar;
                TB_TrithEncCoef_A.ReadOnly = true;

                TB_TrithEncCoef_B.Text = "";
                TB_TrithEncCoef_B.BackColor = SystemColors.ScrollBar;
                TB_TrithEncCoef_B.ReadOnly = true;

                TB_TrithEncCoef_C.Text = "";
                TB_TrithEncCoef_C.BackColor = SystemColors.ScrollBar;
                TB_TrithEncCoef_C.ReadOnly = true;

                TB_TrithEncKeyword.Text = "";
                TB_TrithEncKeyword.BackColor = SystemColors.Window;
                TB_TrithEncKeyword.ReadOnly = false;
            }

        }

        // Відкриття панелі: "Panel_TrithFileEncrypt" та закриття усіх інших панелей даного методу шифрування
        private void Btn_TrithEncryptFile_Click(object sender, EventArgs e)
        {
            Panel_TrithText.Visible = false;
            Panel_TrithText.Enabled = false;

            Panel_TrithFileDecrypt.Visible = false;
            Panel_TrithFileDecrypt.Enabled = false;

            Panel_TrithFileEncrypt.Visible = true;
            Panel_TrithFileEncrypt.Enabled = true;

            Panel_TrithAttack.Visible = false;
            Panel_TrithAttack.Enabled = false;

            CB_TrithEncMethod.SelectedIndex = 0;
        }

        // Перевірка, чи є введений символ числом для коефіцієнту: "А"
        private void TB_TrithEncCoef_A_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если не является, отменяем ввод
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        // Перевірка, чи є введений символ числом для коефіцієнту: "B"
        private void TB_TrithEncCoef_B_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если не является, отменяем ввод
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        // Перевірка, чи є введений символ числом для коефіцієнту: "C"
        private void TB_TrithEncCoef_C_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ числом або спеціальним символом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если не является, отменяем ввод
                e.Handled = true;
                MessageBox.Show("Enter an integer value! This string accepts digits from 0-9.");
            }
        }

        // Очищує строку: "Coefficient A", "TB_TrithEncCoef_A"
        private void Btn_TrithEncCoef_A_Clear_Click(object sender, EventArgs e)
        {
            TB_TrithEncCoef_A.Text = "";
        }

        // Очищує строку: "Coefficient В", "TB_TrithEncCoef_B"
        private void Btn_TrithEncCoef_B_Clear_Click(object sender, EventArgs e)
        {
            TB_TrithEncCoef_B.Text = "";
        }

        // Очищує строку: "Coefficient С", "TB_TrithEncCoef_C"
        private void Btn_TrithEncCoef_C_Clear_Click(object sender, EventArgs e)
        {
            TB_TrithEncCoef_C.Text = "";
        }

        // Очищує строку: "Keyword", "TB_TrithEncKeyword"
        private void Btn_TrithEncKeyword_Clear_Click(object sender, EventArgs e)
        {
            TB_TrithEncKeyword.Text = "";
        }

        // Закриває панель: "TRITHEMIUS CIPHER SAVE ENCRYPT FILE", "Panel_TrithFileEncrypt_Save"
        private void Panel_TrithFileEncrypt_Save_Close_Click(object sender, EventArgs e)
        {
            Panel_TrithFileEncrypt_Save.Visible = false;
            Panel_TrithFileEncrypt_Save.Enabled = false;
        }
    }
}