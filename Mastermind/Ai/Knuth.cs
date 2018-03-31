using System;
using System.Collections.Generic;

namespace Mastermind.Ai
{
    /// <summary>
    /// Represents an <see cref="AI"/> based on knuth's five-guess algorithm.
    /// </summary>
    public class Knuth : AI
    {
        /// <summary>
        /// Constructs a <see cref="Knuth"/> object with the specified <see cref="Rules"/>.
        /// </summary>
        /// <param name="rules">The <see cref="Rules"/>.</param>
        public Knuth(Rules rules) 
            : base(rules)
        {
            _name = "Knuth";
        }

        /// <summary>
        /// Returns a new guess <see cref="Code"/> based on the previous <see cref="Response"/>.
        /// Uses five-guess algorithm.
        /// </summary>
        /// <param name="previousResponse">The previous <see cref="Response"/>.</param>
        /// <returns>A new guess <see cref="Code"/>.</returns>
        /// <remarks>
        /// code adapted from here https://stackoverflow.com/questions/20418347/knuths-algorithm-for-solving-mastermind-with-5-guesses
        /// </remarks>
        public override Code GenerateGuess(Response previousResponse)
        {
            Code previousGuess = _guess;

            _bestGuesses = FilterCodes(_bestGuesses, previousGuess, previousResponse);

            int min = int.MaxValue;
            foreach (var guess in _bestGuesses)
            {
                var max = 0;
                foreach (var outcome in _allResponses)
                {
                    var count = 0;
                    foreach (var solution in _allCodes)
                    {
                        if (_rules.Check(guess, solution) == outcome)
                        {
                            count++;
                        }
                    }

                    if (count > max)
                    {
                        max = count;
                    }
                }

                if (max < min)
                {
                    min = max;
                    _guess = guess;
                }
            }

            return _guess;
        }
    }
}
