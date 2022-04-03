using System.Collections.Generic;


namespace OthelloMinimaxAI
{
    /// <summary>
    /// @author KyleEB
    /// Represents a Move on an Reversi board, also saves all flanked pieces in a move.
    /// Each move is also hashed such that they can be easily compared for deleting duplicates.
    /// </summary>
    class Move
    {
        public int row;
        public int col;
        public Board.PIECE who;

        public HashSet<(int row, int col)> flanked;

       public Move()
       {
            row = -1;
            col = -1;
            who = Board.PIECE.EMPTY;
            flanked = new HashSet<(int,int)>();
       } 

       public Move( int row, int col, Board.PIECE who)
       {
            this.row = row;
            this.col = col;
            this.who = who;
       }

        public Move( Move toCopy)
        {
            this.row = toCopy.row;
            this.col = toCopy.col;
            this.who = toCopy.who;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Move);
        }

        public override int GetHashCode()
        {
            return row * 8 + col; //one-to-one 
        }
        public bool Equals(Move other)
        {
            return (this.row == other.row && this.col == other.col && this.who == other.who);
        }

        public override string ToString()
        {

            return "who: " + who + " row: " + row + " col: " + col + " hash: " + GetHashCode();
        }
    }
}
