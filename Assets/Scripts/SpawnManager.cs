using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabArray;
    public Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>(); //to have refrences for the prefabs
    private Dictionary<string, GameObject> prefabGroups = new Dictionary<string, GameObject>(); //for sorting in the hirearchy

    // Start is called before the first frame update
    void Awake()
    {
        int i = 0;

        foreach(GameObject prefab in prefabArray)
        {
            prefabs.Add(prefabArray[i].name, prefabArray[i]);

            GameObject prefabGroup = new GameObject(prefab.name);
            prefabGroup.transform.parent = transform;
            prefabGroups.Add(prefab.name, prefabGroup);

            i++;
        }
    }

    public void SpawnFish(string name)
    {
        Instantiate(prefabs[name], prefabGroups[name].transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
