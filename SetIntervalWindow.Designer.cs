
namespace Conway_s_Game_of_Life
{
    partial class SetIntervalWindow
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
            this.setGenerationIntervalLabel = new System.Windows.Forms.Label();
            this.intervalInput = new System.Windows.Forms.NumericUpDown();
            this.submitIntervalButton = new System.Windows.Forms.Button();
            this.cancelIntervalButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.intervalInput)).BeginInit();
            this.SuspendLayout();
            // 
            // setGenerationIntervalLabel
            // 
            this.setGenerationIntervalLabel.AutoSize = true;
            this.setGenerationIntervalLabel.Location = new System.Drawing.Point(35, 9);
            this.setGenerationIntervalLabel.Name = "setGenerationIntervalLabel";
            this.setGenerationIntervalLabel.Size = new System.Drawing.Size(180, 13);
            this.setGenerationIntervalLabel.TabIndex = 0;
            this.setGenerationIntervalLabel.Text = "Set Generation Interval (1 - 3000ms):";
            // 
            // intervalInput
            // 
            this.intervalInput.Location = new System.Drawing.Point(65, 34);
            this.intervalInput.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.intervalInput.Name = "intervalInput";
            this.intervalInput.Size = new System.Drawing.Size(120, 20);
            this.intervalInput.TabIndex = 1;
            // 
            // submitIntervalButton
            // 
            this.submitIntervalButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.submitIntervalButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitIntervalButton.Location = new System.Drawing.Point(12, 64);
            this.submitIntervalButton.Name = "submitIntervalButton";
            this.submitIntervalButton.Size = new System.Drawing.Size(98, 35);
            this.submitIntervalButton.TabIndex = 2;
            this.submitIntervalButton.Text = "Set Time Interval";
            this.submitIntervalButton.UseVisualStyleBackColor = true;
            // 
            // cancelIntervalButton
            // 
            this.cancelIntervalButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.cancelIntervalButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelIntervalButton.Location = new System.Drawing.Point(124, 64);
            this.cancelIntervalButton.Name = "cancelIntervalButton";
            this.cancelIntervalButton.Size = new System.Drawing.Size(98, 35);
            this.cancelIntervalButton.TabIndex = 3;
            this.cancelIntervalButton.Text = "Cancel";
            this.cancelIntervalButton.UseVisualStyleBackColor = true;
            // 
            // SetIntervalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.cancelIntervalButton);
            this.Controls.Add(this.submitIntervalButton);
            this.Controls.Add(this.intervalInput);
            this.Controls.Add(this.setGenerationIntervalLabel);
            this.Name = "SetIntervalWindow";
            this.Text = "Set Interval";
            ((System.ComponentModel.ISupportInitialize)(this.intervalInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label setGenerationIntervalLabel;
        private System.Windows.Forms.NumericUpDown intervalInput;
        private System.Windows.Forms.Button submitIntervalButton;
        private System.Windows.Forms.Button cancelIntervalButton;
    }
}