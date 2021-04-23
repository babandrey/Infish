using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    [SerializeField] private float hungerTimer; // lower over time, once gets to 0 the fish dies
    [SerializeField] private float hungerStartValue;
    [SerializeField] private float hungryColorStartTime; //after the fish becomes hungry
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
            StartCoroutine(SetHungryColor());
        }
        else if(hungerTimer > hungerStartValue && isHungry) //fish just ate
        {
            isHungry = false;
            spriteRenderer.color = normalColor;
        }
        else if (hungerTimer <= 0)
        {
            ObjectPooler.instance.SetObjectInactive(gameObject);
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

    IEnumerator SetHungryColor()
    {
        yield return new WaitForSeconds(hungryColorStartTime);

        if (isHungry)
        {
            spriteRenderer.color = hungryColor;
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
