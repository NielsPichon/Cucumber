# Cucumber

This is a small unity game project I made in a few hours for a game jam. The concept is that instead of using a controller, the player has to pronounce some funny sounding words, like cucumber or turtle. The words are randomly selected from a pool for each level. Add to that a wild card word which inverts the movement when pronounced and the slugishness of the speech recognition engine, and you have the key ingredients for a fun little prototype game. 

Under the hood, this uses the UnityEngine Windows speech recognition engine (see `./Assets/SpeechRecognition.cs`) which then acts as a controller for the player character which movement is roughly set up in `Assets/playerMovement.cs`.


I never got around to finish this prototype but feel free to reuse the little code (which is indeed quite minimal in this instance) for whatever project you may want.

To play simply boot up unity and open the project and press play.
