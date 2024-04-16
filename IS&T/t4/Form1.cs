namespace t4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), checkBox1.Checked);
            label8.Text = $"емя: {emp.CalculateESN()}";
        }
    }
}
