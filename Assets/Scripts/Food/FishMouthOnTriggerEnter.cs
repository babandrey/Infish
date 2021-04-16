using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMouthOnTriggerEnter : MonoBehaviour
{
    private Fish fish;

    private void Start()
    {
        fish = gameObject.GetComponentInParent<Fish>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fish.CheckCollision(collision);
    }
}
