using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;


namespace Xylo
{
    public partial class Form1 : Form
    {
        // song will hold the arrays holding the note and the duration of the note
        List<int[]> song;
        // projectDirectory is the path in the computer where the sounds for each note are saved
        string projectDirectory;
        // Determines wether the user is starting to play a song or has started already (this is to start the timer the first time)
        bool isFirstStroke;
        // time saves the time in ms counted by the timer between strokes
        int time;
        // Counter used to jump the line in the label that saves the played notes
        int jumper;
        // note holds the played note at a certain time
        int note;
        // 
        System.IO.Ports.SerialPort arduinoPort;

        public Form1()
        {
            InitializeComponent();
            
            // project directory is needed to access the sounds for each note
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;            
            // Configurate the connection through the serial port to the Arduino
            arduinoPort          = new System.IO.Ports.SerialPort();
            arduinoPort.PortName = "COM";
            arduinoPort.BaudRate = 9600;
            // Connect to the Arduino
            //arduinoPort.Open();
            // Initialize some variables
            song             = new List<int[]>();
            isFirstStroke    = true;
            jumper           = 0;
            time             = 0;
            note             = 0;
        }

        private void button1Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\1.wav");
            player.Play();
            labelSequence.Text += "{Ab";
        }

        private void button2Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\2.wav");
            player.Play();
            labelSequence.Text += "{Bb";
        }

        private void button3Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\3.wav");
            player.Play();
            labelSequence.Text += "{C";
        }

        private void button4Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\4.wav");
            player.Play();
            labelSequence.Text += "{Db";
        }

        private void button5Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\5.wav");
            player.Play();
            labelSequence.Text += "{Eb";
        }

        private void button6Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\6.wav");
            player.Play();
            labelSequence.Text += "{F";
        }

        private void button7Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\7.wav");
            player.Play();
            labelSequence.Text += "{G";
        }

        private void button8Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\8.wav");
            player.Play();
            labelSequence.Text += "{Ab";
        }

        private void button9Press()
        {
            SoundPlayer player = new SoundPlayer($"{projectDirectory}\\9.wav");
            player.Play();
            labelSequence.Text += "{Bb";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Set all vars to their default to start with a new song
            timer1.Stop();
            song = new List<int[]>();
            labelSequence.Text = "";
            jumper = 0;
            time = 0;
            isFirstStroke = true;
            buttonSend.Enabled = false;
        }

        private void buttonTerminate_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                song.Add(new int[] { note, time });
                labelSequence.Text += $",{time}}}]";
                jumper++;
                if (jumper == 10)
                {
                    labelSequence.Text += "\n";
                    jumper = 0;
                }
                play();
                time = 0;
                isFirstStroke = true;
                buttonSend.Enabled = true;
            }
            else
            {
                play();
            }
        }

        private async void play()
        {
            foreach (int[] noteArr in song)
            {
                SoundPlayer player = new SoundPlayer($"{projectDirectory}\\{noteArr[0]}.wav");
                player.Play();
                await Task.Delay(noteArr[1]*14);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isFirstStroke)
            {
                // Start the timer on the first note
                timer1.Start();
                isFirstStroke = false;
                labelSequence.Text += "[";
            }
            else
            {
                timer1.Stop();
                // Add the note with its delay to the song list
                song.Add(new int[] { note, time });
                // Add the note with its delay to the label showing the sequence
                labelSequence.Text += $",{time}}}, ";
                jumper++;
                // After then notes a line jump is performed so sequence can continue 
                if (jumper == 10)
                {
                    labelSequence.Text += "\n";
                    jumper = 0;
                }
                time = 0;
                timer1.Start();
            }
            switch (e.KeyCode)
            {
                case Keys.A: button1Press(); note = 1; break;
                case Keys.S: button2Press(); note = 2; break;
                case Keys.D: button3Press(); note = 3; break;
                case Keys.F: button4Press(); note = 4; break;
                case Keys.G: button5Press(); note = 5; break;
                case Keys.H: button6Press(); note = 6; break;
                case Keys.J: button7Press(); note = 7; break;
                case Keys.K: button8Press(); note = 8; break;
                case Keys.L: button9Press(); note = 9; break;
                case Keys.Space: buttonTerminate.PerformClick(); break;
            }
        }

        // Increment time delay variable every millisecond the timer is enabled
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            byte[,] byteArr = new byte[song.Count, 2];
            byte noteByte;
            byte delayByte;
            int i = 0;
            foreach (var noteArr in song)
            {
                noteByte = Convert.ToByte(noteArr[0]);
                delayByte = Convert.ToByte(noteArr[1]);
                byteArr[i, 0] = noteByte;
                byteArr[i, 1] = delayByte;
                MessageBox.Show($"{byteArr[i, 0]}, {byteArr[i, 1]}");
            }
        }
    }
}
