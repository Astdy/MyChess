using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.PlayTable;

namespace Engine.Pieces
{
    public class Rook : Piece
    {
        private List<int> verticalMovementSelection;
        private List<int> horisontalMovementSelection;
        public Rook(ColorPiece color) : base(color)
        {
            verticalMovementSelection = new List<int>();
            horisontalMovementSelection = new List<int>();

        }
        public override List<int> movementSelection(int position)
        {
            verticalMovementSelection.Clear();
            horisontalMovementSelection.Clear();
            buffer.Clear();
            int verticalLineStart = position % 8;
            int horisontalLineStart = position - verticalLineStart;
            for (int i = verticalLineStart; i < ChessTable.COUNT_CELLS;)
            {
                verticalMovementSelection.Add(i);
                buffer.Add(i);
                i += 8;
            }
            for (int i = horisontalLineStart; i < (horisontalLineStart + 8); i++)
            {
                horisontalMovementSelection.Add(i);
                buffer.Add(i);
            }
            //verticalMovementSelection.Where(a => a != position).ToList();
            //horisontalMovementSelection.Where(a => a != position).ToList();
            verticalMovementSelection.Remove(position);
            horisontalMovementSelection.Remove(position);
            return  buffer.Where(a => a != position).ToList();
        }
        public List<int> getVerticalmovementSelection()
        {
            return verticalMovementSelection;
        }

        public List<int> getHorisontalmovementSelection()
        {
            return horisontalMovementSelection;
        }

    }
}
