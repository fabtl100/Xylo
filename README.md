# Xylo
This repository contains all the code used for my project for the Microprocessors class in my exchange semester in UANL. The solution is a Windows Forms project that can connect to an Arduino through the serial port to send songs in a string format so a robotic arm can play the songs in a xylophone.
The Arduino code deals with parsing the string passed by the Windows application and playing the song by moving the servo motors and using delays.

## The project
The robotic arm is composed by two servo motors: one works as the base that can rotate to change the note to play on the xylophone and the other one is perpendicular to the first one working as the arm with a stick attached to it to actually play the note on the xylophone. The following images can better illustrate this:
<p align="center"><img src="/imgs/xylo1.JPG"><br><b>Robotic Base</b></p>
<p align="center"><img src="/imgs/xylo2.JPG"><br><b>Robotic Arm</b></p><br>
The circuit is pretty basic, it just has two servo motors connected the an Arduino. The Arduino is connected to the pc with the USB port the Arduino has to download programs to it.
<p align="center"><img src="/imgs/circuit.JPG"><br><b>Circuit</b></p>

## 

