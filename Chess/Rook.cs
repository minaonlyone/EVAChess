public class Rook : ChessPiece
{
    public Rook(string color, string position, ChessBoard board) : base(color, position, board) { }

    public override bool CanMoveTo(string newPosition)
    {
        // Check if the move is vertical or horizontal
        bool isVertical = Position[0] == newPosition[0];
        bool isHorizontal = Position[1] == newPosition[1];
        if (!isVertical && !isHorizontal) return false; // Move is not valid if it's neither

        int currentColumn = Position[0] - 'a';
        int currentRow = Position[1] - '1';
        int newColumn = newPosition[0] - 'a';
        int newRow = newPosition[1] - '1';

        // Calculate steps for iteration (direction)
        int stepX = isHorizontal ? (newColumn > currentColumn ? 1 : -1) : 0;
        int stepY = isVertical ? (newRow > currentRow ? 1 : -1) : 0;

        int distance = isVertical ? Math.Abs(newRow - currentRow) : Math.Abs(newColumn - currentColumn);

        // Check each square along the path for obstacles
        for (int i = 1; i < distance; i++)
        {
            int checkX = currentColumn + stepX * i;
            int checkY = currentRow + stepY * i;
            string positionToCheck = $"{(char)('a' + checkX)}{(char)('1' + checkY)}";
            if (chessBoard.IsOccupied(positionToCheck))
            {
                return false; // Path is blocked
            }
        }

        // Final position check (could be an opponent's piece, so capture is allowed)
        return !chessBoard.IsOccupied(newPosition) || chessBoard.GetPieceColor(newPosition) != this.Color;
    }

    public override void Move(string newPosition)
    {
        if (CanMoveTo(newPosition))
        {
            chessBoard.MovePiece(Position, newPosition, Color); // Assuming ChessBoard can move pieces
            Position = newPosition;
            Console.WriteLine($"Rook moved to {newPosition}.");
        }
        else
        {
            Console.WriteLine("Move is invalid or path is blocked.");
        }
    }
}
