namespace WorldEditor;

public interface IPlaceableEntity
{
    void SetPosition(int x, int y);
    Position GetPosition();
}