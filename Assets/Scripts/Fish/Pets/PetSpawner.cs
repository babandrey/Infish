using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    private SaveManager saveManager;

    void Start()
    {
        saveManager = SaveManager.Instance;
        SpawnPets();
    }
    private void SpawnPets()
    {
        foreach (string pet in saveManager.activeSave.currentPets)
        {
            GameObject petGameObject = PetData.Pets[pet];
            Instantiate(petGameObject, transform);
        }
    }
}
