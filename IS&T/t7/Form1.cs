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
            dataGridView1.Columns.Add("Date", "Дата");
            dataGridView1.Columns.Add("Description", "Описание");
            dataGridView1.Columns.Add("Amount", "Сумма");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем новый объект ExpenseItem
            ExpenseItem expense = new ExpenseItem
            {
                Date = dateTimePicker1.Value,
                Description = textBox3.Text,
                Amount = numericUpDown1.Value
            };

            // Добавляем объект в список
            expenses.Add(expense);

            // Добавляем строку в DataGridView
            dataGridView1.Rows.Add(expense.Date, expense.Description, expense.Amount);

            // Очищаем поля ввода
            dateTimePicker1.Value = DateTime.Now;
            textBox3.Text = "";
            numericUpDown1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Путь к файлу Excel (бланк отчета)
            string excelFilePath = @"D:\repos\susu\4sem\cw_is_t\t7\ExpenseReportTemplate.xlsx";

            // Данные сотрудника
            string employeeName = textBox1.Text;
            string department = textBox2.Text;

            // Создаем объект Excel
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Add(excelFilePath);
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1]; // Предполагаем, что отчет на первом листе

            // Заполняем данные сотрудника (подставьте фактические ячейки из вашего бланка)
            worksheet.Cells[3, 2].Value = employeeName;       // Имя сотрудника
            worksheet.Cells[4, 2].Value = department;        // Отдел

            // Начальная строка для заполнения расходов
            int startRow = 7;

            // Заполняем расходы из DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    worksheet.Cells[startRow, 2].Value = row.Cells["Date"].Value;            // Дата
                    worksheet.Cells[startRow, 3].Value = row.Cells["Description"].Value; // Описание расходов
                    worksheet.Cells[startRow, 4].Value = row.Cells["Amount"].Value;           // Сумма

                    startRow++; // Переходим на следующую строку
                }
            }

            excelApp.Visible = true;
            // Сохраняем изменения и закрываем Excel
            //workbook.Save();
            //workbook.Close();
            //excelApp.Quit();

            MessageBox.Show("Отчет о затратах заполнен!");
        }

        // Класс для хранения информации о расходе
        public class ExpenseItem
        {
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
