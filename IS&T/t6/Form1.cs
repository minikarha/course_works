using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace t6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Путь к бланку конверта
            string templatePath = @"D:\repos\susu\4sem\cw_is_t\t6\EnvelopeTemplate.docx";

            // Проверка существования файла
            if (!System.IO.File.Exists(templatePath))
            {
                MessageBox.Show("Шаблон конверта не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Создаем объект приложения Word
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                // Открываем документ
                Microsoft.Office.Interop.Word.Document document = wordApp.Documents.Add(templatePath);

                // Заполняем поля конверта
                document.Bookmarks["RecipientName"].Range.Text = textBox1.Text;
                document.Bookmarks["RecipientAddress"].Range.Text = textBox2.Text;
                document.Bookmarks["SenderName"].Range.Text = textBox3.Text;
                document.Bookmarks["SenderAddress"].Range.Text = textBox4.Text;

                // Сохраняем изменения
                //document.Save();
                wordApp.Visible = true;
                // Закрываем документ
                //document.Close();

                // Закрываем Word
                //wordApp.Quit();

                MessageBox.Show("Конверт успешно заполнен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при заполнении конверта: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
