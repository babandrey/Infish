using UnityEngine;

public static class Utility
{
    public static Vector3 GenerateRandomVector3() 
    {
        Vector3 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value));

        return new Vector3(randomPositionOnScreen.x, randomPositionOnScreen.y, 0);
    }
}