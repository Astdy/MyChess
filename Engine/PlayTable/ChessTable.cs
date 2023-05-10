using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Pieces;

namespace Engine.PlayTable
{
    public class ChessTable
    {
        public static readonly int COUNT_CELLS = 64;
        private Cell[] cells;
        private int indexLastChossePiece;
        private List<int> movementSelectionLastChossePiece;
        public ChessTable()
        {
            cells = new Cell[COUNT_CELLS];
            ColorCell colorCell = ColorCell.white;
            for (int i = 0; i < cells.Length; i++)
            {
                if (colorCell == ColorCell.white)
                {
                    cells[i] = new Cell(colorCell);
                    colorCell = ColorCell.brown;
                }
                else
                {
                    cells[i] = new Cell(colorCell);
                    colorCell = ColorCell.white;
                }
                if (i % 8 == 7)
                {
                    if (colorCell == ColorCell.white)
                        colorCell = ColorCell.brown;
                    else
                        colorCell = ColorCell.white;
                }
            }
            //setStartposition();
            setStartpositionPieces(ColorPiece.black);
        }

        public void setStartposition()
        {
            cells[11].setPiece(new Pawn(ColorPiece.white, 11));
            cells[12].setPiece(new King(ColorPiece.white));
            cells[10].setPiece(new Bishop(ColorPiece.white));
            cells[40].setPiece(new King(ColorPiece.black));
            cells[46].setPiece(new Pawn(ColorPiece.black,46));
            cells[1].setPiece(new Rook(ColorPiece.white));
            cells[45].setPiece(new Knight(ColorPiece.black));
            cells[50].setPiece(new Queen(ColorPiece.black));
        }
        public void setStartpositionPieces(ColorPiece colorPlay)
        {
            ColorPiece colorEnomy;
            if(colorPlay == ColorPiece.white)
                colorEnomy = ColorPiece.black;
            else
                colorEnomy = ColorPiece.white;
            for (int i = 0; i < cells.Length; i++)
            {
                if (i > 7 & i < 16)
                {
                    cells[i].setPiece(new Pawn(colorEnomy, i));
                }
                else if (i > 47 & i < 56)
                {
                    cells[i].setPiece(new Pawn(colorPlay, i));
                }
                else if (i == 0 || i == 7 | i == 56 || i == 63)
                {
                    if (i < 8)
                        cells[i].setPiece(new Rook(colorEnomy));
                    else
                        cells[i].setPiece(new Rook(colorPlay));
                }
                else if (i == 1 || i == 6 || i == 57 || i == 62)
                {
                    if (i < 8)
                        cells[i].setPiece(new Knight(colorEnomy));
                    else
                        cells[i].setPiece(new Knight(colorPlay));
                }
                else if (i == 2 || i == 5 || i == 58 || i == 61)
                {
                    if (i < 8)
                        cells[i].setPiece(new Bishop(colorEnomy));
                    else
                        cells[i].setPiece(new Bishop(colorPlay));
                }
                else if (i == 3 || i == 59 )
                {
                    if (ColorPiece.white == colorPlay)
                    {
                        if (i == 3)
                            cells[i].setPiece(new Queen(colorEnomy));
                        else
                            cells[i].setPiece(new Queen(colorPlay));
                    }
                    else
                    {
                        if (i==3)
                            cells[i].setPiece(new King(colorEnomy));
                        else
                            cells[i].setPiece(new King(colorPlay));
                    }
                }else if (i == 4 || i == 60)
                {
                    if (ColorPiece.white == colorPlay)
                    {
                        if (i == 4)
                            cells[i].setPiece(new King(colorEnomy));
                        else 
                            cells[i].setPiece(new King(colorPlay));
                    }
                    else
                    {
                        if (i == 4)
                            cells[i].setPiece(new Queen(colorEnomy));
                        else
                            cells[i].setPiece(new Queen(colorPlay));
                    }
                }
            }
           
        }
            public List<int> choosePiece(int positionPiece)
        {
            if (cells[positionPiece].getPiece() != null)
            {
                List<int> movementSelection = new List<int>();
                indexLastChossePiece = positionPiece;
                Piece piece = cells[positionPiece].getPiece();
                movementSelection = piece.movementSelection(positionPiece).Where(a => a >= 0 & a <= 63).ToList();
                movementSelectionLastChossePiece = filterMovementSelection(movementSelection);
                return movementSelectionLastChossePiece;
            }
            return null;
        }
        public bool movePiece(int indexToMove)
        {
            bool isMove = false;
            if (cells[indexLastChossePiece].getPiece() != null & movementSelectionLastChossePiece.Contains(indexToMove))
            {
                if (cells[indexToMove].getPiece()?.getColorPiece() != cells[indexLastChossePiece].getPiece()?.getColorPiece())
                {
                    Piece movePice = cells[indexLastChossePiece].getPiece();
                    cells[indexToMove].setPiece(movePice);
                    cells[indexLastChossePiece].removePiece();
                    return true;
                }
            }
            return isMove;
        }
        private List<int> filterMovementSelection(List<int> movementSelection)
        {
            List<int> correctMovements = new List<int>();
            switch (cells[indexLastChossePiece].getPiece().getTypePiece())
            {
                case "King":
                    //Нужна проверка сможет ли король съесть фигуру или пойти на какую либо клетку
                    for (int i = 0; i < movementSelection.Count; i++)
                    {
                        if (cells[movementSelection[i]].getPiece() != null)
                        {
                            if (cells[movementSelection[i]].getPiece().getColorPiece() != cells[indexLastChossePiece]?.getPiece().getColorPiece())
                            {
                                correctMovements.Add(movementSelection[i]);
                            }
                        }
                        else
                        {
                            correctMovements.Add(movementSelection[i]);
                        }
                    }
                    break;
                case "Pawn":
                    for (int i = 0; i < movementSelection.Count; i++)
                    {
                        if (cells[movementSelection[i]].getPiece() == null)
                        {
                            correctMovements.Add(movementSelection[i]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    Pawn pawn = cells[indexLastChossePiece].getPiece() as Pawn;
                    foreach (int indexCell in pawn.getattackCells())
                    {
                        if (cells[indexCell].getPiece() != null)
                        {
                            if (cells[indexCell].getPiece().getColorPiece() != pawn.getColorPiece())
                            {
                                correctMovements.Add(indexCell);
                            }
                        }
                    }
                    break;
                case "Knight":
                    Knight knight = cells[indexLastChossePiece].getPiece() as Knight;
                    foreach (var indexCell in movementSelection)
                    {
                        if (cells[indexCell].getPiece() != null)
                        {
                            if (cells[indexCell].getPiece().getColorPiece() != knight.getColorPiece())
                            {
                                correctMovements.Add(indexCell);
                            }
                        }else
                        {
                            correctMovements.Add(indexCell);
                        }
                    }
                    break;
                case "Rook":
                    Rook rook = cells[indexLastChossePiece].getPiece() as Rook;
                    correctMovements.AddRange(filterLine(rook.getHorisontalmovementSelection(),rook));
                    correctMovements.AddRange(filterLine(rook.getVerticalmovementSelection(), rook));
                    break;
                case "Bishop":
                    Bishop bishop = cells[indexLastChossePiece].getPiece() as Bishop;
                    correctMovements.AddRange(filterLine(bishop.getFirstMoveLine(), bishop));
                    correctMovements.AddRange(filterLine(bishop.getSecondMoveLine(), bishop));
                    break;
                case "Queen":
                    Queen queen = cells[indexLastChossePiece].getPiece() as Queen;
                    correctMovements.AddRange(filterLine(queen.getFirstMoveLine(), queen));
                    correctMovements.AddRange(filterLine(queen.getSecondMoveLine(), queen));
                    correctMovements.AddRange(filterLine(queen.getHorisontalmovementSelection(), queen));
                    correctMovements.AddRange(filterLine(queen.getVerticalmovementSelection(), queen));
                    break;
                default:
                    correctMovements = movementSelection;
                    break;
            }
            return correctMovements;
        }

        public int getIndexLastChossePiece()
        {
            return indexLastChossePiece;
        }

        public List<int> getmovementSelectionLastChossePiece()
        {
            return movementSelectionLastChossePiece;
        }
        public List<string> getTypePiecesInTableCells()
        {
            List<string> piecesInCells = new List<string>();
            foreach (var piece in cells)
            {
                piecesInCells.Add(piece.getPiece()?.getTypePiece());
            }
            return piecesInCells;
        }
        public List<Piece> getPieces()
        {
            List<Piece> pieces = new List<Piece>();
            foreach (var cell in cells)
            {
                pieces.Add(cell.getPiece());
            }
            return pieces;
        }
        //public string getTypePiece(int numberCell)
        //{
        //    return cells[numberCell].getPiece()?.getTypePiece();
        //}

        public List<ColorCell> getColorTableCells()
        {
            return cells.Select(a => a.getColorCell()).ToList();
        }
        private List<int> filterLine(List<int> line, Piece piece)
        {
            List<int> result = new List<int>();
            line.Add(indexLastChossePiece);
            line =line.OrderBy(a => a).ToList();
            bool isSecondPart = false;
            List<int> partLine = new List<int>();
            for (int i = 0; i < line.Count; i++)
            {
                if (!isSecondPart && line[i] == indexLastChossePiece)
                {
                    result.AddRange(partLine);
                    partLine.Clear();
                    isSecondPart = true;
                    continue;
                }

                if (cells[line[i]].getPiece() != null)
                {
                    if (cells[line[i]].getPiece().getColorPiece() == piece.getColorPiece())
                    {
                        if (isSecondPart)
                        {
                            result.AddRange(partLine);
                            break;
                        }
                        else
                        {
                            partLine.Clear();
                        }
                    }
                    else
                    {
                        if (isSecondPart)
                        {
                            partLine.Add(line[i]);
                            result.AddRange(partLine);
                            break;
                        }
                        else
                        {
                            partLine.Clear();
                            partLine.Add(line[i]);
                        }
                    }
                }
                else
                {
                    partLine.Add(line[i]);    
                }
            }
            if (partLine.Count != 0)
            {
                result.AddRange(partLine);
            }
            return result;
        }
       //event  на проверку короля и пешки
    }
}
