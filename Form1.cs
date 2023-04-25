using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EchoAlgorithm.GraphSamples;

namespace EchoAlgorithm
{
    public partial class Form1 : Form
    {
        private List<IGraph> graphLayouts = new List<IGraph>();
        private GraphModel currentGraph;
        
        public Form1()
        {
            InitializeComponent();
            graphLayouts.Add(new TreeSevenNodesGraph());
            graphLayouts.Add(new FiveNodesGraphV1());

            foreach (var graph in graphLayouts)
                cbGraphLayouts.Items.Add(graph.Description);
            
            cbGraphLayouts.SelectedItem = cbGraphLayouts.Items[0];
        }
        
        private void WriteToLog(string message)
        {
            rtbLog.Invoke((MethodInvoker)delegate
            {
                if (message != null)
                    rtbLog.Text += "\n\n" + message;
            });
        }
        private void UpdateGraph()
        {
            graphViewer.Invoke((MethodInvoker)delegate
            {
                graphViewer.Graph = currentGraph.GraphPicture;
            });
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            btnStartAlg.Enabled = true;
            btnStopAlg.Enabled = true;
            
            if (cbGraphLayouts.SelectedIndex == -1) return;
            
            currentGraph = graphLayouts[cbGraphLayouts.SelectedIndex].Graph;
            UpdateGraph();
        }

        private void btnStartAlg_Click(object sender, EventArgs e)
        {
            EchoAlgorithm.Workers.Clear();
            
            btnStartAlg.Enabled = false;
            btnGraph.Enabled = false;

            try
            {
                EchoAlgorithm.CreateWorkersFromGraph(currentGraph);

                foreach (var worker in EchoAlgorithm.Workers)
                {
                    worker.Logger += WriteToLog;
                }
                foreach (var kvp in currentGraph.NodeSet)
                {
                    kvp.Value.GraphPictureChanged += UpdateGraph;
                }
                
                EchoAlgorithm.Run();
            }
            catch (Exception exc)
            {
                WriteToLog(exc.Message);
            }
        }

        private void btnStopAlg_Click(object sender, EventArgs e)
        {
            try
            {
                EchoAlgorithm.Stop();
            }
            catch (Exception exc)
            {
                WriteToLog(exc.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                EchoAlgorithm.Stop();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}