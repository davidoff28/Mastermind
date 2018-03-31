using System;

namespace Mastermind
{
    /// <summary>
    /// Represents the main entry point to application.
    /// </summary>
    class Program
    {
        private static Mastermind _mastermind;
        private static bool _startGame = true;

        /// <summary>
        /// Main entry point to application.
        /// </summary>
        /// <param name="args">Command arguments.</param>
        static void Main(string[] args)
        {            
            while (_startGame)
            {
                _startGame = false;
                Start();
                Restart();
            }
        }

        public static void Start()
        {
            _mastermind = new Mastermind(13);
            _mastermind.IntroScreen();

            while (_mastermind.IsRunning)
            {
                _mastermind.Run();
            }
        }

        public static void Restart()
        {
            bool correctKey = false;

            while (correctKey != true)
            {
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("Press Y for Yes");
                Console.WriteLine("Press N for No");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    correctKey = true;
                    _startGame = true;
                }

                if (keyInfo.Key == ConsoleKey.N)
                {
                    correctKey = true;
                    _startGame = false;
                }
            }
        }
    }
}
