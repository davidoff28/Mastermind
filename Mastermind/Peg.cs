using System;

namespace Mastermind
{
    /// <summary>
    /// Represents a peg that contains a colour.
    /// </summary>
    public struct Peg
    {
        /// <summary>
        /// The <see cref="PegColour"/> of this <see cref="Peg"/>.
        /// </summary>
        public PegColour Colour
        {
            get; set;
        }

        /// <summary>
        /// Constructs a <see cref="Peg"/> with a specified colour.
        /// </summary>
        /// <param name="colour">The colour.</param>
        public Peg(PegColour colour)
        {
            Colour = colour;
        }

        /// <summary>
        /// Compares whether two <see cref="Peg"/> instances are equal.
        /// </summary>
        /// <param name="left"><see cref="Peg"/> instance on the left side of the equal sign.</param>
        /// <param name="right"><see cref="Peg"/> instance on the right side of the equal sign.</param>
        /// <returns>True if both instances are equal, otherwise false.</returns>
        public static bool operator ==(Peg left, Peg right)
        {
            return left.Colour == right.Colour;
        }

        /// <summary>
        /// Compares whether two <see cref="Peg"/> instances are not equal.
        /// </summary>
        /// <param name="left"><see cref="Peg"/> instance on the left side of the not equal sign.</param>
        /// <param name="right"><see cref="Peg"/> instance on the right side of the not equal sign.</param>
        /// <returns>True if both instances are not equal, otherwise false.</returns>
        public static bool operator !=(Peg left, Peg right)
        {
            return left.Colour != right.Colour;
        }

        /// <summary>
        /// Compares whether this <see cref="Peg"/> is equal to another <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns>True if both instances are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (!(obj is Peg)) ? false : (Peg)obj == this;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Peg"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Peg"/>.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() + Colour.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="String"/> of this <see cref="Peg"/> depending on the <see cref="PegColour"/>.
        /// <see cref="PegColour.Red"/>: [R],
        /// <see cref="PegColour.Green"/>: [G],
        /// <see cref="PegColour.Blue"/>: [B],
        /// <see cref="PegColour.Yellow"/>: [Y],
        /// <see cref="PegColour.Cyan"/>: [C],
        /// <see cref="PegColour.Purple"/>: [P],
        /// <see cref="PegColour.Black"/>: (B),
        /// <see cref="PegColour.White"/>: (W).
        /// </summary>
        /// <returns>A <see cref="String"/> of this <see cref="Peg"/>.</returns>
        public override string ToString()
        {
            string colour = string.Empty;

            switch (Colour)
            {
                case PegColour.None:    { colour = "[*]"; Console.ForegroundColor = ConsoleColor.DarkGray; }    break;
                case PegColour.Red:     { colour = "[R]"; Console.ForegroundColor = ConsoleColor.Red;      }    break;
                case PegColour.Green:   { colour = "[G]"; Console.ForegroundColor = ConsoleColor.Green;    }    break;
                case PegColour.Blue:    { colour = "[B]"; Console.ForegroundColor = ConsoleColor.Blue;     }    break;
                case PegColour.Yellow:  { colour = "[Y]"; Console.ForegroundColor = ConsoleColor.Yellow;   }    break;
                case PegColour.Cyan:    { colour = "[C]"; Console.ForegroundColor = ConsoleColor.Cyan;     }    break;
                case PegColour.Purple:  { colour = "[P]"; Console.ForegroundColor = ConsoleColor.Magenta;  }    break;
                case PegColour.Black:   { colour = "(B)"; Console.ForegroundColor = ConsoleColor.Gray;     }    break;
                case PegColour.White:   { colour = "(W)"; Console.ForegroundColor = ConsoleColor.White;    }    break;
                default:                { colour = "[ ]"; Console.ForegroundColor = ConsoleColor.DarkGray; }    break;
            }

            return colour;
        }
    }
}
