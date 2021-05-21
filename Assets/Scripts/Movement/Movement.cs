using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private List<GameObject> foodPool;

    private Fish fish;
    private Hunger hunger;
    private Animator animator;
    private Transform fishMouth;

    private float timeLeft; //the time left to switch to a new random vector

    [SerializeField] private bool isFacingRight;
    private Vector2 direction;

    [Range(0.0f, 10f)]
    [SerializeField] private float speed;
    [Range(0.0f, 10f)]
    [SerializeField] private float hungrySpeed;

    private void Awake()
    {
        fish = GetComponent<Fish>();
        hunger = GetComponent<Hunger>();
        animator = GetComponent<Animator>();
        
        fishMouth = transform.Find("Fish Mouth");
    }

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    protected virtual void Update()
    {
        if(hunger.IsHungry)
        {
            foreach(GameObject foodObject in fish.Food)
            {
                if (objectPooler.EdibleFoodPoolDictonary[foodObject.name].Count > 0)
                {
                    ChaseFood();
                    return;
                }
            }  
        }

        MoveIdle();
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    protected void MoveIdle()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            float minRandomX = -1f;
            float maxRandomX = 1f;
            float minRandomY = -1f;
            float maxRandomY = 1f;

            // Motivators to move away from the borders
            if (transform.position.x < -5)
            {
                minRandomX = 0f;
            }
            else if (transform.position.x > 5)
            {
                maxRandomX = 0f;
            }

            if (transform.position.y < -4)
            {
                minRandomY = 0f;
            }
            else if (transform.position.y > 4)
            {
                maxRandomY = 0f;
            }

            float directionX = Random.Range(minRandomX, maxRandomX);
            float directionY = Random.Range(minRandomY, maxRandomY);

            if (directionX > 0f && !isFacingRight)
            {
                TurnRight();
            }
            else if (directionX < 0f && isFacingRight)
            {
                TurnLeft();
            }

            direction = new Vector2(directionX, directionY);
            timeLeft += Random.Range(1f, 5f);
            speed = Random.Range(1f, 3f);
        }
    }

    private void TurnLeft()
    {
        animator.SetTrigger("turnLeft");
        isFacingRight = false;
    }

    private void TurnRight()
    {
        animator.SetTrigger("turnRight");
        isFacingRight = true;
    }

    private void ChaseFood()
    {
        if(speed != hungrySpeed)
        {
            speed = hungrySpeed;
        }

        GameObject foodToChase = ReturnClosestFood();

        direction = (foodToChase.transform.position - fishMouth.position).normalized;

        if (direction.x < 0f && isFacingRight)
        {
            TurnLeft();
        }
        else if(direction.x > 0f && !isFacingRight)
        {
            TurnRight();
        }
    }

    private GameObject ReturnClosestFood()
    {
        GameObject closestFood = null;
        float closestFoodDistance = float.MaxValue;

        foreach (GameObject foodObject in fish.Food)
        {
            foodPool = objectPooler.EdibleFoodPoolDictonary[foodObject.name];

            foreach (GameObject food in foodPool)
            {
                float distance = Vector2.Distance(fishMouth.position, food.transform.position);
                if (closestFoodDistance > distance)
                {
                    closestFoodDistance = distance;
                    closestFood = food;
                }
            }
        }

        return closestFood;
    }
}
