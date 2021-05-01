using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGold : MonoBehaviour
{
    private ObjectPooler objectPooler;

    private Fish fish;
    private float timer;
    [SerializeField] private float timeUntilDrop;

    void Start()
    {
        objectPooler = ObjectPooler.instance;

        fish = GetComponent<Fish>();
        timer = RandomizeTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnGoldDrop();
            timer = RandomizeTimer();
        }
    }

    private void SpawnGoldDrop()
    {
        objectPooler.SpawnFromPool(fish.GoldDrop.name, fish.transform.position, fish.transform.rotation);
    }

    private float RandomizeTimer()
    {
        return Random.Range(timeUntilDrop - 2, timeUntilDrop + 2);
    }
}
