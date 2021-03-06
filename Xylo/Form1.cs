﻿using System;
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
using System.IO.Ports;
using System.Threading;


namespace Xylo
{
    public partial class Form1 : Form
    {
        // song will hold the arrays holding the note and the duration of the note
        List<int[]> song;
        // projectDirectory is the path in the computer where the sounds for each note are saved
        string projectDirectory;
        // Determines wether the user is starting to play a song or has started already 
        bool isFirstStroke;
        // time saves the time in ms between strokes
        int time;
        // dateTime is used to calculate time elapsed between notes
        DateTime dateTime;
        // countingTime if time is being counted or not
        bool countingTime;
        // Counter used to jump the line in the label that saves the played notes
        int jumper;
        int jumperLimit = 7;
        // note holds the played note at a certain time
        int note;
        // arduinoPort is a reference to the serial port object to make the connection and send messages to the Arduino
        SerialPort arduinoPort;

        public Form1()
        {
            InitializeComponent();
            
            // project directory is needed to access the sounds for each note
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;            
            
            // Configure the connection through the serial port to the Arduino
            arduinoPort          = new SerialPort();
            arduinoPort.PortName = "COM1";
            arduinoPort.BaudRate = 9600;
            arduinoPort.RtsEnable = true;
            // Connect to the Arduino
            arduinoPort.Open();
            
            // Initialize some variables
            song             = new List<int[]>();
            isFirstStroke    = true;
            countingTime     = false;
            jumper           = 0;
            time             = 0;
            note             = 0;
        }

        // This button restarts the state of all variables so a new song can be played, saved and sent
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Set all vars to their default to start with a new song
            song = new List<int[]>();
            labelSequence.Text = "";
            jumper = 0;
            time = 0;
            isFirstStroke = true;
            countingTime = false;
            buttonSend.Enabled = false;
        }

        // This button ends the time count for the intervals between sequences and sets the state
        // for the song to be sent to the Arduino
        private void buttonTerminate_Click(object sender, EventArgs e)
        {
            if (countingTime)
            {
                // Finish the song sequence logic: Stop counting time, add the last note
                // with its interval and add the last chars to the song sequence label
                TimeSpan timeElapsed = DateTime.Now - dateTime;
                time = (int)timeElapsed.TotalMilliseconds;
                song.Add(new int[] { note, time });
                labelSequence.Text += $",{time}}}]";
                
                // This logic is used to start a new line in the song sequence label
                jumper++;
                if (jumper == jumperLimit)
                {
                    labelSequence.Text += "\n";
                    jumper = 0;
                }

                // Play the song and set the state for a new song to be played
                // and for this song to be sent to the Arduino
                play();
                time = 0;
                isFirstStroke = true;
                buttonSend.Enabled = true;
                countingTime = false;
            }
            else
            {
                // If the song has been terminated already we just play the song again
                // when this button is clicked
                play();
            }
        }

        // Play the saved song
        // The delay has a constant being multiplied by the interval to be waited for
        // this was done by trial and error, couldn't decipher why the intervals where not
        // waited in the exact time given to the Task.Delay() method
        private async void play()
        {
            await Task.Delay(1000);
            foreach (int[] noteArr in song)
            {
                SoundPlayer player = new SoundPlayer($"{projectDirectory}\\{noteArr[0]}.wav");
                player.Play();
                await Task.Delay(noteArr[1]);
            }
        }

        // Detect Keyboard pressing. Here the logic for the note playing is handled
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Space can be used to finish recording a song
            if (e.KeyCode == Keys.Z)
            {
                buttonTerminate.PerformClick();
                return;
            }
            if (isFirstStroke)
            {
                // Start counting time on the first note
                dateTime = DateTime.Now;
                isFirstStroke = false;
                labelSequence.Text += "[";
            }
            else
            {
                countingTime = false;
                TimeSpan timeElapsed = DateTime.Now - dateTime;
                time = (int)timeElapsed.TotalMilliseconds;
                // Add the note with its delay to the song list
                song.Add(new int[] { note, time });
                // Add the note with its delay to the label showing the sequence
                labelSequence.Text += $",{time}}}, ";
                
                // This logic is used to start a new line in the song sequence label
                jumper++;
                if (jumper == jumperLimit)
                {
                    labelSequence.Text += "\n";
                    jumper = 0;
                }

                // Restart time to count a new interval between the recently played note and the next one
                time = 0;
                countingTime = true;
                dateTime = DateTime.Now;
            }

            // Depending on the key being pressed the corresponding note is played
            // and added to the song sequence label
            SoundPlayer player;
            switch (e.KeyCode)
            {
                case Keys.A: 
                    player = new SoundPlayer($"{projectDirectory}\\1.wav");
                    player.Play();
                    labelSequence.Text += "{Ab"; 
                    note = 1; break;
                case Keys.S: 
                    player = new SoundPlayer($"{projectDirectory}\\2.wav");
                    player.Play();
                    labelSequence.Text += "{Bb"; 
                    note = 2; break;
                case Keys.D: 
                    player = new SoundPlayer($"{projectDirectory}\\3.wav");
                    player.Play();
                    labelSequence.Text += "{C"; 
                    note = 3; break;
                case Keys.F:
                    player = new SoundPlayer($"{projectDirectory}\\4.wav");
                    player.Play();
                    labelSequence.Text += "{Db";
                    note = 4; break;
                case Keys.G:
                    player = new SoundPlayer($"{projectDirectory}\\5.wav");
                    player.Play();
                    labelSequence.Text += "{Eb";
                    note = 5; break;
                case Keys.H:
                    player = new SoundPlayer($"{projectDirectory}\\6.wav");
                    player.Play();
                    labelSequence.Text += "{F";
                    note = 6; break;
                case Keys.J:
                    player = new SoundPlayer($"{projectDirectory}\\7.wav");
                    player.Play();
                    labelSequence.Text += "{G";
                    note = 7; break;
                case Keys.K:
                    player = new SoundPlayer($"{projectDirectory}\\8.wav");
                    player.Play();
                    labelSequence.Text += "{Ab";
                    note = 8; break;
                case Keys.L:
                    player = new SoundPlayer($"{projectDirectory}\\9.wav");
                    player.Play();
                    labelSequence.Text += "{Bb";
                    note = 9; break;
            }
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            // A string will be sent to the Arduino containing the song in the following format: N|n1,t1|...|nm,tm|
            // where N is the length of the song, nk is a note and tk is a time delay.
            // First element is N: the length of the song.
            string songString = $"{song.Count}|";

            // Next elements will be |nk,tk|: the (note, delay) pairs. 
            foreach (var noteArr in song)
            {
                songString += $"{noteArr[0]},{noteArr[1]}|";
            }
            // Send the song to the Arduino
            arduinoPort.Write(songString);

            // Disable the form while waiting for the send of the song to the Arduino
            Enabled = false;
            // Wait for message to be sent, this may need to be adjusted
            await Task.Delay(3000);
            MessageBox.Show($"Canción Personalizada enviada al Arduino");
            Enabled = true;
        }
    }
}
