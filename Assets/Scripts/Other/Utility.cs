using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector3 GenerateRandomVector3()
    {
        float x = Random.Range(-Screen.width, Screen.width);
        float y = Random.Range(-Screen.height, Screen.height);

        return new Vector3(x, y, 0);
    }
}
