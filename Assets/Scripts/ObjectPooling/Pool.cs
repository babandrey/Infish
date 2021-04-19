using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    [SerializeField] private string poolTag;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int size;

    public string PoolTag
    {
        get
        {
            return poolTag;
        }
    }

    public GameObject Prefab
    {
        get
        {
            return prefab;
        }
    }

    public int Size
    {
        get
        {
            return size;
        }
    }
}
