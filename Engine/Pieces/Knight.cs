using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Pieces
{
    public class Knight : Piece
    {
        public Knight(ColorPiece color) : base(color)
        {

        }

        public override List<int> movementSelection(int position)
        {
            buffer.Clear();
            for (int i = -16; i < 33;)
            {
               buffer.Add(position +i -1);
               buffer.Add(position +i +1);
               i+= 32;
            }
            for (int i = -2; i < 5;)
            {
                buffer.Add(position + i - 8);
                buffer.Add(position + i + 8);
                i += 4;
            }
            if (position % 8 == 7)
            {
                return buffer.Where(a => a % 8 != 0 & a% 8 != 1).ToList();
            }
            else if (position % 8 == 0)
            {
                return buffer.Where(a => a % 8 != 7 & a % 8 != 6).ToList();
            }else if (position % 8 == 1)
            {
                return buffer.Where(a => a % 8 != 7).ToList();
            }else if (position % 8 == 6)
            {
                return buffer.Where(a => a % 8 != 0).ToList();
            }
            return buffer;
        }
    }
}
