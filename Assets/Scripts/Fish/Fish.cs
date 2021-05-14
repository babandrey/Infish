using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject goldDrop;

    private ObjectPooler objectPooler;
    private Hunger hunger;

    private void Awake()
    {
        objectPooler = ObjectPooler.instance;
        hunger = gameObject.GetComponent<Hunger>();

        if(food.GetComponent<IEdible>() == null)
        {
            Debug.LogWarning($"The {food} on {gameObject} isn't IEdible.");
        }

        if(goldDrop.GetComponent<IGold>() == null)
        {
            Debug.LogWarning($"The {goldDrop} on {gameObject} isn't IGold.");
        }
    }

    void OnEnable()
    {
        hunger.HungerTimer = 20f;
    }

    public string Name
    { 
        get { return name; }
    }

    public GameObject Food
    {
        get { return food; }
    }

    public GameObject GoldDrop
    {
        get { return goldDrop; }
    }

    public void CheckCollision(Collider2D collision)
    {
        if (hunger.IsHungry)
        {
            IEdible food = collision.gameObject.GetComponent<IEdible>();

            if (food != null && food.Name == this.food.name)
            {
                Eat(food);
            }
        }
    }

    private void Eat(IEdible food)
    {
        MonoBehaviour monoBehaviour = food as MonoBehaviour;
        if(monoBehaviour == null)
        {
            return;
        }

        GameObject obj = monoBehaviour.gameObject;

        foreach (IStatus status in food.Statuses)
        {
            status.Activate(transform);
        }

        hunger.HungerTimer = food.Health;

        objectPooler.SetObjectInactive(obj);
    }
}
