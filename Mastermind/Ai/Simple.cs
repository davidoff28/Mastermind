namespace Mastermind.Ai
{
    /// <summary>
    /// Represents an AI that uses a simple algorithm.
    /// </summary>
    public class Simple : AI
    {
        public Simple(Rules rules)
            : base(rules)
        {
            _name = "Simple";
        }

        /// <summary>
        /// Returns a guess using a simple algorithm.
        /// </summary>
        /// <param name="previousResponse">The previoues <see cref="Response"/>.</param>
        /// <returns></returns>
        public override Code GenerateGuess(Response previousResponse)
        {            
            _bestGuesses = FilterCodes(_bestGuesses, _guess, previousResponse);
            _guess = _bestGuesses[_bestGuesses.Count - 1]; // Return the code at the bottom of the array.
            return _guess;
        }
    }
}
