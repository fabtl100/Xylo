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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelSequenceIndicator = new System.Windows.Forms.Label();
            this.labelSequence = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.songTextBox = new System.Windows.Forms.TextBox();
            this.defaultSongListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(186, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 108);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ab";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(230, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 108);
            this.button2.TabIndex = 1;
            this.button2.Text = "Bb";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(274, 380);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 108);
            this.button3.TabIndex = 2;
            this.button3.Text = "C";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(318, 380);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 108);
            this.button4.TabIndex = 3;
            this.button4.Text = "Db";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(362, 380);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 108);
            this.button5.TabIndex = 4;
            this.button5.Text = "Eb";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(406, 380);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(38, 108);
            this.button6.TabIndex = 5;
            this.button6.Text = "F";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(450, 380);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(38, 108);
            this.button7.TabIndex = 6;
            this.button7.Text = "G";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(494, 380);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 108);
            this.button8.TabIndex = 7;
            this.button8.Text = "Ab";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(538, 380);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(38, 108);
            this.button9.TabIndex = 8;
            this.button9.Text = "Bb";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // buttonTerminate
            // 
            this.buttonTerminate.Location = new System.Drawing.Point(601, 423);
            this.buttonTerminate.Name = "buttonTerminate";
            this.buttonTerminate.Size = new System.Drawing.Size(129, 23);
            this.buttonTerminate.TabIndex = 9;
            this.buttonTerminate.Text = "Terminar / Escuchar";
            this.buttonTerminate.UseVisualStyleBackColor = true;
            this.buttonTerminate.Click += new System.EventHandler(this.buttonTerminate_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(601, 380);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(129, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Comenzar de nuevo";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelSequenceIndicator
            // 
            this.labelSequenceIndicator.AutoSize = true;
            this.labelSequenceIndicator.Location = new System.Drawing.Point(184, 7);
            this.labelSequenceIndicator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSequenceIndicator.Name = "labelSequenceIndicator";
            this.labelSequenceIndicator.Size = new System.Drawing.Size(61, 13);
            this.labelSequenceIndicator.TabIndex = 11;
            this.labelSequenceIndicator.Text = "Secuencia:";
            // 
            // labelSequence
            // 
            this.labelSequence.AutoSize = true;
            this.labelSequence.Location = new System.Drawing.Point(184, 31);
            this.labelSequence.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSequence.Name = "labelSequence";
            this.labelSequence.Size = new System.Drawing.Size(0, 13);
            this.labelSequence.TabIndex = 12;
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(601, 464);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(129, 23);
            this.buttonSend.TabIndex = 13;
            this.buttonSend.Text = "Enviar a Arduino";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(601, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Canción en Arduino:";
            // 
            // songTextBox
            // 
            this.songTextBox.Location = new System.Drawing.Point(604, 322);
            this.songTextBox.Name = "songTextBox";
            this.songTextBox.Size = new System.Drawing.Size(126, 20);
            this.songTextBox.TabIndex = 15;
            this.songTextBox.Text = "Ninguna";
            // 
            // defaultSongListBox
            // 
            this.defaultSongListBox.FormattingEnabled = true;
            this.defaultSongListBox.Location = new System.Drawing.Point(604, 49);
            this.defaultSongListBox.Name = "defaultSongListBox";
            this.defaultSongListBox.Size = new System.Drawing.Size(120, 225);
            this.defaultSongListBox.TabIndex = 16;
            this.defaultSongListBox.DoubleClick += new System.EventHandler(this.defaultSongListBox_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Canciones pre-programadas:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 499);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.defaultSongListBox);
            this.Controls.Add(this.songTextBox);
            this.Controls.Add(this.label1);
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
            this.Text = "Form1";
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelSequenceIndicator;
        private System.Windows.Forms.Label labelSequence;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox songTextBox;
        private System.Windows.Forms.ListBox defaultSongListBox;
        private System.Windows.Forms.Label label2;
    }
}

