public abstract class ChessPiece 
{
    public string Color { get; protected set; }
    public string Position { get; protected set; }
    protected ChessBoard chessBoard;

    protected ChessPiece(string color, string position, ChessBoard board)
    {
        Color = color;
        Position = position;
        chessBoard = board;
        chessBoard.PlacePiece(position, color);
    }

    public abstract bool CanMoveTo(string newPosition);
    public abstract void Move(string newPosition);
}
