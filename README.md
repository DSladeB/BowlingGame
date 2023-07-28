# BowlingGame
This implementation of the Bowling Scoring game tracks the cumulative score by frame, rather than simply calculating the total score. 
This should allow a UI to be attached to the code to output a scoreboard like one found at an alley.

The calculation is accomplished mostly within the Frame object itself. 
Strikes and Spares are calculated using a reference to the next Frame, as well as a recursive function to acquire the next roll(s) should the next frame alone not have enough in the case of multiple strikes in a row. 
