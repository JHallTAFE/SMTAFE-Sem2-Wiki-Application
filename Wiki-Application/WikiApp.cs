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
                var newInfo = new Information();
                try
                {
                    newInfo.SetName(TextBoxName.Text, CheckBoxTitleCase.Checked);
                    newInfo.SetCategory(ComboBoxCategory.Text);
                    newInfo.SetStructure(GetStructure());
                    newInfo.SetDefinition(TextBoxDefinition.Text);
                    Wiki.Add(newInfo);
                    DisplayWiki();
                }
                catch (Exception)
                {
                    // To-Do: add user feedback
                }
            }
            else MessageBox.Show("Cannot add " + TextBoxName.Text + " as it already exists!");
            Clear();
        }
        /// <summary>
        /// Sorts the list and then displays it in the ListView
        /// </summary>
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
        /// <summary>
        /// Initalises the ComboBox with categories from a text file.
        /// Creates the text file and populates it if it doesn't already exist.
        /// </summary>
        private void ComboBoxInit()
        {
            const string categoryList = "categories.txt";

            if (!File.Exists(categoryList))
            {
                // Initialise category.txt if it doesn't exist
                try
                {
                    using (StreamWriter writer = File.CreateText(categoryList))
                    {
                        string[] categories = { "Array", "List", "Tree", "Graphs", "Abstract", "Hash" };

                        foreach (string category in categories)
                        {
                            writer.WriteLine(category);
                        }
                    }
                }
                catch (Exception)
                {

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
        /// <summary>
        /// Gets the checked radio button in the form.
        /// </summary>
        /// <returns>"Linear", "Non-Linear", or an empty string depending on which radio button is checked or if neither are.</returns>
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
        /// <summary>
        /// Sets the given radio button to be cheecked.
        /// </summary>
        /// <param name="i">0 checks Linear, 1 checks Non-Linear</param>
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
                    Clear();
                    DisplayWiki();
                    // TO DO: Status Strip feedback
                }
            }
        }
        // Programming Criteria 6.11 Part A
        /// <summary>
        /// Populates the relevant boxes and button with the given entry in the list, if the entry exists.
        /// </summary>
        /// <param name="i">The index of the entry to populate the fields with.</param>
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
            // If the index changes, either through clicking or arrow keys to navigate
            if (ListViewInfo.FocusedItem != null)
            {
                DisplayInformation(ListViewInfo.FocusedItem.Index);
            }
        }
        // Programming Criteria 6.8
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (ListViewInfo.FocusedItem != null) // If there's something selected to edit
            {
                var i = ListViewInfo.FocusedItem.Index;
                var oldName = Wiki[i].GetName();
                var newName = TextBoxName.Text;

                // If the name is not a duplicate OR if the matching name is from the entry being edited
                if (ValidName(TextBoxName.Text) || String.Equals(oldName, newName, StringComparison.OrdinalIgnoreCase))
                {
                    Wiki[i].SetName(TextBoxName.Text, CheckBoxTitleCase.Checked); // Title case if the box is checked
                    Wiki[i].SetCategory(ComboBoxCategory.Text);
                    Wiki[i].SetStructure(GetStructure());
                    Wiki[i].SetDefinition(TextBoxDefinition.Text);
                    DisplayWiki();
                    Clear();
                    // To-do: Status strip feedback
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
                if (search >= 0) // If the search was successful
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
            TextBoxName.Focus();
        }
        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // Lets the Enter key initiate a search as if the button were clicked
            if (e.KeyCode == Keys.Enter)
            {
                ButtonSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        // Programming Criteria 6.5
        /// <summary>
        /// Checks to see if a given name has a corresponding entry in the list already, case-insensitive.
        /// </summary>
        /// <param name="input">Name to validate.</param>
        /// <returns>True if no such entry exists, false if it exists already.</returns>
        private bool ValidName(string input)
        {
            if (Wiki.Exists(info => info.GetName().Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            return true;
        }

        // Programming Criteria 6.12
        /// <summary>
        /// Clears the input fields.
        /// </summary>
        private void Clear()
        {
            TextBoxName.Clear();
            ComboBoxCategory.Text = String.Empty;
            RadioButtonLinear.Checked = false;
            RadioButtonNonLinear.Checked = false;
            TextBoxDefinition.Clear();
        }

        // Programming Criteria 6.13
        private void TextBoxName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clear();
        }
        // Programming Criteria 6.14 Part A
        /// <summary>
        /// Prompts the user to save the list to a file.
        /// </summary>
        private void SaveFile()
        {
            try
            {
                using (SaveFileDialog saveFile = new SaveFileDialog())
                {
                    saveFile.Title = "Select a file to save to";
                    saveFile.Filter = "Binary Files|*.dat";
                    saveFile.InitialDirectory = Environment.CurrentDirectory;

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = saveFile.FileName;
                        try
                        {
                            using (var bw = new BinaryWriter(new FileStream(fileName, FileMode.Create)))
                            {
                                foreach (var info in Wiki)
                                {
                                    bw.Write(info.GetName());
                                    bw.Write(info.GetCategory());
                                    bw.Write(info.GetStructure());
                                    bw.Write(info.GetDefinition());
                                }
                                // To-do: User feedback
                            }
                        }
                        catch (Exception ex)
                        {
                            // To-do: User feedback
                        }
                    }
                }
            }
            catch (Exception)
            {
                // To-do: User feedback
            }
        }
        // Programming Criteria 6.14 Part B
        /// <summary>
        /// Prompts the user to open information from a file.
        /// </summary>
        private void OpenFile()
        {
            try
            {
                using (var openFile = new OpenFileDialog())
                {
                    openFile.Title = "Select a file to open";
                    openFile.Filter = "Binary Files|*.dat";
                    openFile.InitialDirectory = Environment.CurrentDirectory;

                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFile.FileName;
                        try
                        {
                            using (var br = new BinaryReader(new FileStream(fileName, FileMode.Open)))
                            {
                                Wiki.Clear();
                                while (br.BaseStream.Position < br.BaseStream.Length)
                                {
                                    try
                                    {
                                        var newInfo = new Information();
                                        newInfo.SetName(br.ReadString());
                                        newInfo.SetCategory(br.ReadString());
                                        newInfo.SetStructure(br.ReadString());
                                        newInfo.SetDefinition(br.ReadString());
                                        Wiki.Add(newInfo);
                                    }
                                    catch (Exception)
                                    {
                                        // To-do: User feedback
                                    }
                                }
                                DisplayWiki();
                            }
                        }
                        catch (Exception)
                        {
                            // To-do: User feedback
                        }
                    }
                }
            }
            catch (Exception)
            {
                // To-do: User feedback
            }
        }
        // Programming Criteria 6.14 Part C
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        // Programming Criteria 6.14 Part D
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        // Programming Criteria 6.15
        private void WikiApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Do you wish to save ", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{

            //}
        }

        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow spaces, alphabetical letters, and backspace
            bool isValid = char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back;
            e.Handled = !isValid;
        }
    }
}
