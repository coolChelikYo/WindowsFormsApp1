using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
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
            if (string.IsNullOrWhiteSpace(materialTextBox21.Text)) return;

            AmusementPark park = new AmusementPark
            {
                Id = Guid.NewGuid(),
                Name = materialTextBox21.Text,
                Description = Description.Text,  
                StartDateTime = dateTimePicker1.Value,
                Duration = TimeSpan.FromHours(2)
            };

            FileManager.Add(park);
            FileManager.SaveToFile(park, dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm"));

            UpdateListView(FileManager.Entities);

            materialTextBox21.Clear();
            Description.Clear();  
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileManager.Entities == null) return;

                string searchText = searchTextBox.Text.Trim();
                var results = string.IsNullOrEmpty(searchText)
                    ? FileManager.Entities
                    : FileManager.Search(searchText);

                UpdateListView(results);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void UpdateListView(IEnumerable<IEntity> entities)
        {
            materialListView1.Items.Clear();

            foreach (IEntity entity in entities)
            {
                if (entity is AmusementPark park)
                {
                    var item = new ListViewItem((materialListView1.Items.Count + 1).ToString());
                    item.SubItems.Add(park.Name ?? "");
                    item.SubItems.Add(park.Description ?? ""); 
                    item.SubItems.Add(park.Duration?.ToString() ?? "00:00");
                    item.SubItems.Add(park.StartDateTime?.ToString("dd/MM/yyyy HH:mm") ?? "");

                    materialListView1.Items.Add(item);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}



