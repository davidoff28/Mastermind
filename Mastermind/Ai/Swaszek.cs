using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Ai
{
    public class Swaszek : AI
    {
        public Swaszek(Rules rules)
            : base(rules)
        {
            _name = "Swaszek";
        }

        public override Code GenerateGuess(Response previousResponse)
        {
            Random random = new Random();
            _bestGuesses = FilterCodes(_bestGuesses, _guess, previousResponse);
            _guess = _bestGuesses[random.Next(0, _bestGuesses.Count - 1)];

            return _guess;
        }
    }
}
