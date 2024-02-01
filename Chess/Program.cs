public class Program
{
    public static void Main(string[] args)
    {
        ChessBoard board = new ChessBoard();
        Bishop whiteBishop = new Bishop("white", "b1", board);

        // Let's assume "d3" is occupied by a black piece, making the move legal for a capture
        board.PlacePiece("b3", "black");
        Rook whiteRook = new Rook("white", "b3", board);
        whiteRook.Move("c3");
        //whiteBishop.Move("d3"); // Attempt to move the white bishop to D3 for a capture
    }
}
