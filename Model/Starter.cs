using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using Engine.PlayTable;
using Engine;

namespace Chess.Model
{
    internal static class Starter
    {
        #region oldIntit
        //public static Button[] createInitButtons(UniformGrid uniformGrid, RelayCommand command)
        //{
        //    bool isWhite = true;
        //    Button[] buttons = new Button[ChessTable.COUNT_CELLS];
        //    for (int i = 0; i < ChessTable.COUNT_CELLS; i++)
        //    {
        //        Button button = new Button()
        //        {
        //            BorderBrush = new SolidColorBrush(Colors.Black),
        //            BorderThickness = new Thickness(1),
        //            CommandParameter = i,
        //            Command = command
        //        };

        //        if (isWhite)
        //        {
        //            button.Background = Brushes.White;
        //            isWhite = false;
        //        }
        //        else
        //        {
        //            button.Background = Brushes.Brown;
        //            isWhite = true;
        //        }
        //        uniformGrid.Children.Add(button);
        //        buttons[i] = button;
        //        if (i % 8 == 7)
        //        {
        //            isWhite = !isWhite;
        //        }
        //    }
        //    return buttons;
        //}
        #endregion
        public static Button[] createInitButtons(UniformGrid uniformGrid, RelayCommand command, List<ColorCell> colorList)// переписать генерацию что бы ячейги генерировались из длл
        {
            if (colorList.Count == ChessTable.COUNT_CELLS)
            {
                Button[] buttons = new Button[ChessTable.COUNT_CELLS];
                for (int i = 0; i < colorList.Count; i++)
                {
                    Button button = new Button()
                    {
                        BorderBrush = new SolidColorBrush(Colors.Black),
                        BorderThickness = new Thickness(1),
                        CommandParameter = i,
                        Command = command
                    };
                    if (colorList[i] == ColorCell.white)
                    {
                        button.Background = Brushes.White;
                    }
                    else
                    {
                        button.Background = Brushes.Brown;
                    }
                    uniformGrid.Children.Add(button);
                    buttons[i] = button;
                }
                return buttons;
            }
            else
            {
                return null;
            }
        }
        public static void setPiece(Button[] buttons, ChessTable chessTable)
        {
            List<string> pieceTypes = chessTable.getTypePiecesInTableCells();

            for (int i = 0; i < pieceTypes.Count; i++)
            {
                string urlImage = @"Sprites\";
                if (i >= 31)
                {
                    urlImage = urlImage + @"Black\";
                }
                else
                {
                    urlImage = urlImage + @"White\";
                }
                Button buttonPawn = buttons[i];
                Image imagePawn = new Image();
                BitmapImage bitmapPawn = new BitmapImage(new Uri(urlImage + pieceTypes[i] + ".png", UriKind.Relative));
                imagePawn.Source = bitmapPawn;
                buttonPawn.Content = imagePawn;
            }
        }
        public static void setPiece2(Button[] buttons, ChessTable chessTable)
        {
            string startDirectorySprites = @"Sprites\";
            List<Piece> pieces = chessTable.getPieces();
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i] != null)
                {
                    String pathPiece;
                    if (pieces[i].getColorPiece() == ColorPiece.black)
                    {
                        pathPiece = startDirectorySprites + @"Black\";
                    }
                    else
                    {
                        pathPiece = startDirectorySprites + @"White\";
                    }
                    Button buttonPawn = buttons[i];
                    Image imagePawn = new Image();
                    BitmapImage bitmapPawn = new BitmapImage(new Uri(pathPiece + pieces[i].getTypePiece() + ".png", UriKind.Relative));
                    imagePawn.Source = bitmapPawn;
                    buttonPawn.Content = imagePawn;
                }
            }
            //List<string> pieceTypes = chessTable.getTypePiecesInTableCells();

            //for (int i = 0; i < pieceTypes.Count; i++)
            //{
            //    string urlImage = @"Sprites\";
            //    if (i >= 31)
            //    {
            //        urlImage = urlImage + @"Black\";
            //    }
            //    else
            //    {
            //        urlImage = urlImage + @"White\";
            //    }
            //    Button buttonPawn = buttons[i];
            //    Image imagePawn = new Image();
            //    BitmapImage bitmapPawn = new BitmapImage(new Uri(urlImage + pieceTypes[i] + ".png", UriKind.Relative));
            //    imagePawn.Source = bitmapPawn;
            //    buttonPawn.Content = imagePawn;
            //}
        }
    }
}
