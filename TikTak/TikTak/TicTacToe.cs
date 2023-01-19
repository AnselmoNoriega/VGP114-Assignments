

namespace TicTacToe;

public class TicTacToe : ITicTacToe
{
    Player[][] map = new Player[][]
        {
        new Player[] { Player.None, Player.None, Player.None},
        new Player[] { Player.None, Player.None, Player.None},
        new Player[] { Player.None, Player.None, Player.None}
        };


    public void NewBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                map[i][j] = Player.None;
            }
        }
    }

    int turnIndex = 1;

    public void Move(int r, int c)
    {
        if ((r < 3 && r >= 0) && (c < 3 && c >= 0))
        {
            if (map[r][c] == Player.None)
            {
                map[r][c] = GetTurn();
                turnIndex++;
            }
        }
        else 
        {
            Console.WriteLine("\"[Does coordinates does not exist]\"\n\n");
        }
    }
    public void WrittenGetTurn()
    {
        if ((turnIndex % 2) == 0)
        {
            Console.WriteLine("[O's turn]");
        }
        else
        {
            Console.WriteLine("[X's turn]");
        }
    }
    public Player GetTurn()
    {
        if ((turnIndex % 2) == 0)
        {
            return Player.O;
        }
        else
        {
            return Player.X;
        }
    }

    public bool IsGameOver()
    {
        if (turnIndex == 9)
        {
            return true;
        }
        else if (((map[0][0] == map[1][1] && map[1][1] == map[2][2]) || (map[2][0] == map[1][1] && map[1][1] == map[0][2])) && map[1][1] != Player.None)
        {
            return true;
        }

        for (int i = 0; i < 3; i++)
        {
            if ((map[0][i] == map[1][i] && map[1][i] == map[2][i] && map[0][i] != Player.None) || (map[i][0] == map[i][1] && map[i][1] == map[i][2] && map[i][0] != Player.None))
            {
                return true;
            }
        }

        return false;
    }

    public Player GetWinner()
    {
        turnIndex= 0;

        for (int i = 0; i < 3; i++)
        {
            if (map[0][i] == map[1][i] && map[1][i] == map[2][i])
            {
                return map[0][i];
            }
            else if(map[i][0] == map[i][1] && map[i][1] == map[i][2])
            {
                return map[i][0];
            }
        }

        if ((map[0][0] == map[1][1] && map[1][1] == map[2][2]) || (map[2][0] == map[1][1] && map[1][1] == map[0][2]))
        {
            return map[1][1];
        }

        return Player.None;
    }

    public Player[][] GetBoard()
    {
        return map;
    }

    public Player GetMarkAt(int r, int c)
    {
        return map[r][c];
    }

    // add your implementation here
    public override string ToString()
    {
        var rows = new List<string>();
        foreach (var row in GetBoard())
        {
            var rowStrings = new List<string>();
            foreach (var p in row)
                if (p == Player.None)
                    rowStrings.Add(" ");
                else
                    rowStrings.Add(p.ToString());
            rows.Add(" " + string.Join(" | ", rowStrings));
        }

        return string.Join("\n-----------\n", rows);
    }
}

