using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4InaRow
{
    class FourInARow
    {
        char[,] board = new Char[6, 6];
        private List<Player> players = new List<Player>();

        private bool gameOver = false;
        private bool boardFull = false;
        private int size = 6;
        private string winningPlayer;

        public void Addplayers()
        {
            players.Add(new Player("Player 1", 'X'));
            players.Add(new Player("Player 2", 'O'));
        }

        public void CreateFillAndDisplayBoard()
        {
            for (int y = 0; y <= 5; y++)
            {
                Console.Write("|");
                for (int x = 0; x <= 5; x++)
                {
                    if (board[y, x] != 'X' && board[y, x] != 'O') board[y, x] = '*';
                    Console.Write(board[y, x]);
                }
                Console.Write("| \n");
            }
        }

        public void BoardFull()
        {
            int temp1 = 0;
                for (int x = 0; x < size; x++)
                {
                    if (board[0, x] != '*') temp1++;
                }
                if (temp1 == 6) boardFull = true;
                else temp1 = 0;
        }

        /*public void HorizsiontalWin() //Rules are made to be broken
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size - 3; x++)
                {
                    if (board[y, x] == 'X' && board[y, x + 1] == 'X' && board[y, x + 2] == 'X' &&
                        board[y, x + 3] == 'X') gameOver = true;
                    else gameOver = false;
                }
            }
        }*/


        public void VerticalWin()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if (board[y, x].Equals('X') && board[y + 1, x].Equals('X') && board[y + 2, x].Equals('X') && board[y + 3, x].Equals('X'))
                    {
                        gameOver = true;
                        winningPlayer = "Player 1";
                        goto SuperBreak;
                    }
                    else if (board[y, x].Equals('O') && board[y + 1, x].Equals('O') && board[y + 2, x].Equals('O') && board[y + 3, x].Equals('O'))
                    {
                        gameOver = true;
                        winningPlayer = "Player 2";
                        goto SuperBreak;
                    }
                }
            }
            SuperBreak:; //Goto destination
        }
        
        public void DIRIGONALWin()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (board[y, x].Equals('X') && board[y + 1, x + 1].Equals('X') && board[y + 2, x + 2].Equals('X') && board[y + 3, x + 3].Equals('X'))
                    {
                        gameOver = true;
                        this.winningPlayer = "Player 1";
                        goto SuperBreak;
                    }
                    else if (board[y, x].Equals('O') && board[y + 1, x + 1].Equals('O') && board[y + 2, x + 2].Equals('O') && board[y + 3, x + 3].Equals('O'))
                    {
                        gameOver = true;
                        this.winningPlayer = "Player 2";
                        goto SuperBreak;
                    }
                }
            }
            
            
            for (int y = 5; y > 2; y--)
            {
                for (int x = 0; x <
                                3; x++)
                {
                    if (board[y, x].Equals('X') && board[y - 1, x + 1].Equals('X') && board[y - 2, x + 2].Equals('X') && board[y - 3, x + 3].Equals('X'))
                    {
                        gameOver = true;
                        this.winningPlayer = "Player 1";
                        goto SuperBreak;
                    }
                    else if (board[y, x].Equals('O') && board[y - 1, x + 1].Equals('O') && board[y - 2, x + 2].Equals('O') && board[y - 3, x + 3].Equals('O'))
                    {
                        gameOver = true;
                        this.winningPlayer = "Player 2";
                        goto SuperBreak;
                    }
                }
            }
        SuperBreak:;  //Goto destination
        }

        public void HorizsiontalWin()
        {
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (board[y, x].Equals('X') && board[y, x + 1].Equals('X') && board[y, x + 2].Equals('X') && board[y, x + 3].Equals('X'))
                    {
                        gameOver = true;
                        this.winningPlayer = "Player 1";
                        goto SuperBreak;
                    }
                    else if (board[y, x].Equals('O') && board[y, x + 1].Equals('O') && board[y, x + 2].Equals('O') && board[y, x + 3].Equals('O'))
                    {
                        gameOver = true;
                        this.winningPlayer = "Player 2";
                        goto SuperBreak;
                    }
                }
            }
            SuperBreak:; //Goto destination
        }

        public void Rules()
        {
            HorizsiontalWin();
            VerticalWin();
            DIRIGONALWin();
        }

        public bool Occipied(int X)
        {
            if (board[0, X] != '*')
            {
                Console.WriteLine("The row is filled please use another row.");
                return true;
            }
            else return false;
        }

        public void placePiece(int x, Player player)
        {
            for (int y = 5; y >= 0; y--)
            {
                if (board[y,x] == '*')
                {
                    board[y, x] = player._piece;
                    break;
                }
            }
        }

        public void Play()
        {
            string input;
            int temp;
            while (!gameOver && !boardFull)
            {
                foreach (Player player in players)
                {
                    Console.Clear();
                    CreateFillAndDisplayBoard();
                    Console.WriteLine("Pick a place to place you piece (between 1-6):\n" + player);
                    do
                    {
                        do
                        {
                            do
                            {
                                input = Console.ReadLine();
                                Console.WriteLine("Please try again!");
                            } while (!int.TryParse(input, out temp));
                        } while (!(temp < 7 && temp > 0));
                        temp--;
                    } while (Occipied(temp));
                    placePiece(temp, player);
                } 
                Rules();
                BoardFull();
                Console.Clear();
                CreateFillAndDisplayBoard();
            }

            if (boardFull)
            {
                Console.Write("\nThe board is full and it ends in a draw - no one WINS!");
            }
            else if (gameOver)
            {
                Console.Write("\nThe game has endend " + this.winningPlayer + " has won! \nNow Begun THOT!");
            }
            Console.ReadKey();
        }
    }
}