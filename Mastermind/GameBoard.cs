namespace Mastermind
{
    /// <summary>
    /// Represents the main <see cref="Mastermind"/> game board.
    /// </summary>
    public class GameBoard
    {
        private int _size;
        private Board<Code> _codeBoard;
        private Board<Response> _responseBoard;

        /// <summary>
        /// Gets the size of the <see cref="GameBoard"/>.
        /// </summary>
        public int Size
        {
            get => _size;
        }

        /// <summary>
        /// Gets the <see cref="Board{T}"/> object containing <see cref="Code"/> objects.
        /// </summary>
        public Board<Code> CodeBoard
        {
            get => _codeBoard;
        }

        /// <summary>
        /// Gets the <see cref="Board{T}"/> object containing <see cref="Response"/> objects.
        /// </summary>
        public Board<Response> ResponseBoard
        {
            get => _responseBoard;
        }

        /// <summary>
        /// Constructs <see cref="GameBoard"/> with a specified size.
        /// </summary>
        /// <param name="boardSize">Size of the <see cref="GameBoard"/>.</param>
        public GameBoard(int boardSize)
        {
            _size = boardSize;
            _codeBoard = new Board<Code>(boardSize);
            _responseBoard = new Board<Response>(boardSize);
        }

        /// <summary>
        /// Initializes the <see cref="GameBoard"/>.
        /// </summary>
        public void Initialize()
        {
            for (int i = 0; i < _size; i++)
            {
                _codeBoard[i] = new Code();
            }
        }
    }
}
