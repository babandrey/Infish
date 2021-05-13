using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private int goldAmount;
    [SerializeField] private TextMeshProUGUI goldText;

    #region Singleton

    public static GoldManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    void Start()
    {
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
