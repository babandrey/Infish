using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePetButtons : MonoBehaviour
{
    [SerializeField] private GameObject petButton;
    private SaveManager saveManager;

    void Start()
    {
        saveManager = SaveManager.Instance;
        
        CreateButtons();
    }

    private void CreateButtons()
    {
        var pets = PetData.Pets;
        List<string> unlockedPets = saveManager.activeSave.unlockedPets;

        foreach(string petName in unlockedPets)
        {
            GameObject pet = pets[petName];
            GameObject buttonGameObject = Instantiate(petButton, transform);
            PetSelectionButton button = buttonGameObject.GetComponent<PetSelectionButton>();
            button.InitializeButton(pet);
        }
    }
}
