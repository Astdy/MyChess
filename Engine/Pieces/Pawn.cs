using Engine.PlayTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Pieces
{
    public class Pawn : Piece
    {
        private int[] attackCells;
        private int startingPosition;
        public Pawn(ColorPiece color, int startingPosition) : base(color)
        {
            attackCells = new int[2];
            this.startingPosition = startingPosition;
        }

        public override List<int> movementSelection(int position)
        {
            buffer.Clear();
            if (position == startingPosition)
            {
                if (startingPosition < 31)
                {
                    buffer.Add(position + 8);
                    buffer.Add(position + 16);
                }
                else
                {
                    buffer.Add(position - 8);
                    buffer.Add(position - 16);
                }
            }
            else if (startingPosition < 31)
            {
                buffer.Add(position + 8);

            }
            else if (startingPosition > 31)
            {
                buffer.Add(position - 8);
            }
            checkAttack(position);
            return buffer;
        }
        protected void checkAttack(int position)
        {
            attackCells = new int[2];
            if (startingPosition < 31)
            {
                attackCells[0] = position + 7;
                attackCells[1] = position + 9;
            }else if (startingPosition > 31)
            {
                attackCells[0] = position - 7;
                attackCells[1] = position - 9;
            }
        }

        public int[] getattackCells()
        {
            return attackCells;
        }
    }
}
