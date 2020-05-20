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
using System.IO.Ports;
using System.Threading;


namespace Xylo
{
    public partial class Form1 : Form
    {
        // Pre-defined songs
        List<int[]> prueba = new List<int[]>() {
            new int[2]{1,500}, new int[2]{2,500}, new int[2]{3,500}, new int[2]{4,500},
            new int[2]{5,500}, new int[2]{6,500}, new int[2]{7,500}, new int[2]{8,500}, new int[2]{9,500}
        };
        List<int[]> starWars = new List<int[]>() {
            new int[2]{1,1000},new int[2]{5,1000},new int[2]{4,500},new int[2]{3,500},
            new int[2]{2,500},new int[2]{8,1000},new int[2]{5,1000},new int[2]{4,500},new int[2]{3,500},
            new int[2]{2,500},new int[2]{8,1000},new int[2]{5,1000},new int[2]{4,500},new int[2]{3,500},
            new int[2]{4,500},new int[2]{2,500}
        };

        List<int[]> cucaracha = new List<int[]>() {
            new int[2]{1,333},new int[2]{1,333},new int[2]{1,334},new int[2]{4,1000},
            new int[2]{6,1000},new int[2]{1,333},new int[2]{1,333},new int[2]{1,334},new int[2]{4,1000},
            new int[2]{ 6,1000},new int[2]{4,500},new int[2]{4,500},new int[2]{3,500},new int[2]{3,500},
            new int[2]{ 2,500},new int[2]{2,500},new int[2]{1,1000},new int[2]{1,333},new int[2]{1,333},
            new int[2]{ 1,334},new int[2]{3,1000},new int[2]{5,1000},new int[2]{1,333},new int[2]{1,333},
            new int[2]{ 1,334},new int[2]{3,1000},new int[2]{5,1000},new int[2]{8,500},new int[2]{9,500},
            new int[2]{8,500},new int[2]{7,500},new int[2]{6,500},new int[2]{5,500},new int[2]{4,500}
        };
        List<int[]> himnoAlegria = new List<int[]> {
            new int[2]{3,500},new int[2]{3,500},new int[2]{4,500},new int[2]{5,500},
            new int[2]{ 5,500},new int[2]{4,500},new int[2]{3,500},new int[2]{2,500},new int[2]{1,500},
            new int[2]{ 1,500},new int[2]{2,500},new int[2]{3,500},new int[2]{3,750},new int[2]{2,300},
            new int[2]{ 2,1000},new int[2]{3,500},new int[2]{3,500},new int[2]{4,500},new int[2]{5,500},
            new int[2]{ 5,500},new int[2]{4,500},new int[2]{3,500},new int[2]{2,500},new int[2]{1,500},
            new int[2]{ 1,500},new int[2]{2,500},new int[2]{3,500},new int[2]{2,750},new int[2]{1,300},
            new int[2]{ 1,1000},new int[2]{2,1000},new int[2]{3,500},new int[2]{1,500},new int[2]{2,500},
            new int[2]{ 3,300},new int[2]{4,300},new int[2]{3,500},new int[2]{1,500},new int[2]{2,500},
            new int[2]{ 3,300},new int[2]{4,300},new int[2]{3,500},new int[2]{2,500},new int[2]{1,500},
            new int[2]{ 2,500},new int[2]{5,500},new int[2]{3,1000},new int[2]{3,500},new int[2]{4,500},
            new int[2]{ 5,500},new int[2]{5,500},new int[2]{4,500},new int[2]{3,500},new int[2]{2,500},
            new int[2]{ 1 ,500},new int[2]{1,500},new int[2]{2,500},new int[2]{3,500},new int[2]{2,750},
            new int[2]{1,300},new int[2]{1,2000}};
        List<int[]> estrellita = new List<int[]> {
            new int[2]{1,500},new int[2]{1,500},new int[2]{5,500},new int[2]{5,500},
            new int[2]{ 6,500},new int[2]{6,500},new int[2]{5,1000},new int[2]{4,500},new int[2]{4,500},
            new int[2]{ 3,500},new int[2]{3,500},new int[2]{2,500},new int[2]{2,500},new int[2]{1,1000},
            new int[2]{ 5,500},new int[2]{5,500},new int[2]{4,500},new int[2]{4,500},new int[2]{3,500},
            new int[2]{ 3,500},new int[2]{2,1000},new int[2]{5,500},new int[2]{5,500},new int[2]{4,500},
            new int[2]{ 4,500},new int[2]{3,500},new int[2]{3,500},new int[2]{2,1000},new int[2]{1,500},
            new int[2]{ 1,500},new int[2]{5,500},new int[2]{5,500},new int[2]{6,500},new int[2]{6,500},
            new int[2]{ 5,1000},new int[2]{4,500},new int[2]{4,500},new int[2]{3,500},new int[2]{3,500},
            new int[2]{ 2,500},new int[2]{2,500},new int[2]{1,1000}};

