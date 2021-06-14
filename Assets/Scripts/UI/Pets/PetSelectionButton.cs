using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class PetSelectionButton : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI descriptionText;
    private Image image;

    void Awake()
    {
        image = transform.Find("PetImage").GetComponent<Image>();
    }
    public void InitializeButton(GameObject petGameObject)
    {
        Pet pet = petGameObject.GetComponent<Pet>();

        gameObject.name = $"{pet.name} Button";

        nameText.text = pet.Name;
        descriptionText.text = pet.Description;
        image.sprite = pet.Sprite;
    }
}
