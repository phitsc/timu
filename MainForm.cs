﻿namespace TextManipulationUtility
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private Algorithms algorithms = new Algorithms();
        private Algorithm selectedAlgorithm;
        private bool ignoreCase = false;
        private bool reverseOutputDirection = false;
        private int highlights = 0;
        private CommandLineArguments commandLineOptions;

        public MainForm(string[] args)
        {
            InitializeComponent();

            LoadSettings();

            UpdateIgnoreCaseButton();
            UpdateReverseOutputButton();

            NativeMethods.SetCueText(this.filterTextBox, "Filter (Alt + D)");

            UpdateAlgorithmsTreeView();

            commandLineOptions = new CommandLineArguments(args);

            var node = GetInitialNode();

            this.algorithmsTreeView.SelectedNode = (node != null) ? node : this.algorithmsTreeView.Nodes[0];
        }

        private TreeNode GetInitialNode()
        {
            var initialFunction = commandLineOptions["function"];

            if (initialFunction.Count > 0)
            {
                var nodes = this.algorithmsTreeView.Nodes.Find("Alg_" + initialFunction[0], true);

                return nodes.Length > 0 ? nodes[0] : null;
            }

            return null;
        }

        private List<string> GetInitialParameters(string[] args)
        {
            var parameters = new List<string>();

            for (var index = 0; index < args.Length; ++index)
            {
                if (args[index] == "-p")
                {
                    if ((index + 1) < args.Length)
                    {
                        parameters.Add(args[index + 1]);
                    }
                }
            }

            return parameters;
        }

        private void UpdateAlgorithmsTreeView()
        {
            this.algorithmsTreeView.Nodes.Clear();

            foreach (var algorithm in this.algorithms.List)
            {
                if (this.filterTextBox.Text.Length == 0 || CultureInfo.CurrentCulture.CompareInfo.IndexOf(algorithm.Group + " " + algorithm.Name, this.filterTextBox.Text, CompareOptions.IgnoreCase) >= 0)
                {
                    var nodes = this.algorithmsTreeView.Nodes.Find(algorithm.Group, false);
                    var groupNode = nodes.Length == 0 ? this.algorithmsTreeView.Nodes.Add(algorithm.Group, algorithm.Group) : nodes[0];

                    var node = (algorithm.Group == algorithm.Name) ? groupNode : groupNode.Nodes.Add("Alg_" + algorithm.Name, algorithm.Name);

                    node.Tag = algorithm;
                }
            }

            this.algorithmsTreeView.Sort();
            this.algorithmsTreeView.ExpandAll();

            if (this.algorithmsTreeView.Nodes.Count > 0 && this.algorithmsTreeView.Nodes[0].Nodes.Count > 0)
            {
                this.algorithmsTreeView.SelectedNode = this.algorithmsTreeView.Nodes[0].Nodes[0];
            }
        }

        private void LoadSettings()
        {
            this.ignoreCase = Properties.Settings.Default.IgnoreCase;
            this.reverseOutputDirection = Properties.Settings.Default.ReverseOutput;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.IgnoreCase = this.ignoreCase;
            Properties.Settings.Default.ReverseOutput = this.reverseOutputDirection;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var storedLocation = Properties.Settings.Default.MainFormLocation;
            if (storedLocation != null && 
                (storedLocation.X >= SystemInformation.VirtualScreen.X && storedLocation.X < (SystemInformation.VirtualScreen.X + SystemInformation.VirtualScreen.Width)) &&
                (storedLocation.Y >= SystemInformation.VirtualScreen.Y && storedLocation.Y < (SystemInformation.VirtualScreen.Y + SystemInformation.VirtualScreen.Height))
               )
            {
                this.Location = Properties.Settings.Default.MainFormLocation;
            }

            var storedSize = Properties.Settings.Default.MainFormSize;
            if (storedSize != null && (storedSize.Width != -1 && storedSize.Height != -1))
            {
                this.Size = Properties.Settings.Default.MainFormSize;
            }

            var input = commandLineOptions["input"];

            if (commandLineOptions.ErrorMessage.Length > 0)
            {
                this.inputTextBox.Text = "ERROR : Invalid Command Line Argument\n" + commandLineOptions.ErrorMessage;
            }
            else if (input.Count > 0)
            {
                this.inputTextBox.Text = string.Join(" ", input);
            }
            else
            {
                var inputFile = commandLineOptions["input-file"];

                if (inputFile.Count > 0)
                {
                    try
                    {
                        this.inputTextBox.Text = File.ReadAllText(inputFile[0]);
                    }
                    catch (Exception error)
                    {
                        this.inputTextBox.Text = "ERROR : Invalid Command Line Argument\n" + error.Message;
                    }
                }
                else
                {
                    this.inputTextBox.Text = Clipboard.GetText();
                }
            }

            this.inputTextBox.Select();

            InitInitialParameters();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MainFormLocation = this.Location;

            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainFormSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.MainFormSize = this.RestoreBounds.Size;
            }

            SaveSettings();

            // Save settings
            Properties.Settings.Default.Save();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateInputStatusTextBox();

            this.UpdateOutput();
        }

        private void manipulationsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var treeView = (TreeView)sender;
            this.selectedAlgorithm = (Algorithm)treeView.SelectedNode.Tag;

            this.inputHintTextBox.Text = this.selectedAlgorithm != null ? this.selectedAlgorithm.InputHint : "";

            this.parametersTableLayoutPanel.Controls.Clear();

            if (this.selectedAlgorithm != null)
            {
                this.parametersTableLayoutPanel.RowCount = 2;
                this.parametersTableLayoutPanel.ColumnCount = this.selectedAlgorithm.ParamHints.Count;
                for (var index = 0; index < this.parametersTableLayoutPanel.ColumnCount; ++index)
                {
                    this.parametersTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / this.parametersTableLayoutPanel.ColumnCount));
                    this.parametersTableLayoutPanel.Controls.Add(new TextBox() { TabStop = false, BackColor = Color.LightYellow, Text = this.selectedAlgorithm.ParamHints[index], Dock = DockStyle.Fill, ReadOnly = true }, index, 0);
                    this.parametersTableLayoutPanel.Controls.Add(new TextBox() { Dock = DockStyle.Fill }, index, 1);
                    this.parametersTableLayoutPanel.GetControlFromPosition(index, 1).TextChanged += paramTextBox_TextChanged;
                }
            }

            this.UpdateOutput();
        }

        private void InitInitialParameters()
        {
            var initialParameters = commandLineOptions["param"];

            var index = 0;

            while (index < initialParameters.Count && index < this.parametersTableLayoutPanel.ColumnCount)
            {
                this.parametersTableLayoutPanel.GetControlFromPosition(index, 1).Text = initialParameters[index];

                ++index;
            }
        }

        private void paramTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateOutput();
        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateOutputStatusTextBox();
        }

        private void UpdateOutput()
        {
            if (this.selectedAlgorithm != null)
            {
                try
                {
                    var parameters = new List<string>();
                    for (var index = 0; index < this.selectedAlgorithm.ParamHints.Count; ++index)
                    {
                        parameters.Add(this.parametersTableLayoutPanel.GetControlFromPosition(index, 1).Text);
                    }

                    var result = this.selectedAlgorithm.Apply(this.inputTextBox.Text, parameters, this.ignoreCase, this.reverseOutputDirection);

                    if (result.StartsWith(@"{\rtf"))
                    {
                        this.highlights = Regex.Matches(result, @"\\highlight2" ).Count;
                        this.outputTextBox.Clear();
                        this.outputTextBox.Rtf = result;
                    }
                    else
                    {
                        this.highlights = 0;
                        this.outputTextBox.Clear();
                        this.outputTextBox.Text = result;
                    }
                }
                catch (Exception e)
                {
                    this.outputTextBox.Text = ReportError(e.Message);
                }
            }
        }

        private string ReportError(string text)
        {
            return "Error: " + text;
        }

        private void UpdateInputStatusTextBox()
        {
            var counts = FreeFunctions.Count(this.inputTextBox.Text);

            this.inputStatusTextBox.Text = string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3);
        }

        private void UpdateOutputStatusTextBox()
        {
            var counts = FreeFunctions.Count(this.outputTextBox.Text);

            this.outputStatusTextBox.Text = string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3) + (this.highlights != 0 ? string.Format(" {0} highlights.", this.highlights) : "");
        }

        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.inputTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                    this.inputTextBox.Focus();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Opening file failed.\n" + e.Message);
                }
            }
        }

        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, this.outputTextBox.Text);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Saving file failed.\n" + e.Message);
                }
            }
        }

        private void buttonPasteToInput_Click(object sender, EventArgs e)
        {
            this.inputTextBox.Text = Clipboard.GetText();
        }

        private void buttonCopyOutputToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.outputTextBox.Text);
        }

        private void buttonCopyOutputToInput_Click(object sender, EventArgs e)
        {
            this.inputTextBox.Text = this.outputTextBox.Text;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void buttonSaveOutput_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAlgorithmsTreeView();
        }

        private void outputTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void UpdateIgnoreCaseButton()
        {
            this.ignoreCaseButton.Image = this.ignoreCase ? Properties.Resources.ignore_case_on : Properties.Resources.ignore_case_off;
        }

        private void UpdateReverseOutputButton()
        {
            this.reverseOutputButton.Image = this.reverseOutputDirection ? Properties.Resources.direction_up : Properties.Resources.direction_down;
        }

        private void ignoreCaseButton_Click(object sender, EventArgs e)
        {
            ToggleIgnoreCase();
        }

        private void ToggleIgnoreCase()
        {
            this.ignoreCase = !this.ignoreCase;

            UpdateIgnoreCaseButton();

            UpdateOutput();
        }

        private void reverseOutputButton_Click(object sender, EventArgs e)
        {
            ToggleOutputDirection();
        }

        private void ToggleOutputDirection()
        {
            this.reverseOutputDirection = !this.reverseOutputDirection;

            UpdateReverseOutputButton();

            UpdateOutput();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.D:
                    this.filterTextBox.Focus();
                    this.filterTextBox.SelectAll();
                    break;

                case Keys.Escape:
                    if (this.filterTextBox.Focused)
                    {
                        this.filterTextBox.Clear();
                    }
                    break;

                case Keys.Alt | Keys.I:
                    this.inputTextBox.Focus();
                    break;

                case Keys.Alt | Keys.O:
                    this.outputTextBox.Focus();
                    break;

                case Keys.Control | Keys.I:
                    this.ToggleIgnoreCase();
                    break;

                case Keys.Control | Keys.R:
                    this.ToggleOutputDirection();
                    break;

                case Keys.Control | Keys.O:
                    this.OpenFile();
                    break;

                case Keys.Control | Keys.Q:
                    this.Close();
                    break;

                case Keys.Control | Keys.S:
                    this.SaveFile();
                    break;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }
   }
}
