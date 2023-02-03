
namespace WorldEditor;

public abstract class PointEntity : IPlaceableEntity
{
    protected Position position;

    public void SetPosition(int x, int y)
    {
        position.x = x;
        position.y = y;
        Console.WriteLine($"{this} is placed at {position}");
    }

    public Position GetPosition()
    {
        return new Position(position.x, position.y);
    }
}
