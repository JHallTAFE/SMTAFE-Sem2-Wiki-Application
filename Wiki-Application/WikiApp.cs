﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

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
            ButtonSave.Enabled = false;
        }
        // Programming Criteria 6.3
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                MessageBox.Show("Please fill in a name for the entry.");
            }
            else if (String.IsNullOrWhiteSpace(ComboBoxCategory.Text))
            {
                MessageBox.Show("Please select a category for the entry.");
            }
            else if (String.IsNullOrEmpty(GetStructure()))
            {
                MessageBox.Show("Please select a structure for the entry.");
            }
            else if (String.IsNullOrEmpty(TextBoxDefinition.Text))
            {
                MessageBox.Show("Please fill in a definition for the entry.");
            }
            else if(!ValidName(TextBoxName.Text))
            {
                MessageBox.Show("Cannot add " + TextBoxName.Text + " as it already exists!");
            }
            else
            {
                var newInfo = new Information();
                try
                {
                    newInfo.SetName(TextBoxName.Text.Trim(), CheckBoxTitleCase.Checked);
                    newInfo.SetCategory(ComboBoxCategory.Text);
                    newInfo.SetStructure(GetStructure());
                    newInfo.SetDefinition(TextBoxDefinition.Text);
                    Wiki.Add(newInfo);
                    Clear();
                    DisplayWiki();
                    ButtonSave.Enabled = true;
                    StatusBar.Text = "Successfully added entry " + newInfo.GetName() + "!";
                }
                catch (Exception ex)
                {
                    StatusBar.Text = "Could not add entry to the list: " + ex.Message;
                }
            }
        }
        // Programming Criteria 6.9
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
                    var name = Wiki[selectedItem].GetName();
                    Trace.TraceInformation("Deleting {0} at index {1}.", name, selectedItem);
                    Wiki.RemoveAt(selectedItem);
                    Clear();
                    DisplayWiki();
                    if (Wiki.Count == 0)
                    {
                        ButtonSave.Enabled = false;
                    }
                    StatusBar.Text = "Successfully deleted entry " + name + "!";
                }
                else
                {
                    Trace.TraceInformation("User aborted the delete operation.");
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
                var oldName = Wiki[i].GetName().Trim();
                var newName = TextBoxName.Text.Trim();
                bool namesEqual = String.Equals(oldName, newName, StringComparison.OrdinalIgnoreCase);
                Trace.TraceInformation("Editing index {0}.\nOriginal name: {1}\nNew name: {2}\nNames are equivalent?: {3}", i, oldName, newName, namesEqual);

                // If the name is not a duplicate OR if the matching name is from the entry being edited
                if (ValidName(TextBoxName.Text) || namesEqual)
                {
                    Wiki[i].SetName(newName, CheckBoxTitleCase.Checked); // Title case if the box is checked
                    Wiki[i].SetCategory(ComboBoxCategory.Text);
                    Wiki[i].SetStructure(GetStructure());
                    Wiki[i].SetDefinition(TextBoxDefinition.Text);
                    DisplayWiki();
                    Clear();
                    if (namesEqual) StatusBar.Text = "Successfully edited entry " + oldName + "!";
                    else StatusBar.Text = "Successfully edited entry " + oldName + " to " + Wiki[i].GetName() + "!";
                    Trace.TraceInformation("Edit was successful. No other duplicate entry existed.");
                }
                else MessageBox.Show("Cannot change entry name to " + newName + " as it already exists!");
            }
            else MessageBox.Show("Cannot change entry name to " + TextBoxName.Text.Trim() + " as it already exists!");
        }
        // Programming Criteria 6.10
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxSearch.Text))
            {
                // Create Information object to search and compare with.
                var searchInfo = new Information();
                searchInfo.SetName(TextBoxSearch.Text.Trim());

                var search = Wiki.BinarySearch(searchInfo);
                if (search >= 0) // If the search was successful
                {
                    ListViewInfo.Items[search].Selected = true;
                    StatusBar.Text = "Found " + Wiki[search].GetName() + " at position " + (search + 1) + "!";
                    DisplayInformation(search);
                }
                else
                {
                    StatusBar.Text = "Could not find " + searchInfo.GetName() + " in the list!";
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
            input = input.Trim();
            Trace.TraceInformation("Comparing {0} against the list:", input);
            if (Wiki.Exists(info => info.GetName().Trim().Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                Trace.TraceInformation("{0} exists in the list. ValidName False.", input);
                return false;
            }
            Trace.TraceInformation("{0} does not exist in the list. ValidName True.", input);
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
                                FileInfo fi = new FileInfo(fileName);
                                StatusBar.Text = String.Format("Successfully saved to {0}.", fi.Name);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                                    }
                                }
                                DisplayWiki();
                                FileInfo fi = new FileInfo(fileName);
                                StatusBar.Text = String.Format("Successfully read contents of {0}.", fi.Name);
                                ButtonSave.Enabled = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (MessageBox.Show("Do you wish to save your progress?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveFile();
            }
            else if (Wiki.Count > 0)
            {
                try
                {
                    // Save to temp.dat because the wiki application WILL save data when the form closes.
                    using (var bw = new BinaryWriter(new FileStream(Application.StartupPath + "\\temp.dat", FileMode.Create)))
                    {
                        foreach (var info in Wiki)
                        {
                            bw.Write(info.GetName());
                            bw.Write(info.GetCategory());
                            bw.Write(info.GetStructure());
                            bw.Write(info.GetDefinition());
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow spaces, alphabetical letters, and backspace
            bool isValid = char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back;
            e.Handled = !isValid;
        }
    }
}
