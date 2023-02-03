namespace WorldEditor;

public enum eEntityType
{
    Unknown,
    TownHall,
    GoblinLaboratory,
    GoldMine
}

public class EntityManager
{
    private static EntityManager instance;
    private readonly Stack<IPlaceableEntity> deletedEntities;
    private readonly Dictionary<Position, IPlaceableEntity> entities;

    private EntityManager()
    {
        entities = new Dictionary<Position, IPlaceableEntity>();
        deletedEntities = new Stack<IPlaceableEntity>();
    }

    public static EntityManager GetInstance
    {
        get
        {
            if (instance == null) instance = new EntityManager();
            return instance;
        }
    }

    public IPlaceableEntity CreateEntity(eEntityType entityType, Position pos)
    {
        if (entities.ContainsKey(pos))
            throw new ArgumentException($"Can't create new entity at {pos} since it's occupied.");

        IPlaceableEntity newEntity = null;
        switch (entityType)
        {
            case eEntityType.GoblinLaboratory:
                newEntity = new GoblinLaboratory(pos);
                break;
            case eEntityType.GoldMine:
                newEntity = new GoldMine(pos);
                break;
            case eEntityType.TownHall:
                newEntity = new TownHall(pos);
                break;
        }

        if (newEntity != null) entities.Add(pos, newEntity);

        return newEntity;
    }

    public void RemoveEntity(Position pos)
    {
        if (entities.ContainsKey(pos))
        {
            var entity = entities[pos];
            deletedEntities.Push(entities[pos]);
            entities.Remove(pos);
            Console.WriteLine($"{entity} at {pos} is removed");
        }
        else
        {
            throw new ArgumentException($"No entity is found at {pos}.");
        }
    }

    public void RecoverEntity()
    {
        if (deletedEntities.Count > 0)
        {
            var entity = deletedEntities.Pop();
            entities.Add(entity.GetPosition(), entity);
            Console.WriteLine($"{entity} at {entity.GetPosition()} is recovered");
        }
        else
        {
            throw new ArgumentException("No entity can be recovered.");
        }
    }

    public void MoveEntity(Position oldPos, Position newPos)
    {
        if (entities.ContainsKey(oldPos) && !entities.ContainsKey(newPos))
        {
            var entity = entities[oldPos];
            entities.Remove(oldPos);
            entities.Add(newPos, entity);
            entity.SetPosition(newPos.x, newPos.y);
            return;
        }

        if (!entities.ContainsKey(oldPos))
            throw new ArgumentException($"No entity is found at {oldPos}.");
        throw new ArgumentException($"Can't move {entities[oldPos]} to {newPos} since it's occupied.");
    }

    public void OutputMap()
    {
        foreach (var VARIABLE in entities) Console.WriteLine($"{VARIABLE.Value} at {VARIABLE.Key}");
    }
}