//Inicializar a serial
void setup() {
  //Inicaliza a porta serial
  Serial.begin(9600);  
  //Define o tipo do pino
  //Pino de saída digital  
  pinMode(13,OUTPUT);
}

void loop() {
  //Se a serial estiver disponível
  if(Serial.available() > 0)
  {
    //Ler um caracter da serial
    String dado = Serial.readStringUntil('\n');
    //Se for igual a "iniciar", LED em nível alto
    if(dado == "iniciar")
    {
      digitalWrite(13,HIGH);
      Serial.write(10);
    }
    //Se for igual a "parar", LED em nível baixo
    else if(dado == "parar")
    {
      digitalWrite(13,LOW);
      Serial.write(20);
    }
  }
}
