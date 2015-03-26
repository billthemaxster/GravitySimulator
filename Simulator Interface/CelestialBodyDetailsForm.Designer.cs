namespace Simulator.Interface
{
    partial class CelestialBodyDetailsForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.vePosition = new Simulator.Interface.VectorEditor();
            this.veVelocity = new Simulator.Interface.VectorEditor();
            this.veAccel = new Simulator.Interface.VectorEditor();
            this.lblMass = new System.Windows.Forms.Label();
            this.txtMass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(57, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // vePosition
            // 
            this.vePosition.AutoSize = true;
            this.vePosition.Label = "Postion:";
            this.vePosition.Location = new System.Drawing.Point(14, 38);
            this.vePosition.MaximumSize = new System.Drawing.Size(158, 23);
            this.vePosition.MinimumSize = new System.Drawing.Size(158, 23);
            this.vePosition.Name = "vePosition";
            this.vePosition.Size = new System.Drawing.Size(158, 23);
            this.vePosition.TabIndex = 4;
            // 
            // veVelocity
            // 
            this.veVelocity.AutoSize = true;
            this.veVelocity.Label = "Velocity:";
            this.veVelocity.Location = new System.Drawing.Point(14, 67);
            this.veVelocity.MaximumSize = new System.Drawing.Size(158, 23);
            this.veVelocity.MinimumSize = new System.Drawing.Size(158, 23);
            this.veVelocity.Name = "veVelocity";
            this.veVelocity.Size = new System.Drawing.Size(158, 23);
            this.veVelocity.TabIndex = 5;
            // 
            // veAccel
            // 
            this.veAccel.AutoSize = true;
            this.veAccel.Label = "Accel:";
            this.veAccel.Location = new System.Drawing.Point(14, 96);
            this.veAccel.MaximumSize = new System.Drawing.Size(158, 23);
            this.veAccel.MinimumSize = new System.Drawing.Size(158, 23);
            this.veAccel.Name = "veAccel";
            this.veAccel.Size = new System.Drawing.Size(158, 23);
            this.veAccel.TabIndex = 6;
            // 
            // lblMass
            // 
            this.lblMass.AutoSize = true;
            this.lblMass.Location = new System.Drawing.Point(14, 126);
            this.lblMass.Name = "lblMass";
            this.lblMass.Size = new System.Drawing.Size(35, 13);
            this.lblMass.TabIndex = 7;
            this.lblMass.Text = "Mass:";
            // 
            // txtMass
            // 
            this.txtMass.Location = new System.Drawing.Point(57, 123);
            this.txtMass.Name = "txtMass";
            this.txtMass.Size = new System.Drawing.Size(100, 20);
            this.txtMass.TabIndex = 8;
            this.txtMass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMass_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 158);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CelestialBodyDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 195);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMass);
            this.Controls.Add(this.lblMass);
            this.Controls.Add(this.veAccel);
            this.Controls.Add(this.veVelocity);
            this.Controls.Add(this.vePosition);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "CelestialBodyDetailsForm";
            this.Text = "Save Body";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private VectorEditor vePosition;
        private VectorEditor veVelocity;
        private VectorEditor veAccel;
        private System.Windows.Forms.Label lblMass;
        private System.Windows.Forms.TextBox txtMass;
        private System.Windows.Forms.Button btnSave;
    }
}