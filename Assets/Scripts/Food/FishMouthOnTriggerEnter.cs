using UnityEngine;

public class FishMouthOnTriggerEnter : MonoBehaviour
{
    private Fish fish;

    private void Start()
    {
        fish = GetComponentInParent<Fish>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fish.CheckCollision(collision);
    }
}
