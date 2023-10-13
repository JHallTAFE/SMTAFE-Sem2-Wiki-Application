namespace Wiki_Application
{
    partial class WikiApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ListViewInfo = new System.Windows.Forms.ListView();
            columnName = new System.Windows.Forms.ColumnHeader();
            columnCategory = new System.Windows.Forms.ColumnHeader();
            TextBoxSearch = new System.Windows.Forms.TextBox();
            ButtonSearch = new System.Windows.Forms.Button();
            TextBoxName = new System.Windows.Forms.TextBox();
            ButtonOpen = new System.Windows.Forms.Button();
            ButtonSave = new System.Windows.Forms.Button();
            ComboBoxCategory = new System.Windows.Forms.ComboBox();
            GroupBoxStructure = new System.Windows.Forms.GroupBox();
            RadioButtonNonLinear = new System.Windows.Forms.RadioButton();
            RadioButtonLinear = new System.Windows.Forms.RadioButton();
            LabelName = new System.Windows.Forms.Label();
            LabelCategory = new System.Windows.Forms.Label();
            LabelDefinition = new System.Windows.Forms.Label();
            TextBoxDefinition = new System.Windows.Forms.TextBox();
            ButtonAdd = new System.Windows.Forms.Button();
            ButtonEdit = new System.Windows.Forms.Button();
            ButtonDelete = new System.Windows.Forms.Button();
            CheckBoxTitleCase = new System.Windows.Forms.CheckBox();
            ToolTip = new System.Windows.Forms.ToolTip(components);
            GroupBoxStructure.SuspendLayout();
            SuspendLayout();
            // 
            // ListViewInfo
            // 
            ListViewInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnName, columnCategory });
            ListViewInfo.FullRowSelect = true;
            ListViewInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            ListViewInfo.Location = new System.Drawing.Point(281, 41);
            ListViewInfo.MultiSelect = false;
            ListViewInfo.Name = "ListViewInfo";
            ListViewInfo.Size = new System.Drawing.Size(296, 287);
            ListViewInfo.TabIndex = 0;
            ToolTip.SetToolTip(ListViewInfo, "The wiki entries. Can select entries to edit or delete.");
            ListViewInfo.UseCompatibleStateImageBehavior = false;
            ListViewInfo.View = System.Windows.Forms.View.Details;
            ListViewInfo.SelectedIndexChanged += ListViewInfo_SelectedIndexChanged;
            // 
            // columnName
            // 
            columnName.Text = "Name";
            columnName.Width = 128;
            // 
            // columnCategory
            // 
            columnCategory.Text = "Category";
            columnCategory.Width = 128;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new System.Drawing.Point(362, 12);
            TextBoxSearch.MaxLength = 64;
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new System.Drawing.Size(215, 23);
            TextBoxSearch.TabIndex = 1;
            ToolTip.SetToolTip(TextBoxSearch, "The name to search for.");
            TextBoxSearch.KeyDown += TextBoxSearch_KeyDown;
            // 
            // ButtonSearch
            // 
            ButtonSearch.Location = new System.Drawing.Point(281, 12);
            ButtonSearch.Name = "ButtonSearch";
            ButtonSearch.Size = new System.Drawing.Size(75, 23);
            ButtonSearch.TabIndex = 2;
            ButtonSearch.Text = "Search";
            ToolTip.SetToolTip(ButtonSearch, "Searches the list by name for the query to the right.");
            ButtonSearch.UseVisualStyleBackColor = true;
            ButtonSearch.Click += ButtonSearch_Click;
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new System.Drawing.Point(84, 12);
            TextBoxName.MaxLength = 64;
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new System.Drawing.Size(121, 23);
            TextBoxName.TabIndex = 3;
            ToolTip.SetToolTip(TextBoxName, "Name of the data structure. Double clicking here will clear all fields.");
            TextBoxName.KeyPress += TextBoxName_KeyPress;
            TextBoxName.MouseDoubleClick += TextBoxName_MouseDoubleClick;
            // 
            // ButtonOpen
            // 
            ButtonOpen.Location = new System.Drawing.Point(281, 334);
            ButtonOpen.Name = "ButtonOpen";
            ButtonOpen.Size = new System.Drawing.Size(75, 23);
            ButtonOpen.TabIndex = 4;
            ButtonOpen.Text = "Open";
            ToolTip.SetToolTip(ButtonOpen, "Open a file.");
            ButtonOpen.UseVisualStyleBackColor = true;
            ButtonOpen.Click += ButtonOpen_Click;
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new System.Drawing.Point(362, 334);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new System.Drawing.Size(75, 23);
            ButtonSave.TabIndex = 5;
            ButtonSave.Text = "Save";
            ToolTip.SetToolTip(ButtonSave, "Save to a file.");
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ComboBoxCategory
            // 
            ComboBoxCategory.FormattingEnabled = true;
            ComboBoxCategory.Location = new System.Drawing.Point(84, 41);
            ComboBoxCategory.Name = "ComboBoxCategory";
            ComboBoxCategory.Size = new System.Drawing.Size(121, 23);
            ComboBoxCategory.TabIndex = 6;
            ToolTip.SetToolTip(ComboBoxCategory, "Category of the data structure.");
            // 
            // GroupBoxStructure
            // 
            GroupBoxStructure.Controls.Add(RadioButtonNonLinear);
            GroupBoxStructure.Controls.Add(RadioButtonLinear);
            GroupBoxStructure.Location = new System.Drawing.Point(12, 70);
            GroupBoxStructure.Name = "GroupBoxStructure";
            GroupBoxStructure.Size = new System.Drawing.Size(193, 53);
            GroupBoxStructure.TabIndex = 7;
            GroupBoxStructure.TabStop = false;
            GroupBoxStructure.Text = "Structure";
            // 
            // RadioButtonNonLinear
            // 
            RadioButtonNonLinear.AutoSize = true;
            RadioButtonNonLinear.Location = new System.Drawing.Point(102, 22);
            RadioButtonNonLinear.Name = "RadioButtonNonLinear";
            RadioButtonNonLinear.Size = new System.Drawing.Size(85, 19);
            RadioButtonNonLinear.TabIndex = 1;
            RadioButtonNonLinear.TabStop = true;
            RadioButtonNonLinear.Text = "Non-Linear";
            ToolTip.SetToolTip(RadioButtonNonLinear, "A non-linear data structure.");
            RadioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // RadioButtonLinear
            // 
            RadioButtonLinear.AutoSize = true;
            RadioButtonLinear.Location = new System.Drawing.Point(6, 22);
            RadioButtonLinear.Name = "RadioButtonLinear";
            RadioButtonLinear.Size = new System.Drawing.Size(57, 19);
            RadioButtonLinear.TabIndex = 0;
            RadioButtonLinear.TabStop = true;
            RadioButtonLinear.Text = "Linear";
            ToolTip.SetToolTip(RadioButtonLinear, "A linear data structure.");
            RadioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Location = new System.Drawing.Point(12, 16);
            LabelName.Name = "LabelName";
            LabelName.Size = new System.Drawing.Size(39, 15);
            LabelName.TabIndex = 8;
            LabelName.Text = "Name";
            // 
            // LabelCategory
            // 
            LabelCategory.AutoSize = true;
            LabelCategory.Location = new System.Drawing.Point(12, 44);
            LabelCategory.Name = "LabelCategory";
            LabelCategory.Size = new System.Drawing.Size(55, 15);
            LabelCategory.TabIndex = 9;
            LabelCategory.Text = "Category";
            // 
            // LabelDefinition
            // 
            LabelDefinition.AutoSize = true;
            LabelDefinition.Location = new System.Drawing.Point(12, 126);
            LabelDefinition.Name = "LabelDefinition";
            LabelDefinition.Size = new System.Drawing.Size(59, 15);
            LabelDefinition.TabIndex = 10;
            LabelDefinition.Text = "Definition";
            // 
            // TextBoxDefinition
            // 
            TextBoxDefinition.Location = new System.Drawing.Point(12, 144);
            TextBoxDefinition.Multiline = true;
            TextBoxDefinition.Name = "TextBoxDefinition";
            TextBoxDefinition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            TextBoxDefinition.Size = new System.Drawing.Size(263, 184);
            TextBoxDefinition.TabIndex = 11;
            ToolTip.SetToolTip(TextBoxDefinition, "Definition of the data structure.");
            // 
            // ButtonAdd
            // 
            ButtonAdd.Location = new System.Drawing.Point(211, 12);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new System.Drawing.Size(64, 33);
            ButtonAdd.TabIndex = 12;
            ButtonAdd.Text = "Add";
            ToolTip.SetToolTip(ButtonAdd, "Adds the given entry to the list.");
            ButtonAdd.UseVisualStyleBackColor = true;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // ButtonEdit
            // 
            ButtonEdit.Location = new System.Drawing.Point(211, 51);
            ButtonEdit.Name = "ButtonEdit";
            ButtonEdit.Size = new System.Drawing.Size(64, 33);
            ButtonEdit.TabIndex = 13;
            ButtonEdit.Text = "Edit";
            ToolTip.SetToolTip(ButtonEdit, "Finalise edits on an entry.");
            ButtonEdit.UseVisualStyleBackColor = true;
            ButtonEdit.Click += ButtonEdit_Click;
            // 
            // ButtonDelete
            // 
            ButtonDelete.Location = new System.Drawing.Point(211, 90);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new System.Drawing.Size(64, 33);
            ButtonDelete.TabIndex = 14;
            ButtonDelete.Text = "Delete";
            ToolTip.SetToolTip(ButtonDelete, "Deletes the selected entry.");
            ButtonDelete.UseVisualStyleBackColor = true;
            ButtonDelete.Click += ButtonDelete_Click;
            // 
            // CheckBoxTitleCase
            // 
            CheckBoxTitleCase.AutoSize = true;
            CheckBoxTitleCase.Checked = true;
            CheckBoxTitleCase.CheckState = System.Windows.Forms.CheckState.Checked;
            CheckBoxTitleCase.Location = new System.Drawing.Point(12, 334);
            CheckBoxTitleCase.Name = "CheckBoxTitleCase";
            CheckBoxTitleCase.Size = new System.Drawing.Size(135, 19);
            CheckBoxTitleCase.TabIndex = 15;
            CheckBoxTitleCase.Text = "Automatic Title Case";
            ToolTip.SetToolTip(CheckBoxTitleCase, "If checked, this will automatically title case names added to the list.");
            CheckBoxTitleCase.UseVisualStyleBackColor = true;
            // 
            // WikiApp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(589, 369);
            Controls.Add(CheckBoxTitleCase);
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonEdit);
            Controls.Add(ButtonAdd);
            Controls.Add(TextBoxDefinition);
            Controls.Add(LabelDefinition);
            Controls.Add(LabelCategory);
            Controls.Add(LabelName);
            Controls.Add(GroupBoxStructure);
            Controls.Add(ComboBoxCategory);
            Controls.Add(ButtonSave);
            Controls.Add(ButtonOpen);
            Controls.Add(TextBoxName);
            Controls.Add(ButtonSearch);
            Controls.Add(TextBoxSearch);
            Controls.Add(ListViewInfo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "WikiApp";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            Text = "Wiki Application";
            FormClosing += WikiApp_FormClosing;
            Load += WikiApp_Load;
            GroupBoxStructure.ResumeLayout(false);
            GroupBoxStructure.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView ListViewInfo;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.ComboBox ComboBoxCategory;
        private System.Windows.Forms.GroupBox GroupBoxStructure;
        private System.Windows.Forms.RadioButton RadioButtonNonLinear;
        private System.Windows.Forms.RadioButton RadioButtonLinear;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelCategory;
        private System.Windows.Forms.Label LabelDefinition;
        private System.Windows.Forms.TextBox TextBoxDefinition;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.CheckBox CheckBoxTitleCase;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}

