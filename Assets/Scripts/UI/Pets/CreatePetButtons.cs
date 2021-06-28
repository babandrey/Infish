using System.Collections.Generic;
using UnityEngine;

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
        List<string> unlockedPets = saveManager.activeSave.unlockedPets;

        foreach(string petName in unlockedPets)
        {
            GameObject pet = PetData.GetPetData(petName);
            GameObject buttonGameObject = Instantiate(petButton, transform);
            PetSelectionButton button = buttonGameObject.GetComponent<PetSelectionButton>();
            button.InitializeButton(pet);
        }
    }
}
