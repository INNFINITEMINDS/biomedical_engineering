/*
 * -----------------------------------------------
 * Federal University of Uberlandia
 * Faculty of Electrical Engineering
 * Biomedical Engineering Lab
 * Author: Andrei Nakagawa, MSc
 * contact: nakagawa.andrei@gmail.com
 * -----------------------------------------------
 * Description: Using the arduino as a square wave
 * generator.
 * -----------------------------------------------
 */

#include <TimerOne.h>

//Parameters
double sampfreq = 1000; //Hz
double sampPeriod = 1000; //us 1000 us = 1 ms
int freq = 5;
double dt = 0;
byte genSignal = 0;
int cont = 0;
int ledPin = 13;
bool flagWave = false;

//Initializes the serial communication
void setup() {
  //Stats serial comm
  Serial.begin(9600);  
  //Defines pin 13 as digital output - Led
  pinMode(ledPin,OUTPUT);
  //Timer period in us
  Timer1.initialize(sampPeriod);
  Timer1.attachInterrupt(timerTick);
  dt = 1.0/freq;
}

//Within every timer tick, a new sample is generated and sent through 
//the serial port
void timerTick()
{
  Timer1.stop();
  if(cont*(1.0/sampfreq) >= dt)  
  {
    if(flagWave)
    {
      genSignal = 1;
      flagWave = false;     
    }
    else
    {
      genSignal = 0;
      flagWave = true;
    }
     cont = 0;
  }  
  cont++;
  Serial.write(genSignal);  
  Timer1.initialize(sampPeriod);
}

void loop() {

}
