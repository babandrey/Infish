using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabButtonArray;
    public Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>(); //to have refrences for the prefabs

    // Start is called before the first frame update
    void Awake()
    {
        int i = 0;

        foreach(GameObject prefab in prefabButtonArray)
        {
            prefabs.Add(prefabButtonArray[i].name, prefabButtonArray[i]);

            i++;
        }
    }
}
