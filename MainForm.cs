namespace TextManipulationUtility
{
    using System;
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
        private int? highlights = null;

        public MainForm()
        {
            InitializeComponent();

            LoadSettings();

            UpdateIgnoreCaseButton();
            UpdateReverseOutputButton();

            NativeMethods.SetCueText(this.filterTextBox, "Filter (Alt + D)");

            UpdateAlgorithmsTreeView();

            this.algorithmsTreeView.SelectedNode = this.algorithmsTreeView.Nodes[0];
        }

        private void UpdateAlgorithmsTreeView()
        {
            this.algorithmsTreeView.Nodes.Clear();

            foreach (var algorithm in this.algorithms.List)
            {
                if (this.filterTextBox.Text.Length == 0 || CultureInfo.CurrentCulture.CompareInfo.IndexOf(algorithm.Name, this.filterTextBox.Text, CompareOptions.IgnoreCase) >= 0)
                {
                    var nodes = this.algorithmsTreeView.Nodes.Find(algorithm.Group, false);
                    var groupNode = nodes.Length == 0 ? this.algorithmsTreeView.Nodes.Add(algorithm.Group, algorithm.Group) : nodes[0];

                    var node = (algorithm.Group == algorithm.Name) ? groupNode : groupNode.Nodes.Add(algorithm.Name);

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
            if (storedLocation != null && (storedLocation.X != -1 && storedLocation.Y != -1))
            {
                this.Location = Properties.Settings.Default.MainFormLocation;
            }

            var storedSize = Properties.Settings.Default.MainFormSize;
            if (storedSize != null && (storedSize.Width != -1 && storedSize.Height != -1))
            {
                this.Size = Properties.Settings.Default.MainFormSize;
            }

            this.inputTextBox.Text = Clipboard.GetText();
            this.inputTextBox.Select();
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
            
            this.paramTextBox.Enabled = this.selectedAlgorithm != null ? this.selectedAlgorithm.RequiresParam : false;
            this.inputHintTextBox.Text = this.selectedAlgorithm != null ? this.selectedAlgorithm.InputHint : "";
            this.paramHintTextBox.Text = this.selectedAlgorithm != null ? this.selectedAlgorithm.ParamHint : "";

            this.UpdateOutput();
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
                    var result = this.selectedAlgorithm.Apply(this.inputTextBox.Text, this.paramTextBox.Text, this.ignoreCase, this.reverseOutputDirection);

                    if (result.StartsWith(@"{\rtf"))
                    {
                        this.highlights = Regex.Matches(result, @"\\highlight2" ).Count;
                        this.outputTextBox.Rtf = result;
                    }
                    else
                    {
                        this.highlights = null;
                        this.outputTextBox.Text = result;
                    }
                }
                catch (Exception e)
                {
                    this.outputTextBox.Text = "Error: " + e.Message;
                }
            }
        }

        private void UpdateInputStatusTextBox()
        {
            var counts = FreeFunctions.Count(this.inputTextBox.Text);

            this.inputStatusTextBox.Text = string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3);
        }

        private void UpdateOutputStatusTextBox()
        {
            var counts = FreeFunctions.Count(this.outputTextBox.Text);

            this.outputStatusTextBox.Text = string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3) + (this.highlights != null ? string.Format(" {0} highlights.", this.highlights) : "");
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
