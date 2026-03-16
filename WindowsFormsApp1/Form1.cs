using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visitor v = new Visitor();
            v.Name = textBox1.Text;
            v.Email = textBox2.Text;
            v.TicketNumber = textBox3.Text;
            FileManager.SaveToFile(v);
            MessageBox.Show("Saved visitor!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            m.Name = textBox1.Text;
            m.Email = textBox2.Text;
            m.Department = textBox3.Text;
            FileManager.SaveToFile(m);
            MessageBox.Show("Saved!");
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
