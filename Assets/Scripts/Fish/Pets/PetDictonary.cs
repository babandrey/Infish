using System.Collections.Generic;
using UnityEngine;

public class PetDictonary : MonoBehaviour
{
    public static PetDictonary instance;
    [SerializeField] private List<GameObject> petList;
    private Dictionary<string, GameObject> pets = new Dictionary<string, GameObject>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

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