        // song will hold the arrays holding the note and the duration of the note
        List<int[]> song;
        // projectDirectory is the path in the computer where the sounds for each note are saved
        string projectDirectory;
        // Determines wether the user is starting to play a song or has started already (this is to start the timer the first time)
        bool isFirstStroke;
        // time saves the time in ms counted by the timer between strokes
        int time;
        // dateTime is used to calculate time elapsed between timer start and each tick
        DateTime dateTime;
        // Counter used to jump the line in the label that saves the played notes
        int jumper;
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
            jumper           = 0;
            time             = 0;
            note             = 0;

            // Initialize elements in the listbox
            defaultSongListBox.Items.Add("Prueba");
            defaultSongListBox.Items.Add("Estrellita");
            defaultSongListBox.Items.Add("Star Wars");
            defaultSongListBox.Items.Add("La Cucaracha");
            defaultSongListBox.Items.Add("Himno Alegria");
        }

        // This button restarts the state of all variables so a new song can be played, saved and sent
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

        // This button ends the timer for the intervals between sequences and sets the state
        // for the song to be sent to the Arduino
        private void buttonTerminate_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                // Finish the song sequence logic: Stop timer, add the last note
                // with its interval and add the last chars to the song sequence label
                timer1.Stop();
                song.Add(new int[] { note, time });
                labelSequence.Text += $",{time}}}]";
                
                // This logic is used to start a new line in the song sequence label
                jumper++;
                if (jumper == 5)
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
                // Start the timer on the first note
                timer1.Start();
                dateTime = DateTime.Now;
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
                
                // This logic is used to start a new line in the song sequence label
                jumper++;
                if (jumper == 5)
                {
                    labelSequence.Text += "\n";
                    jumper = 0;
                }

                // Restart timer to count a new interval between the recently played note and the next one
                time = 0;
                timer1.Start();
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

        // Increment time delay variable every millisecond the timer is enabled
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan timeElapsed = DateTime.Now - dateTime;
            time = (int) timeElapsed.TotalMilliseconds;
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
            songTextBox.Text = "Personalizada";
            // Send the song to the Arduino
            arduinoPort.Write(songString);

            // Disable the form while waiting for the send of the song to the Arduino
            Enabled = false;
            // Wait for message to be sent, this may need to be adjusted
            await Task.Delay(3000);
            MessageBox.Show($"Canción Personalizada enviada al Arduino");
            Enabled = true;
        }

        private async void defaultSongListBox_DoubleClick(object sender, EventArgs e)
        {
            string selected = defaultSongListBox.SelectedItem.ToString();
            List<int[]> songToSend = new List<int[]>();

            switch (selected)
            {
                case "Himno Alegria": songToSend = himnoAlegria; break;
                case "La Cucaracha" : songToSend = cucaracha; break;
                case "Estrellita"   : songToSend = estrellita; break;
                case "Star Wars"    : songToSend = starWars; break;
                case "Prueba"       : songToSend = prueba; break;
            }
            // A string will be sent to the Arduino containing the song in the following format: N|n1,t1|...|nm,tm|
            // where N is the length of the song, nk is a note and tk is a time delay.
            // First element is N: the length of the song.
            string songString = $"{songToSend.Count}|";

            // Next elements will be |nk,tk|: the (note, delay) pairs. 
            foreach (var noteArr in songToSend)
            {
                songString += $"{noteArr[0]},{noteArr[1]}|";
            }

            // Write the song to the Arduino
            arduinoPort.Write(songString);
            // Disable the form while waiting for the send of the song to the Arduino
            Enabled = false;
            // Wait for message to be sent, this may need to be adjusted
            await Task.Delay(3000);
            songTextBox.Text = selected;
            MessageBox.Show($"Canción {selected} enviada al Arduino");
            Enabled = true;
        }
    }
}
