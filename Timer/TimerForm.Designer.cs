namespace Timer
{
    partial class TimerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.focusArea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.AllowPromptAsInput = false;
            this.maskedTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 96F);
            this.maskedTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maskedTextBox.Location = new System.Drawing.Point(12, 12);
            this.maskedTextBox.Mask = "00:00:00";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.PromptChar = '0';
            this.maskedTextBox.ResetOnSpace = false;
            this.maskedTextBox.ShortcutsEnabled = false;
            this.maskedTextBox.Size = new System.Drawing.Size(552, 152);
            this.maskedTextBox.TabIndex = 5;
            this.maskedTextBox.TabStop = false;
            this.maskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox.Enter += new System.EventHandler(this.maskedTextBox_Enter);
            this.maskedTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.focusArea_MouseDown);
            this.maskedTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.focusArea_MouseMove);
            this.maskedTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.maskedTextBox_MouseUp);
            // 
            // focusArea
            // 
            this.focusArea.AutoSize = true;
            this.focusArea.Location = new System.Drawing.Point(689, 54);
            this.focusArea.Name = "focusArea";
            this.focusArea.Size = new System.Drawing.Size(0, 13);
            this.focusArea.TabIndex = 6;
            this.focusArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.focusArea_MouseDown);
            this.focusArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.focusArea_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(576, 176);
            this.Controls.Add(this.focusArea);
            this.Controls.Add(this.maskedTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Timer";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Label focusArea;
    }
}

