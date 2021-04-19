using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private FoodManager foodManager;
    private ObjectPooler objectPooler;
    private List<GameObject> foodPool;

    private Fish fish;
    private Hunger hunger;
    private Animator animator;

    Transform foodObjectPool;
    private bool isChasingFood;

    private float timeLeft; //the time left to switch to a new random vector

    private float minRandomX;
    private float maxRandomX;
    private float minRandomY;
    private float maxRandomY;

    private float moveToX;
    private float moveToY;
    private Vector2 moveTo = new Vector2(1f, 0f); // always face on the right side first

    [Range(0.0f, 10f)]
    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        fish = GetComponent<Fish>();
        hunger = GetComponent<Hunger>();
        animator = GetComponent<Animator>();
        
        foodManager = FoodManager.instance;
        objectPooler = ObjectPooler.instance;
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
        transform.Translate(moveTo * speed * Time.deltaTime, Space.World);
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

            moveToX = Random.Range(minRandomX, maxRandomX);
            moveToY = Random.Range(minRandomY, maxRandomY);

            if (moveToX > 0f && moveTo.x < 0f)
            {
                animator.SetTrigger("turnRight");
            }
            else if (moveToX < 0f && moveTo.x > 0f)
            {
                animator.SetTrigger("turnLeft");
            }

            moveTo = new Vector2(moveToX, moveToY);
            timeLeft += Random.Range(1f, 5f);
        }
    }

    private void ChaseFood()
    {
        GameObject foodToChase = ReturnClosestFood();
        moveTo = foodToChase.transform.position;
    }

    private GameObject ReturnClosestFood()
    {
        foodPool = objectPooler.ActivePoolDictonary[fish.Food];

        GameObject closestFood = null;
        float closestFoodDistance = float.MaxValue;

        foreach (GameObject food in foodPool)
        {
            float distance = Vector2.Distance(transform.position, food.transform.position);
            if (closestFoodDistance > distance)
            {
                closestFoodDistance = distance;
                closestFood = food;
            }
        }

        return closestFood;
    }
}
