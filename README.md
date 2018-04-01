# Mastermind
Mastermind board game simulation with 3 different AI opponents.
# AI's
There are 3 different AI's to choose from; Knuth, Simple, and Swaszek.
## Knuth
Knuth uses the Five Guess Algorithm by Donald Knuth: https://en.wikipedia.org/wiki/Mastermind_(board_game). Cracks the code in 1 - 5 steps.
## Simple
Simple returns the last guess from a filtered guess list. Cracks the code in 1-7 steps.

        public override Code GenerateGuess(Response previousResponse)
        {            
            _bestGuesses = FilterCodes(_bestGuesses, _guess, previousResponse);
            _guess = _bestGuesses[_bestGuesses.Count - 1]; // Return the code at the bottom of the array.
            return _guess;
        }

## Swaszek
Swaszek uses the Peter Swaszek algorithm: http://mathworld.wolfram.com/Mastermind.htmlCan where it returns a random guess from a filtered guess list. Cracks the code in 1 - 7 steps.  
        
        public override Code GenerateGuess(Response previousResponse)
        {
            Random random = new Random();
            _bestGuesses = FilterCodes(_bestGuesses, _guess, previousResponse);
            _guess = _bestGuesses[random.Next(0, _bestGuesses.Count - 1)];

            return _guess;
        }
