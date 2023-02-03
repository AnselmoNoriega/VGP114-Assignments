 using System.Windows.Input;

namespace WorldEditor;

public class CreateCommand : ICommand
{
    private readonly eEntityType entityType;
    private readonly Position pos;

    public CreateCommand(eEntityType entityType, int x, int y)
    {
        this.entityType = entityType;
        pos = new Position(x, y);
    }

    public void Execute()
    {
        EntityManager.GetInstance.CreateEntity(entityType, pos);
    }

    public void Undo()
    {
        EntityManager.GetInstance.RemoveEntity(pos);
    }

    public void Redo()
    {
        EntityManager.GetInstance.RecoverEntity();
    }
}