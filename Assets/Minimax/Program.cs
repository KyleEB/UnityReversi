using System;

namespace OthelloMinimaxAI
{
    /// <summary>
    /// @author KyleEB
    /// Not needed for unity, but this was the original runner when the AI was purely console based.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Let's play Othello! \n Please Enter 'B' or 'W' for preferred piece");

            string player = Console.ReadLine();

            Board.PIECE PlayerPiece;

            if(player.ToUpper().Equals("B"))
            {
                PlayerPiece = Board.PIECE.BLACK;
            }
            else
            {
                PlayerPiece = Board.PIECE.WHITE;
            }

            Board currentBoard = new Board(PlayerPiece);

            Console.WriteLine("Choose your difficulty 1-10");

            int minimaxDepth = int.Parse(Console.ReadLine());

            Console.WriteLine("Row and Column numbers are 0-7 instead of 1-8");

            while (true)
            {
                if (currentBoard.terminal)
                {
                    if(currentBoard.getNumBlackPieces() > currentBoard.getNumWhitePieces())
                    {
                        Console.WriteLine("Black Wins!");
                    }
                    else 
                    {
                        Console.WriteLine("White Wins!");
                    }

                    while (true)
                    {

                    }
                }

                Console.Write(currentBoard.ToString());
                Console.WriteLine(currentBoard.currentPlayer + " | Make your move!");

                if (currentBoard.currentPlayer == PlayerPiece)
                {
                    Console.WriteLine("Enter row: ");
                    int row = int.Parse(Console.ReadLine().Trim());

                    Console.WriteLine("Enter col: ");
                    int col = int.Parse(Console.ReadLine().Trim());

                    if (!currentBoard.makeMove(row, col))
                    {
                        Console.WriteLine("Invalid Move \n");
                        continue;
                    }
                }
                else if (currentBoard.currentPlayer != PlayerPiece)
                {
                    (int score, Move move) = currentBoard.minimax(currentBoard, Board.PIECE.WHITE, minimaxDepth, 0, int.MinValue, int.MaxValue);

                    if (move == null)
                    {
                        currentBoard.terminal = true;
                        continue;
                    }
                    currentBoard.makeMove(move.row, move.col);
                    Console.WriteLine("AI placed a piece at " + "row: " + move.row + "col: " + move.col + "\n");
                    
                }

                

            }

        }

    }
}
