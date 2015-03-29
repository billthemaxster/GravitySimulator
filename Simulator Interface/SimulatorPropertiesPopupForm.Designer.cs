namespace Simulator.Interface
{
    partial class SimulatorPropertiesPopupForm
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
            this.txtTimeStep = new System.Windows.Forms.TextBox();
            this.lblTimeStep = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTimeStep
            // 
            this.txtTimeStep.Location = new System.Drawing.Point(94, 12);
            this.txtTimeStep.Name = "txtTimeStep";
            this.txtTimeStep.Size = new System.Drawing.Size(100, 20);
            this.txtTimeStep.TabIndex = 0;
            this.txtTimeStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDouble_KeyPress);
            // 
            // lblTimeStep
            // 
            this.lblTimeStep.AutoSize = true;
            this.lblTimeStep.Location = new System.Drawing.Point(32, 15);
            this.lblTimeStep.Name = "lblTimeStep";
            this.lblTimeStep.Size = new System.Drawing.Size(56, 13);
            this.lblTimeStep.TabIndex = 1;
            this.lblTimeStep.Text = "Time step:";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(94, 38);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 2;
            this.txtDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDouble_KeyPress);
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(94, 64);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(100, 20);
            this.txtResolution.TabIndex = 3;
            this.txtResolution.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(38, 41);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Duration:";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(4, 67);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(84, 13);
            this.lblResolution.TabIndex = 5;
            this.lblResolution.Text = "Print Resolution:";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(65, 90);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // SimulatorPropertiesPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 118);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtResolution);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblTimeStep);
            this.Controls.Add(this.txtTimeStep);
            this.MaximumSize = new System.Drawing.Size(235, 157);
            this.MinimumSize = new System.Drawing.Size(235, 157);
            this.Name = "SimulatorPropertiesPopupForm";
            this.Text = "Set Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimeStep;
        private System.Windows.Forms.Label lblTimeStep;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtResolution;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Button btnRun;
    }
}