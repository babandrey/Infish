using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PetSelectionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image image;
    private Pet pet;

    public void InitializeButton(GameObject petGameObject)
    {
        Pet pet = petGameObject.GetComponent<Pet>();

        gameObject.name = $"{pet.name} Button";

        nameText.text = pet.Name;
        descriptionText.text = pet.Description;
        image.sprite = pet.GetComponent<SpriteRenderer>().sprite;
    }

    public void UnlockPet()
    {
        SaveManager.instance.activeSave.unlockedPets.Add(pet.name);
    }
}
