using UnityEngine;

public class DropGold : MonoBehaviour
{
    private ObjectPooler objectPooler;

    private Fish fish;
    private GameObject currentGoldDrop = null;
    private int currentGoldDropIndex = -1;
    private float timer;
    [SerializeField] private float timeUntilDrop;

    void Awake()
    {
        objectPooler = ObjectPooler.instance;

        fish = GetComponent<Fish>();
        timer = RandomizeTimer();

        if (fish.IsDroppingGold)
        {
            currentGoldDropIndex = 0;
            currentGoldDrop = fish.GoldDrop[currentGoldDropIndex];
        }
    }

    public GameObject CurrentGoldDrop
    {
        get { return currentGoldDrop; }
        set { currentGoldDrop = value; }
    }

    public int CurrentGoldDropIndex
    {
        get { return currentGoldDropIndex; }
        set 
        {
            if (value <= fish.GoldDrop.Length - 1)
            {
                currentGoldDropIndex = value;
                currentGoldDrop = fish.GoldDrop[currentGoldDropIndex];
            }
        }
    }

    void Update()
    {
        if (fish.IsDroppingGold)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SpawnGoldDrop();
                timer = RandomizeTimer();
            }
        }
    }

    private void SpawnGoldDrop()
    {
        objectPooler.SpawnFromPool(currentGoldDrop.name, fish.transform.position, currentGoldDrop.transform.rotation);
    }

    private float RandomizeTimer()
    {
        return Random.Range(timeUntilDrop - 2, timeUntilDrop + 2);
    }
}
