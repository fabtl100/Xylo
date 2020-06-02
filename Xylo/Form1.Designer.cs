namespace Xylo
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonTerminate = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelSequenceIndicator = new System.Windows.Forms.Label();
            this.labelSequence = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(13, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 108);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ab (A)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(57, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 108);
            this.button2.TabIndex = 1;
            this.button2.Text = "Bb (S)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(101, 382);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 108);
            this.button3.TabIndex = 2;
            this.button3.Text = "C (D)";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(145, 382);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 108);
            this.button4.TabIndex = 3;
            this.button4.Text = "Db (F)";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(189, 382);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 108);
            this.button5.TabIndex = 4;
            this.button5.Text = "Eb (G)";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(233, 382);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(38, 108);
            this.button6.TabIndex = 5;
            this.button6.Text = "F  (H)";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(277, 382);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(38, 108);
            this.button7.TabIndex = 6;
            this.button7.Text = "G  (J)";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(321, 382);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 108);
            this.button8.TabIndex = 7;
            this.button8.Text = "Ab (K)";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(365, 382);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(38, 108);
            this.button9.TabIndex = 8;
            this.button9.Text = "Bb (L)";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // buttonTerminate
            // 
            this.buttonTerminate.Location = new System.Drawing.Point(428, 425);
            this.buttonTerminate.Name = "buttonTerminate";
            this.buttonTerminate.Size = new System.Drawing.Size(129, 23);
            this.buttonTerminate.TabIndex = 9;
            this.buttonTerminate.Text = "End / Listen (Z)";
            this.buttonTerminate.UseVisualStyleBackColor = true;
            this.buttonTerminate.Click += new System.EventHandler(this.buttonTerminate_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(430, 198);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(129, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start Again";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelSequenceIndicator
            // 
            this.labelSequenceIndicator.AutoSize = true;
            this.labelSequenceIndicator.Location = new System.Drawing.Point(11, 9);
            this.labelSequenceIndicator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSequenceIndicator.Name = "labelSequenceIndicator";
            this.labelSequenceIndicator.Size = new System.Drawing.Size(85, 13);
            this.labelSequenceIndicator.TabIndex = 11;
            this.labelSequenceIndicator.Text = "Note Sequence:";
            // 
            // labelSequence
            // 
            this.labelSequence.AutoSize = true;
            this.labelSequence.Location = new System.Drawing.Point(11, 33);
            this.labelSequence.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSequence.Name = "labelSequence";
            this.labelSequence.Size = new System.Drawing.Size(0, 13);
            this.labelSequence.TabIndex = 12;
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(430, 227);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(129, 23);
            this.buttonSend.TabIndex = 13;
            this.buttonSend.Text = "Send to Arduino";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 499);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelSequence);
            this.Controls.Add(this.labelSequenceIndicator);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonTerminate);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Xylo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button buttonTerminate;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelSequenceIndicator;
        private System.Windows.Forms.Label labelSequence;
        private System.Windows.Forms.Button buttonSend;
    }
}

