using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PetData
{
    private static string petsPrefabPath = "Prefabs/Fish/Pets/";
    private static GameObject[] loadedPets = GetPetsData();
    private static Dictionary<string, GameObject> pets = CreatePetDictonary();
    private static GameObject[] GetPetsData()
    {
        return Resources.LoadAll<GameObject>(petsPrefabPath);
    }

    private static Dictionary<string, GameObject> CreatePetDictonary()
    {
        var petDictonary = new Dictionary<string, GameObject>();

        foreach(GameObject pet in loadedPets)
        {
            petDictonary.Add(pet.name, pet);
        }

        return petDictonary;
    }

    public static Dictionary<string, GameObject> Pets
    {
        get { return pets; }
    }
}
