using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldfish : Fish, IEdible
{
    private float health;
    private IStatus[] statuses = new IStatus[0];

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public IStatus[] Statuses
    {
        get { return statuses; }
    }
}
