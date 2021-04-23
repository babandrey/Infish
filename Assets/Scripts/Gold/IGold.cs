using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGold
{
    public string Name { get; }
    public int Amount { get; }
    public Sprite Sprite { get; }
}
