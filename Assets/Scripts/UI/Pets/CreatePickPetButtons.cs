using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreatePickPetButtons : MonoBehaviour
{
    [SerializeField] private GameObject petButton;
    [SerializeField] private PetDictonary petData;
    private Dictionary<string, GameObject> pets;
    private SaveManager saveManager;

    private int levelBasedIndex;

    void Start()
    {
        saveManager = SaveManager.instance;
        pets = petData.Pets;
        CreateButtons();
    }

    private void CreateButtons()
    {
        levelBasedIndex = saveManager.activeSave.highestLevel - 3;
        List<GameObject> petPool = new List<GameObject>();

        while (petPool.Count != 3)
        {
            int randomIndex = Random.Range(levelBasedIndex, levelBasedIndex + 5);
            GameObject randomPet;

            if (randomIndex <= pets.Count - 1)
            {
                randomPet = pets.Values.ElementAt(randomIndex);

                if (!saveManager.activeSave.petsUnlocked.Contains(randomPet.name))
                {
                    Instantiate(petButton, transform);
                    petPool.Add(pets[randomPet.name]);
                }
            }
        }
    }   
}
