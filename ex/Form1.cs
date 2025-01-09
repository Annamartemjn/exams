using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerateCaptcha();
        }
        private void GenerateCaptcha()
        {
            // Генерация случайного текста
            string captchaText = GenerateRandomText(4);

            // Создание изображения CAPTCHA
            Bitmap captchaImage = new Bitmap(200, 100);
            Graphics g = Graphics.FromImage(captchaImage);

            g.Clear(Color.White); // Заполнение фона
            Font font = new Font("Arial", 24, FontStyle.Bold);
            Random rnd = new Random();

            // Рисуем текст с небольшими смещениями
            for (int i = 0; i < captchaText.Length; i++)
            {
                g.DrawString(captchaText[i].ToString(), font, Brushes.Black, 40 * i + rnd.Next(-5, 5), rnd.Next(10, 40));
            }

            // Рисуем одну линию для перечеркивания
            g.DrawLine(Pens.Gray, 0, rnd.Next(30, 70), 200, rnd.Next(30, 70));

            g.Dispose();

            // Установка изображения в PictureBox
            pictureBox1.Image = captchaImage;
        }

        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[rnd.Next(chars.Length)];
            }

            return new string(result);
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
