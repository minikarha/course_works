using System.Windows.Forms;

namespace dll_create_ellipse
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ellipse ellipse = new Ellipse(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), pictureBox1.BackColor, pictureBox2.BackColor);
            Form _ = new Form();
            _.Text = $"{ellipse.CalculateLength()}; {ellipse.CalculateArea()}";
            _.Width = Convert.ToInt32(ellipse.X + ellipse.MajorAxis);
            _.Height = Convert.ToInt32(ellipse.Y + ellipse.MajorAxis);
            _.Show();
            ellipse.Draw(_);
        }
    }
}
