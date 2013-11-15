namespace TextManipulationUtility
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private Algorithms algorithms = new Algorithms();
        private Algorithm selectedAlgorithm;

        public MainForm()
        {
            InitializeComponent();

            foreach (var algorithm in this.algorithms.List)
            {
                var nodes = this.manipulationsTreeView.Nodes.Find(algorithm.Group, false);
                var groupNode = nodes.Length == 0 ? this.manipulationsTreeView.Nodes.Add(algorithm.Group, algorithm.Group) : nodes[0];
                
                var node = (algorithm.Group == algorithm.Name) ? groupNode : groupNode.Nodes.Add(algorithm.Name);
                
                node.Tag = algorithm;
            }

            this.manipulationsTreeView.Sort();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.inputTextBox.Text = Clipboard.GetText();
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

        private void UpdateInputStatusTextBox()
        {
            var counts = FreeFunctions.Count(this.inputTextBox.Text);

            this.inputStatusTextBox.Text = string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3);
        }

        private void UpdateOutputStatusTextBox()
        {
            var counts = FreeFunctions.Count(this.outputTextBox.Text);

            this.outputStatusTextBox.Text = string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3);
        }
    }
}
