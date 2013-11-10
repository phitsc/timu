namespace TextManipulationUtility
{
    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private Algorithms algorithms = new Algorithms();
        private Algorithm selectedAlgorithm;

        public MainForm()
        {
            InitializeComponent();

            foreach (var algorithm in this.algorithms.algorithms)
            {
                var nodes = this.manipulationsTreeView.Nodes.Find(algorithm.Group, false);
                var groupNode = nodes.Length == 0 ? this.manipulationsTreeView.Nodes.Add(algorithm.Group, algorithm.Group) : nodes[0];
                
                var node = (algorithm.Group == algorithm.Name) ? groupNode : groupNode.Nodes.Add(algorithm.Name);
                
                node.Tag = algorithm;
            }

            this.manipulationsTreeView.Sort();

            this.inputTextBox.Text = Clipboard.GetText();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateOutput();
        }

        private void manipulationsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var treeView = (TreeView)sender;
            this.selectedAlgorithm = (Algorithm)treeView.SelectedNode.Tag;

            this.UpdateOutput();
        }

        private void paramTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateOutput();
        }

        private void UpdateOutput()
        {
            if (this.selectedAlgorithm != null)
            {
                try
                {
                    var result = this.selectedAlgorithm.Apply(this.inputTextBox.Text, this.paramTextBox.Text);

                    if (result.StartsWith(@"{\rtf"))
                    {
                        this.outputTextBox.Rtf = result;
                    }
                    else
                    {
                        this.outputTextBox.Text = result;
                    }
                }
                catch (Exception e)
                {
                    this.outputTextBox.Text = "Error: " + e.Message;
                }
            }
        }
    }
}
