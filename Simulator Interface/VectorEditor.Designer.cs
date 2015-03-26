namespace Simulator.Interface
{
    partial class VectorEditor
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
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(42, 3);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(33, 20);
            this.txtX.TabIndex = 0;
            this.txtX.TextChanged += new System.EventHandler(this.txtX_TextChanged);
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComponent_KeyPress);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(81, 3);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(33, 20);
            this.txtY.TabIndex = 1;
            this.txtY.TextChanged += new System.EventHandler(this.txtY_TextChanged);
            this.txtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComponent_KeyPress);
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(120, 3);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(33, 20);
            this.txtZ.TabIndex = 2;
            this.txtZ.TextChanged += new System.EventHandler(this.txtZ_TextChanged);
            this.txtZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComponent_KeyPress);
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(-3, 6);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(39, 13);
            this.lblLabel.TabIndex = 3;
            this.lblLabel.Text = "[Label]";
            // 
            // VectorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.txtZ);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.MinimumSize = new System.Drawing.Size(158, 23);
            this.Name = "VectorEditor";
            this.Size = new System.Drawing.Size(158, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.Label lblLabel;
    }
}
