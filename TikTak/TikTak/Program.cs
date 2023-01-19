namespace TicTacToe;
using static System.Console;

public class Program
{
    public static void Main()
    {
        var ticTacToe = new TicTacToe();
        int rowNum, columnNum;
        int xWinCount = 0, oWinCount = 0;

        for (int i = 0; i < 3; i++)
        {
            ticTacToe.NewBoard();
            WriteLine(ticTacToe.ToString());

            while (!ticTacToe.IsGameOver())
            {
                ticTacToe.WrittenGetTurn();
                WriteLine("\nIn which row do you want to draw your turn?");
                string rowTurn = ReadLine();

                WriteLine("In which column do you want to draw your turn?");
                string columnTurn = ReadLine();
                WriteLine("\n\n");


                int.TryParse(rowTurn, out rowNum);
                int.TryParse(columnTurn, out columnNum);

                ticTacToe.Move(rowNum, columnNum);
                WriteLine(ticTacToe.ToString());
            }

            if(ticTacToe.GetWinner() == Player.X)
            {
                xWinCount++;
                WriteLine("\n\nX Wins = {0}", xWinCount, "\n\n");
                if(xWinCount== 3) { i = 5; };
            }
            else if (ticTacToe.GetWinner() == Player.O)
            {
                oWinCount++;
                WriteLine("\n\nO Wins = {0}", oWinCount, "\n\n");
                if (oWinCount == 3) { i = 5; };
            }
            else
            {
                WriteLine("\n\nStalemate\n\n");
            }
        }
    }
}