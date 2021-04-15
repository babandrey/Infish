using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMouthOnTriggerEnter : MonoBehaviour
{
    IFish fish;
    Hunger fishHunger;

    private void Start()
    {
        fish = gameObject.GetComponentInParent<IFish>();
        fishHunger = gameObject.GetComponentInParent<Hunger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fishHunger.IsHungry)
        {
            Food food = collision.gameObject.GetComponent<Food>();

            if (food != null)
            {
                fish.Eat(food);

                IStatus[] statuses = food.GetComponents<IStatus>();

                foreach(IStatus status in statuses)
                {
                    //status.Activate(fish);
                }

                fishHunger.HungerTimer = food.Health;
                Destroy(food.gameObject);
            }
        }
    }
}
