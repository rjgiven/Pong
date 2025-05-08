// Include the 7 segment display library
#include <TM1637Display.h>
#include <Arduino_JSON.h>

// Define the connections pins
#define p1clockSegDisp 2
#define p1SegDispDIO 3

#define p2clockSegDisp 8
#define p2SegDispDIO 9



// Locked out state variables
boolean pause = false;

// Score keepers
int p1Score = 0;
int p2Score = 0;

// Set the brightness (0=dimmest 7=brightest)
const int p1SegDispBrightness = 4;
const int p2SegDispBrightness = 4;

// Create segment display objects of type TM1637Display
TM1637Display p1SegDisplay = TM1637Display(p1clockSegDisp, p1SegDispDIO);
TM1637Display p2SegDisplay = TM1637Display(p2clockSegDisp, p2SegDispDIO);

// Create an array that turns all segments ON
const uint8_t allON[] = {0xff, 0xff, 0xff, 0xff};

// Create an array that turns all segments OFF
const uint8_t allOFF[] = {0x00, 0x00, 0x00, 0x00};

// Create an array that sets individual segments per digit to display the word "dOnE"
const uint8_t done[] = {
  SEG_B | SEG_C | SEG_D | SEG_E | SEG_G,           // d
  SEG_A | SEG_B | SEG_C | SEG_D | SEG_E | SEG_F,   // O
  SEG_C | SEG_E | SEG_G,                           // n
  SEG_A | SEG_D | SEG_E | SEG_F | SEG_G            // E
};




void setup() {
  //begin serial communication
  Serial.begin(9600);

  // Initialize brightness
  p1SegDisplay.setBrightness(p1SegDispBrightness);
  p2SegDisplay.setBrightness(p2SegDispBrightness);

  // Initialize displays to Off
  p1SegDisplay.clear();
  p2SegDisplay.clear();

  //p1SegDisplay.showNumberDec(p1Score, true, 4, 0);
  //p2SegDisplay.showNumberDec(p2Score, true, 4, 0);
  p1SegDisplay.setSegments(allOFF);
  p2SegDisplay.setSegments(allOFF);
  
  p1Score = 0;
  p2Score = 0;

}

void loop() {

  if(Serial.available()){

    //String command = Serial.readStringUntil('/n');
    //char key = Serial.read();



      String jsonBuffer = Serial.readString();
      Serial.println(jsonBuffer);
      JSONVar jsonObject = JSON.parse(jsonBuffer);
  
  
      if (JSON.typeof(jsonObject) == "undefined") {
        Serial.println("Parsing input failed!");
        return;
      }

      
      Serial.print("JSON object = ");
      Serial.println(jsonObject);
      Serial.print(jsonObject["player1"]["score"]);

      if(jsonObject["player1"]["score"] != "undefined"){
         p1Score = jsonObject["player1"]["score"];
      }
      if(jsonObject["player2"]["score"] != "undefined"){
         p2Score = jsonObject["player2"]["score"];
      }
      
      p1SegDisplay.showNumberDec(p1Score, true, 4, 0);
      p2SegDisplay.showNumberDec(p2Score, true, 4, 0);

      Serial.print("PLAYER 1 SCORE: ");
      Serial.println(p1Score);
      Serial.print("PLAYER 2 SCORE: ");
      Serial.println(p2Score);


  }
    pause == true;
    
    

    //redSegDisplay.clear();
    pause == false;

    //p2SegDisplay.setSegments(done);

}
