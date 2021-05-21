using System.Collections;
using UnityEngine;
public class Hunger : MonoBehaviour
{
    [SerializeField] private float hungerTimer; // lower over time, once gets to 0 the fish dies
    [SerializeField] private float onEnableHungerTime;
    [SerializeField] private float hungerStartTime;
    [SerializeField] private float hungryColorStartTime; //after the fish becomes hungry
    [SerializeField] private bool isHungry = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hungryColor;
    private Color normalColor;

    void Start()
    {
        normalColor = spriteRenderer.color;
    }

    void OnEnable()
    {
        hungerTimer = onEnableHungerTime;
    }

    void Update()
    {
        hungerTimer -= Time.deltaTime;

        if(hungerTimer < hungerStartTime && !isHungry) //fish became hungry
        {
            isHungry = true;
            StartCoroutine(SetHungryColor());
        }
        else if(hungerTimer > hungerStartTime && isHungry) //fish just ate
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
        get { return hungerTimer; }
        set { hungerTimer = value; }
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
        get { return isHungry; }
    }
}
