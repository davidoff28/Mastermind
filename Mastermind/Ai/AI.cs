using System;
using System.Collections.Generic;

namespace Mastermind.Ai
{
    /// <summary>
    /// Represents the base class. Provides methods to generate secret and guess <see cref="Code"/>.
    /// </summary>
    public abstract class AI
    {
        protected string _name;

        protected Rules _rules;
        protected List<Code> _allCodes;
        protected List<Response> _allResponses;
        protected List<Code> _bestGuesses;

        protected Code _guess;
        protected Code _secret;

        /// <summary>
        /// Gets the name of the <see cref="AI"/>.
        /// </summary>
        public string Name
        {
            get => _name;
        }

        /// <summary>
        /// Gets the secret <see cref="Code"/> combination.
        /// </summary>
        public Code Secret
        {
            get => _secret;
        }

        /// <summary>
        /// Gets the guess <see cref="Code"/> combination.
        /// </summary>
        public Code Guess
        {
            get => _guess;
        }

        /// <summary>
        /// Constructs an instance with the specified <see cref="Rules"/>.
        /// </summary>
        /// <param name="rules">The <see cref="Rules"/>.</param>
        public AI(Rules rules)
        {
            _rules = rules;
            _allCodes = _rules.AllCodes;
            _allResponses = _rules.AllResponses;
            _bestGuesses = _allCodes;
        }

        /// <summary>
        /// Randomly generates a secret <see cref="Code"/>.
        /// </summary>
        /// <returns>A randomly generated <see cref="Code"/>.</returns>
        public Code GenerateSecret()
        {
            Random random = new Random();
            _secret = new Code(
                new Peg((PegColour)random.Next(1, 7)),
                new Peg((PegColour)random.Next(1, 7)),
                new Peg((PegColour)random.Next(1, 7)),
                new Peg((PegColour)random.Next(1, 7)));

            return _secret;
        }

        /// <summary>
        /// Returns an initial guess <see cref="Code"/> containing a <see cref="PegColour"/> combination of
        /// <see cref="PegColour.Red"/>, <see cref="PegColour.Red"/>, <see cref="PegColour.Green"/>, <see cref="PegColour.Green"/>.
        /// </summary>
        /// <returns>An initial guess <see cref="Code"/>.</returns>
        public Code InitialGuess()
        {
            return _guess = new Code(
                new Peg(PegColour.Red),
                new Peg(PegColour.Red),
                new Peg(PegColour.Green),
                new Peg(PegColour.Green));
        }

        /// <summary>
        /// Returns a guess <see cref="Code"/> based on derived class algorithm using the previous <see cref="Renderer"/>. 
        /// </summary>
        /// <param name="previousResponse">The previous <see cref="Response"/>.</param>
        /// <returns>Guess <see cref="Code"/>.</returns>
        public abstract Code GenerateGuess(Response previousResponse);

        /// <summary>
        /// Filters all of the <see cref="Code"/> combinations and returns a new <see cref="List{T}"/> containing
        /// <see cref="Code"/> that matches the previous guess <see cref="Code"/> against the previous <see cref="Response"/>.
        /// </summary>
        /// <param name="codes">The list of <see cref="Code"/> to filter.</param>
        /// <param name="previousGuess">The previous guess <see cref="Code"/>.</param>
        /// <param name="previousResponse">The previous <see cref="Response"/>.</param>
        /// <returns>A new list of filtered <see cref="Code"/>'s.</returns>
        protected List<Code> FilterCodes(List<Code> codes, Code previousGuess, Response previousResponse)
        {
            List<Code> result = new List<Code>();

            for (int i = 0; i < codes.Count; i++)
            {
                if (_rules.Check(codes[i], previousGuess) == previousResponse)
                {
                    result.Add(codes[i]);
                }
            }

            return result;
        }
    }
}
