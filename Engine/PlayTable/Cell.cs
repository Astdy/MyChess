using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.PlayTable
{
    internal class Cell
    {
        private static byte allCountCells = 0;
        private int numberCell;
        private ColorCell color;
        private Piece piece;
        public Cell(ColorCell color)
        {
            this.color = color;
            numberCell = allCountCells;
            allCountCells++;
        }
        public int getNumberCell()
        {
            return numberCell;  
        }
        public void setPiece(Piece piece)
        {
            this.piece = piece; 
        }
        public Piece getPiece()
        {
            return piece;   
        }
        public void removePiece()
        {
            this.piece = null;
        }
        public ColorCell getColorCell()
        {
            return color;
        }
    }
}
