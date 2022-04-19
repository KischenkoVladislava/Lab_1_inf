using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class FormOrganizer : Form
    {

        public FormOrganizer()
        {
            InitializeComponent();

            ToolStripMenuItem editToolStripMenuItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem removeToolStripMenuItem = new ToolStripMenuItem("Remove");
            contextMenuStrip1.Items.AddRange(new[] { editToolStripMenuItem, removeToolStripMenuItem });
            listView1.ContextMenuStrip = contextMenuStrip1;
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        private void list(List<string[]> list)
        {
            listView1.Items.Clear();
            foreach (string[] l in list)
            {
                listView1.Items.Add(new ListViewItem(l));
            }
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (Class1.Find)
                list(Class1.r);
            else
                list(Class1.rows);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEventForm frm = new AddEventForm();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Memo");
            comboBox1.Items.Add("Meeting");
            comboBox1.Items.Add("Task");

            list(Class1.rows);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var row in Class1.rows)
            {
                if (row[0] == listView1.FocusedItem.Text)
                {
                    int index = Class1.rows.IndexOf(row);
                    Class1.delete = index;
                    break;
                }
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Class1.rows.RemoveAt(Class1.delete);
            }
            else if (dialogResult == DialogResult.No)
            {
                Close();
            }
            list(Class1.rows);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var row in Class1.rows)
            {
                if (row[0] == listView1.FocusedItem.Text)
                {
                    int index = Class1.rows.IndexOf(row);
                    Class1.delete = index;
                    break;
                }
            }
            Class1.rows.RemoveAt(Class1.delete);
            AddEventForm frm = new AddEventForm();
            frm.ShowDialog(this);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1.r = new List<string[]>();
            foreach (string[] row in Class1.rows)
            {
                if (row[3] == comboBox1.Text)
                {
                    Class1.r.Add(row);
                }
            }
            list(Class1.r);
        }
        private void FormOrganizer_KeyDown(object sender, KeyEventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, listView1.Text);
                MessageBox.Show("Файл сохранен");
            }

            if (e.Control && e.KeyCode == Keys.O)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                string fileText = File.ReadAllText(filename);
                listView1.Text = fileText;
                MessageBox.Show("Файл открыт");
            }

            if (e.Control && e.KeyCode == Keys.Delete)
            {
                foreach (var row in Class1.rows)
                {
                    if (row[0] == listView1.FocusedItem.Text)
                    {
                        int index = Class1.rows.IndexOf(row);
                        Class1.delete = index;
                        break;
                    }
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Remove", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Class1.rows.RemoveAt(Class1.delete);
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
                list(Class1.rows);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.rows = (from row in Class1.rows
                           orderby row[0]
                           select row).ToList();
            list(Class1.rows);
            radioButton1.Checked = false;
            radioButton2.Checked = true;

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                radioButton2.Checked = true;
            }
            if (radioButton1.Checked == true)
            {
                Class1.r = new List<string[]>();
                foreach (string[] row in Class1.rows)
                {
                    if (row[3] == comboBox1.Text)
                    {
                        Class1.r.Add(row);
                    }
                }
                list(Class1.r);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false)
            {
                radioButton1.Checked = true;
            }
            if (radioButton2.Checked == true)
            {
                list(Class1.rows);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindForm FF = new FindForm();
            FF.ShowDialog();
        }
    }
}
