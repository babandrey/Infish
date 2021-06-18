using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> poolDictonary;
    [SerializeField] private Dictionary<string, List<GameObject>> activePoolDictonary;
    [SerializeField] private Dictionary<string, List<GameObject>> edibleFoodPoolDictonary;

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    
    void Start()
    {
        InitializePools();
    }

    private void InitializePools()
    {
        poolDictonary = new Dictionary<string, Queue<GameObject>>();
        activePoolDictonary = new Dictionary<string, List<GameObject>>();
        edibleFoodPoolDictonary = new Dictionary<string, List<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            List<GameObject> activeObjectPool = new List<GameObject>();
            List<GameObject> edibleFoodPool = new List<GameObject>();

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

            if(pool.IsEdible)
            {
                edibleFoodPoolDictonary.Add(pool.PoolTag, edibleFoodPool);
            }
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

        if (edibleFoodPoolDictonary.ContainsKey(tag))
        {
            edibleFoodPoolDictonary[tag].Add(objectToSpawn);
        }

        return objectToSpawn;
    }

    public void SetObjectInactive(GameObject obj)
    {
        string tag = obj.transform.parent.name;

        obj.SetActive(false);
        activePoolDictonary[tag].Remove(obj);
        poolDictonary[tag].Enqueue(obj);

        if (edibleFoodPoolDictonary.ContainsKey(tag))
        {
            RemoveObjectFromEdiblePool(obj);
        } 
    }

    public void RemoveObjectFromEdiblePool(GameObject obj)
    {
        string tag = obj.transform.parent.name;

        if (edibleFoodPoolDictonary[tag].Contains(obj))
        {
            edibleFoodPoolDictonary[tag].Remove(obj);
        }
    }

    public Dictionary<string, List<GameObject>> ActivePoolDictonary
    {
        get { return activePoolDictonary; }
    }

    public Dictionary<string, List<GameObject>> EdibleFoodPoolDictonary
    {
        get { return edibleFoodPoolDictonary; }
    }
}
