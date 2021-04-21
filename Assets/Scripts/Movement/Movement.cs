using System.Collections;
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

    private float minRandomX;
    private float maxRandomX;
    private float minRandomY;
    private float maxRandomY;

    private float directionX;
    private float directionY;
    private Vector2 direction = new Vector2(1f, 0f); // always face on the right side first

    [Range(0.0f, 10f)]
    [SerializeField] private float speed;
    [Range(0.0f, 10f)]
    [SerializeField] private float hungrySpeed;

    private void Awake()
    {
        fish = GetComponent<Fish>();
        hunger = GetComponent<Hunger>();
        animator = GetComponent<Animator>();
        
        objectPooler = ObjectPooler.instance;
        fishMouth = transform.Find("Fish Mouth");
    }

    // Update is called once per frame
    void Update()
    {
        if(hunger.IsHungry && objectPooler.ActivePoolDictonary[fish.Food].Count != 0)
        {
            ChaseFood();
            return;
        }

        MoveIdle();
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void MoveIdle()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            minRandomX = -1f;
            maxRandomX = 1f;
            minRandomY = -1f;
            maxRandomY = 1f;

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

            directionX = Random.Range(minRandomX, maxRandomX);
            directionY = Random.Range(minRandomY, maxRandomY);

            if (directionX > 0f && direction.x < 0f)
            {
                animator.SetTrigger("turnRight");
            }
            else if (directionX < 0f && direction.x > 0f)
            {
                animator.SetTrigger("turnLeft");
            }

            direction = new Vector2(directionX, directionY);
            timeLeft += Random.Range(1f, 5f);
            speed = Random.Range(1f, 3f);
        }
    }

    private void ChaseFood()
    {
        if(speed != hungrySpeed)
        {
            speed = hungrySpeed;
        }

        GameObject foodToChase = ReturnClosestFood();

        if(direction.x < 0f && transform.rotation.eulerAngles.y == 180)
        {
            animator.SetTrigger("turnRight");
        }
        else if(direction.x > 0f && transform.rotation.eulerAngles.y == 0)
        {
            animator.SetTrigger("turnLeft");
        }

        direction = (foodToChase.transform.position - fishMouth.position).normalized;
    }

    private GameObject ReturnClosestFood()
    {
        foodPool = objectPooler.ActivePoolDictonary[fish.Food];

        GameObject closestFood = null;
        float closestFoodDistance = float.MaxValue;

        foreach (GameObject food in foodPool)
        {
            float distance = Vector2.Distance(fishMouth.position, food.transform.position);
            if (closestFoodDistance > distance)
            {
                closestFoodDistance = distance;
                closestFood = food;
            }
        }

        return closestFood;
    }
}
