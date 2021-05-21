using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonEatingMovement : Movement
{
    protected override void Update()
    {
        base.MoveIdle();
    }
}
