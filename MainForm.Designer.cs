namespace TextManipulationUtility
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.algorithmsTreeView = new System.Windows.Forms.TreeView();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputStatusTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPasteToInput = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.inputHintTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.paramTextBox = new System.Windows.Forms.RichTextBox();
            this.paramHintTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outputStatusTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCopyOutputToInput = new System.Windows.Forms.Button();
            this.buttonCopyOutputToClipboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(996, 585);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.algorithmsTreeView, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.filterTextBox, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(331, 585);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // algorithmsTreeView
            // 
            this.algorithmsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algorithmsTreeView.HideSelection = false;
            this.algorithmsTreeView.Location = new System.Drawing.Point(3, 23);
            this.algorithmsTreeView.Name = "algorithmsTreeView";
            this.algorithmsTreeView.Size = new System.Drawing.Size(325, 559);
            this.algorithmsTreeView.TabIndex = 1;
            this.algorithmsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.manipulationsTreeView_AfterSelect);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTextBox.Location = new System.Drawing.Point(3, 3);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(325, 20);
            this.filterTextBox.TabIndex = 0;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(661, 585);
            this.splitContainer2.SplitterDistance = 316;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel5);
            this.splitContainer3.Size = new System.Drawing.Size(661, 316);
            this.splitContainer3.SplitterDistance = 251;
            this.splitContainer3.TabIndex = 1;
            this.splitContainer3.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.inputStatusTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 251);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // inputStatusTextBox
            // 
            this.inputStatusTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputStatusTextBox.Location = new System.Drawing.Point(3, 228);
            this.inputStatusTextBox.Name = "inputStatusTextBox";
            this.inputStatusTextBox.ReadOnly = true;
            this.inputStatusTextBox.Size = new System.Drawing.Size(655, 20);
            this.inputStatusTextBox.TabIndex = 1;
            this.inputStatusTextBox.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel3.Controls.Add(this.buttonPasteToInput, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.inputTextBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.inputHintTextBox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(655, 218);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonPasteToInput
            // 
            this.buttonPasteToInput.Image = global::TextManipulationUtility.Properties.Resources.editpaste;
            this.buttonPasteToInput.Location = new System.Drawing.Point(610, 23);
            this.buttonPasteToInput.Name = "buttonPasteToInput";
            this.buttonPasteToInput.Size = new System.Drawing.Size(38, 38);
            this.buttonPasteToInput.TabIndex = 0;
            this.buttonPasteToInput.TabStop = false;
            this.buttonPasteToInput.UseVisualStyleBackColor = true;
            this.buttonPasteToInput.Click += new System.EventHandler(this.buttonPasteToInput_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(610, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(42, 14);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextBox.Location = new System.Drawing.Point(3, 23);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(601, 192);
            this.inputTextBox.TabIndex = 1;
            this.inputTextBox.Text = "";
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // inputHintTextBox
            // 
            this.inputHintTextBox.BackColor = System.Drawing.Color.LightYellow;
            this.inputHintTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputHintTextBox.Location = new System.Drawing.Point(3, 3);
            this.inputHintTextBox.Name = "inputHintTextBox";
            this.inputHintTextBox.ReadOnly = true;
            this.inputHintTextBox.Size = new System.Drawing.Size(601, 20);
            this.inputHintTextBox.TabIndex = 0;
            this.inputHintTextBox.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.paramTextBox, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.paramHintTextBox, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(661, 61);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // paramTextBox
            // 
            this.paramTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramTextBox.Location = new System.Drawing.Point(3, 23);
            this.paramTextBox.Name = "paramTextBox";
            this.paramTextBox.Size = new System.Drawing.Size(655, 35);
            this.paramTextBox.TabIndex = 1;
            this.paramTextBox.Text = "";
            this.paramTextBox.TextChanged += new System.EventHandler(this.paramTextBox_TextChanged);
            // 
            // paramHintTextBox
            // 
            this.paramHintTextBox.BackColor = System.Drawing.Color.LightYellow;
            this.paramHintTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramHintTextBox.Location = new System.Drawing.Point(3, 3);
            this.paramHintTextBox.Name = "paramHintTextBox";
            this.paramHintTextBox.ReadOnly = true;
            this.paramHintTextBox.Size = new System.Drawing.Size(655, 20);
            this.paramHintTextBox.TabIndex = 0;
            this.paramHintTextBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.outputStatusTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(661, 265);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // outputStatusTextBox
            // 
            this.outputStatusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputStatusTextBox.Location = new System.Drawing.Point(3, 244);
            this.outputStatusTextBox.Name = "outputStatusTextBox";
            this.outputStatusTextBox.Size = new System.Drawing.Size(655, 20);
            this.outputStatusTextBox.TabIndex = 0;
            this.outputStatusTextBox.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel4.Controls.Add(this.outputTextBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(655, 235);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(3, 3);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(601, 229);
            this.outputTextBox.TabIndex = 1;
            this.outputTextBox.Text = "";
            this.outputTextBox.TextChanged += new System.EventHandler(this.outputTextBox_TextChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.buttonCopyOutputToInput);
            this.flowLayoutPanel2.Controls.Add(this.buttonCopyOutputToClipboard);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(610, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(42, 229);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // buttonCopyOutputToInput
            // 
            this.buttonCopyOutputToInput.Image = global::TextManipulationUtility.Properties.Resources.editcopy32;
            this.buttonCopyOutputToInput.Location = new System.Drawing.Point(3, 3);
            this.buttonCopyOutputToInput.Name = "buttonCopyOutputToInput";
            this.buttonCopyOutputToInput.Size = new System.Drawing.Size(38, 38);
            this.buttonCopyOutputToInput.TabIndex = 0;
            this.buttonCopyOutputToInput.TabStop = false;
            this.buttonCopyOutputToInput.UseVisualStyleBackColor = true;
            this.buttonCopyOutputToInput.Click += new System.EventHandler(this.buttonCopyOutputToInput_Click);
            // 
            // buttonCopyOutputToClipboard
            // 
            this.buttonCopyOutputToClipboard.Image = global::TextManipulationUtility.Properties.Resources.editcopy;
            this.buttonCopyOutputToClipboard.Location = new System.Drawing.Point(3, 47);
            this.buttonCopyOutputToClipboard.Name = "buttonCopyOutputToClipboard";
            this.buttonCopyOutputToClipboard.Size = new System.Drawing.Size(38, 38);
            this.buttonCopyOutputToClipboard.TabIndex = 1;
            this.buttonCopyOutputToClipboard.TabStop = false;
            this.buttonCopyOutputToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyOutputToClipboard.Click += new System.EventHandler(this.buttonCopyOutputToClipboard_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 585);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Text Inspection & Manipulation Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView algorithmsTreeView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox inputTextBox;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RichTextBox paramTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox inputStatusTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox outputStatusTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonCopyOutputToInput;
        private System.Windows.Forms.Button buttonCopyOutputToClipboard;
        private System.Windows.Forms.Button buttonPasteToInput;
        private System.Windows.Forms.TextBox inputHintTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox paramHintTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox filterTextBox;
    }
}

