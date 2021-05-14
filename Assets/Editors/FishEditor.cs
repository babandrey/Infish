using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Fish), true)]
public class FishEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Fish fish = (Fish)target;

        if(fish.Food != null)
        {
            if (fish.Food.GetComponent<IEdible>() == null)
            {
                Debug.LogError($"The {fish.Food} on {fish.gameObject} isn't IEdible.");
                fish.Food = null;
            }
        }

        if(fish.GoldDrop != null)
        {
            if (fish.GoldDrop.GetComponent<IGold>() == null)
            {
                Debug.LogError($"The {fish.GoldDrop} on {fish.gameObject} isn't IGold.");
                fish.GoldDrop = null;
            }
        }   
    }
}
