namespace WorldEditor;

public class GoldMine : PointEntity
{
    public GoldMine(Position pos)
    {
        position = new Position(pos.x, pos.y);
        Console.WriteLine($"A new {this} is created at {position}");
    }

    public override string ToString()
    {
        return "GoldMine";
    }
}