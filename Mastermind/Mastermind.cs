using System;
using Mastermind.Ai;

namespace Mastermind
{
    /// <summary>
    /// Represents the main mastermind game.
    /// </summary>
    public class Mastermind
    {        
        private int _boardSize;
        private Rules _rules;
        private GameBoard _gameBoard;
        private Renderer _renderer;

        private AI _ai;

        private Code _secret;
        private Code _guess;
        private Response _response;
        private Response _winningResponse;

        private bool _isRunning;
        private int _turnCount;

        /// <summary>
        /// Gets whether the <see cref="Mastermind"/> game is running.
        /// </summary>
        public bool IsRunning
        {
            get => _isRunning;
        }

        /// <summary>
        /// Constructs a <see cref="Mastermind"/> object with a specified size.
        /// </summary>
        /// <param name="boardSize"></param>
        public Mastermind(int boardSize)
        {
            _boardSize = boardSize;
            _rules = new Rules();
            _gameBoard = new GameBoard(boardSize);
            _renderer = new Renderer();
            _isRunning = true;
            _turnCount = 0;
        }

        /// <summary>
        /// Draws the intro screen to the <see cref="Console"/> window.
        /// </summary>
        public void IntroScreen()
        {
            bool correctKey = false;
            while (!correctKey)
            {
                _renderer.ClearScreen();
                _renderer.DrawText(System.IO.File.ReadAllText("../../Resources/MastermindTitle.txt"),
                "=================================================================================",
                "Press P to play",
                "Press Q to quit");


                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.P)
                {
                    correctKey = true;
                    Initialize();
                }
                else if (keyInfo.Key == ConsoleKey.Q)
                {
                    correctKey = true;
                    Environment.Exit(-1);
                }
                else
                {
                    correctKey = false;
                }
            }
        }

        /// <summary>
        /// Initializes the <see cref="Mastermind"/> game.
        /// </summary>
        public void Initialize()
        {
            bool correctKey = false;

            while (!correctKey)
            {
                _renderer.ClearScreen();
                _renderer.DrawText("Who would you like to go against?",
                    "1) Knuth",
                    "2) Simple",
                    "3) Swaszek",
                    "(Enter 1, 2, or 3 to select your choice)");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            _ai = new Knuth(_rules);
                            correctKey = true;
                        }
                        break;
                    case 2:
                        {
                            _ai = new Simple(_rules);
                            correctKey = true;
                        }
                        break;
                    case 3:
                        {
                            _ai = new Swaszek(_rules);
                            correctKey = true;
                        }
                        break;
                    default: correctKey = false;  break;
                }
            }

            _gameBoard.Initialize();
            _secret = _ai.GenerateSecret();
            _response = new Response(0, 0);
            _winningResponse = new Response(4, 0);
        }

        /// <summary>
        /// Runs the <see cref="Mastermind"/> game. Updates every turn. Takes in input and displays output. 
        /// </summary>
        public void Run()
        {
            Draw();
            _renderer.DrawText("Press the spacebar to continue");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key != ConsoleKey.Spacebar)
            {
                _renderer.DrawText("Incorrect input! Please try again!");
            }
            else
            {
                if (_response != _winningResponse)
                {
                    if (_turnCount != _boardSize)
                    {
                        _renderer.DrawText("" + _ai.Name + " is thinking...");

                        _guess = (_turnCount != 0) ? _ai.GenerateGuess(_response) : _ai.InitialGuess();
                        _response = _rules.Check(_guess, _secret);

                        _gameBoard.CodeBoard.Update(_turnCount, _guess);
                        _gameBoard.ResponseBoard.Update(_turnCount, _response);

                        _turnCount++;
                    }
                    else
                    {
                        LoseScreen();
                    }
                }
                else
                {
                    WinScreen();
                }
            }
        }

        /// <summary>
        /// Draws the header, turn count and <see cref="GameBoard"/> to the <see cref="Console"/> window.
        /// </summary>
        public void Draw()
        {
            _renderer.ClearScreen();
            _renderer.DrawText(System.IO.File.ReadAllText("../../Resources/MastermindTitle.txt"),
                "=============================================================================",
                string.Format("Turn {0}", _turnCount + 1),
                "=============================================================================");
            _renderer.DrawGameBoard(_gameBoard);
            _renderer.ResetColour();
        }

        /// <summary>
        /// Draw the lose screen to the <see cref="Console"/> window.
        /// </summary>
        public void LoseScreen()
        {
            _isRunning = false;
            _renderer.ClearScreen();
            _renderer.DrawText(
                System.IO.File.ReadAllText("../../Resources/Congratulations.txt"),
                System.IO.File.ReadAllText("../../Resources/CodeMaker.txt"),
                "Your secret code was unbreakable!");

            _renderer.DrawRow(_secret.ToPegArray());
            _renderer.ResetColour();
        }

        /// <summary>
        /// Draws the win screen to the <see cref="Console"/> window.
        /// </summary>
        public void WinScreen()
        {
            _isRunning = false;
            _renderer.ClearScreen();
            _renderer.DrawText(
                System.IO.File.ReadAllText("../../Resources/Congratulations.txt"),
                System.IO.File.ReadAllText("../../Resources/CodeBreaker.txt"),
                "You broke the secret code in " + _turnCount + " turns!");

            _renderer.DrawRow(_secret.ToPegArray());
            _renderer.ResetColour();          
        }
    }
}