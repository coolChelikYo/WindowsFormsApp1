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
using MaterialSkin;
using MaterialSkin.Controls;

namespace WindowsFormsApp1
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
                       private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
           
            string selectedDate = dateTimePicker1.Value.ToString("dd/MM/yyyy hh:mm tt");

            Visitor v = new Visitor
            {
                Name = materialTextBox21.Text,
                TicketNumber = materialTextBox22.Text,
               
                Email = "example@mail.com"
            };

           
            FileManager.SaveToFile(v, selectedDate);

          
            ListViewItem item = new ListViewItem(v.Name);
            item.SubItems.Add(v.TicketNumber); 
            item.SubItems.Add(selectedDate);

            materialListView1.Items.Add(item);

            MessageBox.Show("Дані разом з датою збережено успішно!");
        }
    }
}
