using System;

namespace Mastermind
{
    /// <summary>
    /// Represents a scoring result.
    /// </summary>
    public struct Response
    {
        /// <summary>
        /// The number of black scores.
        /// </summary>
        public int Blacks
        {
            get; set;
        }

        /// <summary>
        /// The number of white scores.
        /// </summary>
        public int Whites
        {
            get; set;
        }

        /// <summary>
        /// Constructs a <see cref="Response"/> with the specified number of blacks and whites.
        /// </summary>
        /// <param name="blacks">Number of blacks.</param>
        /// <param name="whites">Number of whites.</param>
        public Response(int blacks, int whites)
        {
            Blacks = blacks;
            Whites = whites;
        }

        /// <summary>
        /// Compares whether two <see cref="Response"/> instances are equal.
        /// </summary>
        /// <param name="left"><see cref="Response"/> instance on the left side of the equal sign.</param>
        /// <param name="right"><see cref="Response"/> instance on the right side of the equal sign.</param>
        /// <returns>True if both instances are equal, otherwise false.</returns>
        public static bool operator ==(Response left, Response right)
        {
            return left.Blacks == right.Blacks && left.Whites == right.Whites;
        }

        /// <summary>
        /// Compares whether two <see cref="Response"/> instances are not equal.
        /// </summary>
        /// <param name="left"><see cref="Response"/> instance on the left side of the not equal sign.</param>
        /// <param name="right"><see cref="Response"/> instance on the right side of the not equal sign.</param>
        /// <returns>True if both instances are not equal, otherwise false.</returns>
        public static bool operator !=(Response left, Response right)
        {
            return left.Blacks != right.Blacks || left.Whites != right.Whites;
        }

        /// <summary>
        /// Returns a <see cref="Peg"/> array with their <see cref="PegColour"/> set to 
        /// <see cref="PegColour.Black"/> or <see cref="PegColour.White"/>
        /// depening on the number of <see cref="Blacks"/> and <see cref="Whites"/>.
        /// </summary>
        /// <returns>An array of <see cref="Peg"/> with their <see cref="Peg.Colour"/> set to 
        /// <see cref="PegColour.Black"/> or <see cref="PegColour.White"/>.</returns>
        public Peg[] ToPegArray()
        {            
            Peg[] blacks = PopulateBlacks();
            Peg[] whites = PopulateWhites();
            Peg[] result = new Peg[4];

            if (Blacks != 0)
            {
                if (Whites != 0)
                {
                    Array.Copy(blacks, result, blacks.Length);
                    Array.Copy(whites, 0, result, blacks.Length, whites.Length);
                }
                else
                {
                    Array.Copy(blacks, result, blacks.Length);
                }
            }
            else
            {
                Array.Copy(whites, result, whites.Length);
            }

            return result;
        }

        /// <summary>
        /// Returns an array of <see cref="Peg"/> with their <see cref="PegColour"/> set to <see cref="PegColour.Black"/>.
        /// </summary>
        /// <returns>An array of <see cref="Peg"/> with their <see cref="PegColour"/> set to <see cref="PegColour.Black"/>.</returns>
        private Peg[] PopulateBlacks()
        {
            Peg[] blacks = new Peg[Blacks];

            for (int i = 0; i < Blacks; i++)
            {
                blacks[i] = new Peg(PegColour.Black);
            }

            return blacks;
        }

        /// <summary>
        /// Returns an array of <see cref="Peg"/> with their <see cref="PegColour"/> set to <see cref="PegColour.White"/>.
        /// </summary>
        /// <returns>An array of <see cref="Peg"/> with their <see cref="PegColour"/> set to <see cref="PegColour.White"/>.</returns>
        private Peg[] PopulateWhites()
        {
            Peg[] whites = new Peg[Whites];

            for (int i = 0; i < Whites; i++)
            {
                whites[i] = new Peg(PegColour.White);
            }

            return whites;
        }

        /// <summary>
        /// Compares whether this <see cref="Response"/> is equal to another <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns>True if both instances are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (!(obj is Response)) ? false : (Response)obj == this;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Response"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Response"/>.</returns>
        public override int GetHashCode()
        {
            return Blacks.GetHashCode() + Whites.GetHashCode();
        }
    }
}
