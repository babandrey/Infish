using System.Collections.Generic;
using UnityEngine;

public class CreatePickPetButtons : MonoBehaviour
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
        string[] petNames = PetData.PetNames;
        List<string> petPool = new List<string>();

        int levelBasedIndex = saveManager.activeSave.highestLevel - 3;

        while (petPool.Count != 3)
        {
            int randomIndex = Random.Range(levelBasedIndex, levelBasedIndex + 5);
            string randomPetName;

            if (randomIndex <= petNames.Length)
            {
                randomPetName = petNames[randomIndex];

                if (!saveManager.activeSave.unlockedPets.Contains(randomPetName) && !petPool.Contains(randomPetName))
                {
                    petPool.Add(randomPetName);
                }
            }
        }

        List<GameObject> randomPets = new List<GameObject>();

        foreach (string petName in petPool)
        {
            randomPets.Add(PetData.GetPetData(petName));
        }

        return randomPets;
    }
}
