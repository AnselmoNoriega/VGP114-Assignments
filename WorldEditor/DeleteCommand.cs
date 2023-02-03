using System.Windows.Input;

namespace WorldEditor;

public class DeleteCommand : ICommand
{
    private readonly Position pos;


    public DeleteCommand(int x, int y)
    {
        pos = new Position(x, y);
    }

    public void Execute()
    {
        EntityManager.GetInstance.RemoveEntity(pos);
    }

    public void Undo()
    {
        EntityManager.GetInstance.RecoverEntity();
    }

    public void Redo()
    {
        Execute();
    }
}