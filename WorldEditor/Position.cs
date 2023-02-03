namespace WorldEditor;

public class Position
{
    public int x, y;

    public Position() : this(0, 0)
    {
    }

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        //Check for null and compare run-time types.
        if (obj == null || !GetType().Equals(obj.GetType())) return false;

        var p = (Position)obj;
        return x == p.x && y == p.y;
    }

    public override int GetHashCode()
    {
        return (x << 2) ^ y;
    }

    public override string ToString()
    {
        return string.Format("Point({0}, {1})", x, y);
    }
}