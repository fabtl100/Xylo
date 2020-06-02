#include <Servo.h>
#include <stdio.h>
#include <stdlib.h>
Servo baseServo;
Servo armServo; 

// melody will hold the array with the note,time arrays.
float **melody;
// inString will hold the string sent from the software through the serial port.
String inString;
// melodySaved helps us to know when a melody is saved in memory so that memory 
// can be cleaned when a new melody is going to be saved.
bool melodySaved;
// Milliseconds by crotchet.
const int tempo = 1000;
// Degree calibration for each note. These were obtained empirically.
const int degrees[9] = {6, 10, 15, 18, 23, 27, 30, 33, 37};

void setup() {
  Serial.println("Preparing");
  // Base servo is connected to the pin #9
  baseServo.attach(9);
  // Arm servo is connected to the pin #10
  armServo.attach(10);
  // Position base on the first note
  baseServo.write(degrees[0]);
  delay(500);
  // Position arm being lifted
  armServo.write(30);
  delay(500);
  // Starting serial connection at 9600 bauds.
  Serial.begin(9600);
  melodySaved = false;
  Serial.println("Ready");
}

void loop() {
  if (Serial.available() > 0) {
    inString = Serial.readString();
    Serial.println("Parsing melody");
    melody = parseMelody(inString);
    Serial.println("Done");
    melodySaved = true;
    Serial.println("Playing");
    play();
  }
}

// Positions arm in the degree that corresponds to the tone.
void setNote(int tone){
  baseServo.write(degrees[tone-1]);
}

// Hits the xylophone with the arm.
void hitNote(int tone){
  // The last notes require more strength.
  if(tone<6)
    armServo.write(20);
  else
    armServo.write(19);
  delay(200);
  // Lift the arm back up.
  armServo.write(30);
  delay(10);
}

void play(){
  noteCount = melody[0][0];
  for(int i=1; i<=noteCount; i=i+1){
    // In the first note we need to prepare in case the arm is positioned
    // somewhere else.
    if(i==1){
      setNote((int)melody[1][0]);
      delay(1000);
    } 
    hitNote((int)melody[i][0]);
    if(i!=noteCount){
      // Position arm in the next note.
      setNote((int)melody[i+1][0]);
    }
    else{
      // In the case of the last note we go back to the first one.
      setNote((int)melody[1][0]);
    }
    // Time lost in the hit is taken in account here.
    int duration = melody[i][1] * tempo - 210;
    delay(duration);
  }
}

float **parseMelody(String str) {
    if (melodySaved) {
      cleanMelodyMemory();
    }
    // Index for the string.
    int i = 0;
    // Song length is saved in a string to be cast to int later.
    char strMelodyLength[] = "        ";
    // First chars correspond to the song length.
    // Up until the first '|' where note,time pairs start to appear.
    while (str[i] != '|') {
        strMelodyLength[i] = str[i];
        i++;
    }
    // Increment to go past the '|'.
    i++;
    // Cast to int the song length.
    int melodyLength = atoi(strMelodyLength);
    // Allocate memory for the array of note,time arrays.
    float **melody = (float**) malloc((melodyLength+1)*sizeof(float*));
    // Index for the array of note,time arrays.
    int melodyIndex = 0;
    // Allocate memory for first note,time array. 
    // This one will have the song length in the note position and
    // no time (0).
    melody[0] = (float*) malloc(2*sizeof(float));
    melody[melodyIndex][0] = melodyLength;
    melody[melodyIndex++][1] = 0;
    // saveFlag is used to what is being obtained from the string: a note (1) or a time (2).
    int saveFlag = 1;
    // Here we do the same we did for the song length but for the time: save in a string
    // to cast later to an int.
    char strTime[] = "          ";
    int timeIndex = 0;
    int time = 0;

    for (; i < str.length(); i++) {
        // ',' separates a note from a time.
        if (str[i] == ',') {
            saveFlag = 2;
            continue;
        // '|' indicates the start of a new note,time pair.
        } else if (str[i] == '|') {
            // Here we have saved all chars for the time. Cast to int and reset index.
            time = atoi(strTime);
            timeIndex = 0;
            // Convert the time to seconds.
            melody[melodyIndex++][1] = (float)time / 1000;
            // Reset strTime to hold just spaces again to avoid bugs with leftover digits.
            resetStrTime(&strTime[0]);
            saveFlag = 1;
            // Make sure memory is not allocated for a new pair in the final iteration.
            if (i == (tamanoStr-1)) {
                break;
            }
            continue;
        }

        // Saving a time.
        if (saveFlag == 2) {
            // Concat to strTime
            strTime[timeIndex] = str[i];
            timeIndex++;
        // Saving a note.
        } else if (saveFlag == 1) {
            // Allocate memory for this new note,time pair.
            melody[melodyIndex] = (float*) malloc(2*sizeof(float));
            // Save note by casting to int the note. Get the difference between ASCII values because of
            // the relation ints have withs chars in C.
            melody[melodyIndex][0] = str[i] - '0';
        }
    }
    return melody;
}

void resetStrTime(char *strTime) {
    int tamano = strlen(strTime);
    for (int i = 0; i < tamano; i++) {
        strTime[i] = ' ';
    }
}

void cleanMelodyMemory() {
  int largo = melody[0][0] + 1;
  for (int i = 0; i < largo; i++) {
    free(melody[i]);
  }
  free(melody);
}
