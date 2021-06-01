using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pets = new GameObject[3];

    public void Start()
    {
        SpawnPets();
    }

    public void AddPet(GameObject pet)
    {
        for(int i = 0; i < pets.Length; i++)
        {
            if(pets[i] == null)
            {
                pets[i] = pet;
                return;
            }
        }
    }

    private void SpawnPets()
    {
        foreach (GameObject pet in pets)
        {
            if (pet != null)
            {
                Instantiate(pet, pet.transform.position, pet.transform.rotation, transform);
            }
        }
    }
}
