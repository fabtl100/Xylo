#include <Servo.h>
#include <stdio.h>
#include <stdlib.h>
Servo servo_base;
Servo servo_brazo; 

float **cancion_para_tocar;

String cadena_entrante;
bool hay_cancion;
int notas_total;

const int tempo = 1000; // Milisegundos por nota negra
const int angulos[9] = {6, 10, 15, 18, 23, 27, 30, 33, 37};  // Calibración en grados para cada nota 

void setup() {
  
  servo_base.attach(9);     // Conecta el servo base al pin 9 
  servo_brazo.attach(10);   // Conecta el servo brazo al pin 10

  // Secuencia para prepararse
  Serial.println("Preparandose");
  servo_base.write(angulos[0]);
  delay(500);
  servo_brazo.write(30);
  delay(500);

  //Iniciamos el Serial a 9600 baudios
  Serial.begin(9600);

  hay_cancion = false;

  Serial.println("Listo");
}

void loop() {
  
  if (Serial.available() > 0) {
    cadena_entrante = Serial.readString();
    Serial.println(cadena_entrante);

    Serial.println("Parseando cancion");
    if (hay_cancion) {
      liberar_memoria_cancion();
    }
    cancion_para_tocar = obtener_cancion(cadena_entrante);
    Serial.println("Se parseo la cancion: ");
    notas_total = cancion_para_tocar[0][0];
    for (int i = 0; i <= notas_total; i++) {
      Serial.print(cancion_para_tocar[i][0]);
      Serial.print(",");
      Serial.print(cancion_para_tocar[i][1]);
      Serial.print("|");
    }
    Serial.println("");
    hay_cancion = true;
    
    Serial.println("Tocando");
    tocar_cancion();
  }
}

// Mueve el brazo encima de las notas para mostrar sus ángulos
void prueba_calibracion(){
  servo_brazo.write(21);
  for(int i=1; i<=9; i=i+1){
    if(i==6)
      servo_brazo.write(20);
    posicionar_nota(i);
    delay(1000);
  }
}

// Posiciona el mazo en el ángulo correspondiente al tono
void posicionar_nota(int tono){
  int pos;
  pos = angulos[tono-1]; // -1 porque el arreglo empieza en índice 0
  servo_base.write(pos);
}

// Realiza el golpe
void golpear_nota(int tono){
  if(tono<6)
    servo_brazo.write(20);  // Baja
  else
    servo_brazo.write(19);  // Baja más fuerte para las últimas notas
  delay(200);
  servo_brazo.write(30);  // Sube
  delay(10);
}

// Ciclo para tocar todas las notas en una canción
void tocar_cancion(){
  for(int i=1; i<=notas_total; i=i+1){
    if(i==1){
      posicionar_nota((int)cancion_para_tocar[1][0]);  // Posicionar la primera nota y prepararse
      delay(1000);
    } 
    golpear_nota((int)cancion_para_tocar[i][0]);   // Golpear
    if(i!=notas_total){
      posicionar_nota((int)cancion_para_tocar[i+1][0]);  // Se posiciona el mazo a la siguiente nota mientras se espera la duración de la actual
    }
    else{
      posicionar_nota((int)cancion_para_tocar[1][0]);    // Si ya es la última nota, posicionamos a la primera
    }
    int duracion = cancion_para_tocar[i][1] * tempo - 210;    // Se toma en cuenta el tiempo perdido durante el golpe
    delay(duracion);
  }
}

