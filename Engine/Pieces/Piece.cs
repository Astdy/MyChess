using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.PlayTable;

namespace Engine
{
    public abstract class Piece
    {   
        protected ColorPiece color;
        protected List<int> buffer;

        public Piece(ColorPiece color)
        {
            this.color = color;
            buffer = new List<int>();
        }
        public abstract List<int> movementSelection(int position);

        public ColorPiece getColorPiece()
        {
            return color;
        }

        public string getTypePiece()
        {
            return this.ToString().Split('.').Last();
        }
        
    }
}
