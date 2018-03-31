using System;

namespace Mastermind
{
    /// <summary>
    /// Provides drawing capabilities to the <see cref="Console"/> window.
    /// </summary>
    public class Renderer
    {
        /// <summary>
        /// Clears the <see cref="Console"/> screen.
        /// </summary>
        public void ClearScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// Writes multiple <see cref="String"/> objects to the <see cref="Console"/> window.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public void DrawText(params string[] text)
        {
            foreach (var word in text)
            {
                Console.WriteLine(word);
            }
        }

        /// <summary>
        /// Draws the <see cref="GameBoard"/> onto the <see cref="Console"/> window.
        /// </summary>
        /// <param name="gameBoard">The <see cref="GameBoard"/> to draw.</param>
        public void DrawGameBoard(GameBoard gameBoard)
        {
            for (int i = 0; i < 13; i++)
            {
                DrawRow(gameBoard.CodeBoard[i].ToPegArray());
                Console.Write("\t");
                DrawRow(gameBoard.ResponseBoard[i].ToPegArray());
                Console.WriteLine();
            }

            ResetColour();
        }

        /// <summary>
        /// Draws a row of <see cref="Peg"/> objects to the <see cref="Console"/> window.
        /// </summary>
        /// <param name="row">The row to draw.</param>
        public void DrawRow(Peg[] row)
        {
            for (int i = 0; i < 4; i++)
            {
                ChangeConsoleColour(row[i]);
                Console.Write(row[i].ToString());
            }            
        }

        /// <summary>
        /// Resest the <see cref="Console.ForegroundColor"/> to <see cref="ConsoleColor.White"/>.
        /// </summary>
        public void ResetColour()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Chnages the <see cref="Console.ForegroundColor"/> to the specified <see cref="Peg.Colour"/>.
        /// </summary>
        /// <param name="peg">The peg to change the <see cref="Console.ForegroundColor"/>.</param>
        private void ChangeConsoleColour(Peg peg)
        {
            switch (peg.Colour)
            {
                case PegColour.None: Console.ForegroundColor = ConsoleColor.DarkGray; break;
                case PegColour.Red: Console.ForegroundColor = ConsoleColor.Red; break;
                case PegColour.Green: Console.ForegroundColor = ConsoleColor.Green; break;
                case PegColour.Blue: Console.ForegroundColor = ConsoleColor.Blue; break;
                case PegColour.Yellow: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case PegColour.Cyan: Console.ForegroundColor = ConsoleColor.Cyan; break;
                case PegColour.Purple: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case PegColour.Black: Console.ForegroundColor = ConsoleColor.Gray; break;
                case PegColour.White: Console.ForegroundColor = ConsoleColor.White; break;
                default: Console.ForegroundColor = ConsoleColor.DarkGray; break;
            }
        }
    }
}
