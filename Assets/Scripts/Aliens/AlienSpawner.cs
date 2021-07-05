using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] aliens;
    [SerializeField] private float startTime;
    [SerializeField] private float timer;
    [SerializeField] private int currentAlienIndex = 0;
    [SerializeField] private int aliensToSpawn;

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
                for(int i = 0; i < aliensToSpawn; i++)
                {
                    SpawnAlien();
                }
                
                GameStateManager.IsFighting = true;
                timer = startTime;
            }
        }
    }

    private void SpawnAlien()
    {
        GameObject alien = Instantiate(aliens[currentAlienIndex], Utility.GenerateRandomVector3(), aliens[currentAlienIndex].transform.rotation, transform);
        GameStateManager.AddActiveAlien(alien);

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
