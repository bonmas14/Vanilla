using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public const float MaxHealth = 100;
    public const float MaxFood = 80;
    public const float MaxEnergy = 1000;

    public EntityType Type => EntityType.Player;
    public int Id => 0;
    public float Health => _health;
    public float Food => _food;
    public float Energy => _energy;

    [SerializeField] private float _startHealth = 100;
    [SerializeField] private float _startFood = 80;
    [SerializeField] private float _startEnergy = 1000;

    private float _health;
    private float _food;
    private float _energy;

    public EntitySave GetState()
    {
        return new EntitySave()
        {
            energy = _energy,
            food = _food,
            health = _health,
            id = Id,
            type = Type
        };
    }

    public void LoadState(EntitySave state)
    {
        _health = state.health;
        _food = state.food;
        _energy = state.energy;
    }

    public void Init()
    {
        _health = _startHealth;
        _energy = _startEnergy;
        _food = _startFood;
    }

    public void Tick()
    {


    }

    void Start()
    {
        // save file load logic

        Init();

        GameObject.FindGameObjectWithTag("Entity Debug").GetComponent<EntityVisualizer>().Subscribe(this);
    }

    void Update()
    {
        
    }
}
