using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> poolDictonary;

    #region Singleton

    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        poolDictonary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            GameObject poolParentObj = new GameObject(pool.PoolTag);
            poolParentObj.transform.parent = gameObject.transform;

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab, poolParentObj.transform); // trying to  creating object groups for different types of stuff like fish, food or coins.
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictonary.Add(pool.PoolTag, objectPool);
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

        poolDictonary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
