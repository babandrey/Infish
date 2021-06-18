using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeManagers : MonoBehaviour
{
    private void Start()
    {
        if(FindObjectOfType(typeof(SaveManager)) == null)
        {
            _ = SaveManager.Instance;
            _ = LevelManager.Instance;       
        }

        Destroy(gameObject);
    }
}
