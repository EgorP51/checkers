using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сheckers
{
    class CheckerFieldState
    {

        public int[] coordinates = new int[2];   // coordinates[0] - X, coordinates[1] - Y
        public bool isQueen;                     // true - queen, false - !queen
        public int color;                        // 1 - white,2 - black,0 - empty

        public override string ToString()
        {
            return $"Color => {color}, Coordinates [{coordinates[0]},{coordinates[1]}]"; // just for me, useless in program!
        }

        public static int CoordinatesMatching(int x,int y) // возвращает number шашки по координатам 
        {
            int temp = 0;

            foreach (var chek in Desk.checkers)
            {
                if(chek.coordinates[0] == x && chek.coordinates[1] == y)
                {
                    return temp;//chek.color;
                }
                temp++;
            }
            return 4;
        } 

        public static int DiagonalAndChe(int[][] diagonal,int a )// возврaщает номер шашки по номеру в диагонали  
        {
            for (int i = 0; i < Desk.checkers.Length; i++)
            {
                if (a < diagonal.Length)
                {
                    if(a == -1)
                    {
                        Desk.ShowDiagonal(diagonal);
                    }
                    if (diagonal[a][0] == Desk.checkers[i].coordinates[0] &&
                        diagonal[a][1] == Desk.checkers[i].coordinates[1])
                    {
                        return i;
                    }
                }
            }

            return 4;
        }

        public static int CheckerNumbInDiagonal(int[][] diagonal, CheckerFieldState checker)
        {
            for (int j = 0; j < diagonal.Length; j++)
            {
                if (diagonal[j][0] == checker.coordinates[0] && diagonal[j][1] == checker.coordinates[1])
                {
                    return j;
                }
            }
            return -1;
        }


    }
}
