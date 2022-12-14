
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
            this.label1 = new System.Windows.Forms.Label();
            this.intervalInput = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.noTimeIntervalCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.intervalInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set Generation Interval (30 - 3000ms):";
            // 
            // intervalInput
            // 
            this.intervalInput.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
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
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set Time Interval";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(124, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // noTimeIntervalCheckBox
            // 
            this.noTimeIntervalCheckBox.AutoSize = true;
            this.noTimeIntervalCheckBox.Location = new System.Drawing.Point(241, 35);
            this.noTimeIntervalCheckBox.Name = "noTimeIntervalCheckBox";
            this.noTimeIntervalCheckBox.Size = new System.Drawing.Size(78, 17);
            this.noTimeIntervalCheckBox.TabIndex = 4;
            this.noTimeIntervalCheckBox.Text = "No Interval";
            this.noTimeIntervalCheckBox.UseVisualStyleBackColor = true;
            this.noTimeIntervalCheckBox.CheckedChanged += new System.EventHandler(this.noTimeIntervalCheckBox_CheckedChanged);
            // 
            // SetIntervalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 111);
            this.Controls.Add(this.noTimeIntervalCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.intervalInput);
            this.Controls.Add(this.label1);
            this.Name = "SetIntervalWindow";
            this.Text = "Set Interval";
            ((System.ComponentModel.ISupportInitialize)(this.intervalInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown intervalInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox noTimeIntervalCheckBox;
    }
}