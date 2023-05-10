using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Pieces
{
    public class Bishop : Piece
    {
        private List<int> leftMoveLine;
        private List<int> rightMoveLine;
        public Bishop(ColorPiece color) : base(color)
        {
            leftMoveLine = new List<int>();
            rightMoveLine = new List<int>();
        }

        public override List<int> movementSelection(int position)
        {
            buffer.Clear();
            leftMoveLine.Clear();
            rightMoveLine.Clear();
            leftMoveLine = createLine(position, true);
            rightMoveLine = createLine(position, false); 
            buffer.AddRange(leftMoveLine);
            buffer.AddRange(rightMoveLine);
            return buffer;
        }

        
        private List<int> createLine(int position, bool isLeftLine)
        {
            List<int> result = new List<int>();
            int upDistance;
            int downDistance;
            int lenghtToWall;
            if (isLeftLine)
            {
                upDistance = 9;
                downDistance = 7;
                lenghtToWall = position % 8;
            }
            else
            {
                upDistance = 7;
                downDistance = 9;
                lenghtToWall = 7 - (position % 8);
            }
            for (int i = 1; i < lenghtToWall +1; i++)
            {
                result.Add(position - (upDistance *i));
                result.Add(position + (downDistance * i));
            }
            return result.Where(a => a >= 0 & a <= 63).ToList();
        }
        public List<int> getFirstMoveLine()
        {
            return leftMoveLine;
        }
        public List<int> getSecondMoveLine()
        {
            return rightMoveLine;
        }
    }
}
