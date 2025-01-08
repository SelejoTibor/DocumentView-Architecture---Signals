namespace Signals
{
    partial class GraphicsSignalView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            zoomIn = new Button();
            zoomOut = new Button();
            SuspendLayout();
            // 
            // zoomIn
            // 
            zoomIn.Location = new Point(35, 31);
            zoomIn.Name = "zoomIn";
            zoomIn.Size = new Size(40, 29);
            zoomIn.TabIndex = 0;
            zoomIn.Text = "+";
            zoomIn.UseVisualStyleBackColor = true;
            zoomIn.Click += zoomIn_Click;
            // 
            // zoomOut
            // 
            zoomOut.Location = new Point(81, 31);
            zoomOut.Name = "zoomOut";
            zoomOut.Size = new Size(40, 29);
            zoomOut.TabIndex = 1;
            zoomOut.Text = "-";
            zoomOut.UseVisualStyleBackColor = true;
            zoomOut.Click += zoomOut_Click;
            // 
            // GraphicsSignalView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(zoomOut);
            Controls.Add(zoomIn);
            Name = "GraphicsSignalView";
            Size = new Size(511, 356);
            ResumeLayout(false);
        }

        #endregion

        private Button zoomIn;
        private Button zoomOut;
    }
}
