using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabButtonArray;

    private Transform buttonGrid;
    // Start is called before the first frame update
    void Start()
    {
        buttonGrid = transform.Find("Button Grid");

        foreach(GameObject prefab in prefabButtonArray)
        {
            GameObject button = Instantiate(prefab, buttonGrid);
        }
    }
}
