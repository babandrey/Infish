using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEdible : IGameComponent
{
    public string Name { get; }
    public float Health { get; set; }
    public int NutritionalValue { get; }
    public IStatus[] Statuses { get; }
}
