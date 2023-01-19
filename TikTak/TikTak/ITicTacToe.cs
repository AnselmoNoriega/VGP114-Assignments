namespace TicTacToe;

/// <summary>
///     A single game of Tic Tac Toe, played on a three-by-three grid with two players,
///     with the object of the game to achieve three markers in a row either vertically,
///     horizontally, or diagonally.
///     <see cref="Player" />
///     X goes first.
/// </summary>
///

public interface ITicTacToe
{
    /// <summary>
    ///     Execute a move in the position specified by the given row and column.
    ///     <paramref name="r" />
    ///     the row of the intended move
    ///     <paramref name="c" />
    ///     the column of the intended move
    ///     <exception cref="ArgumentException">if the space is occupied or the position is otherwise invalid</exception>
    ///     <exception cref="InvalidOperationException">if the game is over</exception>
    /// </summary>
    void Move(int r, int c);

    /// <summary>Get the current turn, i.e., the player who will mark on the next call to move().</summary>
    /// <returns> the <see cref="Player" /> whose turn it is </returns>
    Player GetTurn();

    /// <summary>
    ///     Return whether the game is over. The game is over when either the board is full, or
    ///     one player has won.
    /// </summary>
    /// <returns>true if the game is over, false otherwise</returns>
    bool IsGameOver();

    /// <summary>
    ///     Return the winner of the game, or null if there is no winner. If the game is not
    ///     over, returns null.
    /// </summary>
    /// <returns>the winner, or null if there is no winner</returns>
    Player GetWinner();

    /// <summary>
    ///     Return the current game state, as a 2D array of Player. A {@code null} value in the grid
    ///     indicates an empty position on the board.
    /// </summary>
    /// <returns>the current game board</returns>
    Player[][] GetBoard();

    /// <summary>
    ///     Return the current {@link Player} mark at a given row and column, or {@code null} if the
    ///     position is empty.
    ///     <paramref name="r" />the row
    ///     <paramref name="c" />the column
    /// </summary>
    /// <returns> the player at the given position, or null if it's empty</returns>
    Player GetMarkAt(int r, int c);
}
