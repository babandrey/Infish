using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] private GameObject[] food;
    [SerializeField] private GameObject goldDrop;

    private ObjectPooler objectPooler;
    private Hunger hunger;

    private void Awake()
    {
        objectPooler = ObjectPooler.instance;
        hunger = GetComponent<Hunger>();
    }

    public string Name
    { 
        get { return name; }
    }

    public GameObject[] Food
    {
        get { return food; }
        set { food = value; }
    }

    public GameObject GoldDrop
    {
        get { return goldDrop; }
        set { goldDrop = value; }
    }

    public void CheckCollision(Collider2D collision)
    {
        if (hunger.IsHungry)
        {
            IEdible food = collision.GetComponentInParent<IEdible>();

            if (food != null)
            {
                if (objectPooler.EdibleFoodPoolDictonary[food.Name].Contains(collision.transform.parent.gameObject))
                {
                    foreach (GameObject foodObject in this.food)
                    {
                        if (food.Name == foodObject.name)
                        {
                            Eat(food);
                            return;
                        }
                    }
                }
            }
        }
    }

    public virtual void Eat(IEdible food)
    {
        MonoBehaviour monoBehaviour = food as MonoBehaviour;
        if (monoBehaviour == null) return;

        GameObject obj = monoBehaviour.gameObject;

        foreach (IStatus status in food.Statuses)
        {
            status.Activate(transform);
        }

        hunger.HungerTimer = food.Health;

        objectPooler.SetObjectInactive(obj);
    }
}
