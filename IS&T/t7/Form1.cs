using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace t7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private List<ExpenseItem> expenses = new List<ExpenseItem>();

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("Date", "����");
            dataGridView1.Columns.Add("Description", "��������");
            dataGridView1.Columns.Add("Amount", "�����");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ������� ����� ������ ExpenseItem
            ExpenseItem expense = new ExpenseItem
            {
                Date = dateTimePicker1.Value,
                Description = textBox3.Text,
                Amount = numericUpDown1.Value
            };

            // ��������� ������ � ������
            expenses.Add(expense);

            // ��������� ������ � DataGridView
            dataGridView1.Rows.Add(expense.Date, expense.Description, expense.Amount);

            // ������� ���� �����
            dateTimePicker1.Value = DateTime.Now;
            textBox3.Text = "";
            numericUpDown1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ���� � ����� Excel (����� ������)
            string excelFilePath = @"D:\repos\susu\4sem\cw_is_t\t7\ExpenseReportTemplate.xlsx";

            // ������ ����������
            string employeeName = textBox1.Text;
            string department = textBox2.Text;

            // ������� ������ Excel
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Add(excelFilePath);
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1]; // ������������, ��� ����� �� ������ �����

            // ��������� ������ ���������� (���������� ����������� ������ �� ������ ������)
            worksheet.Cells[3, 2].Value = employeeName;       // ��� ����������
            worksheet.Cells[4, 2].Value = department;        // �����

            // ��������� ������ ��� ���������� ��������
            int startRow = 7;

            // ��������� ������� �� DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    worksheet.Cells[startRow, 2].Value = row.Cells["Date"].Value;            // ����
                    worksheet.Cells[startRow, 3].Value = row.Cells["Description"].Value; // �������� ��������
                    worksheet.Cells[startRow, 4].Value = row.Cells["Amount"].Value;           // �����

                    startRow++; // ��������� �� ��������� ������
                }
            }

            excelApp.Visible = true;
            // ��������� ��������� � ��������� Excel
            //workbook.Save();
            //workbook.Close();
            //excelApp.Quit();

            MessageBox.Show("����� � �������� ��������!");
        }

        // ����� ��� �������� ���������� � �������
        public class ExpenseItem
        {
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
