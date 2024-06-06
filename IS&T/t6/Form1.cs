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
            // ���� � ������ ��������
            string templatePath = @"D:\repos\susu\4sem\cw_is_t\t6\EnvelopeTemplate.docx";

            // �������� ������������� �����
            if (!System.IO.File.Exists(templatePath))
            {
                MessageBox.Show("������ �������� �� ������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // ������� ������ ���������� Word
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                // ��������� ��������
                Microsoft.Office.Interop.Word.Document document = wordApp.Documents.Add(templatePath);

                // ��������� ���� ��������
                document.Bookmarks["RecipientName"].Range.Text = textBox1.Text;
                document.Bookmarks["RecipientAddress"].Range.Text = textBox2.Text;
                document.Bookmarks["SenderName"].Range.Text = textBox3.Text;
                document.Bookmarks["SenderAddress"].Range.Text = textBox4.Text;

                // ��������� ���������
                //document.Save();
                wordApp.Visible = true;
                // ��������� ��������
                //document.Close();

                // ��������� Word
                //wordApp.Quit();

                MessageBox.Show("������� ������� ��������!", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ���������� ��������: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
