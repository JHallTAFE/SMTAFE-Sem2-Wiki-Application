using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        // Programming Criteria 6.3
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // To-do: Add input validation
            string name = TextBoxName.Text.ToString();
            string category = ComboBoxCategory.Text.ToString();
            // To-do: Add logic for checking radio boxes, from Programming Criteria 6.6
            string structure = "Placeholder";
            string definition = TextBoxDefinition.Text.ToString();
            var newInfo = new Information(name, category, structure, definition);
            Wiki.Add(newInfo);
            DisplayWiki();
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
    }
}
