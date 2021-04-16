using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Food : MonoBehaviour
{
    [SerializeField] string foodName;
    private Sprite sprite;
    [SerializeField] private float health = 30;
    public IStatus[] Statuses { get; private set; }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        Statuses = GetComponents<IStatus>();
    }

    private void OnEnable()
    {
        FoodManager.instance.FoodsOnScreen++;
    }

    private void OnDisable()
    {
        FoodManager.instance.FoodsOnScreen--;
    }

    public float Health
    {
        get
        {
            return health;
        }
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
