# KartAssignement
 Assignement for a C#/unity course
 
  About:
  
  simple little racing game, played with 4 keys, you can accelerate, turn and break.
  
  The cars have a forward and back contact patch with slightly different physics behaviors, making the car drift in sharp turn 
  (the approximation I used is from https://www.youtube.com/watch?v=CdPYlj5uZeI&t=6s&ab_channel=ToyfulGames and isn't very satisfying at low speeds)
  
  Each player has a struct with it's data and an input receiver that persists scene to scene and forwards it to the car 
  (this design is a workaround a previously encountered bug, I should have the input reciever on the car directly and use C# events instead of messages)
  
  The game keeps a singleton with a list of level and goes through them in sequence before going back to the main menu 
  (there are a few crude singletons in the project, ideally they should be injected, here there are serialized where needed)
  
  The player must go through a series of triggers to complete a lap (the starting line checks that the player entered all the trigger when a player enters it)
  
  There are a few C# static events here and there that create coupling, but are more convenient than UnityEvent.
  
  
 To play:
 start play mode from the main menu and select the number of player.
 first player plays with wasd second player with arrow keys
 
 technically the laps can be completed in either direction
 

 
