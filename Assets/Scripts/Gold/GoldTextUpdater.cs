using TMPro;
using UnityEngine;

public class GoldTextUpdater : MonoBehaviour
{
    private TextMeshProUGUI goldText;

    void Start()
    {
        goldText = GetComponent<TextMeshProUGUI>();

        GoldManager.OnGoldUpdated += UpdateGoldText;

        UpdateGoldText(GoldManager.GoldAmount);
    }
    void OnDestroy()
    {
        GoldManager.OnGoldUpdated -= UpdateGoldText;
    }

    private void UpdateGoldText(int goldAmount)
    {
        goldText.text = $"Gold: {goldAmount}";
    }
}
