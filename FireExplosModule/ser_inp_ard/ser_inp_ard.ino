int counter = 0;
float avCH4 = 0.0;
float sumCH4 = 0.0;
float avCO = 0.0;
float sumCO = 0.0;
float avCO2 = 0.0;
float sumCO2 = 0.0;
float avO2 = 0.0;
float sumO2 = 0.0;

void setup() {
  Serial.begin(9600);
}

void loop() {
  int methane = analogRead(A0);
  int carbonMonoxide = analogRead(A1);
  int carbonDioxide = analogRead(A2);
  int oxygen = analogRead(A3);
  int hydrogenSulphide = analogRead(A4);
  int nitrogenDioxide = analogRead(A5);
  int sulfurDioxide = analogRead(A6);
  
  float CH4 = 0.004887585532*methane;
  float CO = 1.95503421309*carbonMonoxide;
  float CO2 = 0.004887585532*carbonDioxide;
  float O2 = 0.0244379276637*oxygen;
  
  counter++;
  sumCH4 += CH4;
  avCH4 = sumCH4/counter;
  sumCO += CO;
  avCO = sumCO/counter;
  sumCO2 += CO2;
  avCO2 = sumCO2/counter;
  sumO2 += O2;
  avO2 = sumO2/counter;

  if (counter==100)
  {
    Serial.print(avO2);
    Serial.print(",");
    Serial.print(avCO);
    Serial.print(",");
    Serial.print(avCH4);
    Serial.print(",");
    Serial.println(avCO2);
  }
  
//  Serial.write(CH4);
//  Serial.write(",");

 
  delay(10);        
}
