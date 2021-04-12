using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Food : MonoBehaviour
{
    private string foodName;
    private Sprite sprite;
    public float restoreAmount = 20f;

    // Start is called before the first frame update
    void Start()
    {
        restoreAmount = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
