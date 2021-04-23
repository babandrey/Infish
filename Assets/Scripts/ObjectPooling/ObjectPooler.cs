using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> poolDictonary;
    [SerializeField] private Dictionary<string, List<GameObject>> activePoolDictonary;

    #region Singleton

    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    
    void Start()
    {
        poolDictonary = new Dictionary<string, Queue<GameObject>>();
        activePoolDictonary = new Dictionary<string, List<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            List<GameObject> activeObjectPool = new List<GameObject>();

            pool.PoolTag = pool.Prefab.name;

            GameObject poolParentObj = new GameObject(pool.PoolTag);
            poolParentObj.transform.parent = gameObject.transform;

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab, poolParentObj.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictonary.Add(pool.PoolTag, objectPool);
            activePoolDictonary.Add(pool.PoolTag, activeObjectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = SpawnFromPool(tag);

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictonary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return null;
        }

        GameObject objectToSpawn;

        if (poolDictonary[tag].Count > 0)
        {
            objectToSpawn = poolDictonary[tag].Dequeue();
            objectToSpawn.SetActive(true);
        }
        else
        {
            objectToSpawn = Instantiate(pools.Find(pool => pool.PoolTag == tag).Prefab, GameObject.Find(tag).transform);
        }

        activePoolDictonary[tag].Add(objectToSpawn);

        return objectToSpawn;
    }

    public void SetObjectInactive(GameObject obj)
    {
        obj.SetActive(false);
        activePoolDictonary[obj.transform.parent.name].Remove(obj);
        poolDictonary[obj.transform.parent.name].Enqueue(obj);
    }

    public Dictionary<string, List<GameObject>> ActivePoolDictonary
    {
        get
        {
            return activePoolDictonary;
        }
    }
}
