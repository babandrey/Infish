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
        List<string> unlockedPets = saveManager.activeSave.unlockedPets;

        foreach(GameObject pet in pets.Values)
        {
            if (unlockedPets.Contains(pet.name))
            {
                GameObject buttonGameObject = Instantiate(petButton, transform);
                PetSelectionButton button = buttonGameObject.GetComponent<PetSelectionButton>();
                button.InitializeButton(pet);
            } 
        }
    }
}
