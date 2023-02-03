using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldEditor;
public class PlaceCommand : ICommand
{
    private static PlaceCommand instance;
    private Position pos;
    private Position newPos;
    private bool temp;
    private int xpos;
    private int yPos;
    private int newXpos;
    private int newYPos;

    public PlaceCommand()
    {
        temp = false;
    }

    public static PlaceCommand GetInstance
    {
        get
        {
            if (instance == null) instance = new PlaceCommand();
            return instance;
        }
    }

    public void SetOldPos(int x, int y)
    {
        xpos = x;
        yPos = y;
    }
    public void SetNewPos(int x, int y)
    {
        newXpos = x;
        newYPos = y;
    }

    public void Execute()
    {
        pos = new Position(xpos, yPos);
        newPos = new Position(newXpos, newYPos);
        EntityManager.GetInstance.MoveEntity(pos, newPos);
    }
    public void Undo()
    {
        if (pos != null)
        {
            EntityManager.GetInstance.MoveEntity(newPos, pos);
            temp = true;
        }
        else
        {
            Console.WriteLine("Theres nothis to Undo");
        }
    }
    public void Redo()
    {
        if (temp)
        {
            EntityManager.GetInstance.MoveEntity(pos, newPos);
        }
    }
}
