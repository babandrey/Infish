using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] aliens;
    [SerializeField] private float startTime;
    [SerializeField] private float timer;
    [SerializeField] private int currentAlienIndex = 0;

    void Start()
    {
        timer = startTime;
    }

    void Update()
    {
        if (!GameStateManager.IsFighting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SpawnAlien();
                GameStateManager.IsFighting = true;
                timer = startTime;
            }
        }
    }

    private void SpawnAlien()
    {
        Instantiate(aliens[currentAlienIndex], Utility.GenerateRandomVector3(), aliens[currentAlienIndex].transform.rotation, transform);

        if (aliens.Length - 1 > currentAlienIndex)
        {
            currentAlienIndex++;
        }
        else
        {
            currentAlienIndex = 0;
        }
    }
}
