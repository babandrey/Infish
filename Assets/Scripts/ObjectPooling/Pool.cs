using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    private string poolTag;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int size;

    public string PoolTag
    {
        get { return poolTag; }
        set { poolTag = value; }
    }

    public GameObject Prefab
    {
        get { return prefab; }
    }

    public int Size
    {
        get {return size; }
    }
}
