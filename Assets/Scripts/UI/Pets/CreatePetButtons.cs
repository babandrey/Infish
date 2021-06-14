using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePetButtons : MonoBehaviour
{
    [SerializeField] private GameObject petButton;
    [SerializeField] private PetDictonary petData;
    private Dictionary<string, GameObject> pets;
    private SaveManager saveManager;

    void Start()
    {
        saveManager = SaveManager.instance;
        pets = petData.Pets;
        CreateButtons();
    }

    private void CreateButtons()
    {
        List<string> petsUnlocked = saveManager.activeSave.petsUnlocked;

        foreach(GameObject pet in pets.Values)
        {
            if (petsUnlocked.Contains(pet.name))
            {
                GameObject button = Instantiate(petButton, transform);
                button.name = $"{pet.name} Button";
                button.GetComponent<PetSelectionButton>().Image.sprite = pet.GetComponent<Image>().sprite;
            } 
        }
    }
}
