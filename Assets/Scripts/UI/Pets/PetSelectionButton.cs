using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PetSelectionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image image;
    private Pet pet;
    private SaveManager saveManager;
    private LevelManager levelManager;

    void Start()
    {
        saveManager = SaveManager.Instance;
        levelManager = LevelManager.Instance;
    }

    public void InitializeButton(GameObject petGameObject)
    {
        pet = petGameObject.GetComponent<Pet>();

        gameObject.name = $"{pet.name} Button";

        nameText.text = pet.Name;
        descriptionText.text = pet.Description;
        image.sprite = pet.GetComponent<SpriteRenderer>().sprite;
    }

    public void UnlockPet()
    {
        if (!saveManager.activeSave.unlockedPets.Contains(pet.name))
        {
            saveManager.activeSave.unlockedPets.Add(pet.name);
            saveManager.Save();
        }
    }

    public void LoadNextLevel()
    {
        saveManager.activeSave.highestLevel++;
        levelManager.ChangeLevel(saveManager.activeSave.highestLevel);
    }
}
