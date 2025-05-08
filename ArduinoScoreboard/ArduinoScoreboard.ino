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

// Game Status 0:Game Over, 1:In Progress
int gameStatus = 0;

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

// Patterns to simulate a spinning zero
const uint8_t spinFrames[] = {
  SEG_A | SEG_B | SEG_C | SEG_D | SEG_E | SEG_F,          // Normal 0
  SEG_B | SEG_C | SEG_D | SEG_E | SEG_F | SEG_G,          // Tilted bottom
  SEG_A | SEG_B | SEG_E | SEG_F | SEG_G,                  // Tilted left
  SEG_A | SEG_B | SEG_C | SEG_D | SEG_G,                  // Tilted right
  SEG_A | SEG_C | SEG_D | SEG_E | SEG_F,                  // Inverted C shape
};

// Custom segment representations for "G", "A", "M", "E"
const uint8_t gameLetters[] = {
  SEG_A | SEG_C | SEG_D | SEG_E | SEG_F,             // G
  SEG_A | SEG_B | SEG_C | SEG_E | SEG_F | SEG_G,     // A
  SEG_C | SEG_E | SEG_G,                             // M (approximation using E and C only)
  SEG_A | SEG_D | SEG_E | SEG_F | SEG_G              // E
};

// Custom segment representations for "O", "V", "E", "R"
const uint8_t overLetters[] = {
  SEG_A | SEG_B | SEG_C | SEG_D | SEG_E | SEG_F,      // O
  SEG_C | SEG_D | SEG_E,                              // V (approximate)
  SEG_A | SEG_D | SEG_E | SEG_F | SEG_G,              // E
  SEG_E | SEG_G | SEG_C                                // R (approximate)
};

const int numFrames = sizeof(spinFrames) / sizeof(spinFrames[0]);



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

  gameStatus = 0;
  gameOver();

}



// Function to animate spinning zeros on all 4 digits
void spinZeros() {
  static int frame = 0;

  for (int c = 0; c <= 8; c++) {
  
    for (int i = 0; i < 4; i++) {
        p1SegDisplay.setSegments(&spinFrames[frame], 1, i);
        p2SegDisplay.setSegments(&spinFrames[frame], 1, i);
    }
  
    frame = (frame + 1) % numFrames;
    delay(50); // Adjust speed of spinning
  }
  p1SegDisplay.setSegments(allOFF);
  p2SegDisplay.setSegments(allOFF);
}

// Function to animate spinning zeros on all 4 digits
void gameOver() {
  
  static int frame = 0;


  p1SegDisplay.setSegments(gameLetters);
  p2SegDisplay.setSegments(overLetters);

  delay(1000); // Adjust speed of spinning
}



void loop() {

  if(Serial.available()){

    //{"gameStatus":0,"player1":{"score":1},"player2":{"score":35}}
    String jsonBuffer = Serial.readString();
    Serial.println(jsonBuffer);
    JSONVar jsonObject = JSON.parse(jsonBuffer);


    if (JSON.typeof(jsonObject) == "undefined") {
      Serial.println("Parsing input failed!");
      return;
    }

    if(jsonObject["gameStatus"] != "undefined"){
       gameStatus = jsonObject["gameStatus"];
    }
    
    Serial.print("JSON object = ");
    Serial.println(jsonObject);

    if (gameStatus == 0){
      gameOver();
    }
    else{
      bool isSpin = false;
      if (!jsonObject["player1"]["score"] != "undefined") {
        int incomingScore = jsonObject["player1"]["score"];
        
        if (p1Score < incomingScore) {
          isSpin=true;
          Serial.println("p1 spin");
        }
        p1Score = jsonObject["player1"]["score"];
      }
      if (!jsonObject["player2"]["score"] != "undefined") {
        int incomingScore2 = jsonObject["player2"]["score"];
  
        if (p2Score < incomingScore2) {
          isSpin=true;

          Serial.println("p1 spin");
        }
        p2Score = jsonObject["player2"]["score"];
      }
      if(isSpin){spinZeros();}
      p1SegDisplay.showNumberDec(p1Score, true, 4, 0);
      p2SegDisplay.showNumberDec(p2Score, true, 4, 0);
    }


  
    
    

  
    Serial.print("PLAYER 1 SCORE: ");
    Serial.println(p1Score);
    Serial.print("PLAYER 2 SCORE: ");
    Serial.println(p2Score);
    pause == true;
  }
  
}
