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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.algorithmsTreeView = new System.Windows.Forms.TreeView();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.inputTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.inputStatusTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.inputHintTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPasteToInput = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.parameterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.paramTextBox = new System.Windows.Forms.RichTextBox();
            this.paramHintTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.ignoreCaseButton = new System.Windows.Forms.Button();
            this.outputTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.outputStatusTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCopyOutputToInput = new System.Windows.Forms.Button();
            this.buttonCopyOutputToClipboard = new System.Windows.Forms.Button();
            this.buttonSaveOutput = new System.Windows.Forms.Button();
            this.reverseOutputButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.inputTableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.parameterTableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.outputTableLayoutPanel.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1095, 627);
            this.splitContainer1.SplitterDistance = 362;
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
            this.tableLayoutPanel6.Size = new System.Drawing.Size(362, 627);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // algorithmsTreeView
            // 
            this.algorithmsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algorithmsTreeView.HideSelection = false;
            this.algorithmsTreeView.Location = new System.Drawing.Point(3, 23);
            this.algorithmsTreeView.Name = "algorithmsTreeView";
            this.algorithmsTreeView.Size = new System.Drawing.Size(356, 601);
            this.algorithmsTreeView.TabIndex = 1;
            this.algorithmsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.manipulationsTreeView_AfterSelect);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTextBox.Location = new System.Drawing.Point(3, 3);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(356, 20);
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
            this.splitContainer2.Panel2.Controls.Add(this.outputTableLayoutPanel);
            this.splitContainer2.Size = new System.Drawing.Size(729, 627);
            this.splitContainer2.SplitterDistance = 351;
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
            this.splitContainer3.Panel1.Controls.Add(this.inputTableLayoutPanel);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.parameterTableLayoutPanel);
            this.splitContainer3.Size = new System.Drawing.Size(729, 351);
            this.splitContainer3.SplitterDistance = 271;
            this.splitContainer3.TabIndex = 1;
            this.splitContainer3.TabStop = false;
            // 
            // inputTableLayoutPanel
            // 
            this.inputTableLayoutPanel.ColumnCount = 2;
            this.inputTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.inputTableLayoutPanel.Controls.Add(this.inputStatusTextBox, 0, 2);
            this.inputTableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.inputTableLayoutPanel.Controls.Add(this.inputTextBox, 0, 1);
            this.inputTableLayoutPanel.Controls.Add(this.inputHintTextBox, 0, 0);
            this.inputTableLayoutPanel.Controls.Add(this.flowLayoutPanel3, 1, 1);
            this.inputTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.inputTableLayoutPanel.Name = "inputTableLayoutPanel";
            this.inputTableLayoutPanel.RowCount = 3;
            this.inputTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.inputTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.inputTableLayoutPanel.Size = new System.Drawing.Size(729, 271);
            this.inputTableLayoutPanel.TabIndex = 2;
            // 
            // inputStatusTextBox
            // 
            this.inputStatusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputStatusTextBox.Location = new System.Drawing.Point(3, 250);
            this.inputStatusTextBox.Name = "inputStatusTextBox";
            this.inputStatusTextBox.ReadOnly = true;
            this.inputStatusTextBox.Size = new System.Drawing.Size(675, 20);
            this.inputStatusTextBox.TabIndex = 1;
            this.inputStatusTextBox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(684, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(42, 18);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(3, 27);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(675, 217);
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
            this.inputHintTextBox.Size = new System.Drawing.Size(675, 20);
            this.inputHintTextBox.TabIndex = 0;
            this.inputHintTextBox.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.buttonPasteToInput);
            this.flowLayoutPanel3.Controls.Add(this.buttonOpenFile);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(684, 27);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(42, 100);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // buttonPasteToInput
            // 
            this.buttonPasteToInput.Image = global::TextManipulationUtility.Properties.Resources.editpaste;
            this.buttonPasteToInput.Location = new System.Drawing.Point(3, 3);
            this.buttonPasteToInput.Name = "buttonPasteToInput";
            this.buttonPasteToInput.Size = new System.Drawing.Size(38, 38);
            this.buttonPasteToInput.TabIndex = 0;
            this.buttonPasteToInput.TabStop = false;
            this.toolTip.SetToolTip(this.buttonPasteToInput, "Paste clipboard to Input box");
            this.buttonPasteToInput.UseVisualStyleBackColor = true;
            this.buttonPasteToInput.Click += new System.EventHandler(this.buttonPasteToInput_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Image = global::TextManipulationUtility.Properties.Resources.open1;
            this.buttonOpenFile.Location = new System.Drawing.Point(3, 47);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(38, 38);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.TabStop = false;
            this.toolTip.SetToolTip(this.buttonOpenFile, "Open file");
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // parameterTableLayoutPanel
            // 
            this.parameterTableLayoutPanel.ColumnCount = 2;
            this.parameterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.parameterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.parameterTableLayoutPanel.Controls.Add(this.paramTextBox, 0, 1);
            this.parameterTableLayoutPanel.Controls.Add(this.paramHintTextBox, 0, 0);
            this.parameterTableLayoutPanel.Controls.Add(this.flowLayoutPanel4, 1, 1);
            this.parameterTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parameterTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.parameterTableLayoutPanel.Name = "parameterTableLayoutPanel";
            this.parameterTableLayoutPanel.RowCount = 2;
            this.parameterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.parameterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.parameterTableLayoutPanel.Size = new System.Drawing.Size(729, 76);
            this.parameterTableLayoutPanel.TabIndex = 1;
            // 
            // paramTextBox
            // 
            this.paramTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramTextBox.Location = new System.Drawing.Point(3, 27);
            this.paramTextBox.Name = "paramTextBox";
            this.paramTextBox.Size = new System.Drawing.Size(675, 46);
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
            this.paramHintTextBox.Size = new System.Drawing.Size(675, 20);
            this.paramHintTextBox.TabIndex = 0;
            this.paramHintTextBox.TabStop = false;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.ignoreCaseButton);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(684, 27);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(42, 46);
            this.flowLayoutPanel4.TabIndex = 2;
            // 
            // ignoreCaseButton
            // 
            this.ignoreCaseButton.Image = global::TextManipulationUtility.Properties.Resources.ignore_case_on;
            this.ignoreCaseButton.Location = new System.Drawing.Point(3, 3);
            this.ignoreCaseButton.Name = "ignoreCaseButton";
            this.ignoreCaseButton.Size = new System.Drawing.Size(38, 38);
            this.ignoreCaseButton.TabIndex = 3;
            this.ignoreCaseButton.TabStop = false;
            this.toolTip.SetToolTip(this.ignoreCaseButton, "Toggle \'Ignore Case\'");
            this.ignoreCaseButton.UseVisualStyleBackColor = true;
            this.ignoreCaseButton.Click += new System.EventHandler(this.ignoreCaseButton_Click);
            // 
            // outputTableLayoutPanel
            // 
            this.outputTableLayoutPanel.ColumnCount = 2;
            this.outputTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outputTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.outputTableLayoutPanel.Controls.Add(this.outputStatusTextBox, 0, 1);
            this.outputTableLayoutPanel.Controls.Add(this.outputTextBox, 0, 0);
            this.outputTableLayoutPanel.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.outputTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.outputTableLayoutPanel.Name = "outputTableLayoutPanel";
            this.outputTableLayoutPanel.RowCount = 2;
            this.outputTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outputTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.outputTableLayoutPanel.Size = new System.Drawing.Size(729, 272);
            this.outputTableLayoutPanel.TabIndex = 2;
            // 
            // outputStatusTextBox
            // 
            this.outputStatusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputStatusTextBox.Location = new System.Drawing.Point(3, 251);
            this.outputStatusTextBox.Name = "outputStatusTextBox";
            this.outputStatusTextBox.ReadOnly = true;
            this.outputStatusTextBox.Size = new System.Drawing.Size(675, 20);
            this.outputStatusTextBox.TabIndex = 0;
            this.outputStatusTextBox.TabStop = false;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(3, 3);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(675, 242);
            this.outputTextBox.TabIndex = 1;
            this.outputTextBox.Text = "";
            this.outputTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.outputTextBox_LinkClicked);
            this.outputTextBox.TextChanged += new System.EventHandler(this.outputTextBox_TextChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.buttonCopyOutputToInput);
            this.flowLayoutPanel2.Controls.Add(this.buttonCopyOutputToClipboard);
            this.flowLayoutPanel2.Controls.Add(this.buttonSaveOutput);
            this.flowLayoutPanel2.Controls.Add(this.reverseOutputButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(684, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(42, 242);
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
            this.toolTip.SetToolTip(this.buttonCopyOutputToInput, "Copy output to input");
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
            this.toolTip.SetToolTip(this.buttonCopyOutputToClipboard, "Copy output to clipboard");
            this.buttonCopyOutputToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyOutputToClipboard.Click += new System.EventHandler(this.buttonCopyOutputToClipboard_Click);
            // 
            // buttonSaveOutput
            // 
            this.buttonSaveOutput.Image = global::TextManipulationUtility.Properties.Resources.save_as1;
            this.buttonSaveOutput.Location = new System.Drawing.Point(3, 91);
            this.buttonSaveOutput.Name = "buttonSaveOutput";
            this.buttonSaveOutput.Size = new System.Drawing.Size(38, 38);
            this.buttonSaveOutput.TabIndex = 2;
            this.buttonSaveOutput.TabStop = false;
            this.toolTip.SetToolTip(this.buttonSaveOutput, "Save output to file");
            this.buttonSaveOutput.UseVisualStyleBackColor = true;
            this.buttonSaveOutput.Click += new System.EventHandler(this.buttonSaveOutput_Click);
            // 
            // reverseOutputButton
            // 
            this.reverseOutputButton.Image = global::TextManipulationUtility.Properties.Resources.direction_down;
            this.reverseOutputButton.Location = new System.Drawing.Point(3, 135);
            this.reverseOutputButton.Name = "reverseOutputButton";
            this.reverseOutputButton.Size = new System.Drawing.Size(38, 38);
            this.reverseOutputButton.TabIndex = 3;
            this.reverseOutputButton.TabStop = false;
            this.toolTip.SetToolTip(this.reverseOutputButton, "Toggle \'Output Direction\'");
            this.reverseOutputButton.UseVisualStyleBackColor = true;
            this.reverseOutputButton.Click += new System.EventHandler(this.reverseOutputButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 627);
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
            this.inputTableLayoutPanel.ResumeLayout(false);
            this.inputTableLayoutPanel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.parameterTableLayoutPanel.ResumeLayout(false);
            this.parameterTableLayoutPanel.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.outputTableLayoutPanel.ResumeLayout(false);
            this.outputTableLayoutPanel.PerformLayout();
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
        private System.Windows.Forms.TextBox inputStatusTextBox;
        private System.Windows.Forms.TextBox outputStatusTextBox;
        private System.Windows.Forms.TableLayoutPanel inputTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel outputTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonCopyOutputToInput;
        private System.Windows.Forms.Button buttonCopyOutputToClipboard;
        private System.Windows.Forms.Button buttonPasteToInput;
        private System.Windows.Forms.TextBox inputHintTextBox;
        private System.Windows.Forms.TableLayoutPanel parameterTableLayoutPanel;
        private System.Windows.Forms.TextBox paramHintTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button buttonSaveOutput;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button ignoreCaseButton;
        private System.Windows.Forms.Button reverseOutputButton;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

