using System.Collections;
using System.Collections.Generic;
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

            GameObject poolParentObj = new GameObject(pool.PoolTag);
            poolParentObj.transform.parent = gameObject.transform;

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab, poolParentObj.transform); // trying to  creating object groups for different types of stuff like fish, food or coins.
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictonary.Add(pool.PoolTag, objectPool);
            activePoolDictonary.Add(pool.PoolTag, activeObjectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictonary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictonary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        activePoolDictonary[tag].Add(objectToSpawn);
        poolDictonary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictonary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictonary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        activePoolDictonary[tag].Add(objectToSpawn);

        poolDictonary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public void SetObjectInactive(GameObject obj)
    {
        obj.SetActive(false);
        activePoolDictonary[obj.transform.parent.name].Remove(obj);
    }

    public Dictionary<string, List<GameObject>> ActivePoolDictonary
    {
        get
        {
            return activePoolDictonary;
        }
    }
}
