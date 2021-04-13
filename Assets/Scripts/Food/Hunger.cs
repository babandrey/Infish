using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    [SerializeField] private float hungerTimer = 30f; // lower over time, once gets to 0 the fish dies
    [SerializeField] private float hungerStartValue = 15f;
    [SerializeField] private bool isHungry = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hungryColor;
    private Color normalColor;

    // Start is called before the first frame update

    void Start()
    {
        normalColor = spriteRenderer.color;
    }

    void Update()
    {
        hungerTimer -= Time.deltaTime;

        if(hungerTimer < hungerStartValue && !isHungry) //fish became hungry
        {
            isHungry = true;
            spriteRenderer.color = hungryColor;
        }
        else if(hungerTimer > hungerStartValue && isHungry) //fish just ate
        {
            isHungry = false;
            spriteRenderer.color = normalColor;
        }
        else if (hungerTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float HungerTimer
    {
        get
        {
            return hungerTimer;
        }
        set
        {
            hungerTimer = value;
        }
    }

    public bool IsHungry
    {
        get
        {
            return isHungry;
        }
    }
}
