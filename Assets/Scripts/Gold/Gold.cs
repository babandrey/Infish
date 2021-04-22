using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, IGold
{
    [SerializeField] private new string name;
    [SerializeField] private int amount;
    private Sprite sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    public string Name
    {
        get { return name; }
    }

    public int Amount
    {
        get { return amount; }
    }

    public Sprite Sprite
    {
        get { return sprite; }
    }
}
