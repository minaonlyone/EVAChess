public class ChessBoard
{
    private Dictionary<string, string> board = new Dictionary<string, string>();

    public ChessBoard()
    {
        for (char column = 'a'; column <= 'h'; column++)
        {
            for (int row = 1; row <= 8; row++)
            {
                board[$"{column}{row}"] = null; // Initialize all positions as unoccupied
            }
        }
    }

    public void PlacePiece(string position, string color)
    {
        board[position] = color; // Assign color to the position
    }

    public bool IsOccupied(string position)
    {
        return board[position] != null;
    }

    public string GetPieceColor(string position)
    {
        return board[position]; // Returns the color of the piece at the given position, or null if unoccupied
    }

    public void MovePiece(string fromPosition, string toPosition, string color)
    {
        board[fromPosition] = null; // Remove piece from the original position
        board[toPosition] = color; // Place piece at the new position
    }
}
