using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Pieces
{
    public class Queen : Piece    
    {
        private Bishop bishop;
        private Rook rook;

        public Queen(ColorPiece color) : base(color)
        {
            bishop = new Bishop(color);
            rook = new Rook(color);
        }

        public override List<int> movementSelection(int position)
        {
            buffer.Clear();
            buffer.AddRange(bishop.movementSelection(position));
            buffer.AddRange(rook.movementSelection(position));
            return buffer;
        }

        public List<int> getFirstMoveLine()
        {
            return bishop.getFirstMoveLine();
        }
        public List<int> getSecondMoveLine()
        {
            return bishop.getSecondMoveLine(); 
        }
        public List<int> getVerticalmovementSelection()
        {
            return rook.getVerticalmovementSelection();
        }

        public List<int> getHorisontalmovementSelection()
        {
            return rook.getHorisontalmovementSelection();
        }
    }
}
