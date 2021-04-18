using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Food : MonoBehaviour, IEdible
{
    [SerializeField] private new string name;
    [SerializeField] private float health;
    private Sprite sprite;
    private IStatus[] statuses;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        statuses = GetComponents<IStatus>();
    }

    private void OnEnable()
    {
        FoodManager.instance.FoodsOnScreen++;
    }

    private void OnDisable()
    {
        FoodManager.instance.FoodsOnScreen--;
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
        gameObject.SetActive(false);
    }
}
