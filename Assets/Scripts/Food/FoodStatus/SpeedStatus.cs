using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStatus : MonoBehaviour, IStatus
{
    [SerializeField] private float speedAmount;

    public void Activate(Transform fish)
    {
        //StartCoroutine(SpeedFish(fish, speedAmount));
    }

    /*IEnumerator SpeedFish(Transform fish, float speedAmount)
    {
        fish.Movement.SetSpeed(speedAmount);

        yield return new WaitForSeconds(5);

        fish.Movement.SetSpeed(Movement.defaultSpeed);
    }*/
}
