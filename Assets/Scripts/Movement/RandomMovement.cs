using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private float timeLeft;
    private Vector2 moveTo = new Vector2(1f,0f); // always face on the right side first

    [Range(0.0f, 10f)]
    [SerializeField] private float maxSpeed = 1f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            float minRandomX = -1f;
            float maxRandomX = 1f;
            float minRandomY = -1f;
            float maxRandomY = 1f;

            if (transform.position.x < -5)
            {
                minRandomX = 0f;
            } 
            else if(transform.position.x > 5)
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

            float moveToX = Random.Range(minRandomX, maxRandomX);
            float moveToY = Random.Range(minRandomY, maxRandomY);

            if(moveToX > 0f && moveTo.x < 0f)
            {
                animator.SetTrigger("turnRight");
            }
            else if(moveToX < 0f && moveTo.x > 0f)
            {
                animator.SetTrigger("turnLeft");
            }

            moveTo = new Vector2(moveToX, moveToY);
            timeLeft += Random.Range(1f, 5f);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(moveTo * maxSpeed * Time.deltaTime, Space.World);
    }
}
