using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private int goldAmount;
    private TextMeshProUGUI goldText;

    #region Singleton

    public static GoldManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    void Start()
    {
        goldText = GameObject.Find("Gold Text").GetComponent<TextMeshProUGUI>();

        UpdateGoldText();
    }

    public int GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
    }

    public void AddGold(int amount)
    {
        goldAmount += amount;
        UpdateGoldText();
    }

    public void DecreaseGold(int amount)
    {
        goldAmount = goldAmount - amount >= 0 ? goldAmount - amount : goldAmount;
        UpdateGoldText();
    }

    private void UpdateGoldText()
    {
        goldText.text = $"Gold: {goldAmount}";
    }
}
