using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Engine;
using Engine.PlayTable;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Chess.Model
{
    public class Regulator
    {
        private readonly ChessTable chessTable;
        private Button[] buttons;
        private UniformGrid uniformGrid;
        private List<ColorCell> colorCellsTable;
        bool isChoosePiece;
        public Regulator(UniformGrid uniformGrid, RelayCommand command)
        {
            chessTable = new ChessTable();
            colorCellsTable = chessTable.getColorTableCells();
            this.buttons = Starter.createInitButtons(uniformGrid,command,colorCellsTable);
            this.uniformGrid = uniformGrid;
            isChoosePiece = false;
            Starter.setPiece2(buttons, chessTable);
        }

        public void clickToCell(int positionClick)
        {
            if (isChoosePiece)
            {
                if (chessTable.getmovementSelectionLastChossePiece() != null & chessTable.movePiece(positionClick))
                {
                    unshowcСellsMoveOptions(chessTable.getmovementSelectionLastChossePiece());
                    Image imagePawn = buttons[chessTable.getIndexLastChossePiece()].Content as Image;
                    buttons[chessTable.getIndexLastChossePiece()].Content = null;
                    buttons[positionClick].Content = imagePawn;
                    isChoosePiece = false;
                }
                else
                {
                    unshowcСellsMoveOptions(chessTable.getmovementSelectionLastChossePiece());
                    isChoosePiece = false;
                }
            }
            else
            {
                chessTable.choosePiece(positionClick);
                showcСellsMoveOptions(chessTable.getmovementSelectionLastChossePiece());
                if (chessTable.getmovementSelectionLastChossePiece() != null)
                {
                    isChoosePiece = true;
                }
            }
        }
        private void unshowcСellsMoveOptions(List<int> movementSelection)
        {
            foreach (int indexCell in movementSelection)
            {
                if (colorCellsTable[indexCell] == ColorCell.white)
                {
                    buttons[indexCell].Background = Brushes.White;
                }
                else if (colorCellsTable[indexCell] == ColorCell.brown)
                {
                    buttons[indexCell].Background = Brushes.Brown;
                }
            }
        }
        private void showcСellsMoveOptions(List<int> movementSelection)
        {
            foreach (int indexCell in movementSelection)
            {
                if (colorCellsTable[indexCell] == ColorCell.white)
                {
                    buttons[indexCell].Background = Brushes.Gray;
                }
                else if(colorCellsTable[indexCell] == ColorCell.brown)
                {
                    buttons[indexCell].Background = Brushes.RosyBrown;
                }
            }
        }
        public Button[] getButtons()
        {
            return buttons;
        }
        private void replacePawn(int indexCell)
        {

        }
    }
}
