using System.Collections;
using UnityEngine;

[System.Serializable]
public class Food : MonoBehaviour, IEdible
{
    [SerializeField] private new string name;
    [SerializeField] private float health;
    [SerializeField] private int nutritionalValue;
    private Sprite sprite;
    private IStatus[] statuses;

    private ObjectPooler objectPooler;
    private FoodManager foodManager;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
        foodManager = FoodManager.Instance;
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        statuses = GetComponents<IStatus>(); 
    }

    private void OnEnable()
    {
        foodManager.FoodsOnScreen++;
    }

    private void OnDisable()
    {
        foodManager.FoodsOnScreen--;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public float Health
    { 
        get { return health; }
        set { health = value; }
    }
    public IStatus[] Statuses
    {
        get{ return statuses; }
    }

    public int NutritionalValue
    {
        get { return Random.Range(nutritionalValue - 1, nutritionalValue + 1); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom Collider")
        {
            StartCoroutine(DespawnTimeout());
        }
    }

    IEnumerator DespawnTimeout()
    {
        yield return new WaitForSeconds(1f);
        objectPooler.SetObjectInactive(gameObject);
    }
}
