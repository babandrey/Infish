using UnityEngine;

public static class Utility
{
    private static float maxFishHeight = 0;
    public static Vector3 GenerateRandomVector3() 
    {
        Vector3 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value));
        float clampedFishHeight = Mathf.Clamp(randomPositionOnScreen.y, 0, MaxFishHeight);

        return new Vector3(randomPositionOnScreen.x, clampedFishHeight, 0);
    }

    public static float MaxFishHeight
    {
        get
        {
            if(maxFishHeight == 0)
            {
                float screenHeight = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
                RectTransform buttonGrid = GameObject.Find("Button Grid").GetComponent<RectTransform>();
                maxFishHeight = screenHeight - buttonGrid.anchorMin.y * 2;
            }

            return maxFishHeight;
        }
    }
}