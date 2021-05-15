using UnityEngine;

public class Goldfish : Fish, IEdible
{
    [SerializeField] private float health;
    private IStatus[] statuses = new IStatus[0];

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public IStatus[] Statuses
    {
        get { return statuses; }
    }

    [ContextMenu("Grow Size")]
    private void GrowSize()
    {
        if (ObjectPooler.instance.EdibleFoodPoolDictonary[transform.parent.name].Contains(gameObject))
        {
            ObjectPooler.instance.EdibleFoodPoolDictonary[transform.parent.name].Remove(gameObject);
        }
    }
}
