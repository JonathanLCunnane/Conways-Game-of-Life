namespace Conway_s_Game_of_Life
{
    partial class SetDimensionsWindow
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
            this.cancelDimensionsButton = new System.Windows.Forms.Button();
            this.submitDimensionsButton = new System.Windows.Forms.Button();
            this.setDimensionsLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xInput = new System.Windows.Forms.NumericUpDown();
            this.yInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.xInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yInput)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelDimensionsButton
            // 
            this.cancelDimensionsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.cancelDimensionsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelDimensionsButton.Location = new System.Drawing.Point(124, 114);
            this.cancelDimensionsButton.Name = "cancelDimensionsButton";
            this.cancelDimensionsButton.Size = new System.Drawing.Size(98, 35);
            this.cancelDimensionsButton.TabIndex = 5;
            this.cancelDimensionsButton.Text = "Cancel";
            this.cancelDimensionsButton.UseVisualStyleBackColor = true;
            // 
            // submitDimensionsButton
            // 
            this.submitDimensionsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.submitDimensionsButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitDimensionsButton.Location = new System.Drawing.Point(12, 114);
            this.submitDimensionsButton.Name = "submitDimensionsButton";
            this.submitDimensionsButton.Size = new System.Drawing.Size(98, 35);
            this.submitDimensionsButton.TabIndex = 4;
            this.submitDimensionsButton.Text = "Set Dimensions";
            this.submitDimensionsButton.UseVisualStyleBackColor = true;
            // 
            // setDimensionsLabel
            // 
            this.setDimensionsLabel.AutoSize = true;
            this.setDimensionsLabel.Location = new System.Drawing.Point(44, 9);
            this.setDimensionsLabel.Name = "setDimensionsLabel";
            this.setDimensionsLabel.Size = new System.Drawing.Size(156, 13);
            this.setDimensionsLabel.TabIndex = 6;
            this.setDimensionsLabel.Text = "Set Dimensions (2 < x, y < 513):";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(12, 39);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(15, 13);
            this.xLabel.TabIndex = 7;
            this.xLabel.Text = "x:";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(9, 74);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(15, 13);
            this.yLabel.TabIndex = 8;
            this.yLabel.Text = "y:";
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(47, 39);
            this.xInput.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.xInput.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(120, 20);
            this.xInput.TabIndex = 9;
            this.xInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(47, 74);
            this.yInput.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.yInput.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(120, 20);
            this.yInput.TabIndex = 10;
            this.yInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // SetDimensionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 161);
            this.Controls.Add(this.yInput);
            this.Controls.Add(this.xInput);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.setDimensionsLabel);
            this.Controls.Add(this.cancelDimensionsButton);
            this.Controls.Add(this.submitDimensionsButton);
            this.Name = "SetDimensionsWindow";
            this.Text = "Set Dimensions";
            ((System.ComponentModel.ISupportInitialize)(this.xInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelDimensionsButton;
        private System.Windows.Forms.Button submitDimensionsButton;
        private System.Windows.Forms.Label setDimensionsLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.NumericUpDown xInput;
        private System.Windows.Forms.NumericUpDown yInput;
    }
}