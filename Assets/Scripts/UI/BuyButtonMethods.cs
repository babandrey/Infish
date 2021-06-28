using UnityEngine;

public static class BuyButtonMethods
{
    public static void SpawnFish(string tag, string goldAmount)
    {
        int amount = int.Parse(goldAmount);

        if(GoldManager.GoldAmount >= amount)
        {
            Vector3 position = new Vector3(Utility.GenerateRandomVector3().x, Camera.main.ViewportToWorldPoint(new Vector3(0, Random.value)).y, 0);

            ObjectPooler.Instance.SpawnFromPool(tag, position);

            //Add force down
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