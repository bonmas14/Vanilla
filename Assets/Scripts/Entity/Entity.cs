using UnityEngine;

public interface IEntity
{
    public EntityType Type { get; }

    public int Id { get; }

    public float Health { get; }

    public float Food { get; }

    public float Energy { get; }

    public EntitySave GetState();
    public void LoadState(EntitySave state);

    public void Init();
    public void Tick();
}

public struct EntitySave
{
    public EntityType type;
    public int id;
    public float health;
    public float food;
    public float energy;
}

public interface IAi
{
    public void LogicUpdate();
}

public enum EntityType
{
    Player,
    Shadow,
    Glider,
    Spark,
    Dweller,
}

public static class EntityHelper
{
    public static float GetMaxHealthByType(EntityType type)
    {
        switch (type)
        {
            case EntityType.Player:
                return Player.MaxHealth;
            case EntityType.Shadow:
                return 40;
            case EntityType.Glider:
                return 100;
            case EntityType.Spark:
                return 20;
            case EntityType.Dweller:
                return 200;
            default:
                Debug.LogError("undefined entity type");
                return 0;
        }
    }
    
    public static float GetMaxEnergyByType(EntityType type)
    {
        switch (type)
        {
            case EntityType.Player:
                return Player.MaxEnergy;
            case EntityType.Shadow:
                return 200;
            case EntityType.Glider:
                return 2000;
            case EntityType.Spark:
                return 400;
            case EntityType.Dweller:
                return 800;
            default:
                Debug.LogError("undefined entity type");
                return 0;
        }
    }
    public static float GetMaxFoodByType(EntityType type)
    {
        switch (type)
        {
            case EntityType.Player:
                return Player.MaxFood;
            case EntityType.Glider:
                return 200;
            default:
                return 0;
        }
    }
}