using UnityEngine;

public class Goldfish : Fish, IEdible
{
    [SerializeField] private float health;
    private IStatus[] statuses = new IStatus[0];
    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

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
        objectPooler.RemoveObjectFromEdiblePool(gameObject);
    }
}
