using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, IGold
{
    public new string name;
    public int amount;
    public Sprite sprite;

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