float **obtener_cancion(String str) {
    // Tamaño de la cadena pasada para ser parseada
    int tamanoStr = str.length();
    // Indice para recorrer la cadena
    int i = 0;
    // En esta cadena se guarda el tamaño de la canción
    char tamanoCancion[] = "        ";

    // Los primero caracteres corresponden al tamaño de la canción.
    // Se guardan hasta topar el primer "|" que denota el inicio de 
    // la secuencia de pares nota,delay
    while (str[i] != '|') {
        tamanoCancion[i] = str[i];
        i++;
    }
    // Incrementamos una vez más el contador de la cadena para pasar el "|"
    i++;
    // Convertimos la cadena que contiene el tamaño a un entero para poder utilizarlo
    int tamanoCancionInt = atoi(tamanoCancion);
    
    // Alojamos memoria bidimensional para tener un arreglo de dos dimensiones dinámico
    float **cancion = (float**) malloc((tamanoCancionInt+1)*sizeof(float*));
    // Indice para recorrer los pares contenidos en el arreglo bidimensional
    int indexCancion = 0;

    // Alojamos memoria para el primer par (primer arreglo)
    // contenido en el arreglo bidimensional
    cancion[0] = (float*) malloc(2*sizeof(float));
    // El primer par del arreglo es el tamaño de la canción y un 0 ya que este elemento no es nota
    // y no necesita ir acompañado de delay
    cancion[indexCancion][0] = tamanoCancionInt;
    cancion[indexCancion++][1] = 0;
    
    // bandera es usada para saber cuando guardar la nota, o cuando guardar el delay
    // si la bandera es 1 entonces se guarda la nota, si es 2 se guarda el delay
    int bandera = 1;
    // tiempo es usado para guardar el delay caracter por caracter para despues ser 
    // convertido a un entero. Esto es ya que los delays están compuesto de más de un caracter.
    char tiempo[] = "          ";
    int indexTiempo = 0;
    int tiempoInt = 0;

    for (; i < tamanoStr; i++) {
        // La coma delimita cuando se termina la nota y comienza el delay
        if (str[i] == ',') {
            bandera = 2;
            continue;
        // La barra delimita cuando termina el delay y comienza una nota
        } else if (str[i] == '|') {
            // Como ya se guardaron todos los caracteres del delay se convierte a entero
            // y se guarda en el par, después de incrementa el contador para comenzar
            // con el siguiente par nota, delay
            tiempoInt = atoi(tiempo);
            indexTiempo = 0;
            // Normalizamos a 1 los milisegundos (vienen como enteros)
            cancion[indexCancion++][1] = (float)tiempoInt / 1000;
            // Se reinicia la variable de tiempo con espacios para usarla de nuevo en la siguiente iteración
            reiniciar_tiempo(&tiempo[0]);
            bandera = 1;

            // Esta condicional se asegura que no se aloja memoria para una siguiente nota no existente en la última iteración
            if (i == (tamanoStr-1)) {
                break;
            }
            continue;
        }

        // Estamos guardando el delay
        if (bandera == 2) {
            // Concatenamos a la variable de delay
            tiempo[indexTiempo] = str[i];
            indexTiempo++;
        // Estamos guardando una nota
        } else if (bandera == 1) {
            // Se aloja memoria para este nuevo par
            cancion[indexCancion] = (float*) malloc(2*sizeof(float));
            // Se guarda la nota, como la nota es un solo caracter esta lógica se encarga de obtener
            // un entero y que C no nos regrese el valor ASCII del número en caracter. (Ej. castear '0' a entero devolvería 48)
            // que es el valor ASCII del caracter '0'.
            cancion[indexCancion][0] = str[i] - '0';
        }
    }
    return cancion;
}

// Se guarda un espacio en cada posición del arreglo
// Estos espacios son ignorados al castear a entero, esta es una manera de reiniciar
// el arreglo de caracteres que utilizamos para guardar los delays
void reiniciar_tiempo(char *tiempo) {
    int tamano = strlen(tiempo);
    for (int i = 0; i < tamano; i++) {
        tiempo[i] = ' ';
    }
}

// Función que sirve para liberar la memoria del puntero doble cancion_para_tocar
void liberar_memoria_cancion() {
  int largo = cancion_para_tocar[0][0] + 1;
  for (int i = 0; i < largo; i++) {
    free(cancion_para_tocar[i]);
  }
  free(cancion_para_tocar);
}
