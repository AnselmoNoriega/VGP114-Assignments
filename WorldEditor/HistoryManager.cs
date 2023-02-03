using System.Windows.Input;

namespace WorldEditor;

// HistoryManager has the following functionalities:
// 1. It records the commands that are executed.
//    It should not record the command if any exception
//    is caught when executing the command.
//    To get possible exceptions, read EntityManager.cs.
// 2. It records what commands are undone.
// 3. It abandons commands that are undone once a new command is executed.
//
//    If you need a live example to better understand expected behavior,
//    you can check out this online image editor and play with its history https://www.photopea.com/

public class HistoryManager
{

    //private static HistoryManager instance;
    private Stack<ICommand> command;
    private Stack<ICommand> delcommand;
    private static HistoryManager instance;

    private HistoryManager()
    {
        command = new Stack<ICommand>();
        delcommand = new Stack<ICommand>();
    }

    public static HistoryManager GetInstance
    {
        get
        {
            if (instance == null) instance = new HistoryManager();
            return instance;
        }
    }
    public void ExecuteCmd(ICommand cmd)
    {
        delcommand.Clear();
        try
        {
            cmd.Execute();
            Console.WriteLine("\n");
        }
        catch(Exception problem)
        {
            Console.WriteLine($"{problem.Message}\n");
            return;
        }

        command.Push(cmd);
    }

    public void UndoCmd()
    {
        try
        {
            command.Peek().Undo();
            delcommand.Push(command.Pop());
            Console.WriteLine("\n");
        }
        catch(Exception problem)
        {
            Console.WriteLine($"{problem.Message}\n");
            return;
        }
    }

    public void RedoCmd()
    {
        if (delcommand.Count != 0)
        {
            command.Push(delcommand.Pop());
            command.Peek().Redo();
            Console.WriteLine("\n");
        }
        else
        {
            Console.WriteLine("There are no more Actions to do\n");
        }
    }

    public void Map()
    {
        Console.WriteLine("\n---------------------------------------------------");
        EntityManager.GetInstance.OutputMap();
        Console.WriteLine("---------------------------------------------------\n");
    }
}