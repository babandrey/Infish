using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabButtonArray;

    private Transform buttonGrid;
    private Transform background;

    void Start()
    {
        CreateButtonGrid();
        CreateBackgroundCollider();
    }

    private void CreateButtonGrid()
    {
        buttonGrid = transform.Find("Button Grid");

        foreach (GameObject prefab in prefabButtonArray)
        {
            GameObject button = Instantiate(prefab, buttonGrid);
        }
    }

    private void CreateBackgroundCollider()
    {
        background = transform.Find("Background");

        BoxCollider2D backgroundCollider = background.gameObject.AddComponent<BoxCollider2D>();
        backgroundCollider.size = new Vector2(Screen.width, Screen.height);
        backgroundCollider.isTrigger = true;
    }
}
