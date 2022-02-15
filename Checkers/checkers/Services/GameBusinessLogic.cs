using checkers.Models;
using checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace checkers.Services
{
    class GameBusinessLogic : BaseNotification
    {

        private int clickNumber = 1;
        private Cell lastCell;


        private string turn;
        public string Turn
        {
            get { return turn; }
            set
            {
                turn = value;
                NotifyPropertyChanged("turn");
            }
        }

        private ObservableCollection<ObservableCollection<Cell>> cells;
        public GameBusinessLogic(ObservableCollection<ObservableCollection<Cell>> cells)
        {

            this.cells = cells;
            this.turn = "first";
            TurnChange();
        }
        public bool isSimpleMove(Cell currentCell, Cell lastCell)
        {
            if (currentCell.Type != "emptyBlack")
                return false;

            if (lastCell.Type == "playerRed")
            {
                if (currentCell.X + 1 != lastCell.X)
                {
                    return false;
                }
                if (currentCell.Y - 1 != lastCell.Y && currentCell.Y + 1 != lastCell.Y)
                {
                    return false;
                }
            }

            if (lastCell.Type == "playerBlue")
            {
                if (currentCell.X - 1 != lastCell.X)
                {
                    return false;
                }
                if (currentCell.Y - 1 != lastCell.Y && currentCell.Y + 1 != lastCell.Y)
                {
                    return false;
                }
            }

            if (lastCell.Type == "kingRed" || lastCell.Type == "kingBlue")
            {
                if (currentCell.X + 1 != lastCell.X && currentCell.X - 1 != lastCell.X)
                {
                    return false;
                }
                if (currentCell.Y - 1 != lastCell.Y && currentCell.Y + 1 != lastCell.Y)
                {
                    return false;
                }
            }

            return true;
        }
        public bool isOverMove(Cell currentCell, Cell lastCell)
        {
            if (currentCell.Type != "emptyBlack")
                return false;

            if (lastCell.Type == "playerRed")
            {
                if (currentCell.X + 2 != lastCell.X)
                {
                    return false;
                }

                if (currentCell.Y - 2 == lastCell.Y && (cells[lastCell.X - 1][lastCell.Y + 1].Type == "playerBlue" || cells[lastCell.X - 1][lastCell.Y + 1].Type == "kingBlue"))
                {

                    cells[lastCell.X - 1][lastCell.Y + 1].Type = "emptyBlack";
                    cells[lastCell.X - 1][lastCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }

                if (currentCell.Y + 2 == lastCell.Y && (cells[lastCell.X - 1][lastCell.Y - 1].Type == "playerBlue" || cells[lastCell.X - 1][lastCell.Y - 1].Type == "kingBlue"))
                {
                    cells[lastCell.X - 1][lastCell.Y - 1].Type = "emptyBlack";
                    cells[lastCell.X - 1][lastCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }
            }
            if (lastCell.Type == "playerBlue")
            {
                if (currentCell.X - 2 != lastCell.X)
                {
                    return false;
                }
                if (currentCell.Y + 2 == lastCell.Y && (cells[lastCell.X + 1][lastCell.Y - 1].Type == "playerRed" || cells[lastCell.X + 1][lastCell.Y - 1].Type == "kingRed"))
                {
                    cells[lastCell.X + 1][lastCell.Y - 1].Type = "emptyBlack";
                    cells[lastCell.X + 1][lastCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }
                if (currentCell.Y - 2 == lastCell.Y && (cells[lastCell.X + 1][lastCell.Y + 1].Type == "playerRed" || cells[lastCell.X + 1][lastCell.Y + 1].Type == "kingRed"))
                {
                    cells[lastCell.X + 1][lastCell.Y + 1].Type = "emptyBlack";
                    cells[lastCell.X + 1][lastCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }
            }

            if (lastCell.Type == "kingRed")
            {
                if (currentCell.X + 2 == lastCell.X && currentCell.Y - 2 == lastCell.Y && (cells[lastCell.X - 1][lastCell.Y + 1].Type == "playerBlue" || cells[lastCell.X - 1][lastCell.Y + 1].Type == "kingBlue"))
                {

                    cells[lastCell.X - 1][lastCell.Y + 1].Type = "emptyBlack";
                    cells[lastCell.X - 1][lastCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }

                if (currentCell.X + 2 == lastCell.X && currentCell.Y + 2 == lastCell.Y && (cells[lastCell.X - 1][lastCell.Y - 1].Type == "playerBlue" || cells[lastCell.X - 1][lastCell.Y - 1].Type == "kingBlue"))
                {
                    cells[lastCell.X - 1][lastCell.Y - 1].Type = "emptyBlack";
                    cells[lastCell.X - 1][lastCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }

                if (currentCell.X - 2 == lastCell.X && currentCell.Y + 2 == lastCell.Y && (cells[lastCell.X + 1][lastCell.Y - 1].Type == "playerBlue" || cells[lastCell.X + 1][lastCell.Y - 1].Type == "kingBlue"))
                {
                    cells[lastCell.X + 1][lastCell.Y - 1].Type = "emptyBlack";
                    cells[lastCell.X + 1][lastCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }

                if (currentCell.X - 2 == lastCell.X && currentCell.Y - 2 == lastCell.Y && (cells[lastCell.X + 1][lastCell.Y + 1].Type == "playerBlue" || cells[lastCell.X + 1][lastCell.Y + 1].Type == "kingBlue"))
                {
                    cells[lastCell.X + 1][lastCell.Y + 1].Type = "emptyBlack";
                    cells[lastCell.X + 1][lastCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }
            }

            if (lastCell.Type == "kingBlue")
            {
                if (currentCell.X + 2 == lastCell.X && currentCell.Y - 2 == lastCell.Y && (cells[lastCell.X - 1][lastCell.Y + 1].Type == "playerRed" || cells[lastCell.X - 1][lastCell.Y + 1].Type == "kingRed"))
                {

                    cells[lastCell.X - 1][lastCell.Y + 1].Type = "emptyBlack";
                    cells[lastCell.X - 1][lastCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }

                if (currentCell.X + 2 == lastCell.X && currentCell.Y + 2 == lastCell.Y && (cells[lastCell.X - 1][lastCell.Y - 1].Type == "playerRed" || cells[lastCell.X - 1][lastCell.Y - 1].Type == "kingRed"))
                {
                    cells[lastCell.X - 1][lastCell.Y - 1].Type = "emptyBlack";
                    cells[lastCell.X - 1][lastCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }

                if (currentCell.X - 2 == lastCell.X && currentCell.Y + 2 == lastCell.Y && (cells[lastCell.X + 1][lastCell.Y - 1].Type == "playerRed" || cells[lastCell.X + 1][lastCell.Y - 1].Type == "kingRed"))
                {
                    cells[lastCell.X + 1][lastCell.Y - 1].Type = "emptyBlack";
                    cells[lastCell.X + 1][lastCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }

                if (currentCell.X - 2 == lastCell.X && currentCell.Y - 2 == lastCell.Y && (cells[lastCell.X + 1][lastCell.Y + 1].Type == "playerRed" || cells[lastCell.X + 1][lastCell.Y + 1].Type == "kingRed"))
                {
                    cells[lastCell.X + 1][lastCell.Y + 1].Type = "emptyBlack";
                    cells[lastCell.X + 1][lastCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";

                    return true;
                }
            }

            return false;
        }

        public bool isMultipleMove(ref Cell currentCell)
        {
            if (currentCell.Type == "playerRed")
            {
                if (currentCell.X == 1 || currentCell.X == 0 || currentCell.Y == 0 || currentCell.Y == 7 || currentCell.Y == 1 || currentCell.Y == 6)
                    return false;
                if ((cells[currentCell.X - 1][currentCell.Y - 1].Type == "playerBlue" || cells[currentCell.X - 1][currentCell.Y - 1].Type == "kingBlue") && cells[currentCell.X - 2][currentCell.Y - 2].Type == "emptyBlack")
                {
                    cells[currentCell.X - 1][currentCell.Y - 1].Type = "emptyBlack";
                    cells[currentCell.X - 1][currentCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X - 2][currentCell.Y - 2].Type = "playerRed";
                    cells[currentCell.X - 2][currentCell.Y - 2].Image = "/checkers;component/Resources/redPiece.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X - 2][currentCell.Y - 2];
                    return true;
                }
                if ((cells[currentCell.X - 1][currentCell.Y + 1].Type == "playerBlue" || cells[currentCell.X - 1][currentCell.Y + 1].Type == "kingBlue") && cells[currentCell.X - 2][currentCell.Y + 2].Type == "emptyBlack")
                {
                    cells[currentCell.X - 1][currentCell.Y + 1].Type = "emptyBlack";
                    cells[currentCell.X - 1][currentCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X - 2][currentCell.Y + 2].Type = "playerRed";
                    cells[currentCell.X - 2][currentCell.Y + 2].Image = "/checkers;component/Resources/redPiece.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X - 2][currentCell.Y + 2];
                    return true;
                }
            }

            if (currentCell.Type == "playerBlue")
            {
                if (currentCell.X == 6 || currentCell.X == 7 || currentCell.Y == 0 || currentCell.Y == 7 || currentCell.Y == 1 || currentCell.Y == 6)
                    return false;
                if ((cells[currentCell.X + 1][currentCell.Y - 1].Type == "playerRed" || cells[currentCell.X + 1][currentCell.Y - 1].Type == "kingRed") && cells[currentCell.X + 2][currentCell.Y - 2].Type == "emptyBlack")
                {
                    cells[currentCell.X + 1][currentCell.Y - 1].Type = "emptyBlack";
                    cells[currentCell.X + 1][currentCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X + 2][currentCell.Y - 2].Type = "playerBlue";
                    cells[currentCell.X + 2][currentCell.Y - 2].Image = "/checkers;component/Resources/bluePiece.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X + 2][currentCell.Y - 2];
                    return true;
                }
                if ((cells[currentCell.X + 1][currentCell.Y + 1].Type == "playerRed" || cells[currentCell.X + 1][currentCell.Y + 1].Type == "kingRed") && cells[currentCell.X + 2][currentCell.Y + 2].Type == "emptyBlack")
                {
                    cells[currentCell.X + 1][currentCell.Y + 1].Type = "emptyBlack";
                    cells[currentCell.X + 1][currentCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X + 2][currentCell.Y + 2].Type = "playerBlue";
                    cells[currentCell.X + 2][currentCell.Y + 2].Image = "/checkers;component/Resources/bluePiece.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X + 2][currentCell.Y + 2];
                    return true;
                }

            }
            return false;
        }

        public bool isMultipleKingMove(ref Cell currentCell)
        {
            if (currentCell.Type == "kingRed")
            {
                if (currentCell.X == 7 || currentCell.X == 6 || currentCell.X == 1 || currentCell.X == 0 || currentCell.Y == 1 || currentCell.Y == 6 || currentCell.Y == 0 || currentCell.Y == 7)
                    return false;
                if ((cells[currentCell.X - 1][currentCell.Y - 1].Type == "playerBlue" || cells[currentCell.X - 1][currentCell.Y - 1].Type == "kingBlue") && cells[currentCell.X - 2][currentCell.Y - 2].Type == "emptyBlack")
                {
                    cells[currentCell.X - 1][currentCell.Y - 1].Type = "emptyBlack";
                    cells[currentCell.X - 1][currentCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X - 2][currentCell.Y - 2].Type = "kingRed";
                    cells[currentCell.X - 2][currentCell.Y - 2].Image = "/checkers;component/Resources/redKing.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X - 2][currentCell.Y - 2];
                    return true;
                }
                if ((cells[currentCell.X - 1][currentCell.Y + 1].Type == "playerBlue" || cells[currentCell.X - 1][currentCell.Y + 1].Type == "kingBlue") && cells[currentCell.X - 2][currentCell.Y + 2].Type == "emptyBlack")
                {
                    cells[currentCell.X - 1][currentCell.Y + 1].Type = "emptyBlack";
                    cells[currentCell.X - 1][currentCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X - 2][currentCell.Y + 2].Type = "kingRed";
                    cells[currentCell.X - 2][currentCell.Y + 2].Image = "/checkers;component/Resources/redKing.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X - 2][currentCell.Y + 2];
                    return true;
                }
                if ((cells[currentCell.X + 1][currentCell.Y - 1].Type == "playerBlue" || cells[currentCell.X + 1][currentCell.Y - 1].Type == "kingBlue") && cells[currentCell.X + 2][currentCell.Y - 2].Type == "emptyBlack")
                {
                    cells[currentCell.X + 1][currentCell.Y - 1].Type = "emptyBlack";
                    cells[currentCell.X + 1][currentCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X + 2][currentCell.Y - 2].Type = "kingRed";
                    cells[currentCell.X + 2][currentCell.Y - 2].Image = "/checkers;component/Resources/redKing.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X + 2][currentCell.Y - 2];
                    return true;
                }
                if ((cells[currentCell.X + 1][currentCell.Y + 1].Type == "playerBlue" || cells[currentCell.X + 1][currentCell.Y + 1].Type == "kingBlue") && cells[currentCell.X + 2][currentCell.Y + 2].Type == "emptyBlack")
                {
                    cells[currentCell.X + 1][currentCell.Y + 1].Type = "emptyBlack";
                    cells[currentCell.X + 1][currentCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X + 2][currentCell.Y + 2].Type = "kingRed";
                    cells[currentCell.X + 2][currentCell.Y + 2].Image = "/checkers;component/Resources/redKing.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X + 2][currentCell.Y + 2];
                    return true;
                }
            }
            if (currentCell.Type == "kingBlue")
            {
                if (currentCell.X == 7 || currentCell.X == 6 || currentCell.X == 1 || currentCell.X == 0 || currentCell.Y == 1 || currentCell.Y == 6 || currentCell.Y == 0 || currentCell.Y == 7)
                    return false;
                if ((cells[currentCell.X - 1][currentCell.Y - 1].Type == "playerRed" || cells[currentCell.X - 1][currentCell.Y - 1].Type == "kingRed") && cells[currentCell.X - 2][currentCell.Y - 2].Type == "emptyBlack")
                {
                    cells[currentCell.X - 1][currentCell.Y - 1].Type = "emptyBlack";
                    cells[currentCell.X - 1][currentCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X - 2][currentCell.Y - 2].Type = "kingBlue";
                    cells[currentCell.X - 2][currentCell.Y - 2].Image = "/checkers;component/Resources/blueKing.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X - 2][currentCell.Y - 2];
                    return true;
                }
                if ((cells[currentCell.X - 1][currentCell.Y + 1].Type == "playerRed" || cells[currentCell.X - 1][currentCell.Y + 1].Type == "kingRed") && cells[currentCell.X - 2][currentCell.Y + 2].Type == "emptyBlack")
                {
                    cells[currentCell.X - 1][currentCell.Y + 1].Type = "emptyBlack";
                    cells[currentCell.X - 1][currentCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X - 2][currentCell.Y + 2].Type = "kingBlue";
                    cells[currentCell.X - 2][currentCell.Y + 2].Image = "/checkers;component/Resources/blueKing.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X - 2][currentCell.Y + 2];
                    return true;
                }
                if ((cells[currentCell.X + 1][currentCell.Y - 1].Type == "playerRed" || cells[currentCell.X + 1][currentCell.Y - 1].Type == "kingRed") && cells[currentCell.X + 2][currentCell.Y - 2].Type == "emptyBlack")
                {
                    cells[currentCell.X + 1][currentCell.Y - 1].Type = "emptyBlack";
                    cells[currentCell.X + 1][currentCell.Y - 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X + 2][currentCell.Y - 2].Type = "kingBlue";
                    cells[currentCell.X + 2][currentCell.Y - 2].Image = "/checkers;component/Resources/blueKing.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X + 2][currentCell.Y - 2];
                    return true;
                }
                if ((cells[currentCell.X + 1][currentCell.Y + 1].Type == "playerRed" || cells[currentCell.X + 1][currentCell.Y + 1].Type == "kingRed") && cells[currentCell.X + 2][currentCell.Y + 2].Type == "emptyBlack")
                {
                    cells[currentCell.X + 1][currentCell.Y + 1].Type = "emptyBlack";
                    cells[currentCell.X + 1][currentCell.Y + 1].Image = "/checkers;component/Resources/blackCell.png";
                    cells[currentCell.X + 2][currentCell.Y + 2].Type = "kingBlue";
                    cells[currentCell.X + 2][currentCell.Y + 2].Image = "/checkers;component/Resources/blueKing.png";
                    cells[currentCell.X][currentCell.Y].Type = "emptyBlack";
                    cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blackCell.png";
                    currentCell = cells[currentCell.X + 2][currentCell.Y + 2];
                    return true;
                }
            }
            return false;
        }
        public void simpleMove(Cell currentCell, Cell lastCell)
        {
            Cell aux = new Cell();
            aux.Image = currentCell.Image;
            aux.Type = currentCell.Type;
            cells[currentCell.X][currentCell.Y].Image = lastCell.Image;
            cells[currentCell.X][currentCell.Y].Type = lastCell.Type;
            cells[lastCell.X][lastCell.Y].Image = aux.Image;
            cells[lastCell.X][lastCell.Y].Type = aux.Type;

        }

        public void turnIntoKing(Cell currentCell)
        {
            if (currentCell.Type == "playerRed" && currentCell.X == 0)
            {
                cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/redKing.png";
                cells[currentCell.X][currentCell.Y].Type = "kingRed";
            }
            if (currentCell.Type == "playerBlue" && currentCell.X == 7)
            {
                cells[currentCell.X][currentCell.Y].Image = "/checkers;component/Resources/blueKing.png";
                cells[currentCell.X][currentCell.Y].Type = "kingBlue";
            }

        }

        public void gameOver()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\checkers\checkers\Resources\TextFile2.txt");
            int redWin = int.Parse(lines[0]);
            int blueWin = int.Parse(lines[1]);
            int nrr = 0, nrb = 0;
            foreach (ObservableCollection<Cell> line in cells)
            {
                foreach (Cell item in line)
                {
                    if (item.Type == "playerRed" || item.Type == "kingRed")
                        nrr++;
                    if (item.Type == "playerBlue" || item.Type == "kingBlue")
                        nrb++;
                }
            }
            if (nrr == 0)
            {
                blueWin++;
                lines[1] = blueWin.ToString();
                MessageBox.Show("Blue win");
            }
            if (nrb == 0)
            {
                redWin++;
                lines[0] = redWin.ToString();
                MessageBox.Show("Red win");
            }
            File.WriteAllLines(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\checkers\checkers\Resources\TextFile2.txt", lines);
        }

        public void TurnChange()
        {
            if (turn == "first")
            {
                foreach (ObservableCollection<Cell> line in cells)
                {
                    foreach (Cell item in line)
                    {
                        if (item.Type == "playerRed")
                            cells[item.X][item.Y].Image = "/checkers;component/Resources/redPieceTurn.png";
                        if(item.Type == "kingRed")
                            cells[item.X][item.Y].Image = "/checkers;component/Resources/redKingTurn.png";
                        if (item.Type == "playerBlue")
                            cells[item.X][item.Y].Image = "/checkers;component/Resources/bluePiece.png";
                        if (item.Type == "kingBlue")
                            cells[item.X][item.Y].Image = "/checkers;component/Resources/blueKing.png";
                    }
                }
            }
            if (turn == "second")
            {
                foreach (ObservableCollection<Cell> line in cells)
                {
                    foreach (Cell item in line)
                    {
                        if (item.Type == "playerRed")
                            cells[item.X][item.Y].Image = "/checkers;component/Resources/redPiece.png";
                        if (item.Type == "kingRed")
                            cells[item.X][item.Y].Image = "/checkers;component/Resources/redKing.png";
                        if (item.Type == "playerBlue")
                            cells[item.X][item.Y].Image = "/checkers;component/Resources/bluePieceTurn.png";
                        if (item.Type == "kingBlue")
                            cells[item.X][item.Y].Image = "/checkers;component/Resources/blueKingTurn.png";
                    }
                }
            }
        }
        public void ClickAction(Cell obj)
        {

            if (clickNumber == 1)
            {
                if ((obj.Type == "playerRed" || obj.Type == "kingRed") && turn == "first")
                {
                    lastCell = obj;

                    clickNumber++;
                    turn = "second";
                }
                if ((obj.Type == "playerBlue" || obj.Type == "kingBlue") && turn == "second")
                {
                    lastCell = obj;

                    clickNumber++;
                    turn = "first";
                }

            }
            else
            {
                if (isSimpleMove(obj, lastCell) == true)
                {
                    simpleMove(obj, lastCell);
                    clickNumber = 1;
                }
                else
                {
                    if (isOverMove(obj, lastCell) == true)
                    {
                        simpleMove(obj, lastCell);
                        clickNumber = 1;
                        bool ok = true;
                        while (ok == true)
                        {
                            if (obj.Type == "playerRed" || obj.Type == "playerBlue")
                            {
                                ok = isMultipleMove(ref obj);
                            }
                            else
                            {
                                ok = isMultipleKingMove(ref obj);
                            }

                            turnIntoKing(obj);
                        }

                    }
                    else
                    {
                        clickNumber = 1;
                        if (turn == "second")
                        {
                            turn = "first";
                        }
                        else
                        {
                            turn = "second";
                        }

                    }
                }
        
                turnIntoKing(obj);
                TurnChange();
                gameOver();

            }

        }
    }
}
