using System;
using System.Threading;
using Сheckers;



namespace Checkers
{
    class Program
    {
        static void Main()
        {
            Desk desk = new Desk();
            GameProces gameProces = new GameProces();

            Desk.ShowDesk();

            for (int i = 0; i < (i + 1); i++)
            {
                Thread.Sleep(500);
                //Console.Clear();
                gameProces.BotMove(2);
                Console.Clear();
                Desk.ShowDesk();

                Thread.Sleep(500);
                Console.Clear();
                gameProces.BotMove(1);
                Desk.ShowDesk();
            }
        }
    }
}




