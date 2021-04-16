using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Hunger hunger;
    // Start is called before the first frame update
    void Start()
    {
        hunger = gameObject.GetComponent<Hunger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Eat(Food food)
    {
        foreach (IStatus status in food.Statuses)
        {
            status.Activate(transform);
        }

        hunger.HungerTimer = food.Health;
        Destroy(food.gameObject);
    }

    public void CheckCollision(Collider2D collision)
    {
        if (hunger.IsHungry)
        {
            Food food = collision.gameObject.GetComponent<Food>();

            if (food != null)
            {
                Eat(food); 
            }
        }
    }
}
