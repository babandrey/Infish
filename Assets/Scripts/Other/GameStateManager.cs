using UnityEngine;
using System;
using System.Collections.Generic;

public static class GameStateManager
{
    private static bool isFighting = false;
    private static List<GameObject> activeAliens = new List<GameObject>();

    public static bool IsFighting
    {
        get { return isFighting; }
        set { isFighting = value; }
    }

    public static void AddActiveAlien(GameObject alien)
    {
        activeAliens.Add(alien);
    }

    public static void RemoveActiveAlien(GameObject alien)
    {
        if (activeAliens.Contains(alien))
        {
            activeAliens.Remove(alien);

            if(activeAliens.Count == 0)
            {
                isFighting = false;
            }
        }
        else
        {
            Debug.LogError($"List Doesn't contain {alien}");
        }
    }
}
