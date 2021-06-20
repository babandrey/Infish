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

    public Pet Pet
    {
        get { return pet; }
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
        saveManager.UnlockPet(pet.name);
    }

    public void LoadNextLevel()
    {
        saveManager.activeSave.highestLevel++;

        if(saveManager.activeSave.unlockedPets.Count > 3)
        {
            levelManager.ChangeLevel("Pet Selection Menu");
        }
        else
        {
            levelManager.ChangeLevel(saveManager.activeSave.highestLevel);
        }    
    }
}
