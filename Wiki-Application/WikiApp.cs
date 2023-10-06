using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiki_Application
{
    public partial class WikiApp : Form
    {
        // Programming Criteria 6.2
        private List<Information> Wiki = new List<Information>();
        public WikiApp()
        {
            InitializeComponent();
        }
        private void WikiApp_Load(object sender, EventArgs e)
        {
            ComboBoxInit(); // Programming Criteria 6.4 Part B
        }
        // Programming Criteria 6.3
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ValidName(TextBoxName.Text))
            {
                string name = TextBoxName.Text.ToString();
                string category = ComboBoxCategory.Text.ToString();
                string structure = GetStructure();
                string definition = TextBoxDefinition.Text.ToString();
                var newInfo = new Information(name, category, structure, definition);
                Wiki.Add(newInfo);
                DisplayWiki();
            }
            else MessageBox.Show("Cannot add " + TextBoxName.Text + " as it already exists!");
            // To-do: Clear boxes
        }
        private void DisplayWiki()
        {
            Wiki.Sort();
            ListViewInfo.Items.Clear();
            foreach (var info in Wiki)
            {
                var item = new ListViewItem(info.GetName());
                item.SubItems.Add(info.GetCategory());
                ListViewInfo.Items.Add(item);
            }
        }
        // Programming Criteria 6.4 Part A
        private void ComboBoxInit()
        {
            const string categoryList = "categories.txt";

            if (!File.Exists(categoryList))
            {
                // Initialise category.txt if it doesn't exist
                using (StreamWriter writer = File.CreateText(categoryList))
                {
                    string[] categories = { "Array", "List", "Tree", "Graphs", "Abstract", "Hash" };

                    foreach (string category in categories)
                    {
                        writer.WriteLine(category);
                    }
                }
            }
            try
            {
                // Read from category.txt
                using (StreamReader reader = File.OpenText(categoryList))
                {
                    //ComboBoxCategory.Items.Add(String.Empty);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        ComboBoxCategory.Items.Add(line);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured trying to open " + categoryList + "!");
            }
        }
        // Programming Criteria 6.6 Part A
        private string GetStructure()
        {
            if (RadioButtonLinear.Checked)
            {
                return RadioButtonLinear.Text;
            }
            else if (RadioButtonNonLinear.Checked)
            {
                return RadioButtonNonLinear.Text;
            }
            else return String.Empty;
        }
        // Programming Criteria 6.6 Part B
        private void SetStructure(int i)
        {
            switch (i)
            {
                case 0: RadioButtonLinear.Checked = true; break;
                case 1: RadioButtonNonLinear.Checked = true; break;
            }
        }
        // Programming Criteria 6.7
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            var selectedItem = ListViewInfo.FocusedItem.Index;

            if (selectedItem >= 0)
            {
                if (MessageBox.Show("Do you wish to delete the entry " + Wiki[selectedItem].GetName()
                    + " from the records?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Wiki.RemoveAt(selectedItem);
                    DisplayWiki();
                    // TO DO: Status Strip feedback
                    // Also clear boxes
                }
            }
        }
        // Programming Criteria 6.11 Part A
        private void DisplayInformation(int i)
        {
            if (0 <= i && i < Wiki.Count) // If input in range of List<>
            {
                TextBoxName.Text = Wiki[i].GetName();
                ComboBoxCategory.Text = Wiki[i].GetCategory();

                if (Wiki[i].GetStructure() == RadioButtonLinear.Text)
                {
                    SetStructure(0);
                }
                else if (Wiki[i].GetStructure() == RadioButtonNonLinear.Text)
                {
                    SetStructure(1);
                }

                TextBoxDefinition.Text = Wiki[i].GetDefinition();
            }
        }
        // Programming Criteria 6.11 Part B
        private void ListViewInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewInfo.FocusedItem != null)
            {
                DisplayInformation(ListViewInfo.FocusedItem.Index);
            }
        }
        // Programming Criteria 6.8
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            // To-do: validate name inputs for duplicates and other validation checks
            if (ValidName(TextBoxName.Text))
            {
                if (ListViewInfo.FocusedItem != null)
                {
                    var i = ListViewInfo.FocusedItem.Index;
                    Wiki[i].SetName(TextBoxName.Text);
                    Wiki[i].SetCategory(ComboBoxCategory.Text);
                    Wiki[i].SetStructure(GetStructure());
                    Wiki[i].SetDefinition(TextBoxDefinition.Text);
                    DisplayWiki();
                    // To-do: clear boxes and status strip feedback
                }
            }
            else MessageBox.Show("Cannot change entry name to " + TextBoxName.Text + " as it already exists!");
        }
        // Programming Criteria 6.10
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxSearch.Text))
            {
                // Create Information object to search and compare with.
                var searchInfo = new Information();
                searchInfo.SetName(TextBoxSearch.Text);

                var search = Wiki.BinarySearch(searchInfo);
                if (search >= 0)
                {
                    DisplayInformation(search);
                    // To-do: Status strip feedback
                }
                else
                {
                    // To-do: Status strip feedback
                }
            }
            TextBoxSearch.Clear();
        }
        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        // Programming Criteria 6.5
        private bool ValidName(string input)
        {
            if (Wiki.Exists(info => info.GetName().Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            return true;
        }
    }
}
