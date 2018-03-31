using System;

namespace Mastermind
{
    /// <summary>
    /// Represents a container of <see cref="Peg"/> instances.
    /// </summary>
    public struct Code
    {
        /// <summary>
        /// First code.
        /// </summary>
        public Peg A;

        /// <summary>
        /// Second code.
        /// </summary>
        public Peg B;

        /// <summary>
        /// Third code.
        /// </summary>
        public Peg C;

        /// <summary>
        /// Fourth code.
        /// </summary>
        public Peg D;

        /// <summary>
        /// Constructs a <see cref="Code"/> that contains four code <see cref="Peg"/> instances.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public Code(Peg a, Peg b, Peg c, Peg d)
        {
            A = a;
            B = b;
            C = c;
            D = d;            
        }

        /// <summary>
        /// Gets/Sets a <see cref="Peg"/> at the specified index.
        /// </summary>
        /// <param name="index">The index to access.</param>
        /// <returns>A <see cref="Peg"/> at the specified index.</returns>
        public Peg this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return A;
                    case 1: return B;
                    case 2: return C;
                    case 3: return D;
                    default: throw new IndexOutOfRangeException("Invalid Code Index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: A = value; break;
                    case 1: B = value; break;
                    case 2: C = value; break;
                    case 3: D = value; break;
                    default: throw new IndexOutOfRangeException("Invalid Code Index!");                        
                }
            }
        }

        /// <summary>
        /// Compares whether two <see cref="Code"/> instances are equal.
        /// </summary>
        /// <param name="left"><see cref="Code"/> instance on the left side of the equal sign.</param>
        /// <param name="right"><see cref="Code"/> instance on the right side of the equal sign.</param>
        /// <returns>True if both instances are equal, otherwise false.</returns>
        public static bool operator ==(Code left, Code right)
        {
            return left.A == right.A && left.B == right.B && left.C == right.C && left.D == right.D;
        }

        /// <summary>
        /// Compares whether two <see cref="Code"/> instances are not equal.
        /// </summary>
        /// <param name="left"><see cref="Code"/> instance on the left side of the not equal sign.</param>
        /// <param name="right"><see cref="Code"/> instance on the right side of the not equal sign.</param>
        /// <returns>True if both instances are not equal, otherwise false.</returns>
        public static bool operator !=(Code left, Code right)
        {
            return left.A != right.A || left.B != right.B || left.C != right.C || left.D != right.D;
        }

        /// <summary>
        /// Returns <see cref="Peg"/> array containing all the elements that this instance contains. 
        /// </summary>
        /// <returns>A <see cref="Peg"/> array.</returns>
        public Peg[] ToPegArray()
        {
            return new Peg[4] { A, B, C, D };
        }

        /// <summary>
        /// Compares whether this <see cref="Code"/> is equal to another <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns>True if both instances are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (!(obj is Code)) ? false : (Code)obj == this;
        }

        /// <summary>
        /// Get the hash code of this <see cref="Code"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Code"/>.</returns>
        public override int GetHashCode()
        {
            return A.GetHashCode() + B.GetHashCode() + C.GetHashCode() + D.GetHashCode();
        }

        #region Genetic

        public static Code Crossover(Code parentA, Code parentB)
        {
            Random random = new Random();
            Code child = new Code();

            for (int i = 0; i < 4; i++)
            {
                child[i] = random.NextDouble() < 0.5 ? parentA[i] : parentB[i];
            }

            return child;
        }

        #endregion Genetic
    }
}
