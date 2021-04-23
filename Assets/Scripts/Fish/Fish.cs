using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] private string food; // give each fish a way to set the food from a prefab somehow, using IEdible type

    private ObjectPooler objectPooler;
    private Hunger hunger;

    private void Awake()
    {
        objectPooler = ObjectPooler.instance;
        hunger = gameObject.GetComponent<Hunger>();
    }

    void OnEnable()
    {
        hunger.HungerTimer = 20f;
    }

    public string Name
    { 
        get { return name; }
    }

    public string Food
    {
        get { return food; }
    }

    public void CheckCollision(Collider2D collision)
    {
        if (hunger.IsHungry)
        {
            IEdible food = collision.gameObject.GetComponent<IEdible>();

            if (food != null && food.Name == this.food)
            {
                Eat(food);
            }
        }
    }

    private void Eat(IEdible food)
    {
        MonoBehaviour monoBehaviour = food as MonoBehaviour;
        if(monoBehaviour == null)
        {
            return;
        }

        GameObject obj = monoBehaviour.gameObject;

        foreach (IStatus status in food.Statuses)
        {
            status.Activate(transform);
        }

        hunger.HungerTimer = food.Health;

        objectPooler.SetObjectInactive(obj);
    }
}
