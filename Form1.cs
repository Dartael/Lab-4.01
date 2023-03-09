using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4._01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // Отримати шлях до вибраного файлу
            string filePath = openFileDialog.FileName;

            // Перевірити, чи файл існує
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не знайдено.");
                return;
            }

            // Прочитати всі рядки з файлу
            string[] lines = File.ReadAllLines(filePath);
            // Перевернути кожен рядок, а не окремі слова
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' '); // Розбиваємо рядок на слова
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = ReverseString(words[j]); // Перевертаємо кожне слово
                }
                lines[i] = string.Join(" ", words); // З'єднуємо перевернуті слова назад у рядок
                lines[i] = ReverseString(lines[i]); // Перевертаємо цілий рядок
            }


            // Створити нове ім'я файлу з переверненими рядками
            string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "mirror_" + Path.GetFileNameWithoutExtension(filePath) + ".tmp");

            // Зберегти перевернені рядки в новому файлі
            File.WriteAllLines(outputFilePath, lines);

            MessageBox.Show("Файл згенеровано успішно.");
        }
        // Функція для перевертання рядка
        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
    
}
