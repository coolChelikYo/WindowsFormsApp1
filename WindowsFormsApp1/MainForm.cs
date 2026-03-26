using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
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
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900, 
                Primary.BlueGrey500, Accent.LightBlue200, 
                TextShade.WHITE
            );
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string selectedDate = dateTimePicker1.Value.ToString("dd/MM/yyyy hh:mm tt");

            Visitor visitor = new Visitor(Guid.NewGuid(), materialTextBox21.Text, "visitor@park.com", materialTextBox22.Text);

            Entity[] elements = new Entity[] 
            { 
                visitor, 
                new Manager(Guid.NewGuid(), "Oleg Admin", "admin@park.com", "Main Gate") 
            };

            FileManager.Add(visitor);
            FileManager.SaveToFile(visitor, selectedDate);

            ListViewItem item = new ListViewItem(visitor.Name);
            item.SubItems.Add(visitor.TicketNumber); 
            item.SubItems.Add(selectedDate);
            materialListView1.Items.Add(item);

            string currentList = Entity.ViewList();
            
           
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void materialTextBox22_Click(object sender, EventArgs e) { }
    }
}