using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сheckers
{
    class Desk
    {

        public static CheckerFieldState[] checkers = new CheckerFieldState[32];
        public static List<int[][]> diagonals;
        private int[][] allCoordinates;
        private static char[,] field;

        public Desk()
        {
            field = new char[10, 10];

            field = FieldInitialization();
            allCoordinates = FigureInitialization();
            diagonals = DiagonalsInitialization();

        }

        public static char[,] Field
        {
            get { return field; }
            set { field = value; }
        }

        private List<int[][]> DiagonalsInitialization()
        {
            diagonals = new List<int[][]>();                                 // right diagonals

            diagonals.Add(new int[8][]                                       // "main" - 0                     
            {
                new int[]{8,1},new int[]{7,2},new int[]{6,3},new int[]{5,4},
                new int[]{4,5},new int[]{3,6},new int[]{2,7},new int[]{1,8}
            });
            diagonals.Add(new int[6][]                                       //"sixfield1" - 1
            {
                new int[]{8,3}, new int[]{7,4}, new int[]{6,5},
                new int[]{5,6}, new int[]{4,7}, new int[]{3,8}
            });
            diagonals.Add(new int[6][]                                       //"sixfield2" - 2
            {
                new int[]{6,1},new int[]{5,2},new int[]{4,3},
                new int[]{3,4},new int[]{2,5},new int[]{1,6}
            });
            diagonals.Add(new int[4][]                                        //"fourfield1" - 3
            {
                new int[]{8,5}, new int[]{7,6},
                new int[]{6,7}, new int[]{5,8}
            });
            diagonals.Add(new int[4][]                                       //"fourfield2" - 4
            {
                new int[]{4,1}, new int[]{3,2},
                new int[]{2,3}, new int[]{1,4}
            });
                                                                             // left diagonals

            diagonals.Add(new int[7][]                                       //"sevenfield1" - 5
            {
                new int[]{7,8},new int[]{6,7},new int[]{5,6},new int[]{4,5},
                new int[]{3,4},new int[]{2,3},new int[]{1,2}
            });
            diagonals.Add(new int[7][]                                       //"sevenfield2" - 6 
            {
                new int[]{8,7},new int[]{7,6},new int[]{6,5},new int[]{5,4},
                new int[]{4,3},new int[]{3,2},new int[]{2,1}
            });
            diagonals.Add(new int[5][]                                        //"fivefield1" - 7
            {
                new int[]{5,8},new int[]{4,7},new int[]{3,6},
                new int[]{2,5},new int[]{1,4}
            });
            diagonals.Add(new int[5][]                                        //"fivefield2" - 8
            {
                new int[]{8,5},new int[]{7,4},new int[]{6,3},
                new int[]{5,2},new int[]{4,1}
            });
            diagonals.Add(new int[3][]                                       //"threefield1" - 9
            {
                new int[]{3,8},new int[]{2,7},new int[]{1,6}
            });
            diagonals.Add(new int[3][]                                      //"threefield2" - 10
            {
                new int[]{8,3},new int[]{7,2},new int[]{6,1}
            });

            return diagonals;
        } // array of diagonals coordinates
        private char[,] FieldInitialization()
        {
            for (int i = 0; i < field.GetLength(0); i++) // cteate desk
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = ' ';

                    if (j == 0 && i<9)
                        field[i, j] = Convert.ToChar((i).ToString());

                    if (i == 0 && j > 0 && j<9)
                        field[i, j] = (char)(96 + j);

                }
            }
            field[0, 0] = '#';


            return field;
        } // drawing desk without figures
        private int[][] FigureInitialization()
        {

            allCoordinates = new int[32][]
            {
                new int[]{1,2},new int[]{1,4},new int[]{1,6},new int[]{1,8}, //black
                new int[]{2,1},new int[]{2,3},new int[]{2,5},new int[]{2,7},
                new int[]{3,2},new int[]{3,4},new int[]{3,6},new int[]{3,8},

                new int[]{4,1},new int[]{4,3},new int[]{4,5},new int[]{4,7}, //empty
                new int[]{5,2},new int[]{5,4},new int[]{5,6},new int[]{5,8},

                new int[]{6,1},new int[]{6,3},new int[]{6,5},new int[]{6,7}, //white
                new int[]{7,2},new int[]{7,4},new int[]{7,6},new int[]{7,8},
                new int[]{8,1},new int[]{8,3},new int[]{8,5},new int[]{8,7}

            };

            for (int i = 0; i < 12; i++) // black initialization
            {
                checkers[i] = new CheckerFieldState();

                checkers[i].color = 1;
                checkers[i].isQueen = false;
                checkers[i].coordinates = allCoordinates[i];
            }

            for (int i = 12; i < 20; i++) // empty initialization
            {
                checkers[i] = new CheckerFieldState();

                checkers[i].color = 0;
                checkers[i].isQueen = false;
                checkers[i].coordinates = allCoordinates[i];
            }

            for (int i = 20; i < 32; i++) //white initialization
            {
                checkers[i] = new CheckerFieldState();

                checkers[i].color = 2;
                checkers[i].isQueen = false;
                checkers[i].coordinates = allCoordinates[i];
            }


            //var a = checkers[9].coordinates;

            //checkers[9].coordinates = checkers[18].coordinates;
            //checkers[18].coordinates = a;

            //var b = checkers[12].coordinates;

            //checkers[12].coordinates = checkers[7].coordinates;
            //checkers[7].coordinates = b;

            //var c = checkers[25].coordinates;

            //checkers[25].coordinates = checkers[16].coordinates;
            //checkers[16].coordinates = c;
            
            //var e = checkers[5].coordinates;

            //checkers[5].coordinates = checkers[9].coordinates;
            //checkers[9].coordinates = e;




            return allCoordinates;
        } // array of possible coordinates and figure initialization 


        public static void ShowDesk()
        {
            foreach(var i in Desk.checkers)
            {
                if(i.color == 0)
                {
                    field[i.coordinates[0], i.coordinates[1]] = '0';
                }
                else
                if (i.color == 1)
                {
                    field[i.coordinates[0], i.coordinates[1]] = 'B';
                }
                else
                if (i.color == 2)
                {
                    field[i.coordinates[0], i.coordinates[1]] = 'W';
                }
            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i ==0 || j == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if(field[i, j] == ' ')
                    {
                        Console.BackgroundColor= ConsoleColor.White;
                    }
                    if (field[i, j] == '0')
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (i == 9 || j == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    //field[3, 9] = Convert.ToChar(GameProces.whiteCount.ToString());
                    //field[7, 9] = Convert.ToChar(GameProces.blackCount.ToString());

                    Console.Write(field[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public static void ShowDiagonal(int[][] diagonal)// Выводит координаты элементов диагонали и цвет шашки 
        {
            for (int i = 0; i < diagonal.Length; i++)
            {
                Console.WriteLine($"[{diagonal[i][0]},{diagonal[i][1]}], color => {Desk.checkers[CheckerFieldState.CoordinatesMatching(diagonal[i][0], diagonal[i][1])].color}");
            }
        }
    }
}
