using UnityEngine.SceneManagement;

public static class BuyButtonMethods
{
    public static void SpawnFish(string tag, string goldAmount)
    {
        int amount = int.Parse(goldAmount);

        if(GoldManager.instance.GoldAmount >= amount)
        {
            ObjectPooler.instance.SpawnFromPool(tag);
            GoldManager.instance.DecreaseGold(amount);
        }
    }

    public static void UpgradeFood()
    {
        int amount = 300;

        if (GoldManager.instance.GoldAmount >= amount)
        {
            FoodManager.instance.CurrentFoodIndex++;
            GoldManager.instance.DecreaseGold(amount);
        }
    }

    public static void IncreaseFoodAmount()
    {
        int amount = 200;

        if (GoldManager.instance.GoldAmount >= amount)
        {
            FoodManager.instance.MaxFoodAmount++;
            GoldManager.instance.DecreaseGold(amount);
        }
    }

    public static void UpgradeWeapon()
    {

    }

    public static void BuyLevelUp(string goldAmount)
    {
        int amount = int.Parse(goldAmount);

        if (GoldManager.instance.GoldAmount >= amount)
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            int nextLevel = currentLevel + 1;
            LevelManager.instance.ChangeLevel(nextLevel);
        }
    }
}
