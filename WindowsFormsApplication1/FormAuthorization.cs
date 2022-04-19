using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (textBox1.Text == "user" && textBox2.Text == "pass") 
            {
                this.Hide();
                FormOrganizer fo = new FormOrganizer();
                fo.ShowDialog(this);
                Close();
            }
            else 
            {
                MessageBox.Show("Wrong login or password!"); 
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.PasswordChar = (char)0;
            else
                textBox2.PasswordChar = '*';
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
