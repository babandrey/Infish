using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Food : MonoBehaviour
{
    [SerializeField] string foodName;
    private Sprite sprite;
    [SerializeField] private float health = 30;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    public float Health
    {
        get
        {
            return health;
        }
    }
}
