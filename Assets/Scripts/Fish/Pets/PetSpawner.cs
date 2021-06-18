using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    public static PetSpawner instance;
    private SaveManager saveManager;
    private PetDictonary petDictonary;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        petDictonary = PetDictonary.instance;
        saveManager = SaveManager.Instance;
        SpawnPets();
    }
    private void SpawnPets()
    {
        foreach (string pet in saveManager.activeSave.currentPets)
        {
            Instantiate(petDictonary.Pets[pet], transform);
        }
    }
}
