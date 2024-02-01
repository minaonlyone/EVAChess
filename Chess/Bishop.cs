public class Bishop : ChessPiece
{
    public Bishop(string color, string position, ChessBoard board) : base(color, position, board) { }


    public bool IsLegalMove(string newPosition)
    {
        string pieceColorAtNewPosition = chessBoard.GetPieceColor(newPosition);
        // Move is legal if the newPosition is not occupied or occupied by a different color
        return pieceColorAtNewPosition == null || pieceColorAtNewPosition != this.Color;
    }

    public override bool CanMoveTo(string newPosition)
    {
        // Check if the move is diagonally valid
        int currentColumn = Position[0] - 'a';
        int currentRow = Position[1] - '1';
        int newColumn = newPosition[0] - 'a';
        int newRow = newPosition[1] - '1';

        int columnDifference = Math.Abs(currentColumn - newColumn);
        int rowDifference = Math.Abs(currentRow - newRow);

        // The move is diagonal if the column and row differences are equal and not zero
        if (columnDifference == rowDifference && columnDifference > 0)
        {
            // Check if the path is clear
            int stepX = (newColumn - currentColumn) / columnDifference;
            int stepY = (newRow - currentRow) / rowDifference;
            for (int i = 1; i < columnDifference; i++)
            {
                int checkX = currentColumn + stepX * i;
                int checkY = currentRow + stepY * i;
                string positionToCheck = $"{(char)('a' + checkX)}{(char)('1' + checkY)}";
                if (chessBoard.IsOccupied(positionToCheck))
                {
                    // Path is blocked
                    return false;
                }
            }
            // Check if the final position is not occupied or occupied by an opponent's piece
            return !chessBoard.IsOccupied(newPosition) || chessBoard.GetPieceColor(newPosition) != this.Color;
        }

        // Move is not diagonally valid
        return false;
    }


    public override void Move(string newPosition)
    {
        if (chessBoard.IsOccupied(newPosition) && !IsLegalMove(newPosition))
        {
            Console.WriteLine($"Cannot move to {newPosition} as it is occupied by a piece of the same color.");
            return;
        }

        int currentColumnIndex = Position[0] - 'a' + 1;
        int newColumnIndex = newPosition[0] - 'a' + 1;
        int currentRowIndex = int.Parse(Position[1].ToString());
        int newRowIndex = int.Parse(newPosition[1].ToString());
        int columnDifference = Math.Abs(currentColumnIndex - newColumnIndex);
        int rowDifference = Math.Abs(currentRowIndex - newRowIndex);

        if (columnDifference == rowDifference)
        {
            chessBoard.MovePiece(Position, newPosition, Color); // Update board with the move
            Position = newPosition;
            Console.WriteLine("Moved to " + newPosition);
        }
        else
        {
            Console.WriteLine("Invalid move for a bishop. Bishops can only move diagonally.");
        }
    }
}
