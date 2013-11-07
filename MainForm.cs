﻿namespace TextManipulationUtility
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

            foreach (var algorithm in algorithms.algorithms)
            {
                var nodes = manipulationsTreeView.Nodes.Find(algorithm.Group, false);
                var groupNode = nodes.Length == 0 ? manipulationsTreeView.Nodes.Add(algorithm.Group, algorithm.Group) : nodes[0];
                
                var node = (algorithm.Group == algorithm.Name) ? groupNode : groupNode.Nodes.Add(algorithm.Name);
                
                node.Tag = algorithm;
            }

            inputTextBox.Text = Clipboard.GetText();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void manipulationsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var treeView = (TreeView)sender;
            selectedAlgorithm = (Algorithm)treeView.SelectedNode.Tag;

            updateOutput();
        }

        private void updateOutput()
        {
            if (selectedAlgorithm != null)
            {
                outputTextBox.Text = selectedAlgorithm.Apply(inputTextBox.Text);
            }
        }
    }
}
