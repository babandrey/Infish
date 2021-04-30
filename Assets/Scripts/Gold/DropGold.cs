using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGold : MonoBehaviour
{
    private ObjectPooler objectPooler;

    private Fish fish;
    [SerializeField] private float timer;
    [SerializeField] private float timeUntilDrop;

    void Start()
    {
        objectPooler = ObjectPooler.instance;

        fish = GetComponent<Fish>();
        timer = timeUntilDrop;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnGoldDrop();
            timer = timeUntilDrop;
        }
    }

    private void SpawnGoldDrop()
    {
        objectPooler.SpawnFromPool(fish.GoldDrop.name, fish.transform.position, fish.transform.rotation);
    }
}
