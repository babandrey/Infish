using UnityEngine;

public static class GameStateManager
{
    private static bool isFighting = false;

    public static bool IsFighting
    {
        get { return isFighting; }
        set { isFighting = value; }
    }

}
