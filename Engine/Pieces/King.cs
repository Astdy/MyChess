using Engine.PlayTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Pieces
{
    public class King : Piece
    {
        public King(ColorPiece color) : base(color)
        {
        }
        public override List<int> movementSelection(int position)
        {
            List<int> movecells = new List<int>();
            movecells.Add(position  - 1);
            movecells.Add(position + 1);
            for (int i = 3; i > 0; i--)
            {
                movecells.Add((position -6) -i);
            }
            for (int i = 1; i <= 3; i++)
            {
                movecells.Add((position+6) + i);
            }
            if (position % 8 == 7)
            {
              return movecells.Where(a => a % 8 != 0).ToList(); 
            }else if (position % 8 == 0)
            {
              return movecells.Where(a => a % 8 != 7).ToList();
            }
            return movecells;
        }
    }
}
