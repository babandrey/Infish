using UnityEngine.SceneManagement;

public static class BuyButtonMethods
{
    public static void SpawnFish(string tag, string goldAmount)
    {
        int amount = int.Parse(goldAmount);

        if(GoldManager.Instance.GoldAmount >= amount)
        {
            ObjectPooler.Instance.SpawnFromPool(tag);
            GoldManager.Instance.DecreaseGold(amount);
        }
    }

    public static void UpgradeFood()
    {
        int amount = 300;

        if (GoldManager.Instance.GoldAmount >= amount)
        {
            FoodManager.Instance.CurrentFoodIndex++;
            GoldManager.Instance.DecreaseGold(amount);
        }
    }

    public static void IncreaseFoodAmount()
    {
        int amount = 200;

        if (GoldManager.Instance.GoldAmount >= amount)
        {
            FoodManager.Instance.MaxFoodAmount++;
            GoldManager.Instance.DecreaseGold(amount);
        }
    }

    public static void UpgradeWeapon()
    {

    }

    public static void BuyLevelUp(string goldAmount)
    {
        int amount = int.Parse(goldAmount);

        if (GoldManager.Instance.GoldAmount >= amount)
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            int nextLevel = currentLevel + 1;
            LevelManager.Instance.ChangeLevel(nextLevel);
        }
    }
}
