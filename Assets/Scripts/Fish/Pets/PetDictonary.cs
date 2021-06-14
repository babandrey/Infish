using System.Collections.Generic;
using UnityEngine;

public class PetDictonary : MonoBehaviour
{
    [SerializeField] private List<GameObject> petList;
    private Dictionary<string, GameObject> pets = new Dictionary<string, GameObject>();

    void Awake()
    {
        InitializeDictonary();
    }
    public void InitializeDictonary()
    {
        foreach(GameObject pet in petList)
        {
            pets.Add(pet.name, pet);
        }
    }

    public Dictionary<string, GameObject> Pets
    {
        get { return pets; }
    }
}
