using UnityEngine;

public class Goldfish : Fish, IEdible
{
    [SerializeField] private float health;
    [SerializeField] private int nutritionalValue;
    private IStatus[] statuses = new IStatus[0];

    [SerializeField] private GrowSize growSize;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public IStatus[] Statuses
    {
        get { return statuses; }
    }

    public int NutritionalValue
    {
        get { return Random.Range(nutritionalValue - 1, nutritionalValue + 1); }
    }

    public override void Eat(IEdible food)
    {
        base.Eat(food);
        growSize.OnEatFood(food.NutritionalValue);
    }
}
