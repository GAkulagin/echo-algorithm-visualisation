using System.ComponentModel;

namespace EchoAlgorithm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.graphViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.cbGraphLayouts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGraph = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnStartAlg = new System.Windows.Forms.Button();
            this.btnStopAlg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // graphViewer
            // 
            this.graphViewer.ArrowheadLength = 10D;
            this.graphViewer.AsyncLayout = false;
            this.graphViewer.AutoScroll = true;
            this.graphViewer.BackwardEnabled = false;
            this.graphViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphViewer.BuildHitTree = true;
            this.graphViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.graphViewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.graphViewer.EdgeInsertButtonVisible = false;
            this.graphViewer.FileName = "";
            this.graphViewer.ForwardEnabled = false;
            this.graphViewer.Graph = null;
            this.graphViewer.InsertingEdge = false;
            this.graphViewer.LayoutAlgorithmSettingsButtonVisible = false;
            this.graphViewer.LayoutEditingEnabled = true;
            this.graphViewer.Location = new System.Drawing.Point(0, 0);
            this.graphViewer.LooseOffsetForRouting = 0.25D;
            this.graphViewer.MouseHitDistance = 0.05D;
            this.graphViewer.Name = "graphViewer";
            this.graphViewer.NavigationVisible = false;
            this.graphViewer.NeedToCalculateLayout = true;
            this.graphViewer.OffsetForRelaxingInRouting = 0.6D;
            this.graphViewer.PaddingForEdgeRouting = 8D;
            this.graphViewer.PanButtonPressed = false;
            this.graphViewer.SaveAsImageEnabled = true;
            this.graphViewer.SaveAsMsaglEnabled = true;
            this.graphViewer.SaveButtonVisible = false;
            this.graphViewer.SaveGraphButtonVisible = false;
            this.graphViewer.SaveInVectorFormatEnabled = true;
            this.graphViewer.Size = new System.Drawing.Size(624, 758);
            this.graphViewer.TabIndex = 0;
            this.graphViewer.TightOffsetForRouting = 0.125D;
            this.graphViewer.ToolBarIsVisible = true;
            this.graphViewer.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("graphViewer.Transform")));
            this.graphViewer.UndoRedoButtonsVisible = false;
            this.graphViewer.WindowZoomButtonPressed = false;
            this.graphViewer.ZoomF = 1D;
            this.graphViewer.ZoomWindowThreshold = 0.05D;
            // 
            // cbGraphLayouts
            // 
            this.cbGraphLayouts.FormattingEnabled = true;
            this.cbGraphLayouts.Location = new System.Drawing.Point(630, 35);
            this.cbGraphLayouts.Name = "cbGraphLayouts";
            this.cbGraphLayouts.Size = new System.Drawing.Size(444, 24);
            this.cbGraphLayouts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(630, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор графа";
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(1084, 36);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 3;
            this.btnGraph.Text = "OK";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(630, 261);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(529, 485);
            this.rtbLog.TabIndex = 4;
            this.rtbLog.Text = "";
            // 
            // btnStartAlg
            // 
            this.btnStartAlg.Enabled = false;
            this.btnStartAlg.Location = new System.Drawing.Point(630, 121);
            this.btnStartAlg.Name = "btnStartAlg";
            this.btnStartAlg.Size = new System.Drawing.Size(129, 44);
            this.btnStartAlg.TabIndex = 5;
            this.btnStartAlg.Text = "Start";
            this.btnStartAlg.UseVisualStyleBackColor = true;
            this.btnStartAlg.Click += new System.EventHandler(this.btnStartAlg_Click);
            // 
            // btnStopAlg
            // 
            this.btnStopAlg.Enabled = false;
            this.btnStopAlg.Location = new System.Drawing.Point(830, 121);
            this.btnStopAlg.Name = "btnStopAlg";
            this.btnStopAlg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStopAlg.Size = new System.Drawing.Size(129, 44);
            this.btnStopAlg.TabIndex = 6;
            this.btnStopAlg.Text = "Stop";
            this.btnStopAlg.UseVisualStyleBackColor = true;
            this.btnStopAlg.Click += new System.EventHandler(this.btnStopAlg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 758);
            this.Controls.Add(this.btnStopAlg);
            this.Controls.Add(this.btnStartAlg);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbGraphLayouts);
            this.Controls.Add(this.graphViewer);
            this.Name = "Form1";
            this.Text = "Алгоритм \"Эхо\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnStopAlg;

        private System.Windows.Forms.Button btnStartAlg;

        private System.Windows.Forms.ComboBox cbGraphLayouts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.RichTextBox rtbLog;

        private Microsoft.Msagl.GraphViewerGdi.GViewer graphViewer;

        #endregion
    }
}