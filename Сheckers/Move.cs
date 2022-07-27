using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сheckers
{
    static class Move
    {
        public static int[][][] FindDiagonals()// Возвращает две диагонали (0,1), на которых находится шашка с координатами X = GameProces.x и Y = GameProces.y 
        {
            int[][][] diagon = new int[2][][];
            bool b = false;
            int x = GameProces.x;
            int y = GameProces.y;

            for (int i = 0; i < Desk.diagonals.Count; i++)
            {
                for (int j = 0; j < Desk.diagonals[i].Length; j++)
                {
                    if(Desk.diagonals[i][j][0] == x && Desk.diagonals[i][j][1] == y)
                    {
                        if (!b)
                        {
                            diagon[0] = Desk.diagonals[i];
                            b = true;
                        }
                        if (b)
                        {
                            diagon[1] = Desk.diagonals[i];
                            break;
                        }
                    }
                }
            }

            return diagon;
        }

        public static int[][][] FindDiagonals(int x, int y)// Перегрузка ^ метода, принимает свои координаты X и Y 
        {
            int[][][] diagon = new int[2][][];
            bool b = false;

            for (int i = 0; i < Desk.diagonals.Count; i++)
            {
                for (int j = 0; j < Desk.diagonals[i].Length; j++)
                {
                    if (Desk.diagonals[i][j][0] == x && Desk.diagonals[i][j][1] == y)
                    {
                        if (!b)
                        {
                            diagon[0] = Desk.diagonals[i];
                            b = true;
                        }
                        if (b)
                        {
                            diagon[1] = Desk.diagonals[i];
                            break;
                        }
                    }
                }
            }

            return diagon;
        }

        public static bool CanTake(int[][] diagonal,int player)// Проверяет, есть ли возможность взятия фигуры игроком PLAYER на диагонали DIAGONAL 
        {

            int x = GameProces.x;
            int y = GameProces.y;
            int temp = 0;
            int a = 0,b = 0;

            if(player == 2)
            {
                a = 2;
                b = 1;
            }
            if(player == 1)
            {
                a = 1;
                b = 2;
            }
            for (int i = 0; i < diagonal.Length; i++)
            {
                if(x==diagonal[i][0] && y == diagonal[i][1])
                {
                    temp = i;
                    break;
                }
            }

            if(temp < diagonal.Length - 2)
            {
                if (temp > 1)
                {
                    if (Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color == a &&
                         Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 1)].color == b &&
                         Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].color == 0)
                    {
                        return true;
                    }
                }

                if (Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color == a &&
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 1)].color == b &&
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].color == 0)
                {
                    return true;
                }

            }
            else if(temp > 1)
            {
                if (temp < diagonal.Length - 2)
                {
                    if (Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color == a &&
                         Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 1)].color == b &&
                         Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].color == 0)
                    {
                        return true;
                    }
                }
                if (Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color == a &&
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 1)].color == b &&
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].color == 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        public static void FigureTaking(int[][] diagonal,int temp,int player)// Взятие фигуры игроком PLAYER на диагонали DIAGONAL по номеру в диагонали TEMP 
        {
            int a = 0, b = 0;

            if (player == 2)
            {
                a = 2;
                b = 1;


            }
            if (player == 1)
            {
                a = 1;
                b = 2;
            }

            if (temp < diagonal.Length - 2)
            {
                if (temp > 1)
                {
                    if (Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color == a &&
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 1)].color == b &&
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].color == 0)
                    {
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].color = a;
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 1)].color = 0;
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color = 0;

                        GameProces.x = Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].coordinates[0];
                        GameProces.y = Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].coordinates[1];

                    }
                }
                if (Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color == a &&
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 1)].color == b &&
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].color == 0)
                {

                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].color = a;
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 1)].color = 0;
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color = 0;

                    GameProces.x = Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].coordinates[0];
                    GameProces.y = Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].coordinates[1];


                }
            }
            else if (temp > 1)
            {
                if (temp < diagonal.Length - 2)
                {
                    if (Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color == a &&
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 1)].color == b &&
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].color == 0)
                    {

                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].color = a;
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 1)].color = 0;
                        Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color = 0;

                        GameProces.x = Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].coordinates[0];
                        GameProces.y = Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp + 2)].coordinates[1];

                    }
                }

                if (Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color == a &&
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 1)].color == b &&
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].color == 0)
                {
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].color = a;
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 1)].color = 0;
                    Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp)].color = 0;

                    GameProces.x = Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].coordinates[0];
                    GameProces.y = Desk.checkers[CheckerFieldState.DiagonalAndChe(diagonal, temp - 2)].coordinates[1];

                }
            }else
                Console.WriteLine("Что-то не так !");

        }

    }
}
