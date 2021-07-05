using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] protected GameObject[] food;
    [SerializeField] private GameObject[] goldDrop;
    [SerializeField] private bool isDroppingGold;

    protected ObjectPooler objectPooler;
    private Sprite sprite;
    private Hunger hunger;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
        hunger = GetComponent<Hunger>();
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    #region Getters & Setters

    public string Name
    { 
        get { return name; }
    }

    public GameObject[] Food
    {
        get { return food; }
        set { food = value; }
    }

    public GameObject[] GoldDrop
    {
        get { return goldDrop; }
        set { goldDrop = value; }
    }

    public bool IsDroppingGold
    {
        get { return isDroppingGold; }
        set { isDroppingGold = value; }
    }

    public Sprite Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    #endregion

    public virtual void CheckCollision(Collider2D collision)
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

    protected virtual void Eat(IEdible food)
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
