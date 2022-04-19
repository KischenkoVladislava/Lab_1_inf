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
    public partial class AddEventForm : Form
    {
        public AddEventForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Class1.Change == false)
            {
                DateTime date = monthCalendar1.SelectionStart;
                Class1.rows.Add(new string[] { string.Format("{0}.{1}.{2}", date.Day, date.Month, date.Year), dateTimePicker1.Text, textBox1.Text, comboBox1.Text });
                this.Close();
            }
            else
            {
                foreach (var row in Class1.rows)
                {
                    if (row[0] == Class1.change)
                    {
                        int index = Class1.rows.IndexOf(row);
                        DateTime date = monthCalendar1.SelectionStart;
                        Class1.rows[index] = (new string[] { string.Format("{0}.{1}.{2}", date.Day, date.Month, date.Year), dateTimePicker1.Text, textBox1.Text, comboBox1.Text });
                        Class1.Change = false;
                        break;

                    }
                }
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {              
            comboBox1.Items.Add("Memo");
            comboBox1.Items.Add("Meeting");
            comboBox1.Items.Add("Task");
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar1.SelectionStart < DateTime.Today)
            {
                MessageBox.Show("Нельзя ввести дату меньше текущей");
                monthCalendar1.SelectionStart = DateTime.Today;
            }
            else
            {
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
