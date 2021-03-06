﻿namespace munchkin_card_editor
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.cardListBox = new System.Windows.Forms.ListBox();
            this.cardListBoxContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCardCtxItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCardCtxItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pBarText = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.cardPropertiesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cardCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.cardScriptComboBox = new System.Windows.Forms.ComboBox();
            this.cardStyleComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cardDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.cardTitleTextBox = new System.Windows.Forms.TextBox();
            this.cardPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.cardListBoxContextStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(38, 373);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 1;
            label1.Text = "Card Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 402);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(85, 13);
            label2.TabIndex = 3;
            label2.Text = "Card Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(31, 539);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(59, 13);
            label4.TabIndex = 8;
            label4.Text = "Card Script";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(16, 512);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(74, 13);
            label5.TabIndex = 10;
            label5.Text = "Card Category";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(11, 564);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(79, 13);
            label6.TabIndex = 11;
            label6.Text = "Card Properties";
            // 
            // cardListBox
            // 
            this.cardListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardListBox.ContextMenuStrip = this.cardListBoxContextStrip;
            this.cardListBox.FormattingEnabled = true;
            this.cardListBox.Location = new System.Drawing.Point(5, 4);
            this.cardListBox.Name = "cardListBox";
            this.cardListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cardListBox.Size = new System.Drawing.Size(517, 654);
            this.cardListBox.TabIndex = 0;
            this.cardListBox.SelectedValueChanged += new System.EventHandler(this.cardListBox_SelectedValueChanged);
            this.cardListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cardListBox_KeyDown);
            // 
            // cardListBoxContextStrip
            // 
            this.cardListBoxContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCardCtxItem,
            this.deleteCardCtxItem});
            this.cardListBoxContextStrip.Name = "cardListBoxContextStrip";
            this.cardListBoxContextStrip.Size = new System.Drawing.Size(125, 48);
            this.cardListBoxContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cardListBoxContextStrip_Opening);
            // 
            // addCardCtxItem
            // 
            this.addCardCtxItem.Name = "addCardCtxItem";
            this.addCardCtxItem.Size = new System.Drawing.Size(124, 22);
            this.addCardCtxItem.Text = "Add Card";
            this.addCardCtxItem.Click += new System.EventHandler(this.addCardToolStripMenuItem_Click);
            // 
            // deleteCardCtxItem
            // 
            this.deleteCardCtxItem.Name = "deleteCardCtxItem";
            this.deleteCardCtxItem.Size = new System.Drawing.Size(124, 22);
            this.deleteCardCtxItem.Text = "Delete";
            this.deleteCardCtxItem.Click += new System.EventHandler(this.deleteCardCtxItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cardListBox);
            this.splitContainer1.Panel1.Controls.Add(this.pBarText);
            this.splitContainer1.Panel1.Controls.Add(this.pBar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cardPropertiesLayoutPanel);
            this.splitContainer1.Panel2.Controls.Add(label6);
            this.splitContainer1.Panel2.Controls.Add(label5);
            this.splitContainer1.Panel2.Controls.Add(this.cardCategoryComboBox);
            this.splitContainer1.Panel2.Controls.Add(label4);
            this.splitContainer1.Panel2.Controls.Add(this.cardScriptComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.cardStyleComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.cardDescriptionTextBox);
            this.splitContainer1.Panel2.Controls.Add(label2);
            this.splitContainer1.Panel2.Controls.Add(this.cardTitleTextBox);
            this.splitContainer1.Panel2.Controls.Add(label1);
            this.splitContainer1.Panel2.Controls.Add(this.cardPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(868, 723);
            this.splitContainer1.SplitterDistance = 525;
            this.splitContainer1.TabIndex = 1;
            // 
            // pBarText
            // 
            this.pBarText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBarText.AutoSize = true;
            this.pBarText.Location = new System.Drawing.Point(123, 694);
            this.pBarText.Name = "pBarText";
            this.pBarText.Size = new System.Drawing.Size(50, 13);
            this.pBarText.TabIndex = 4;
            this.pBarText.Text = "pBarText";
            this.pBarText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pBarText.Visible = false;
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBar.Location = new System.Drawing.Point(5, 692);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(112, 17);
            this.pBar.TabIndex = 3;
            this.pBar.Visible = false;
            // 
            // cardPropertiesLayoutPanel
            // 
            this.cardPropertiesLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardPropertiesLayoutPanel.AutoScroll = true;
            this.cardPropertiesLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.cardPropertiesLayoutPanel.ColumnCount = 1;
            this.cardPropertiesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardPropertiesLayoutPanel.Location = new System.Drawing.Point(14, 581);
            this.cardPropertiesLayoutPanel.Name = "cardPropertiesLayoutPanel";
            this.cardPropertiesLayoutPanel.RowCount = 1;
            this.cardPropertiesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.cardPropertiesLayoutPanel.Size = new System.Drawing.Size(316, 127);
            this.cardPropertiesLayoutPanel.TabIndex = 13;
            // 
            // cardCategoryComboBox
            // 
            this.cardCategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardCategoryComboBox.Location = new System.Drawing.Point(96, 509);
            this.cardCategoryComboBox.Name = "cardCategoryComboBox";
            this.cardCategoryComboBox.Size = new System.Drawing.Size(234, 21);
            this.cardCategoryComboBox.TabIndex = 9;
            this.cardCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.cardCategoryComboBox_SelectedIndexChanged);
            // 
            // cardScriptComboBox
            // 
            this.cardScriptComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardScriptComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cardScriptComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cardScriptComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardScriptComboBox.FormattingEnabled = true;
            this.cardScriptComboBox.Location = new System.Drawing.Point(96, 536);
            this.cardScriptComboBox.Name = "cardScriptComboBox";
            this.cardScriptComboBox.Size = new System.Drawing.Size(234, 21);
            this.cardScriptComboBox.TabIndex = 7;
            this.cardScriptComboBox.SelectionChangeCommitted += new System.EventHandler(this.cardScriptComboBox_SelectedIndexChanged);
            // 
            // cardStyleComboBox
            // 
            this.cardStyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardStyleComboBox.FormattingEnabled = true;
            this.cardStyleComboBox.Location = new System.Drawing.Point(96, 482);
            this.cardStyleComboBox.Name = "cardStyleComboBox";
            this.cardStyleComboBox.Size = new System.Drawing.Size(234, 21);
            this.cardStyleComboBox.TabIndex = 6;
            this.cardStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.cardStyleComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Card Style";
            // 
            // cardDescriptionTextBox
            // 
            this.cardDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardDescriptionTextBox.Location = new System.Drawing.Point(96, 399);
            this.cardDescriptionTextBox.Multiline = true;
            this.cardDescriptionTextBox.Name = "cardDescriptionTextBox";
            this.cardDescriptionTextBox.Size = new System.Drawing.Size(234, 76);
            this.cardDescriptionTextBox.TabIndex = 4;
            this.cardDescriptionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cardDescriptionTextBox_KeyUp);
            // 
            // cardTitleTextBox
            // 
            this.cardTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardTitleTextBox.Location = new System.Drawing.Point(96, 370);
            this.cardTitleTextBox.Name = "cardTitleTextBox";
            this.cardTitleTextBox.Size = new System.Drawing.Size(234, 20);
            this.cardTitleTextBox.TabIndex = 2;
            this.cardTitleTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cardTitleTextBox_KeyUp);
            // 
            // cardPictureBox
            // 
            this.cardPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardPictureBox.Location = new System.Drawing.Point(3, 4);
            this.cardPictureBox.Name = "cardPictureBox";
            this.cardPictureBox.Size = new System.Drawing.Size(333, 360);
            this.cardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cardPictureBox.TabIndex = 0;
            this.cardPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.pasteFromClipboardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // pasteFromClipboardToolStripMenuItem
            // 
            this.pasteFromClipboardToolStripMenuItem.Name = "pasteFromClipboardToolStripMenuItem";
            this.pasteFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.pasteFromClipboardToolStripMenuItem.Text = "Paste From Clipboard";
            this.pasteFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.pasteFromClipboardToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 747);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Card Editor";
            this.cardListBoxContextStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cardListBox;
        private System.Windows.Forms.PictureBox cardPictureBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox cardTitleTextBox;
        private System.Windows.Forms.TextBox cardDescriptionTextBox;
        private System.Windows.Forms.ComboBox cardStyleComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cardListBoxContextStrip;
        private System.Windows.Forms.ToolStripMenuItem addCardCtxItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCardCtxItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ComboBox cardScriptComboBox;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label pBarText;
        private System.Windows.Forms.ComboBox cardCategoryComboBox;
        private System.Windows.Forms.TableLayoutPanel cardPropertiesLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem pasteFromClipboardToolStripMenuItem;
    }
}

