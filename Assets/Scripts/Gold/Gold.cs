using System.Collections;
using UnityEngine;

public class Gold : MonoBehaviour, IGold
{
    ObjectPooler objectPooler;
    GoldManager goldManager;
    Rigidbody2D rb;

    [SerializeField] private new string name;
    [SerializeField] private int amount;
    private Sprite sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        objectPooler = ObjectPooler.instance;
        goldManager = GoldManager.instance;
        rb.freezeRotation = true;
    }

    public string Name
    {
        get { return name; }
    }

    public int Amount
    {
        get { return amount; }
    }

    public Sprite Sprite
    {
        get { return sprite; }
    }

    public void OnMouseDown()
    {
        goldManager.AddGold(Amount);
        objectPooler.SetObjectInactive(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bottom Collider")
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
