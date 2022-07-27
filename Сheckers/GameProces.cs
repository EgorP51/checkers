using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сheckers
{
    class GameProces
    {
        public static int whiteCount { get; set; } = 0;
        public static int blackCount { get; set; } = 0;

        public static int x { get; set; }
        public static int y { get; set; }


        public void BotMove(int player)// потенциально очень классноая штука, но пока нет)))
        {
            Random random = new Random();

            List<CheckerFieldState> listOfFistPriority = new List<CheckerFieldState>();
            List<CheckerFieldState> listOfSecondPriority = new List<CheckerFieldState>();
            List<CheckerFieldState> listOfThirdPriority = new List<CheckerFieldState>();


            foreach(var item in Desk.checkers)
            {
                int col;
                if (item.color == player)
                {
                    col = Priority(item);

                    if (col == 1)
                        listOfFistPriority.Add(item);
                    if (col == 2)
                        listOfSecondPriority.Add(item);
                    if (col == 3)
                        listOfThirdPriority.Add(item);
                }
            }

            if(listOfFistPriority.Count > 0)
            {
                bool haveTake = false;
                int[] coor = listOfFistPriority[random.Next(0, listOfFistPriority.Count)].coordinates;

                int[][] firstDiagonal = Move.FindDiagonals(coor[0], coor[1])[0];
                int[][] secondDiagonal = Move.FindDiagonals(coor[0], coor[1])[1];

                GameProces.x = coor[0];
                GameProces.y = coor[1]; 


                if (Move.CanTake(firstDiagonal,player))
                {
                    int numberInDiagonal = 0;

                    for (int j = 0; j < firstDiagonal.Length; j++)
                        if(firstDiagonal[j][0] == coor[0] && firstDiagonal[j][1] == coor[1])
                            numberInDiagonal = j;
                    
                    Move.FigureTaking(firstDiagonal, numberInDiagonal, player);
                    haveTake = true;

                }
                else
                if (Move.CanTake(secondDiagonal,player))
                {
                    int numberInDiagonal = 0;

                    for (int j = 0; j < secondDiagonal.Length; j++)
                        if (secondDiagonal[j][0] == coor[0] && secondDiagonal[j][1] == coor[1])
                            numberInDiagonal = j;

                    Move.FigureTaking(secondDiagonal,numberInDiagonal, player);
                    haveTake = true;
                }
                if (haveTake)
                {
                    if(player == 1)
                    {
                        GameProces.blackCount++;
                    }
                    else if(player == 2)
                    {
                        GameProces.whiteCount++;
                    }
                }//ЗДЕСЬ СДЕЛАТЬ ПРОВЕРКУ НА ДАМКУ !!!!

                if (Move.CanTake(Move.FindDiagonals(GameProces.x,GameProces.y)[0],player) || 
                   Move.CanTake(Move.FindDiagonals(GameProces.x, GameProces.y)[1], player))
                {
                    BotMove(player);
                }
            }
            else if(listOfFistPriority.Count == 0 && listOfSecondPriority.Count > 0) 
            {
                MoveWithoutTaking(listOfSecondPriority);
            }
            else
            {
                Console.WriteLine("Игра окончена");
                Environment.Exit(0);
            }


        }

        public void MoveWithoutTaking(List<CheckerFieldState> ArrayOfSecondPriority)
        {
            Random ran = new Random();
            CheckerFieldState checker;
            bool b = false;
            int number1;
            int number2;
            int[][] firstDiagonal;
            int[][] secondDiagonal;

            while (true)
            {
                checker = ArrayOfSecondPriority[ran.Next(0,ArrayOfSecondPriority.Count)];

                firstDiagonal = Move.FindDiagonals(checker.coordinates[0],checker.coordinates[1])[0];
                secondDiagonal = Move.FindDiagonals(checker.coordinates[0], checker.coordinates[1])[1];

                number1 = CheckerFieldState.CheckerNumbInDiagonal(firstDiagonal, checker);
                number2 = CheckerFieldState.CheckerNumbInDiagonal(secondDiagonal, checker);

                if(checker.color == 1)
                {
                    if(number1 > 0)
                    {
                        if (Desk.checkers[CheckerFieldState.DiagonalAndChe(firstDiagonal, number1 - 1)].color == 0)
                        {
                            Desk.checkers[CheckerFieldState.DiagonalAndChe(firstDiagonal, number1)].color = 0;
                            Desk.checkers[CheckerFieldState.DiagonalAndChe(firstDiagonal, number1 - 1)].color = 1;

                            b = true;
                        }
                    }
                    if(number2 > 0 && !b)
                    {
                        if (Desk.checkers[CheckerFieldState.DiagonalAndChe(secondDiagonal,number2 - 1)].color == 0)
                        {
                            Desk.checkers[CheckerFieldState.DiagonalAndChe(secondDiagonal, number2)].color = 0;
                            Desk.checkers[CheckerFieldState.DiagonalAndChe(secondDiagonal, number2 - 1)].color = 1;

                            b = true;
                        }
                    }
                }
                else 
                if(checker.color == 2)
                {
                    if(number1 < firstDiagonal.Length)
                    {
                        if (Desk.checkers[CheckerFieldState.DiagonalAndChe(firstDiagonal,number1 + 1)].color == 0)
                        {
                            Desk.checkers[CheckerFieldState.DiagonalAndChe(firstDiagonal, number1)].color = 0;
                            Desk.checkers[CheckerFieldState.DiagonalAndChe(firstDiagonal, number1 + 1)].color = 2;

                            b = true;
                        }
                    }
                    if (number2 < secondDiagonal.Length && !b)
                    {
                        if (Desk.checkers[CheckerFieldState.DiagonalAndChe(secondDiagonal,number2 + 2)].color == 0)
                        {
                            Desk.checkers[CheckerFieldState.DiagonalAndChe(secondDiagonal, number2)].color = 0;
                            Desk.checkers[CheckerFieldState.DiagonalAndChe(secondDiagonal, number2 + 2)].color = 2;

                            b = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Игра окончена");
                    Environment.Exit(0);
                }

                if (b)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public int Priority(CheckerFieldState checker)
        {

            GameProces.x = checker.coordinates[0];
            GameProces.y = checker.coordinates[1];
            int tempColor = checker.color;

            if (Move.CanTake(Move.FindDiagonals()[0],tempColor) || 
                Move.CanTake( Move.FindDiagonals()[1],tempColor))
            {
                return 1;
            }
            else if (Desk.checkers[CheckerFieldState.CoordinatesMatching(checker.coordinates[0] - 1,checker.coordinates[1] - 1)].color== 0 || //TODO: Здесь нужно пересмотреть условия для 2
                                                                                                                                              //приоритета !
                     Desk.checkers[CheckerFieldState.CoordinatesMatching(checker.coordinates[0] + 1, checker.coordinates[1] + 1)].color == 0 ||
                     Desk.checkers[CheckerFieldState.CoordinatesMatching(checker.coordinates[0] - 1, checker.coordinates[1] + 1)].color == 0 ||
                     Desk.checkers[CheckerFieldState.CoordinatesMatching(checker.coordinates[0] + 1, checker.coordinates[1] - 1)].color == 0)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public void MyMove()
        {
            bool moveBeforeTakind = true;
            Console.Write("Enter start X Y: ");
            string coor1 = Console.ReadLine();
            string[] coorArr1 = coor1.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            GameProces.x = int.Parse(coorArr1[0]);
            GameProces.y = Convert.ToChar(coorArr1[1]) - 96;

            if (Desk.checkers[CheckerFieldState.CoordinatesMatching(GameProces.x,GameProces.y)].color == 2)
            {
                Console.Write("Enter final X Y : ");
                string coor2 = Console.ReadLine();
                string[] coorArr2 = coor2.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int x = int.Parse(coorArr2[0]);
                int y = Convert.ToChar(coorArr2[1]) - 96;

                if (Move.CanTake(Move.FindDiagonals()[0], 2) || Move.CanTake(Move.FindDiagonals()[1], 2))
                {
                    if (Desk.checkers[CheckerFieldState.CoordinatesMatching(x, y)].color == 0)
                    {
                        Desk.checkers[CheckerFieldState.CoordinatesMatching(GameProces.x, GameProces.y)].color = 0;
                        Desk.checkers[CheckerFieldState.CoordinatesMatching((x + GameProces.x) / 2, (y + GameProces.y) / 2)].color = 0;
                        Desk.checkers[CheckerFieldState.CoordinatesMatching(x, y)].color = 2;

                        GameProces.x = x;
                        GameProces.y = y;

                        moveBeforeTakind = false;
                    }
                    else
                    {
                        Console.WriteLine("Мимо мимо !");
                    }
                }
                else
                {
                    Desk.checkers[CheckerFieldState.CoordinatesMatching(GameProces.x, GameProces.y)].color = 0;
                    Desk.checkers[CheckerFieldState.CoordinatesMatching(x, y)].color = 2;
                    
                    GameProces.x = x;
                    GameProces.y = y;
                }
            }
            if (CheckerFieldState.CoordinatesMatching(GameProces.x, GameProces.y) == 0)
            {
                Console.WriteLine("Empty field !");
            }
            if (CheckerFieldState.CoordinatesMatching(GameProces.x, GameProces.y) == 1)
            {
                Console.WriteLine("Black color of checker !");
            }

            if ((Move.CanTake(Move.FindDiagonals()[0],2) || 
                Move.CanTake(Move.FindDiagonals()[1],2)) &&
                !moveBeforeTakind)
            {

                Desk.ShowDesk();
                MyMove();
            }
        }

        
    }
}