namespace Mastermind
{
    /// <summary>
    /// Represents a generic board matrix.
    /// </summary>
    /// <typeparam name="T">The type of object to contain.</typeparam>
    public class Board<T>
    {
        private T[] _board;
        private int _size;

        /// <summary>
        /// Gets the size of this <see cref="Board{T}"/>. The size is the number of rows.
        /// </summary>
        public int Size
        {
            get => _size;
        }

        /// <summary>
        /// Constructs a <see cref="Board{T}"/> with a specified size.
        /// </summary>
        /// <param name="size">The size (number of rows).</param>
        public Board(int size)
        {
            _size = size;
            _board = new T[size];
        }

        /// <summary>
        /// Gets/Sets a <see cref="T"/> object at the specified index.
        /// </summary>
        /// <param name="index">The index to access.</param>
        /// <returns>A <see cref="T"/> object at the specified index.</returns>
        public T this[int index]
        {
            get => _board[index];
            set => _board[index] = value;
        }

        /// <summary>
        /// Updates the <see cref="Board{T}"/> row at the specified index.
        /// </summary>
        /// <param name="index">The index to access.</param>
        /// <param name="row">The row of <see cref="T"/> to update.</param>
        public void Update(int index, T row)
        {
            _board[index] = row;
        }
    }
}
