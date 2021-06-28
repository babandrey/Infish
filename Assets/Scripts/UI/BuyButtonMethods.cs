using UnityEngine;

public static class BuyButtonMethods
{
    private static Vector2 downForce = new Vector2(0f, -2.7f);
    public static void SpawnFish(string tag, string goldAmount)
    {
        int amount = int.Parse(goldAmount);

        if(GoldManager.GoldAmount >= amount)
        {
            Vector3 position = new Vector3(Utility.GenerateRandomVector3().x, Utility.MaxFishHeight, 0);
            GameObject fishSpawned = ObjectPooler.Instance.SpawnFromPool(tag, position);
            fishSpawned.GetComponent<Rigidbody2D>().AddForce(downForce, ForceMode2D.Impulse);

            GoldManager.DecreaseGold(amount);
        }
    }

    public static void UpgradeFood()
    {
        int amount = 300;

        if (GoldManager.GoldAmount >= amount)
        {
            FoodManager.Instance.CurrentFoodIndex++;
            GoldManager.DecreaseGold(amount);
        }
    }

    public static void IncreaseFoodAmount()
    {
        int amount = 200;

        if (GoldManager.GoldAmount >= amount)
        {
            FoodManager.Instance.MaxFoodAmount++;
            GoldManager.DecreaseGold(amount);
        }
    }

    public static void UpgradeWeapon()
    {

    }

    public static void BuyLevelUp(string goldAmount)
    {
        int amount = int.Parse(goldAmount);

        if (GoldManager.GoldAmount >= amount)
        {
            LevelManager.Instance.ChangeLevel("Pick New Pet Menu");
        }
    }
}