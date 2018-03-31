using System;
using System.Collections.Generic;

namespace Mastermind
{
    /// <summary>
    /// Governs how <see cref="Mastermind"/> plays. Also provides every possible <see cref="Code"/> combination and <see cref="Response"/> outcome.
    /// </summary>
    public class Rules
    {
        private List<Code> _allCodes;
        private List<Response> _allResponses;
        
        /// <summary>
        /// Gets a <see cref="List{T}"/> of every possible <see cref="Code"/> combination.
        /// </summary>
        public List<Code> AllCodes
        {
            get => _allCodes;
        }

        /// <summary>
        /// Gets a <see cref="List{T}"/> of every possible <see cref="Response"/> outcome.
        /// </summary>
        public List<Response> AllResponses
        {
            get => _allResponses;
        }

        /// <summary>
        /// Default constructor, generates every possible <see cref="Code"/> combination and <see cref="Response"/> outcome.
        /// </summary>
        public Rules()
        {
            GenerateAllCodes();
            GenerateAllResponses();
        }

        /// <summary>
        /// Compares two <see cref="Code"/> instances and returns a <see cref="Response"/> outcome.
        /// </summary>
        /// <param name="guess">The guess <see cref="Code"/> combination.</param>
        /// <param name="secret">The secret <see cref="Code"/> combination.</param>
        /// <returns>The <see cref="Response"/> outcome.</returns>
        public Response Check(Code guess, Code secret)
        {
            int black = 0;
            int white = 0;

            bool[] checkedGuess = new bool[4];
            bool[] checkedSecret = new bool[4];

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secret[i])
                {
                    black++;
                    checkedGuess[i] = checkedSecret[i] = true;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (checkedGuess[i])
                {
                    continue;
                }

                for (int j = 0; j < 4; j++)
                {
                    if ((i != j) && !checkedSecret[j] && (guess[i] == secret[j]))
                    {
                        white++;
                        checkedSecret[j] = true;
                        break; // Break out of the loop to avoid futher comparison checks.
                    }
                }
            }

            return FindResponse(black, white);
        }

        /// <summary>
        /// Checks to see if a <see cref="Response"/> that matches the number of black and white scores exist.
        /// Throws an <see cref="Exception"/> if invalid.
        /// </summary>
        /// <param name="blacks">The number of blacks.</param>
        /// <param name="whites">The number of whites.</param>
        /// <returns>A <see cref="Response"/> that matches the number of blacks and whites.</returns>
        private Response FindResponse(int blacks, int whites)
        {
            Response temp = new Response(blacks, whites);
            return (_allResponses.Contains(temp)) ? temp : throw new Exception(string.Format("Invalid Response: {0}!", temp.ToString()));
        }

        /// <summary>
        /// Generates every possible <see cref="Code"/> combination.
        /// </summary>
        private void GenerateAllCodes()
        {
            // 6 colours ^ 4 slots = 1296 possible code combinations
            _allCodes = new List<Code>((int)Math.Pow(6, 4));

            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    for (int k = 1; k <= 6; k++)
                    {
                        for (int l = 1; l <= 6; l++)
                        {                            
                            _allCodes.Add(new Code(new Peg((PegColour)i), new Peg((PegColour)j), new Peg((PegColour)k), new Peg((PegColour)l)));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates every possible <see cref="Response"/> outcome.
        /// </summary>
        private void GenerateAllResponses()
        {
            _allResponses = new List<Response>(14)
            {
                new Response(0, 0),

                new Response(0, 1),
                new Response(0, 2),
                new Response(0, 3),
                new Response(0, 4),

                new Response(1, 0),
                new Response(1, 1),
                new Response(1, 2),
                new Response(1, 3),

                new Response(2, 0),
                new Response(2, 1),
                new Response(2, 2),

                new Response(3, 0),
                new Response(4, 0)
            };
        }
    }
}
