# Xylo
This repository contains all the code used for my project for the Microprocessors class in my exchange semester in UANL. The solution is a Windows Forms project that can connect to an Arduino through the serial port to send a melody in a string format so a robotic arm can play it in a xylophone.
The Arduino code deals with parsing the string passed by the Windows application and playing the melody by moving the servo motors and using delays.

## The Project
The robotic arm is composed by two servo motors: one works as the base that can rotate to change the note to play on the xylophone and the other one is perpendicular to the first one working as the arm with a stick attached to it to actually play the note on the xylophone. The following images can better illustrate this:
<p align="center"><img src="/imgs/xylo1.JPG"><br><b>Robotic Base</b></p>
<p align="center"><img src="/imgs/xylo2.JPG"><br><b>Robotic Arm</b></p><br>
The circuit is pretty basic, it just has two servo motors connected to an Arduino. The Arduino is connected to the pc through the Arduino's USB port.
<p align="center"><img src="/imgs/circuit.JPG"><br><b>Circuit</b></p>

## The Application
The Windows Application is a Form where the user can play a melody with the keyboard and send it to the Arduino. The software deals with registering the notes and calculating the time between each note played to generate a tuple <i>(n,t)</i> for each note, where <b>n</b> represents the note and <b>t</b> the time between the note and the next note.
The UI is simple:
<p align="center"><img src="/imgs/ui.JPG"><br><b>UI</b></p>
There are 9 buttons below representing the notes that can be played in the xylohpone. The notes can be played in the software using the keyboard with the keys <b>A</b>, <b>S</b>, <b>D</b>, <b>F</b>, <b>G</b>, <b>H</b>, <b>J</b>, <b>K</b>, <b>L</b> as illustrated in the UI. There is a label that shows the sequence of tuples <i>(n,t)</i> and three more buttons: one to start a new melody, one to send the melody to the Arduino and one to stop playing our current melody (this one can be called with the <b>Z</b> key).



