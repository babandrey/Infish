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
        foreach (string petName in saveManager.activeSave.currentPets)
        {
            GameObject petGameObject = PetData.GetPetData(petName);
            Instantiate(petGameObject, Utility.GenerateRandomVector3(), petGameObject.transform.rotation, transform);
        }
    }
}
