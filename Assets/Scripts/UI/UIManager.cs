using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private GameObject buyButtonPrefab;

    private Transform buttonGrid;
    // Start is called before the first frame update
    void Start()
    {
        buttonGrid = transform.Find("Button Grid");

        foreach(GameObject prefab in spawnManager.prefabs.Values)
        {
            GameObject button = Instantiate(buyButtonPrefab, buttonGrid);
            button.name = $"{prefab.name} Button";
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"{prefab.name} Text";

            //check on different condition based on what object it is, what addlistener method to add
            button.GetComponent<Button>().onClick.AddListener(() => ObjectPooler.instance.SpawnFromPool(prefab.name));
        }
    }
}
