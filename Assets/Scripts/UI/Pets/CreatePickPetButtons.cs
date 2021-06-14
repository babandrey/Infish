using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CreatePickPetButtons : MonoBehaviour
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
        var randomPets = GenerateRandomPets();

        foreach (GameObject pet in randomPets)
        {
            GameObject buttonGameObject = Instantiate(petButton, transform);
            PetSelectionButton button = buttonGameObject.GetComponent<PetSelectionButton>();
            button.InitializeButton(pet);
        }
    }
    
    private List<GameObject> GenerateRandomPets()
    {
        int levelBasedIndex = saveManager.activeSave.highestLevel - 3;
        List<GameObject> petPool = new List<GameObject>();

        while (petPool.Count != 3)
        {
            int randomIndex = Random.Range(levelBasedIndex, levelBasedIndex + 5);
            GameObject randomPet;

            if (randomIndex <= pets.Count - 1)
            {
                randomPet = pets.Values.ElementAt(randomIndex);

                if (!saveManager.activeSave.unlockedPets.Contains(randomPet.name))
                {
                    Instantiate(petButton, transform);
                    petPool.Add(pets[randomPet.name]);  
                }
            }
        }

        return petPool;
    }
}
