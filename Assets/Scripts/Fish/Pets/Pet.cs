using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pet : Fish
{
    [TextArea(5, 10)]
    [SerializeField] private string description;
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
}
