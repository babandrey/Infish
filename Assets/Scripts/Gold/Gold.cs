using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, IGold
{
    ObjectPooler objectPooler;

    [SerializeField] private new string name;
    [SerializeField] private int amount;
    private Sprite sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Start()
    {
        objectPooler = ObjectPooler.instance;
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
